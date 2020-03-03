using CMCLIS.GATEWAY.CORE;
using CMCLIS.GATEWAY.DATA.OBJECTS;
using CMCLIS.GATEWAY.ENTITY;
using CMCLIS.GATEWAY.SETTING;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;


namespace CMCLIS.GATEWAY.WServiceSendMail
{
    public partial class ServiceSendMail : ServiceBase
    {
        private string configPath = string.Empty;
        private Timer timer = null;
        DataSet dsTasks = new DataSet();
        public ServiceSendMail()
        {
            InitializeComponent();
            timer = new Timer();

            this.timer.Interval = int.Parse(ConfigurationManager.AppSettings["INTERVAL"]);
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Tick);
            //TEST();
        }

        public void SendMaiExecute()
        {
            int totalRecord = 0;
            List<CVAN_MAILInfo> listData = DataObjectFactory.GetInstanceCVAN_MAIL().CVAN_MAIL_GetAllWithPadding(string.Empty, string.Empty, string.Empty, string.Empty, 0, 0, 1, 100, ref totalRecord);
            if (listData != null && listData.Count > 0)
            {

                //nhtoan3: update trạng thái 2: chờ xử lý để không bị lặp lại email
                foreach (var info in listData)
                {
                    info.CVAN_STATUS = 2;
                    DataObjectFactory.GetInstanceCVAN_MAIL().Update(info);
                }

                List<int> listPage = Utility.GetListPage(listData.Count, int.Parse(Config.PAGE_SIZE));
                Task[] tasks = new Task[listPage.Count];
                int ctr = 0;
                foreach (var item in listPage)
                {
                    var task = Task.Factory.StartNew(() => DoSomeWork(item, int.Parse(Config.PAGE_SIZE), listData));
                    tasks[ctr] = task;
                    ctr++;

                }
                var result = Task.Factory.ContinueWhenAll(tasks,
                 (taskResult) =>
                 {
                     try
                     {
                         Task.WaitAll(taskResult);
                     }
                     catch (Exception ex)
                     {
                         LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                         var faultedTasks = tasks.Where(t => t.IsFaulted);
                     }

                 });
            }

        }

