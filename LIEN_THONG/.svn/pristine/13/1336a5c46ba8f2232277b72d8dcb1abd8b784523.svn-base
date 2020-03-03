using CMCLIS.CVAN.CORE;
using CMCLIS.CVAN.DATA.OBJECTS;
using CMCLIS.CVAN.ENTITY;
using CMCLIS.CVAN.SETTING;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CMCLIS.CVAN.LOG.Controller
{
    [EnableCors("*", "*", "*")]
    public class LogController : ApiController
    {
        [Route("LogApi/Check/{id}"), HttpGet]
        public Response Example(string id)
        {
            return new Response
            {
                ResultCode = Constant.RETURN_CODE_SUCCESS,
                Message = Constant.MESSAGE_SUCCESS,
                ReturnValue = id
            };
        }

        /// <summary>
        /// hàm thực hiện load Log
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="applicationname"></param>
        /// <param name="message"></param>
        /// <param name="logtype"></param>
        /// <param name="cstartdate"></param>
        /// <param name="cenddate"></param>
        /// <returns></returns>
        /// created by: ntkien5 13.02.2020
        [Route("LogApi/{ip}/{port}/{applicationname}/{message}/{logtype}/{cstartdate}/{cenddate}"), HttpGet]
        public ResponseList<LOG_DATAInfo> SERVICE_LOG_LOAD(string ip,int port,string applicationname, string message,int logtype,string cstartdate,string cenddate)
        {
            try {
                ip = ip.EqualsValue(Config.cstExpectValue) ? "" : ip;
                applicationname = applicationname.EqualsValue(Config.cstExpectValue) ? "" : applicationname;
                message = message.EqualsValue(Config.cstExpectValue) ? "" : message;
                DateTime? startDate = null;
                DateTime? endDate = null;
                if (!cstartdate.EqualsValue(Config.cstExpectValue))
                {
                    startDate = DateTime.ParseExact(cstartdate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                }
                if (!cenddate.EqualsValue(Config.cstExpectValue))
                {
                    endDate = DateTime.ParseExact(cenddate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                }
                int totalCount = 0;
                List<LOG_DATAInfo> logs = DataObjectFactory.GetInstanceLOG_DATA().LOG_DATA_QuerySolr_GetAllWithPadding(string.Empty, ip, port, applicationname, message, logtype, startDate, endDate, 1, int.MaxValue, ref totalCount);
                return new ResponseList<LOG_DATAInfo>
                {
                    ResultCode = Constant.RETURN_CODE_SUCCESS,
                    Message = Constant.MESSAGE_SUCCESS,
                    TotalRecords = totalCount,
                    Data = logs
                };
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new ResponseList<LOG_DATAInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = ex.Message
                };
            }
            
        }

        /// <summary>
        /// Hàm thực hiện ghi Log
        /// </summary>
        /// <param name="logObject">đối tượng ghi log</param>
        /// <returns></returns>
        /// Created By: 13.02.2020
        [Route("LogApi/Post")]
        public Response SERVICE_LOG_POST(LogObject logObject)
        {
            try
            {
                LOG_DATAInfo objLog = new LOG_DATAInfo();
                objLog.IP = logObject.IP;
                objLog.PORT = logObject.PORT;
                objLog.APPLICATION_NAME = logObject.APPLICATION_NAME;
                objLog.MESSAGE = logObject.MESSAGE;
                objLog.LOG_TYPE = logObject.LOG_TYPE == 0 ? false:true ;
                objLog.CUSER = logObject.CUSER;
                int result = DataObjectFactory.GetInstanceLOG_DATA().Add(objLog);
                if (result != -1)
                {
                    return new Response
                    {
                        ResultCode = Constant.RETURN_CODE_SUCCESS,
                        Message = Constant.MESSAGE_SUCCESS,
                        ReturnValue = result.ToString()
                    };
                }
                return new Response
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR
                };
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new Response
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR,
                    ReturnValue = ex.Message
                };
            }
        }
    }
}
