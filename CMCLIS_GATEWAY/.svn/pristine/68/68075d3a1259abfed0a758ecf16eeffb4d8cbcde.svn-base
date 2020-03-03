using CMCLIS.GATEWAY.CORE;
using CMCLIS.GATEWAY.CORE.Sercurity;
using CMCLIS.GATEWAY.SETTING;
using CMCLIS.GATEWAY.ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using CMCLIS.GATEWAY.DATA.OBJECTS;

namespace CMCLIS.GATEWAY.WServiceRequest
{
    public class REQUEST_PROCESS_DATA
    {
        private const string Constant_Error_PhieuChuyen = "ERROR_CODE_02";
        private const string Constant_Error_TruyVanHoSo = "ERROR_CODE_40";
        private const string Constant_Error_TruyVanTBT = "ERROR_CODE_11";
        private const string Constant_Error_TruyVanNVTC = "ERROR_CODE_29";

        //private const string Constant_KetQua_PhieuChuyen = "MA_KETQUA_02";
        //private const string Constant_KetQua_TruyVanHoSo = "MA_KETQUA_40";
        //private const string Constant_KetQua_TruyVanTBT = "MA_KETQUA_11";
        //private const string Constant_KetQua_TruyVanNVTC = "MA_KETQUA_29";
        public static Response SenderToThue(string xmlContent, string msgTypeCode)
        {
            try
            {
                string resXMLContent = string.Empty;
                switch (msgTypeCode)
                {
                    case "TCT_GPC":
                    case "10":
                    case "11":
                        resXMLContent = GetXML_PhieuChuyen(xmlContent);
                        break;
                    case "TCT_TVTBT":
                    case "14":
                    case "15":
                        resXMLContent = GetXML_TruyVanThongBaoThue(xmlContent);
                        break;
                    case "TCT_TVNVTC":
                    case "16":
                        resXMLContent = GetXML_TruyVanNghiaVuTaiChinh(xmlContent);
                        break;
                    case "TCT_TVHSSC":
                    case "17":
                        resXMLContent = GetXML_TruyVanHoSo(xmlContent);
                        break;
                }
                return new Response
                {
                    ResultCode = CMCLIS.GATEWAY.SETTING.Constant.RETURN_CODE_SUCCESS,
                    Message = CMCLIS.GATEWAY.SETTING.Constant.MESSAGE_SUCCESS,
                    ReturnValue = resXMLContent
                };
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new Response
                {
                    ResultCode = CMCLIS.GATEWAY.SETTING.Constant.RETURN_CODE_ERROR,
                    Message = CMCLIS.GATEWAY.SETTING.Constant.MESSAGE_ERROR,
                    ReturnValue = ex.Message
                };
            }
        }