        private List<CVAN_MAILInfo> GetListDataByPageIndex(int pageIndex, int pageSize, List<CVAN_MAILInfo> listData)
        {
            try
            {
                List<CVAN_MAILInfo> childList = new List<CVAN_MAILInfo>();
                if (pageIndex == 1)
                {
                    childList = listData.Where(m => m.STT >= (pageIndex - 1) * pageSize && m.STT <= pageIndex * pageSize).ToList();
                }
                else
                {
                    childList = listData.Where(m => m.STT > (pageIndex - 1) * pageSize && m.STT <= pageIndex * pageSize).ToList();
                }
                return childList;
            }
            catch (Exception ex)
            {

                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }

        private void DoSomeWork(int pageIndex, int pageSize, List<CVAN_MAILInfo> listData)
        {
            try
            {
                List<CVAN_MAILInfo> childList = GetListDataByPageIndex(pageIndex, pageSize, listData);

                if (childList != null && childList.Count > 0)
                {
                    foreach (var info in childList)
                    {
                        bool result = false;
                        if (!string.IsNullOrEmpty(info.CVAN_DESCRIPTION))
                        {

                            string[] FileName = info.CVAN_DESCRIPTION.TrimEnd(';').Split(';');
                            int totalRecord = 0;
                            List<CVAN_MAIL_ATTACHMENT> Attachments = new List<CVAN_MAIL_ATTACHMENT>();
                            foreach (var item in FileName)
                            {
                                if (string.IsNullOrEmpty(item)) return;
                                List<FILE_SERVER_DATAInfo> List_FileServer = DataObjectFactory.GetInstanceFILE_SERVER_DATA().FILE_SERVER_DATA_GetAllWithPadding(item, string.Empty, string.Empty, string.Empty, string.Empty, 0, 1, 100, ref totalRecord);
                                if (List_FileServer != null && totalRecord > 0)
                                {
                                    string fileFolder = string.Empty;
                                    string fileName = string.Empty;
                                    string pathFileFTP = string.Empty;
                                    CVAN_MAIL_ATTACHMENT attachment = new CVAN_MAIL_ATTACHMENT();
                                    foreach (var info_file in List_FileServer)
                                    {
                                        // Check trường hợp doctype có phải EMAIL hay không... 
                                        if (info_file.DOC_TYPE != "EMAIL") return;

                                        fileFolder = info_file.CDATE.Value.ToString("yyyy-MM-dd");
                                        fileName = string.Format("{0}.{1}", info_file.FILE_NAME, info_file.EXTENSION);
                                        pathFileFTP = Path.Combine(fileFolder, fileName);

                                        var directoryPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "DownloadFile");
                                        string directoryFullPath = Path.Combine(directoryPath, fileFolder);
                                        if (!Directory.Exists(directoryFullPath))
                                        {
                                            Directory.CreateDirectory(directoryFullPath);
                                        }

                                        if (FTPClient.Download(Config.FTP_SERVER_URI, Config.FTP_USER, Config.FTP_PASSWORD, directoryPath, pathFileFTP))
                                        {
                                            string downloadFilePath = Path.Combine(directoryPath, pathFileFTP);
                                            if (File.Exists(downloadFilePath))
                                            {
                                                attachment.FileName = info_file.DESCRIPTION;
                                                attachment.Extension = info_file.EXTENSION;
                                                attachment.Content = Convert.ToBase64String(File.ReadAllBytes(downloadFilePath));
                                            }
                                        }
                                    }
                                    Attachments.Add(attachment);
                                }
                            }
                            CMCLIS.GATEWAY.SendMail.MailExchangeService.SendMailAttachment_SMTP(info.CVAN_TO, info.CVAN_SUBJECT, info.CVAN_CONTENT, Attachments, ref result);
                            System.Threading.Thread.Sleep(int.Parse(ConfigurationManager.AppSettings["MAIL_SLEEP"]));

                        }
                        else
                        {
                            CMCLIS.GATEWAY.SendMail.MailExchangeService.SendMail_SMTP(info.CVAN_TO, info.CVAN_SUBJECT, info.CVAN_CONTENT, ref result);
                            System.Threading.Thread.Sleep(int.Parse(ConfigurationManager.AppSettings["MAIL_SLEEP"]));
                        }

                        info.LDATE = DateTime.Now;
                        info.CUSER = "IVAN";
                        info.CVAN_STATUS = result == true ? 1 : -1;
                        DataObjectFactory.GetInstanceCVAN_MAIL().Update(info);
                    }
                }
            }
            catch (Exception ex)
            {

                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);

            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                SendMaiExecute();
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);

            }
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                if (File.Exists(ConfigurationManager.AppSettings["FOLDER_CONFIG"] + @"\AppScheduler.xml"))
                {
                    XmlTextReader xRead = new XmlTextReader(ConfigurationManager.AppSettings["FOLDER_CONFIG"] + @"\AppScheduler.xml");
                    XmlValidatingReader xvRead = new XmlValidatingReader(xRead);
                    xvRead.ValidationType = ValidationType.DTD;
                    dsTasks.ReadXml(xvRead);
                    xvRead.Close();
                    xRead.Close();
                }

                timer.Enabled = true;
                timer.Start();
                LogEventError.LogEvent("Service Started successfully" + "[" + DateTime.Now.ToString() + "]");
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);

            }
        }

        protected override void OnStop()
        {
            try
            {
                timer.Enabled = false;
                timer.Stop();
                LogEventError.LogEvent("Service stop successfully" + "[" + DateTime.Now.ToString() + "]");
            }
            catch (Exception ex)
            {

                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);

            }
        }
    }
}
