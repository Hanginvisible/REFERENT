using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMCLIS.CVAN.ENTITY;
using CMCLIS.CVAN.DATA.OBJECTS;
using CMCLIS.CVAN.CORE;
using System.Xml;

namespace CMCLIS.CVAN.WServiceReponse
{
    /// <summary>
    /// class chứa các dữ liệu và các hàm dùng chung
    /// </summary>
    /// created by: ntkien5 14.02.2020
    public static class CommonFunction
    {


        public static void DoSomeWork(List<CVAN_EXCHANGEInfo> listData)
        {
            try
            {
                if (listData != null && listData.Count > 0)
                {
                    CVAN_MSGIInfo _MSGIInfo = null;
                    List<CVAN_MSGIInfo> _MSGIInfos = null;
                    int totalCount = 0;
                    foreach (var info in listData)
                    {
                        string status_code = Constant.EXCHANGE_CVAN_STATUS_NOTPROCESS;
                        try
                        {
                            string MSG_TYPE = string.Empty;
                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.LoadXml(info.CVAN_CONTENT_XML);
                            string namespaceURI = xmlDocument.DocumentElement.NamespaceURI;
                            if (!string.IsNullOrEmpty(namespaceURI))
                            {
                                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDocument.NameTable);
                                nsmgr.AddNamespace("NamespaceCode", namespaceURI);
                                MSG_TYPE = xmlDocument.SelectNodes("//NamespaceCode:MSG_TYPE", nsmgr)[0].InnerXml;
                            }
                            //Kiểm tra xem đối tượng này đã chuyển trạng thái sang hoàn thành chưa? nếu có rồi thì ko thực hiện nữa
                            string completeCode = string.Format("KETQUA_0");
                            _MSGIInfos= DataObjectFactory.GetInstanceCVAN_MSGI().CVAN_MSGI_GetAllWithPadding("", info.CVAN_MA_GD, MSG_TYPE, completeCode, 1, 1, ref totalCount);
                            if (_MSGIInfos!=null)
                            {
                                _MSGIInfo = _MSGIInfos.FirstOrDefault();
                            }
                            if (_MSGIInfo != null) continue;//nếu đã hoàn thành thì dừng luôn

                            var result = REQUEST_PROCESS_DATA.SenderToThue(info.CVAN_CONTENT_XML, MSG_TYPE);
                            if (result.ResultCode.EqualsValue(CMCLIS.CVAN.SETTING.Constant.RETURN_CODE_SUCCESS) && !string.IsNullOrWhiteSpace(result.ReturnValue))
                            {
                                CVAN_DM_MSG_TYPEInfo msgTypeInfo = null;
                                CVAN_DM_STATUSInfo statusInfo = null;

                                XmlDocument xmlResponse = new XmlDocument();
                                xmlResponse.LoadXml(result.ReturnValue);
                                string errorStatusCode = "";
                                string errorDes = "";
                                string successStatusCode = "";
                                string successDes = "";
                                ParserStatus(xmlResponse, ref errorStatusCode, ref errorDes, ref successStatusCode, ref successDes);
                                msgTypeInfo = Config.CVAN_DM_MSG_TYPEInfos.FirstOrDefault(x => x.CVAN_CODE.EqualsValue(MSG_TYPE));
                                statusInfo = Config.CVAN_DM_STATUSInfos.FirstOrDefault(x => x.CVAN_CODE.EqualsValue(errorStatusCode));
                                //nếu có trả về kết quả thì mới thực hiện tiếp
                                if (!string.IsNullOrWhiteSpace(errorStatusCode) || !string.IsNullOrWhiteSpace(successStatusCode))
                                {
                                    string resultStatusCode = (string.IsNullOrWhiteSpace(errorStatusCode)?"KETQUA_"+successStatusCode:"ERROR_"+errorStatusCode);
                                    string resultDes = (string.IsNullOrWhiteSpace(errorStatusCode) ? successDes : errorDes);
                                    //kiểm tra xem có đối tượng này chưa. Nếu chưa thì mới cập nhập tiếp
                                    _MSGIInfos = DataObjectFactory.GetInstanceCVAN_MSGI().CVAN_MSGI_GetAllWithPadding("", info.CVAN_MA_GD, MSG_TYPE, resultStatusCode, 1, 1, ref totalCount);
                                    if (_MSGIInfos != null)
                                    {
                                        _MSGIInfo = _MSGIInfos.FirstOrDefault();
                                    }
                                    if (_MSGIInfo != null) continue;

                                    CVAN_MSGIInfo cVAN_MSGIInfo = new CVAN_MSGIInfo()
                                    {
                                        CVAN_CODE = Guid.NewGuid().ToString().ToUpper(),
                                        CVAN_CONTENT_XML = result.ReturnValue,
                                        CVAN_MSGO_CODE = info.CVAN_MA_GD,
                                        CVAN_MSG_TYPE_CODE = MSG_TYPE,
                                        CVAN_MSG_TYPE_NAME = (msgTypeInfo != null ? msgTypeInfo.CVAN_NAME : ""),
                                        CVAN_STATUS_CODE = resultStatusCode,
                                        CVAN_STATUS_NAME = resultDes,
                                        CUSER = "TCT"
                                    };
                                    var resultValue = DataObjectFactory.GetInstanceCVAN_MSGI().Add(cVAN_MSGIInfo);

                                    //tăng số lần request của exchange
                                    info.CVAN_LAN_GUI = (info.CVAN_LAN_GUI == null ? 0 : info.CVAN_LAN_GUI) + 1;
                                    //nếu trạng thái trả về là hoàn thành thì mới đánh dấu exchange = 1 để kết thúc
                                    if (successStatusCode.EqualsValue(Constant.STATUS_REQUEST_SUCCESS_CODE))
                                    {
                                        status_code = Constant.EXCHANGE_CVAN_STATUS_DONE;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            status_code = Constant.EXCHANGE_CVAN_STATUS_NOTPROCESS;
                            throw;
                        }
                        finally
                        {
                            info.CVAN_STATUS_CODE = status_code;
                            DataObjectFactory.GetInstanceCVAN_EXCHANGE().Update(info);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        // <summary>
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
                errorStatusCode = Utility.GetNodeValue(xmlDocument, "ERROR_CODE");
                errorDes = Utility.GetNodeValue(xmlDocument, "ERROR_DESC");
                successStatusCode = Utility.GetNodeValue(xmlDocument, "MA_KETQUA");
                successDes = Utility.GetNodeValue(xmlDocument, "DIEN_GIAI");
            }
        }
    }
}
