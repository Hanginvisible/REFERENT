using Aspose.Cells;
using CMCLIS.GATEWAY.CORE;
using CMCLIS.GATEWAY.CORE.Redis;
using CMCLIS.GATEWAY.CORE.Sercurity;
using CMCLIS.GATEWAY.DATA.OBJECTS;
using CMCLIS.GATEWAY.ENTITY;
using CMCLIS.GATEWAY.ENTITY.LIEN_THONG;
using CMCLIS.GATEWAY.SETTING;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.Text;
using System.Web;
using System.Xml;

namespace CMCLIS.GATEWAY.SERVICES
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class API_LIEN_THONG : IAPI_LIEN_THONG
    {
        private static string Authorization = string.Empty;
        protected API_LIEN_THONG()
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
        /// nhtoan3: Tra cứu thông tin từ bảng MSGI
        /// </summary>
        /// <param name="CVAN_CODE"></param>
        /// <param name="CVAN_MSGO_CODE"></param>
        /// <param name="CVAN_MSG_TYPE_CODE"></param>
        /// <param name="CVAN_STATUS_CODE"></param>
        /// <returns></returns>
        public ResponseList<CVAN_MSGIInfo> CVAN_MSGIInfo(string CVAN_CODE, string CVAN_MSGO_CODE, string CVAN_MSG_TYPE_CODE, string CVAN_STATUS_CODE)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {

                    int totalCount = 0;
                    CVAN_CODE = CVAN_CODE.EqualsValue(Config.cstExpectValue) ? "" : CVAN_CODE;
                    CVAN_MSGO_CODE = CVAN_MSGO_CODE.EqualsValue(Config.cstExpectValue) ? "" : CVAN_MSGO_CODE;
                    CVAN_MSG_TYPE_CODE = CVAN_MSG_TYPE_CODE.EqualsValue(Config.cstExpectValue) ? "" : CVAN_MSG_TYPE_CODE;
                    CVAN_STATUS_CODE = CVAN_STATUS_CODE.EqualsValue(Config.cstExpectValue) ? "" : CVAN_STATUS_CODE;
                    List<CVAN_MSGIInfo> result = DataObjectFactory.GetInstanceCVAN_MSGI().CVAN_MSGI_QuerySolr_GetAllWithPadding(string.Empty,CVAN_CODE, CVAN_MSGO_CODE, CVAN_MSG_TYPE_CODE, CVAN_STATUS_CODE, 0, 1, int.MaxValue, ref totalCount);
                    return new ResponseList<CVAN_MSGIInfo>
                    {
                        ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
                        TotalRecords = result != null ? result.Count : 0,
                        Data = result
                    };


                }
                else
                {
                    return new ResponseList<CVAN_MSGIInfo>
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
                return new ResponseList<CVAN_MSGIInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR,
                };
            }
        }

        /// <summary>
        /// nhtoan3: Tra cứu thông tin từ bảng MSGO
        /// </summary>
        /// <param name="CVAN_CODE"></param>
        /// <param name="CVAN_MSG_TYPE_CODE"></param>
        /// <param name="CVAN_SENDER_CODE"></param>
        /// <param name="CVAN_STATUS_SEND"></param>
        /// <returns></returns>
        public ResponseList<CVAN_MSGOInfo> CVAN_MSGOInfo(string CVAN_CODE, string CVAN_MSG_TYPE_CODE, string CVAN_SENDER_CODE, string CVAN_STATUS_SEND)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    int totalCount = 0;
                    CVAN_CODE = CVAN_CODE.EqualsValue(Config.cstExpectValue) ? "" : CVAN_CODE;
                    CVAN_MSG_TYPE_CODE = CVAN_MSG_TYPE_CODE.EqualsValue(Config.cstExpectValue) ? "" : CVAN_MSG_TYPE_CODE;
                    CVAN_SENDER_CODE = CVAN_SENDER_CODE.EqualsValue(Config.cstExpectValue) ? "" : CVAN_SENDER_CODE;

                    List<CVAN_MSGOInfo> result = DataObjectFactory.GetInstanceCVAN_MSGO().CVAN_MSGO_QuerySolr_GetAllWithPadding(string.Empty,CVAN_CODE, CVAN_MSG_TYPE_CODE, CVAN_SENDER_CODE, int.Parse(CVAN_STATUS_SEND), 0, 1, int.MaxValue, ref totalCount);
                    return new ResponseList<CVAN_MSGOInfo>
                    {
                        ResultCode = result != null ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                        Message = result != null ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
                        TotalRecords = result != null ? result.Count : 0,
                        Data = result
                    };
                }
                else
                {
                    return new ResponseList<CVAN_MSGOInfo>
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
                return new ResponseList<CVAN_MSGOInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR,
                };
            }
        }

        /// <summary>
        /// nhtoan3: Gửi thông tin message tới MQ
        /// </summary>
        /// <param name="_SERVICE_REQUEST_INFO"></param>
        /// <returns></returns>
        public Response CVAN_TIEP_NHAN_HO_SO(SERVICE_REQUEST_INFO _SERVICE_REQUEST_INFO)
        {
            try
            {

                if (!string.IsNullOrEmpty(Authorization))
                {
                    if (_SERVICE_REQUEST_INFO == null)
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = Constant.MESSAGE_NOT_FOUND,
                            ReturnValue = null
                        };
                    }
                    if (string.IsNullOrEmpty(_SERVICE_REQUEST_INFO.MESSAGE_TYPE))
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = Constant.MESSAGE_NOT_MESSAGE_TYPE,
                            ReturnValue = null
                        };
                    }
                    if (string.IsNullOrEmpty(_SERVICE_REQUEST_INFO.XML_CONTENT))
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = Constant.MESSAGE_NOT_FOUND,
                            ReturnValue = null
                        };
                    }
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(_SERVICE_REQUEST_INFO.XML_CONTENT);
                    XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/DATA/HEADER/MESSAGE_CODE");
                    if (xmlNodeList.Count > 0)
                    {
                        string maGiaoDich = Guid.NewGuid().ToString().ToUpper();
                        xmlNodeList[0].InnerText = maGiaoDich;
                        #region Pushing message to MQ
                        Byte[] arrByteSend = null;
                        if (!string.IsNullOrEmpty(xmlDocument.OuterXml))
                        {
                            arrByteSend = Encoding.UTF8.GetBytes(xmlDocument.OuterXml);
                        }
                        int result = MQProcess.SendDataToMQ(arrByteSend, Config.MQ_NAME);
                        #endregion
                        return new Response
                        {
                            ResultCode = result == 1 ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                            Message = result == 1 ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_ERROR,
                            ReturnValue = result == 1 ? maGiaoDich : string.Empty
                        };
                    }
                    else
                    {
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_ERROR,
                            Message = Constant.MESSAGE_NOT_VALIDATE,
                            ReturnValue = null
                        };
                    }

                }
                else
                {
                    return new Response
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        ReturnValue = null
                    };
                }
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
        #endregion
    }
}
