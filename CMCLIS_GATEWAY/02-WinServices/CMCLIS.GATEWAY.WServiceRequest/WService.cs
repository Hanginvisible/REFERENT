
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
using System.Reflection;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;


namespace CMCLIS.GATEWAY.WServiceRequest
{
    public partial class WService : ServiceBase
    {

        private Timer timer = null;
        MessageSenderInfo senderInfo = new MessageSenderInfo();
        //private string _MSG_TEMP = string.Empty;

        public WService()
        {

            InitializeComponent();
            senderInfo.VERSION = ConfigurationManager.AppSettings["VERSION"];
            senderInfo.SENDER_CODE = ConfigurationManager.AppSettings["SENDER_CODE"];
            senderInfo.SENDER_NAME = ConfigurationManager.AppSettings["SENDER_NAME"];
            senderInfo.RECEIVER_CODE = ConfigurationManager.AppSettings["RECEIVER_CODE"];
            senderInfo.RECEIVER_NAME = ConfigurationManager.AppSettings["RECEIVER_NAME"];
            senderInfo.TRAN_CODE = ConfigurationManager.AppSettings["TRAN_CODE"];
            senderInfo.ORIGINAL_CODE = ConfigurationManager.AppSettings["ORIGINAL_CODE"];
            senderInfo.ORIGINAL_NAME = ConfigurationManager.AppSettings["ORIGINAL_NAME"];
            //Test();
            timer = new Timer();
            this.timer.Interval = int.Parse(ConfigurationManager.AppSettings["INTERVAL"]);
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Tick);
        }

        private void Test()
        {
            int totalRecord = 0;
            int pageSize = 0;
            string pageSizeValue = CMCLIS.GATEWAY.SETTING.Config.PAGE_SIZE;
            int.TryParse(pageSizeValue, out pageSize);
            if (pageSize == 0) pageSize = 50;
            List<CVAN_MSGOInfo> listData = DataObjectFactory.GetInstanceCVAN_MSGO().CVAN_MSGO_GetAllWithPadding(string.Empty, string.Empty, string.Empty, 0,0, 1, pageSize, ref totalRecord);
            //lock data
            //foreach (CVAN_MSGOInfo item in listData)
            //{
            //    DataObjectFactory.GetInstanceCVAN_MSGO()
            //}
            Task.Factory.StartNew(() => CommonFunction.DoSomeWork(listData));
        }

        #region API

        //private void DoSomeWork(List<CVAN_MSGOInfo> listData)
        //{
        //    try
        //    {
        //        if (listData != null && listData.Count > 0)
        //        {
        //            CVAN_DM_MSG_TYPEInfo msgTypeInfo = null;
        //            CVAN_DM_STATUSInfo statusInfo = null;
        //            foreach (var info in listData)
        //            {
        //                string pathFile = Path.Combine(Config.PATH_DATA_SAVE_FILE, info.CVAN_CONTENT_XML);
        //                var result = REQUEST_PROCESS_DATA.SenderToThue(Utility.LoadFile(pathFile), info.CVAN_MSG_TYPE_CODE);
        //                if (result.ResultCode.EqualsValue(Constant.RETURN_CODE_SUCCESS) && !string.IsNullOrWhiteSpace(result.ReturnValue))
        //                {
        //                    XmlDocument xmlDoc = new XmlDocument();
        //                    xmlDoc.LoadXml(result.ReturnValue);
        //                    string errorStatusCode = "";
        //                    string errorDes = "";
        //                    string successStatusCode = "";
        //                    string successDes = "";
        //                    ParserStatus(xmlDoc, ref errorStatusCode, ref errorDes, ref successStatusCode, ref successDes);
        //                    msgTypeInfo = SharedDictionary.CVAN_DM_MSG_TYPEInfos.FirstOrDefault(x => x.CVAN_CODE.EqualsValue(info.CVAN_MSG_TYPE_CODE));
        //                    statusInfo = SharedDictionary.CVAN_DM_STATUSInfos.FirstOrDefault(x => x.CVAN_CODE.EqualsValue(errorStatusCode));
        //                    //nếu bên thuế trả về trạng thái của request là thành công
        //                    if (errorStatusCode.EqualsValue(Constant.STATUS_REQUEST_SUCCESS_CODE))
        //                    {
        //                        //Đẩy dữ liệu vào bảng MSGI
        //                        CVAN_MSGIInfo cVAN_MSGIInfo = new CVAN_MSGIInfo()
        //                        {
        //                            CVAN_CODE = Guid.NewGuid().ToString().ToUpper(),
        //                            CVAN_CONTENT_XML = result.ReturnValue,
        //                            CVAN_MSGO_CODE = info.CVAN_CODE,
        //                            CVAN_MSG_TYPE_CODE = info.CVAN_MSG_TYPE_CODE,
        //                            CVAN_MSG_TYPE_NAME = (msgTypeInfo != null ? msgTypeInfo.CVAN_NAME : info.CVAN_MSG_TYPE_NAME),
        //                            CVAN_STATUS_CODE = errorStatusCode,// trong xml tra ve
        //                            CVAN_STATUS_NAME = (statusInfo != null ? statusInfo.CVAN_NAME : "Not Exist on Dictionary"),
        //                            CUSER = "TCT"
        //                        };
        //                        DataObjectFactory.GetInstanceCVAN_MSGI().Add(cVAN_MSGIInfo);

