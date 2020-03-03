
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


namespace CMCLIS.GATEWAY.WServiceReponse
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

        #region API

        private List<CVAN_EXCHANGEInfo> GetListDataByPageIndex(int pageIndex, int pageSize, List<CVAN_EXCHANGEInfo> listData)
        {
            try
            {
                List<CVAN_EXCHANGEInfo> childList = new List<CVAN_EXCHANGEInfo>();
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

        
   
        #endregion


        //public void Test()
        //{
        //    int totalRecord = 0;
        //    List<CVAN_EXCHANGEInfo> listData = DataObjectFactory.GetInstanceCVAN_EXCHANGE().CVAN_EXCHANGE_GetAllWithPadding("0", string.Empty, string.Empty, 1, int.MaxValue, ref totalRecord);
        //    if (listData != null && listData.Count > 0)
        //    {
        //        List<int> listPage = Utility.GetListPage(listData.Count, int.Parse(Config.PAGE_SIZE));
        //        Task[] tasks = new Task[listPage.Count];
        //        int ctr = 0;
        //        foreach (var item in listPage)
        //        {
        //            var task = Task.Factory.StartNew(() => DoSomeWork(item, int.Parse(Config.PAGE_SIZE), listData));
        //            tasks[ctr] = task;
        //            ctr++;

        //        }
        //        var result = Task.Factory.ContinueWhenAll(tasks,
        //         (taskResult) =>
        //         {
        //             try
        //             {
        //                 Task.WaitAll(taskResult);
        //             }
        //             catch (Exception ex)
        //             {
        //                 LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
        //                 var faultedTasks = tasks.Where(t => t.IsFaulted);
        //             }

        //         });
        //    }
        //}

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                int totalRecord = 0;
                int pageSize = 0;
                string pageSizeValue = CMCLIS.GATEWAY.SETTING.Config.PAGE_SIZE;
                int.TryParse(pageSizeValue, out pageSize);
                if (pageSize == 0) pageSize = 50;

                List<CVAN_EXCHANGEInfo> listData =  DataObjectFactory.GetInstanceCVAN_EXCHANGE().CVAN_EXCHANGE_GetAllWithPadding("","","0","",0,1,pageSize,ref totalRecord);
                foreach(CVAN_EXCHANGEInfo item in listData)
                {
                    item.CVAN_STATUS_CODE = Constant.EXCHANGE_CVAN_STATUS_PROCESSING;
                    DataObjectFactory.GetInstanceCVAN_EXCHANGE().Update(item);
                }
                if (listData != null && listData.Count > 0)
                {
                    Task.Factory.StartNew(() => CommonFunction.DoSomeWork(listData));
                    //List<int> listPage = Utility.GetListPage(listData.Count, int.Parse(Config.PAGE_SIZE));
                    //Task[] tasks = new Task[listPage.Count];
                    //int ctr = 0;
                    //foreach (var item in listPage)
                    //{
                    //    var task = 
                    //    tasks[ctr] = task;
                    //    ctr++;

                    //}
                    //var result = Task.Factory.ContinueWhenAll(tasks,
                    // (taskResult) =>
                    // {
                    //     try
                    //     {
                    //         Task.WaitAll(taskResult);
                    //     }
                    //     catch (Exception ex)
                    //     {
                    //         LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                    //         var faultedTasks = tasks.Where(t => t.IsFaulted);
                    //     }

                    // });
                }
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
                //_MSG_TEMP = Utility.LoadFile(ConfigurationManager.AppSettings["MSG_TEMP"]);
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
