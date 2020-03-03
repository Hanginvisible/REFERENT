using Aspose.Cells;
using CMCLIS.GATEWAY.CORE;
using CMCLIS.GATEWAY.CORE.Redis;
using CMCLIS.GATEWAY.CORE.Sercurity;
using CMCLIS.GATEWAY.DATA.OBJECTS;
using CMCLIS.GATEWAY.ENTITY;
using CMCLIS.GATEWAY.SETTING;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.Text;
using System.Web;

namespace CMCLIS.GATEWAY.SERVICES
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class API_EMAIL : IAPI_EMAIL
    {
        private static string Authorization = string.Empty;
        protected API_EMAIL()
        {
            var request = OperationContext.Current.IncomingMessageProperties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            Authorization = request.Headers[Config.API_KEY];
            if (string.IsNullOrEmpty(Authorization))
            {
                Authorization = Config.KEY_AUTHORIZATION;
            }

        }


        #region Create Functions "GATE_WAY"
        /// <summary>
        /// nhtoan3: Tra cứu thông tin trong bảng CVAN_MAIL
        /// </summary>
        /// <param name="CVAN_FROM"></param>
        /// <param name="CVAN_TO"></param>
        /// <param name="CVAN_SUBJECT"></param>
        /// <param name="CVAN_TYPE_CODE"></param>
        /// <param name="CVAN_STATUS"></param>
        /// <returns></returns>
        public ResponseList<CVAN_MAILInfo> CVAN_MAILInfo(string CVAN_FROM, string CVAN_TO, string CVAN_SUBJECT, string CVAN_TYPE_CODE, string CVAN_STATUS)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    int totalCount = 0;
                    CVAN_FROM = CVAN_FROM.EqualsValue(Config.cstExpectValue) ? "" : CVAN_FROM;
                    CVAN_TO = CVAN_TO.EqualsValue(Config.cstExpectValue) ? "" : CVAN_TO;
                    CVAN_SUBJECT = CVAN_SUBJECT.EqualsValue(Config.cstExpectValue) ? "" : CVAN_SUBJECT;
                    CVAN_TYPE_CODE = CVAN_TYPE_CODE.EqualsValue(Config.cstExpectValue) ? "" : CVAN_TYPE_CODE;
                    List<CVAN_MAILInfo> result = DataObjectFactory.GetInstanceCVAN_MAIL().CVAN_MAIL_QuerySolr_GetAllWithPadding(string.Empty, CVAN_FROM, CVAN_TO, CVAN_SUBJECT, CVAN_TYPE_CODE, int.Parse(CVAN_STATUS), 0, 1, int.MaxValue, ref totalCount);
                    return new ResponseList<CVAN_MAILInfo>
                    {
                        ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
                        TotalRecords = result != null ? result.Count : 0,
                        Data = result
                    };
                }
                else
                {
                    return new ResponseList<CVAN_MAILInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        TotalRecords = 0,
                        Data = null
                    };

                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new ResponseList<CVAN_MAILInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = ex.Message,
                };
            }
        }
        /// <summary>
        /// nhtoan3: Gửi thông tin CVAN_MAIL tới MQ 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public Response CVAN_MAILInfo_POST(CVAN_MAIL info)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    if (string.IsNullOrEmpty(info.EmailTo) || string.IsNullOrWhiteSpace(info.EmailTo))
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "[Email To] không được phép để trống !",
                            ReturnValue = string.Empty
                        };
                    }

                    if (string.IsNullOrEmpty(info.Content) || string.IsNullOrWhiteSpace(info.Content))
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "[Content] không được phép để trống !",
                            ReturnValue = string.Empty
                        };
                    }

                    if (string.IsNullOrEmpty(info.Subject) || string.IsNullOrWhiteSpace(info.Subject))
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = "[Subject] không được phép để trống !",
                            ReturnValue = string.Empty
                        };
                    }

                    string CVAN_MAIL_JSON = JsonConvert.SerializeObject(info);
                    byte[] data = Encoding.UTF8.GetBytes(CVAN_MAIL_JSON);
                    var value = MQProcess.SendDataToMQ(data, Config.CLIS_MAIL_INFO);
                    return new Response
                    {
                        ResultCode = value == 1 ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = value == 1 ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
                        ReturnValue = info != null ? info.Content : "string.Empty"
                    };
                }
                else
                {
                    return new Response
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        ReturnValue = string.Empty
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR,
                    ReturnValue = ex.Message
                };
            }
        }
        #endregion

    }
}