        //                        //nếu ko phải là gửi phiếu chuyển thì mới đẩy vào exchange
        //                        if (!info.CVAN_MSG_TYPE_CODE.EqualsValue("TCT_GPC") && !info.CVAN_MSG_TYPE_CODE.EqualsValue("10") && !info.CVAN_MSG_TYPE_CODE.EqualsValue("11"))
        //                        {
        //                            //Đẩy vào exchange để con Service Response tiếp tục lấy ra để gửi lên thuế
        //                            CVAN_EXCHANGEInfo _CVAN_EXCHANGEInfo = new CVAN_EXCHANGEInfo()
        //                            {
        //                                CVAN_CODE = Guid.NewGuid().ToString().ToUpper(),
        //                                CVAN_CONTENT_XML = xmlDoc.OuterXml,
        //                                CVAN_LAN_GUI = 0,
        //                                CVAN_MA_GD = info.CVAN_CODE,
        //                                CVAN_STATUS_CODE = "0",
        //                                CUSER = "VAN"
        //                            };
        //                            DataObjectFactory.GetInstanceCVAN_EXCHANGE().Add(_CVAN_EXCHANGEInfo);
        //                        }
        //                        info.CVAN_STATUS_SEND = true;
        //                        DataObjectFactory.GetInstanceCVAN_MSGO().Update(info);
        //                    }
        //                    else
        //                    {
        //                        //Đẩy dữ liệu vào bảng MSGI
        //                        CVAN_MSGIInfo cVAN_MSGIInfo = new CVAN_MSGIInfo()
        //                        {
        //                            CVAN_CODE = Guid.NewGuid().ToString().ToUpper(),
        //                            CVAN_CONTENT_XML = result.ReturnValue,
        //                            CVAN_MSGO_CODE = info.CVAN_CODE,
        //                            CVAN_MSG_TYPE_CODE = info.CVAN_MSG_TYPE_CODE,
        //                            CVAN_MSG_TYPE_NAME = (msgTypeInfo != null ? msgTypeInfo.CVAN_NAME : info.CVAN_MSG_TYPE_NAME),
        //                            CVAN_STATUS_CODE = errorStatusCode,// trong xml tra ve
        //                            CVAN_STATUS_NAME = (statusInfo != null ? statusInfo.CVAN_NAME : "Not Exist on Dictionary"),
        //                            CUSER = "TCT"
        //                        };
        //                        DataObjectFactory.GetInstanceCVAN_MSGI().Add(cVAN_MSGIInfo);
        //                    }
        //                }
        //                msgTypeInfo = null;
        //                statusInfo = null;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
        //    }
        //}

        /// <summary>
        /// Hàm dùng để parser ra các trạng thái
        /// </summary>
        /// <param name="xmlDocument">đối tượng xml dùng để parser</param>
        /// <param name="errorStatusCode"></param>
        /// <param name="errorDes"></param>
        /// <param name="successStatusCode"></param>
        /// <param name="successDes"></param>
        /// created by: ntkien 17.02.2020
        private void ParserStatus(XmlDocument xmlDocument, ref string errorStatusCode, ref string errorDes, ref string successStatusCode, ref string successDes)
        {
            if (xmlDocument != null)
            {
                errorStatusCode = Utility.GetNodeValue(xmlDocument, "ERROR_CODE"); // xmlDocument.SelectNodes("//NamespaceCode:ERROR_CODE", nsmgrSign)[0].InnerXml;
                errorDes = Utility.GetNodeValue(xmlDocument, "ERROR_DESC");
                successStatusCode = Utility.GetNodeValue(xmlDocument, "MA_KETQUA"); //xmlDocument.SelectNodes("//NamespaceCode:MA_KETQUA", nsmgrSign)[0].InnerXml;
                successDes = Utility.GetNodeValue(xmlDocument, "DIEN_GIAI"); //xmlDocument.SelectNodes("//NamespaceCode:DIEN_GIAI", nsmgrSign)[0].InnerXml;
            }
        }
        #endregion
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                int totalRecord = 0;
                int pageSize = 0;
                string pageSizeValue = CMCLIS.GATEWAY.SETTING.Config.PAGE_SIZE;
                int.TryParse(pageSizeValue, out pageSize);
                if (pageSize == 0) pageSize = 50;
                List<CVAN_MSGOInfo> listData = DataObjectFactory.GetInstanceCVAN_MSGO().CVAN_MSGO_GetAllWithPadding(string.Empty, string.Empty, string.Empty, 0,0, 1, pageSize, ref totalRecord);
                //lock data
                foreach (CVAN_MSGOInfo item in listData)
                {
                    item.CVAN_STATUS_SEND = decimal.Parse(Constant.MSGO_CVAN_STATUS_SEND_PROCESSING);
                    DataObjectFactory.GetInstanceCVAN_MSGO().Update(item);
                }
                Task.Factory.StartNew(() => CommonFunction.DoSomeWork(listData));

                //if (listData != null && listData.Count > 0)
                //{

                //    var task = Task.Factory.StartNew(() => DoSomeWork(listData));
                //    Task[] tasks = new Task[listData.Count];
                //    for (int i = 0; i < listData.Count; i++)
                //    {
                //        var result = Task.Factory.ContinueWhenAll(tasks,
                //             (taskResult) =>
                //             {
                //                 try
                //                 {
                //                     Task.WaitAll(taskResult);
                //                 }
                //                 catch (Exception ex)
                //                 {
                //                     LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                //                     var faultedTasks = tasks.Where(t => t.IsFaulted);
                //                 }
                //             });
                //    }
                //}
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
                //_MSG_TEMP = Utility.LoadFile(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Log");
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
