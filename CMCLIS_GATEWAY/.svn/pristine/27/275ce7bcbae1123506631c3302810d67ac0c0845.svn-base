using CMCLIS.GATEWAY.CORE;
using CMCLIS.GATEWAY.DATA.OBJECTS;
using CMCLIS.GATEWAY.ENTITY;
using CMCLIS.GATEWAY.SETTING;
using Newtonsoft.Json;
using System;

namespace CMCLIS.GATEWAY.WServiceMQDB.LOG
{
    public class MQ_PROCESS_DATA
    {
        /// <summary>
        /// nhtoan3: Insert log data get từ MQ into database
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static object MAIL_INSERT_MSG_MQ(CVAN_LOG_SENDMQInfo info)
        {
            object result = -1;

            try
            {
                switch (info.Type_Log)
                {
                    case (int)Constant.TYPE_OF_LOG.LOG_CHUC_NANG: // log chức năng type = 1
                        var LogCN = JsonConvert.DeserializeObject<LOG_CHUC_NANGInfo>(info.Log_Value);
                        result = DataObjectFactory.GetInstanceLOG_CHUC_NANG().Add(LogCN);
                        break;
                    case (int)Constant.TYPE_OF_LOG.LOG_DATA: // log data type = 2
                        var LogData = JsonConvert.DeserializeObject<LOG_DATAInfo>(info.Log_Value);
                        result = DataObjectFactory.GetInstanceLOG_DATA().Add(LogData);
                        break;
                    case (int)Constant.TYPE_OF_LOG.LOG_DU_LIEU_DB: // log dữ liệu type =3
                        var LogDB = JsonConvert.DeserializeObject<LOG_DU_LIEU_DBInfo>(info.Log_Value);
                        result = DataObjectFactory.GetInstanceLOG_DU_LIEU_DB().Add(LogDB);
                        break;
                    case (int)Constant.TYPE_OF_LOG.LOG_TRUY_CAP: //log truy cập type = 4
                        var LogTC = JsonConvert.DeserializeObject<LOG_TRUY_CAPInfo>(info.Log_Value);
                        result = DataObjectFactory.GetInstanceLOG_TRUY_CAP().Add(LogTC);
                        break;
                    case (int)Constant.TYPE_OF_LOG.LOG_XU_LY_HANG_LOAT: // log hàng loạt type = 5 
                        var LogXL = JsonConvert.DeserializeObject<LOG_XL_HANG_LOATInfo>(info.Log_Value);
                        result = DataObjectFactory.GetInstanceLOG_XL_HANG_LOAT().Add(LogXL);
                        break;
                    case (int)Constant.TYPE_OF_LOG.LOG_XU_LY_QUY_TRINH: // log quy trình type = 6 
                        var LogXLQT = JsonConvert.DeserializeObject<LOG_XL_QUY_TRINHInfo>(info.Log_Value);
                        result = DataObjectFactory.GetInstanceLOG_XL_QUY_TRINH().Add(LogXLQT);
                        break;
                    default:
                        break;
                }
                return result;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                Console.WriteLine(ex.Message);
                return -1;
            }

        }

    }
}
