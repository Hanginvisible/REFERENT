using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMCLIS.GATEWAY.ENTITY;
using CMCLIS.GATEWAY.DATA.OBJECTS;
using System.Xml;
using CMCLIS.GATEWAY.CORE;
using System.IO;
using CMCLIS.GATEWAY.SETTING;

namespace CMCLIS.GATEWAY.WServiceRequest
{
    /// <summary>
    /// class chứa các dữ liệu và các hàm dùng chung
    /// </summary>
    /// created by: ntkien5 14.02.2020
    public class CommonFunction
    {
        public static void DoSomeWork(List<CVAN_MSGOInfo> listData)
        {
            try
            {
                if (listData != null && listData.Count > 0)
                {
                    CVAN_DM_MSG_TYPEInfo msgTypeInfo = null;
                    CVAN_DM_STATUSInfo statusInfo = null;
                    foreach (var info in listData)
                    {
                        bool blnResult = true;
                        try {
                            string pathFile = Path.Combine(string.Format("{0}{1}", CMCLIS.GATEWAY.SETTING.Config.PATH_DATA_SAVE_FILE, info.CVAN_CONTENT_XML));
                            var result = REQUEST_PROCESS_DATA.SenderToThue(Utility.LoadFile(pathFile), info.CVAN_MSG_TYPE_CODE);
                            if (result.ResultCode.EqualsValue(CMCLIS.GATEWAY.SETTING.Constant.RETURN_CODE_SUCCESS) && !string.IsNullOrWhiteSpace(result.ReturnValue))
                            {
                                XmlDocument xmlDoc = new XmlDocument();
                                xmlDoc.LoadXml(result.ReturnValue);
                                string errorStatusCode = "";
                                string errorDes = "";
                                string successStatusCode = "";
                                string successDes = "";
                                ParserStatus(xmlDoc, ref errorStatusCode, ref errorDes, ref successStatusCode, ref successDes);
                                msgTypeInfo = CommonFunction.CVAN_DM_MSG_TYPEInfos.FirstOrDefault(x => x.CVAN_CODE.EqualsValue(info.CVAN_MSG_TYPE_CODE));
                                statusInfo = CommonFunction.CVAN_DM_STATUSInfos.FirstOrDefault(x => x.CVAN_CODE.EqualsValue(errorStatusCode));
                                //nếu bên thuế trả về trạng thái của request là thành công
                                if (errorStatusCode.EqualsValue(Constant.STATUS_REQUEST_SUCCESS_CODE))
                                {
                                    //Đẩy dữ liệu vào bảng MSGI
                                    CVAN_MSGIInfo cVAN_MSGIInfo = new CVAN_MSGIInfo()
                                    {
                                        CVAN_CODE = Guid.NewGuid().ToString().ToUpper(),
                                        CVAN_CONTENT_XML = result.ReturnValue,
                                        CVAN_MSGO_CODE = info.CVAN_CODE,
                                        CVAN_MSG_TYPE_CODE = info.CVAN_MSG_TYPE_CODE,
                                        CVAN_MSG_TYPE_NAME = (msgTypeInfo != null ? msgTypeInfo.CVAN_NAME : info.CVAN_MSG_TYPE_NAME),
                                        CVAN_STATUS_CODE = "ERROR_"+errorStatusCode,// trong xml tra ve
                                        CVAN_STATUS_NAME = (statusInfo != null ? statusInfo.CVAN_NAME : "Not Exist on Dictionary"),
                                        CUSER = "TCT"
                                    };
                                    DataObjectFactory.GetInstanceCVAN_MSGI().Add(cVAN_MSGIInfo);
                                    //nếu ko phải là gửi phiếu chuyển thì mới đẩy vào exchange
                                    if (!info.CVAN_MSG_TYPE_CODE.EqualsValue("TCT_GPC") && !info.CVAN_MSG_TYPE_CODE.EqualsValue("10") && !info.CVAN_MSG_TYPE_CODE.EqualsValue("11"))
                                    {
                                        //Đẩy vào exchange để con Service Response tiếp tục lấy ra để gửi lên thuế
                                        CVAN_EXCHANGEInfo _CVAN_EXCHANGEInfo = new CVAN_EXCHANGEInfo()
                                        {
                                            CVAN_CODE = Guid.NewGuid().ToString().ToUpper(),
                                            CVAN_CONTENT_XML = xmlDoc.OuterXml,
                                            CVAN_LAN_GUI = 0,
                                            CVAN_MA_GD = info.CVAN_CODE,
                                            CVAN_STATUS_CODE = "0",
                                            CUSER = "VAN"
                                        };
                                        DataObjectFactory.GetInstanceCVAN_EXCHANGE().Add(_CVAN_EXCHANGEInfo);
                                    }
                                }
                                else
                                {
                                    //Đẩy dữ liệu vào bảng MSGI
                                    CVAN_MSGIInfo cVAN_MSGIInfo = new CVAN_MSGIInfo()
                                    {
                                        CVAN_CODE = Guid.NewGuid().ToString().ToUpper(),
                                        CVAN_CONTENT_XML = result.ReturnValue,
                                        CVAN_MSGO_CODE = info.CVAN_CODE,
                                        CVAN_MSG_TYPE_CODE = info.CVAN_MSG_TYPE_CODE,
                                        CVAN_MSG_TYPE_NAME = (msgTypeInfo != null ? msgTypeInfo.CVAN_NAME : info.CVAN_MSG_TYPE_NAME),
                                        CVAN_STATUS_CODE = errorStatusCode,// trong xml tra ve
                                        CVAN_STATUS_NAME = (statusInfo != null ? statusInfo.CVAN_NAME : "Not Exist on Dictionary"),
                                        CUSER = "TCT"
                                    };
                                    DataObjectFactory.GetInstanceCVAN_MSGI().Add(cVAN_MSGIInfo);
                                    blnResult = false;
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            blnResult = false;
                            throw;
                        }
                        finally
                        {
                            //cập nhật trạng thái cho msgo
                            info.CVAN_STATUS_SEND = (blnResult?decimal.Parse(Constant.MSGO_CVAN_STATUS_SEND_DONE): decimal.Parse(Constant.MSGO_CVAN_STATUS_SEND_NOTPROCESS));
                            DataObjectFactory.GetInstanceCVAN_MSGO().Update(info);
                        }
                        msgTypeInfo = null;
                        statusInfo = null;
                    }
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        /// <summary>
        /// Hàm dùng để parser ra các trạng thái
        /// </summary>
        /// <param name="xmlDocument">đối tượng xml dùng để parser</param>
        /// <param name="errorStatusCode"></param>
        /// <param name="errorDes"></param>
        /// <param name="successStatusCode"></param>
        /// <param name="successDes"></param>
        /// created by: ntkien 17.02.2020
        private static void ParserStatus(XmlDocument xmlDocument, ref string errorStatusCode, ref string errorDes, ref string successStatusCode, ref string successDes)
        {
            if (xmlDocument != null)
            {
                errorStatusCode = Utility.GetNodeValue(xmlDocument, "ERROR_CODE"); // xmlDocument.SelectNodes("//NamespaceCode:ERROR_CODE", nsmgrSign)[0].InnerXml;
                errorDes = Utility.GetNodeValue(xmlDocument, "ERROR_DESC");
                successStatusCode = Utility.GetNodeValue(xmlDocument, "MA_KETQUA"); //xmlDocument.SelectNodes("//NamespaceCode:MA_KETQUA", nsmgrSign)[0].InnerXml;
                successDes = Utility.GetNodeValue(xmlDocument, "DIEN_GIAI"); //xmlDocument.SelectNodes("//NamespaceCode:DIEN_GIAI", nsmgrSign)[0].InnerXml;
            }
        }
        /// <summary>
        /// Danh mục MSG_TYPE
        /// </summary>
        /// created by: ntkien5 14.02.2020 
        private static List<CVAN_DM_MSG_TYPEInfo> _CVAN_DM_MSG_TYPEInfos;
        public static List<CVAN_DM_MSG_TYPEInfo> CVAN_DM_MSG_TYPEInfos
        {
            get
            {
                if (_CVAN_DM_MSG_TYPEInfos==null || _CVAN_DM_MSG_TYPEInfos.Count==0)
                {
                    _CVAN_DM_MSG_TYPEInfos = DataObjectFactory.GetInstanceCVAN_DM_MSG_TYPE().GetList();
                    return _CVAN_DM_MSG_TYPEInfos;
                }
                return _CVAN_DM_MSG_TYPEInfos;
            }
        }

        /// <summary>
        /// Danh mục trạng thái 
        /// </summary>
        // created by: ntkien 17.02.2020
        private static List<CVAN_DM_STATUSInfo> _CVAN_DM_STATUSInfos;
        public static List<CVAN_DM_STATUSInfo> CVAN_DM_STATUSInfos
        {
            get
            {
                if (_CVAN_DM_STATUSInfos==null || _CVAN_DM_STATUSInfos.Count==0)
                {
                    _CVAN_DM_STATUSInfos = DataObjectFactory.GetInstanceCVAN_DM_STATUS().GetList();
                }
                return _CVAN_DM_STATUSInfos;
            }
        }
    }
}
