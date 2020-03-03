using CMCLIS.GATEWAY.CORE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;


namespace CMCLIS.GATEWAY.WServiceScheduler
{
    public partial class ServiceScheduler : ServiceBase
    {
        private string configPath = string.Empty;
        private Timer timer = null;
        DataSet dsTasks = new DataSet();
        bool writeResult = false;
        public ServiceScheduler()
        {
            InitializeComponent();
            timer = new Timer();

            this.timer.Interval = int.Parse(ConfigurationManager.AppSettings["INTERVAL"]);
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Tick);
        }
        

        public string Download(string uriDownload, int timeOut)
        {
            HttpWebResponse response;
            WebException exception;            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriDownload);
            request.Method = "GET";
            request.KeepAlive = true;
            request.Timeout = timeOut * 1000;
            request.AllowAutoRedirect = true;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.1) Gecko/20060111 Firefox/1.5.0.1";
            //request.CookieContainer = new CookieContainer();

            string str = string.Empty;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                if (response == null)
                {
                    str = "{\"result_code\":-333,\"message\":\"Empty\"}";
                    return str;
                }
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                str = reader.ReadToEnd();
                response.Close();
                reader.Close();
                return str;
            }
            catch (WebException exception1)
            {
                exception = exception1;
                if (exception.Status == WebExceptionStatus.Timeout)
                    str = "{\"result_code\":-111,\"message\":\"Timeout\"}";
                else
                    str = "{\"result_code\":-222,\"message\":\"exception\"}";
                LogEventError.LogEvent(string.Format("{0} - {1}", uriDownload, str));
                return str;
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime currTime = DateTime.Now;
                foreach (DataRow dRow in dsTasks.Tables["Task"].Rows)
                {
                    if (!string.IsNullOrEmpty(dRow["TimeExcute"].ToString()))
                    {
                        DateTime runTime = DateTime.ParseExact(dRow["TimeExcute"].ToString(), "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        //DateTime runTime = Convert.ToDateTime(dRow["TimeExcute"]);
                        if (currTime >= runTime)
                        {
                            runTime = runTime.AddSeconds(int.Parse(dRow["Interval"].ToString()));
                            string UrlExcute = dRow["AppServer"].ToString() + "/" + dRow["SorlName"].ToString() + "/" + dRow["SorlCore"].ToString() + "/" + dRow["UrlExcute"].ToString();
                            string result = Download(UrlExcute, 15);
                            if (writeResult)
                            {
                                LogEventError.LogEvent(string.Format("{0} - {1}", runTime.ToString("MM/dd/yyyy HH:mm:ss"), result));
                            }

                            dRow["TimeExcute"] = runTime.ToString("MM/dd/yyyy HH:mm:ss");
                            dsTasks.AcceptChanges();
                            StreamWriter sWrite = new StreamWriter(configPath);
                            XmlTextWriter xWrite = new XmlTextWriter(sWrite);
                            dsTasks.WriteXml(xWrite);
                            xWrite.Close();
                        }
                    }
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
                string WRITE_RERULT = ConfigurationManager.AppSettings["WRITE_RERULT"];
                if (WRITE_RERULT == "1")
                {
                    writeResult = true;
                }
                else {
                    writeResult = false;
                }
                configPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\AppScheduler.xml";
                XmlTextReader xRead = new XmlTextReader(configPath);
                XmlValidatingReader xvRead = new XmlValidatingReader(xRead);
                xvRead.ValidationType = ValidationType.DTD;
                dsTasks.ReadXml(xvRead);
                xvRead.Close();
                xRead.Close();
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