        /// <summary>
        /// Giả lập cho phiếu điều chuyển
        /// </summary>
        /// <param name="xmlContent"></param>
        /// <returns></returns>
        /// created by: ntkien 17.02.2020
        private static string GetXML_PhieuChuyen(string xmlContent)
        {
            string MSG_TYPE = string.Empty;
            string SEQ_ID = string.Empty;
            string SEQ_REFID = string.Empty;
            string MA_HS = string.Empty;
            string MA_GCN = string.Empty;
            string SO_PHIEU = string.Empty;
            string NGAYCHUYEN = string.Empty;
            string NGUOICHUYEN = string.Empty;
            string LOAI_DENGHI = string.Empty;
            string LOAI_HOSO = string.Empty;
            string DK_GHINO_NVTC = string.Empty;
            string TT_SOHUU = string.Empty;

            XmlDocument xmlDocumentSign = new XmlDocument();
            xmlDocumentSign.LoadXml(xmlContent);
            string namespaceURISign = xmlDocumentSign.DocumentElement.NamespaceURI;
            if (!string.IsNullOrEmpty(namespaceURISign))
            {
                XmlNamespaceManager nsmgrSign = new XmlNamespaceManager(xmlDocumentSign.NameTable);
                nsmgrSign.AddNamespace("NamespaceCode", namespaceURISign);
                MSG_TYPE = xmlDocumentSign.SelectNodes("//NamespaceCode:MSG_TYPE", nsmgrSign)[0].InnerXml;
                SEQ_ID = xmlDocumentSign.SelectNodes("//NamespaceCode:SEQ_ID", nsmgrSign)[0].InnerXml;
                SEQ_REFID = xmlDocumentSign.SelectNodes("//NamespaceCode:SEQ_REFID", nsmgrSign)[0].InnerXml;

                MA_HS = xmlDocumentSign.SelectNodes("//NamespaceCode:MA_HS", nsmgrSign)[0].InnerXml;
                MA_GCN = xmlDocumentSign.SelectNodes("//NamespaceCode:MA_GCN", nsmgrSign)[0].InnerXml;
                SO_PHIEU = xmlDocumentSign.SelectNodes("//NamespaceCode:SO_PHIEU", nsmgrSign)[0].InnerXml;
                NGAYCHUYEN = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                NGUOICHUYEN = "Tổng cụ Thuế";
                LOAI_DENGHI = xmlDocumentSign.SelectNodes("//NamespaceCode:LOAI_DENGHI", nsmgrSign)[0].InnerXml;
                LOAI_HOSO = xmlDocumentSign.SelectNodes("//NamespaceCode:LOAI_HOSO", nsmgrSign)[0].InnerXml;
                DK_GHINO_NVTC = xmlDocumentSign.SelectNodes("//NamespaceCode:DK_GHINO_NVTC", nsmgrSign)[0].InnerXml;
                TT_SOHUU = xmlDocumentSign.SelectNodes("//NamespaceCode:TT_SOHUU", nsmgrSign)[0].InnerXml;
            }
            //Service gui len Thue

            // Giả lập message Thue tra ve

            XmlDocument xmlDocumentResponse = new XmlDocument();
            xmlDocumentResponse.LoadXml(Utility.LoadFile(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\TEMPLATE\GuiPhieuChuyen_Response.xml"));
            string namespaceURIResponse = xmlDocumentResponse.DocumentElement.NamespaceURI;
            if (!string.IsNullOrEmpty(namespaceURIResponse))
            {
                XmlNamespaceManager nsmgrResponse = new XmlNamespaceManager(xmlDocumentResponse.NameTable);
                nsmgrResponse.AddNamespace("NamespaceCode", namespaceURIResponse);
                xmlDocumentResponse.SelectNodes("//NamespaceCode:MSG_TYPE", nsmgrResponse)[0].InnerXml = MSG_TYPE;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:SEQ_ID", nsmgrResponse)[0].InnerXml = SEQ_ID;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:SEQ_REFID", nsmgrResponse)[0].InnerXml = SEQ_REFID;

                xmlDocumentResponse.SelectNodes("//NamespaceCode:MA_HS", nsmgrResponse)[0].InnerXml = MA_HS;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:MA_GCN", nsmgrResponse)[0].InnerXml = MA_GCN;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:SO_PHIEU", nsmgrResponse)[0].InnerXml = SO_PHIEU;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:NGAYCHUYEN", nsmgrResponse)[0].InnerXml = NGAYCHUYEN;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:NGUOICHUYEN", nsmgrResponse)[0].InnerXml = NGUOICHUYEN;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:LOAI_DENGHI", nsmgrResponse)[0].InnerXml = LOAI_DENGHI;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:LOAI_HOSO", nsmgrResponse)[0].InnerXml = LOAI_HOSO;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:DK_GHINO_NVTC", nsmgrResponse)[0].InnerXml = DK_GHINO_NVTC;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TT_SOHUU", nsmgrResponse)[0].InnerXml = TT_SOHUU;
                //random kết quả trả về
                string result = GetRandomValue(0, 5);
                if (!string.IsNullOrWhiteSpace(Config.ALLOW_MOCK_UP_SUCCESS))
                {
                    result = "0";
                }
                CVAN_DM_STATUSInfo objStatus = CommonFunction.CVAN_DM_STATUSInfos.FirstOrDefault(x => x.CVAN_PARENT.EqualsValue(Constant_Error_PhieuChuyen) && x.CVAN_CODE.EqualsValue(result));
                if (objStatus != null)
                {
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:ERROR_CODE", nsmgrResponse)[0].InnerXml = objStatus.CVAN_CODE;
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:ERROR_DESC", nsmgrResponse)[0].InnerXml = objStatus.CVAN_NAME;
                }
                else
                {
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:ERROR_CODE", nsmgrResponse)[0].InnerXml = "";
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:ERROR_DESC", nsmgrResponse)[0].InnerXml = "Lỗi không nằm trong danh mục";
                }
            }
            // end Giả lập message Thue tra ve
            return xmlDocumentResponse != null ? xmlDocumentResponse.OuterXml : string.Empty;
        }

        /// <summary>
        /// giả lập cho truy vấn hồ sơ
        /// </summary>
        /// <param name="xmlContent"></param>
        /// <returns></returns>
        /// created by: ntkien 17.02.2020
        private static string GetXML_TruyVanHoSo(string xmlContent)
        {
            string MSG_TYPE = string.Empty;
            string MA_HS = string.Empty;
            string MA_GCN = string.Empty;
            string SO_PHIEU = string.Empty;

            XmlDocument xmlDocumentSign = new XmlDocument();
            xmlDocumentSign.LoadXml(xmlContent);
            string namespaceURISign = xmlDocumentSign.DocumentElement.NamespaceURI;
            if (!string.IsNullOrEmpty(namespaceURISign))
            {
                XmlNamespaceManager nsmgrSign = new XmlNamespaceManager(xmlDocumentSign.NameTable);
                nsmgrSign.AddNamespace("NamespaceCode", namespaceURISign);
                MSG_TYPE = xmlDocumentSign.SelectNodes("//NamespaceCode:MSG_TYPE", nsmgrSign)[0].InnerXml;
                MA_HS = xmlDocumentSign.SelectNodes("//NamespaceCode:MA_HS", nsmgrSign)[0].InnerXml;
                MA_GCN = xmlDocumentSign.SelectNodes("//NamespaceCode:MA_GCN", nsmgrSign)[0].InnerXml;
                SO_PHIEU = xmlDocumentSign.SelectNodes("//NamespaceCode:SO_PHIEU", nsmgrSign)[0].InnerXml;
            }

            XmlDocument xmlDocumentResponse = new XmlDocument();
            xmlDocumentResponse.LoadXml(Utility.LoadFile(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\TEMPLATE\TruyVanHoSoScan_Response.xml"));
            string namespaceURIResponse = xmlDocumentResponse.DocumentElement.NamespaceURI;
            if (!string.IsNullOrEmpty(namespaceURIResponse))
            {
                XmlNamespaceManager nsmgrResponse = new XmlNamespaceManager(xmlDocumentResponse.NameTable);
                nsmgrResponse.AddNamespace("NamespaceCode", namespaceURIResponse);
                xmlDocumentResponse.SelectNodes("//NamespaceCode:MSG_TYPE", nsmgrResponse)[0].InnerXml = MSG_TYPE;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:MA_HS", nsmgrResponse)[0].InnerXml = MA_HS;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:MA_GCN", nsmgrResponse)[0].InnerXml = MA_GCN;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:SO_PHIEU", nsmgrResponse)[0].InnerXml = SO_PHIEU;

                //random kết quả trả về lỗi
                string result = GetRandomValue(0, 5);
                if (!string.IsNullOrWhiteSpace(Config.ALLOW_MOCK_UP_SUCCESS))
                {
                    result = "0";
                }
                CVAN_DM_STATUSInfo objStatus = CommonFunction.CVAN_DM_STATUSInfos.FirstOrDefault(x => x.CVAN_PARENT.EqualsValue(Constant_Error_TruyVanHoSo) && x.CVAN_CODE.EqualsValue(result));
                if (objStatus != null)
                {
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:ERROR_CODE", nsmgrResponse)[0].InnerXml = objStatus.CVAN_CODE;
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:ERROR_DESC", nsmgrResponse)[0].InnerXml = objStatus.CVAN_NAME;
                }
                else
                {
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:ERROR_CODE", nsmgrResponse)[0].InnerXml = "";
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:ERROR_DESC", nsmgrResponse)[0].InnerXml = "Lỗi không nằm trong danh mục";
                }
            }
            // end Giả lập message Thue tra ve
            return xmlDocumentResponse != null ? xmlDocumentResponse.OuterXml : string.Empty;
        }

        /// <summary>
        /// Giả lập cho truy vấn nghĩa vụ tài chính
        /// </summary>
        /// <param name="xmlContent"></param>
        /// <returns></returns>
        /// created by: ntkien 17.02.2020
        private static string GetXML_TruyVanNghiaVuTaiChinh(string xmlContent)
        {
            string MSG_TYPE = string.Empty;

            string MA_HS = string.Empty;
            string MA_GCN = string.Empty;
            string SO_PHIEU = string.Empty;


            XmlDocument xmlDocumentSign = new XmlDocument();
            xmlDocumentSign.LoadXml(xmlContent);
            string namespaceURISign = xmlDocumentSign.DocumentElement.NamespaceURI;
            if (!string.IsNullOrEmpty(namespaceURISign))
            {
                XmlNamespaceManager nsmgrSign = new XmlNamespaceManager(xmlDocumentSign.NameTable);
                nsmgrSign.AddNamespace("NamespaceCode", namespaceURISign);
                MSG_TYPE = xmlDocumentSign.SelectNodes("//NamespaceCode:MSG_TYPE", nsmgrSign)[0].InnerXml;
                MA_HS = xmlDocumentSign.SelectNodes("//NamespaceCode:MA_HS", nsmgrSign)[0].InnerXml;
                MA_GCN = xmlDocumentSign.SelectNodes("//NamespaceCode:MA_GCN", nsmgrSign)[0].InnerXml;
                SO_PHIEU = xmlDocumentSign.SelectNodes("//NamespaceCode:SO_PHIEU", nsmgrSign)[0].InnerXml;
            }
            //Service gui len Thue

            // Giả lập message Thue tra ve

            XmlDocument xmlDocumentResponse = new XmlDocument();
            xmlDocumentResponse.LoadXml(Utility.LoadFile(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\TEMPLATE\TruyVanNghiaVuTaiChinh_Response.xml"));
            string namespaceURIResponse = xmlDocumentResponse.DocumentElement.NamespaceURI;
            if (!string.IsNullOrEmpty(namespaceURIResponse))
            {
                XmlNamespaceManager nsmgrResponse = new XmlNamespaceManager(xmlDocumentResponse.NameTable);
                nsmgrResponse.AddNamespace("NamespaceCode", namespaceURIResponse);
                xmlDocumentResponse.SelectNodes("//NamespaceCode:MSG_TYPE", nsmgrResponse)[0].InnerXml = MSG_TYPE;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:MA_HS", nsmgrResponse)[0].InnerXml = MA_HS;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:MA_GCN", nsmgrResponse)[0].InnerXml = MA_GCN;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:SO_PHIEU", nsmgrResponse)[0].InnerXml = SO_PHIEU;

                //random kết quả trả về lỗi
                string result = GetRandomValue(0, 5);
                if (!string.IsNullOrWhiteSpace(Config.ALLOW_MOCK_UP_SUCCESS))
                {
                    result = "0";
                }
                CVAN_DM_STATUSInfo objStatus = CommonFunction.CVAN_DM_STATUSInfos.FirstOrDefault(x => x.CVAN_PARENT.EqualsValue(Constant_Error_TruyVanNVTC) && x.CVAN_CODE.EqualsValue(result));
                if (objStatus != null)
                {
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:ERROR_CODE", nsmgrResponse)[0].InnerXml = objStatus.CVAN_CODE;
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:ERROR_DESC", nsmgrResponse)[0].InnerXml = objStatus.CVAN_NAME;
                }
                else
                {
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:ERROR_CODE", nsmgrResponse)[0].InnerXml = "";
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:ERROR_DESC", nsmgrResponse)[0].InnerXml = "Lỗi không nằm trong danh mục";
                }
            }
            // end Giả lập message Thue tra ve
            return xmlDocumentResponse != null ? xmlDocumentResponse.OuterXml : string.Empty;
        }

        /// <summary>
        /// Giả lập cho truy vấn thông báo thuế
        /// </summary>
        /// <param name="xmlContent"></param>
        /// <returns></returns>
        /// created by: ntkien 17.02.2020
        private static string GetXML_TruyVanThongBaoThue(string xmlContent)
        {
            string MSG_TYPE = string.Empty;
            string MA_HS = string.Empty;
            string MA_GCN = string.Empty;
            string SO_PHIEU = string.Empty;

            XmlDocument xmlDocumentSign = new XmlDocument();
            xmlDocumentSign.LoadXml(xmlContent);
            string namespaceURISign = xmlDocumentSign.DocumentElement.NamespaceURI;
            if (!string.IsNullOrEmpty(namespaceURISign))
            {
                XmlNamespaceManager nsmgrSign = new XmlNamespaceManager(xmlDocumentSign.NameTable);
                nsmgrSign.AddNamespace("NamespaceCode", namespaceURISign);
                MSG_TYPE = xmlDocumentSign.SelectNodes("//NamespaceCode:MSG_TYPE", nsmgrSign)[0].InnerXml;
                MA_HS = xmlDocumentSign.SelectNodes("//NamespaceCode:MA_HS", nsmgrSign)[0].InnerXml;
                MA_GCN = xmlDocumentSign.SelectNodes("//NamespaceCode:MA_GCN", nsmgrSign)[0].InnerXml;
                SO_PHIEU = xmlDocumentSign.SelectNodes("//NamespaceCode:SO_PHIEU", nsmgrSign)[0].InnerXml;
            }
            //Service gui len Thue

            // Giả lập message Thue tra ve

            XmlDocument xmlDocumentResponse = new XmlDocument();
            xmlDocumentResponse.LoadXml(Utility.LoadFile(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\TEMPLATE\TruyVanThongBaoThue_Response.xml"));
            string namespaceURIResponse = xmlDocumentResponse.DocumentElement.NamespaceURI;
            if (!string.IsNullOrEmpty(namespaceURIResponse))
            {
                XmlNamespaceManager nsmgrResponse = new XmlNamespaceManager(xmlDocumentResponse.NameTable);
                nsmgrResponse.AddNamespace("NamespaceCode", namespaceURIResponse);
                xmlDocumentResponse.SelectNodes("//NamespaceCode:MSG_TYPE", nsmgrResponse)[0].InnerXml = MSG_TYPE;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:MA_HS", nsmgrResponse)[0].InnerXml = MA_HS;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:MA_GCN", nsmgrResponse)[0].InnerXml = MA_GCN;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:SO_PHIEU", nsmgrResponse)[0].InnerXml = SO_PHIEU;

                //random kết quả trả về lỗi
                string result = GetRandomValue(0, 5);
                if (!string.IsNullOrWhiteSpace(Config.ALLOW_MOCK_UP_SUCCESS))
                {
                    result = "0";
                }
                CVAN_DM_STATUSInfo objStatus = CommonFunction.CVAN_DM_STATUSInfos.FirstOrDefault(x => x.CVAN_PARENT.EqualsValue(Constant_Error_TruyVanTBT) && x.CVAN_CODE.EqualsValue(result));
                if (objStatus != null)
                {
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:ERROR_CODE", nsmgrResponse)[0].InnerXml = objStatus.CVAN_CODE;
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:ERROR_DESC", nsmgrResponse)[0].InnerXml = objStatus.CVAN_NAME;
                }
                else
                {
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:ERROR_CODE", nsmgrResponse)[0].InnerXml = "";
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:ERROR_DESC", nsmgrResponse)[0].InnerXml = "Lỗi không nằm trong danh mục";
                }
            }
            // end Giả lập message Thue tra ve
            return xmlDocumentResponse != null ? xmlDocumentResponse.OuterXml : string.Empty;
        }

        /// <summary>
        /// lấy mặc định một giá trị
        /// </summary>
        /// <returns></returns>
        private static string GetRandomValue(int minValue, int maxValue)
        {
            Random rd = new Random();
            return rd.Next(minValue, maxValue).ToString();
        }

    }
}
