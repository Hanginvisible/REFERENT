using CMCLIS.CVAN.CORE;
using CMCLIS.CVAN.CORE.Sercurity;
using CMCLIS.CVAN.SETTING;
using CMCLIS.CVAN.ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace CMCLIS.CVAN.GATEWAY
{
    public class MQ_PROCESS_DATA
    {
        public static int SendToMQ(string message, Byte[] fileMessage, string MQ_NAME)
        {
            try
            {
                int result = 0;
                Byte[] arrByteSend = null;
                if (!string.IsNullOrEmpty(message))
                {
                    arrByteSend = Encoding.UTF8.GetBytes(message);
                }
                else if (fileMessage != null)
                {
                    arrByteSend = fileMessage;
                }
                result = MQProcess.SendDataToMQ(arrByteSend, MQ_NAME);
                return result;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return -1;
            }
        }

    }
}
