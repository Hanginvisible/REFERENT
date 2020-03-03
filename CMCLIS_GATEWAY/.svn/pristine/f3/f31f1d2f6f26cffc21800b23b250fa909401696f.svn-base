using CMCLIS.GATEWAY.SETTING;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CMCLIS.GATEWAY.CORE
{
    public class LogEventError
    {
        #region "Event Log"

        public static void LogEvent(string mes)
        {
           
            DateTime date = DateTime.Now;
            string fileName = date.ToString("yyyy-MM-dd") + "-Temp.log";
            if (!Directory.Exists(Config.LOG_PATH))
            {
                Directory.CreateDirectory(Config.LOG_PATH);
            }
            string Source = Path.Combine(Config.LOG_PATH, fileName);

            try
            {
                using (StreamWriter writer = new StreamWriter(Source, true))
                {
                    writer.WriteLine(mes);
                }

            }
            catch (Exception e)
            {
            }

        }

        public static void LogEvent(string source, Exception ex)
        {
            string strValue = string.Empty;

            strValue += "{";
            strValue += Environment.NewLine + "  \"Guid\":" + "\"" + Guid.NewGuid() + "\"" + ",";
            strValue += Environment.NewLine + "  \"Version\":" + "\"" + Config.VERSION + "\"" + ",";
            strValue += Environment.NewLine + "  \"Product\":" + "\"" + Config.SOFTWARE_NAME + "\"" + ",";
            strValue += Environment.NewLine + "  \"Date\":" + "\"" + DateTime.Now.ToString() + "\"" + ",";
            strValue += Environment.NewLine + "  \"Source\":" + "\"[" + source + "]\"" + ",";
            strValue += Environment.NewLine + "  \"Message\":" + "\"" + ex.Message.Replace(@"\", @"\\").Replace("\r\n", "\\r\\n").Replace("\"", "'") + "\"" + ",";
            strValue += Environment.NewLine + "  \"StackTrace\":" + "\"" + ex.StackTrace.Replace(@"\", @"\\").Replace("\r\n", "\\r\\n").Replace("\"", "'") + "\"" + ",";
            strValue += Environment.NewLine + "  \"Status\":" + "\"0\"" + ",";
            strValue += Environment.NewLine + "  \"AssignedTo\":" + "\"\"" + ",";
            strValue += Environment.NewLine + "  \"CreatedBy\":" + "\"" + DateTime.Now.ToString() + "\"";
            strValue += Environment.NewLine + "},";           
            DateTime date = DateTime.Now;
            string fileName = date.ToString("yyyy-MM-dd") + ".log";
            if (!Directory.Exists(Config.LOG_PATH))
            {
                Directory.CreateDirectory(Config.LOG_PATH);
            }
            string Source = Path.Combine(Config.LOG_PATH, fileName);

            try
            {
                using (StreamWriter writer = new StreamWriter(Source, true))
                {
                    writer.WriteLine(strValue);
                }
                //if (Boolean.Parse(Config.FTP_USING))
                //{
                //    if (File.Exists(Source))
                //    {
                //        FTPClient.CreateFolder(Config.FTP_SERVER_URI, Config.FTP_USER, Config.FTP_PASSWORD, date.ToString("yyyy-MM-dd"));
                //        FTPClient.CreateFolder(Config.FTP_SERVER_URI + "/" + date.ToString("yyyy-MM-dd"), Config.FTP_USER, Config.FTP_PASSWORD, Config.SOFTWARE_NAME);
                //        FTPClient.Upload(Config.FTP_SERVER_URI + "/" + date.ToString("yyyy-MM-dd") + "/" + Config.SOFTWARE_NAME, Config.FTP_USER, Config.FTP_PASSWORD, Source);
                        
                //    }
                //}
            }
            catch (Exception e)
            {
            }

        }

        #endregion
    }
}
