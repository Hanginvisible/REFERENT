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

namespace CMCLIS.GATEWAY.WServiceReponse
{
    public class REQUEST_PROCESS_DATA
    {

        private const string Constant_KetQua_TruyVanHoSo = "MA_KETQUA_40";
        private const string Constant_KetQua_TruyVanTBT = "MA_KETQUA_11";
        private const string Constant_KetQua_TruyVanNVTC = "MA_KETQUA_29";

        private const string Constant_Error_TruyVanHoSo = "ERROR_CODE_40";
        private const string Constant_Error_TruyVanTBT = "ERROR_CODE_11";
        private const string Constant_Error_TruyVanNVTC = "ERROR_CODE_29";

        public static Response SenderToThue(string xmlContent, string msgTypeCode)
        {
            try
            {
                string resXMLContent = string.Empty;
                switch (msgTypeCode)
                {
                    //case "1TCT_GPC":
                    //case "10":
                    //case "11":
                    //    resXMLContent = GetXML_PhieuChuyen(xmlContent);
                    //break;
                    case "TCT_TVTBT"://truy vấn thông báo thuế
                    case "14":
                    case "15":
                        resXMLContent = GetXML_TruyVanThongBaoThue(xmlContent);
                        break;
                    case "TCT_TVNVTC"://truy vấn nghĩa vụ tài chính
                    case "16":
                        resXMLContent = GetXML_TruyVanNghiaVuTaiChinh(xmlContent);
                        break;
                    case "TCT_TVHSSC"://truy vấn hồ sơ
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

                //random kết quả trả về 
                string resultSuccess = GetRandomValue(0, 6);
                CVAN_DM_STATUSInfo objStatusSuccess = Config.CVAN_DM_STATUSInfos.FirstOrDefault(x => x.CVAN_PARENT.EqualsValue(Constant_KetQua_TruyVanHoSo) && x.CVAN_CODE.EqualsValue(resultSuccess));
                if (objStatusSuccess != null)
                {
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:MA_KETQUA", nsmgrResponse)[0].InnerXml = objStatusSuccess.CVAN_CODE;
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:DIEN_GIAI", nsmgrResponse)[0].InnerXml = objStatusSuccess.CVAN_NAME;
                }
                else
                {
                    string result = GetRandomValue(0, 5);
                    CVAN_DM_STATUSInfo objStatus = Config.CVAN_DM_STATUSInfos.FirstOrDefault(x => x.CVAN_PARENT.EqualsValue(Constant_Error_TruyVanHoSo) && x.CVAN_CODE.EqualsValue(result));
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

                //random kết quả trả về
                string resultSuccess = GetRandomValue(0, 3);
                CVAN_DM_STATUSInfo objStatusSuccess = Config.CVAN_DM_STATUSInfos.FirstOrDefault(x => x.CVAN_PARENT.EqualsValue(Constant_KetQua_TruyVanNVTC) && x.CVAN_CODE.EqualsValue(resultSuccess));
                if (objStatusSuccess != null)
                {
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:MA_KETQUA", nsmgrResponse)[0].InnerXml = objStatusSuccess.CVAN_CODE;
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:DIEN_GIAI", nsmgrResponse)[0].InnerXml = objStatusSuccess.CVAN_NAME;
                }
                else
                {
                    string result = GetRandomValue(0, 5);
                    CVAN_DM_STATUSInfo objStatus = Config.CVAN_DM_STATUSInfos.FirstOrDefault(x => x.CVAN_PARENT.EqualsValue(Constant_Error_TruyVanNVTC) && x.CVAN_CODE.EqualsValue(result));
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
                xmlDocumentResponse.SelectNodes("//NamespaceCode:MA_HS", nsmgrResponse)[1].InnerXml = MA_HS;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:MA_GCN", nsmgrResponse)[1].InnerXml = MA_GCN;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:SO_PHIEU", nsmgrResponse)[1].InnerXml = SO_PHIEU;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:MA_CQT", nsmgrResponse)[0].InnerXml = "CTQ001"; 
                xmlDocumentResponse.SelectNodes("//NamespaceCode:NGAY_TRA", nsmgrResponse)[0].InnerXml = "2020-02-17";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:NGUOI_TRA", nsmgrResponse)[0].InnerXml = "Nguyễn Văn A";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TONG_PHAI_NOP", nsmgrResponse)[0].InnerXml = "2000000";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TONG_MIEN_GIAM", nsmgrResponse)[0].InnerXml = "100000";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TONG_DA_NOP", nsmgrResponse)[0].InnerXml = "1500000";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TONG_CON_PNOP", nsmgrResponse)[0].InnerXml = "300000";
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

                //random kết quả trả về 
                string resultSuccess = GetRandomValue(0, 10);
                CVAN_DM_STATUSInfo objStatusSuccess = Config.CVAN_DM_STATUSInfos.FirstOrDefault(x => x.CVAN_PARENT.EqualsValue(Constant_KetQua_TruyVanTBT) && x.CVAN_CODE.EqualsValue(resultSuccess));
                if (objStatusSuccess != null)
                {
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:MA_KETQUA", nsmgrResponse)[0].InnerXml = objStatusSuccess.CVAN_CODE;
                    xmlDocumentResponse.SelectNodes("//NamespaceCode:DIEN_GIAI", nsmgrResponse)[0].InnerXml = objStatusSuccess.CVAN_NAME;
                }
                else
                {
                    string result = GetRandomValue(0, 5);
                    CVAN_DM_STATUSInfo objStatus = Config.CVAN_DM_STATUSInfos.FirstOrDefault(x => x.CVAN_PARENT.EqualsValue(Constant_Error_TruyVanTBT) && x.CVAN_CODE.EqualsValue(result));
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
                xmlDocumentResponse.SelectNodes("//NamespaceCode:MA_HS", nsmgrResponse)[1].InnerXml = MA_HS;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:MA_GCN", nsmgrResponse)[1].InnerXml = MA_GCN;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:SO_PHIEU", nsmgrResponse)[1].InnerXml = SO_PHIEU;
                xmlDocumentResponse.SelectNodes("//NamespaceCode:MA_CQT", nsmgrResponse)[0].InnerXml = "CTQ001";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:NGAYTRA", nsmgrResponse)[0].InnerXml = "2020-02-17";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:NGUOITRA", nsmgrResponse)[0].InnerXml = "Nguyễn Văn A";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TONG_PHAI_NOP", nsmgrResponse)[0].InnerXml = "2000000";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TONG_MIEN_GIAM", nsmgrResponse)[0].InnerXml = "100000";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TONG_DA_NOP", nsmgrResponse)[0].InnerXml = "1500000";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TONG_CON_PNOP", nsmgrResponse)[0].InnerXml = "300000";

                //NNT
                xmlDocumentResponse.SelectNodes("//NamespaceCode:NNT_TEN", nsmgrResponse)[0].InnerXml = "Nguyễn Thị Lê";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:NNT_MST", nsmgrResponse)[0].InnerXml = "0101243556";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:NNT_CMT", nsmgrResponse)[0].InnerXml = "151745785";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:NNT_DIA_CHI", nsmgrResponse)[0].InnerXml = "Hà Nội";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:CREATE_DATE", nsmgrResponse)[0].InnerXml = "2020-02-17";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TONG_PHAI_NOP", nsmgrResponse)[0].InnerXml = "200000";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TONG_MIEN_GIAM", nsmgrResponse)[0].InnerXml = "0";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TONG_DA_NOP", nsmgrResponse)[0].InnerXml = "200000";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TONG_CON_PNOP", nsmgrResponse)[0].InnerXml = "0";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:LPTB_SO_THONG_BAO", nsmgrResponse)[0].InnerXml = "00010";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:LPTB_NGAY_THONG_BAO", nsmgrResponse)[0].InnerXml = "2020-02-17";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:LPTB_HAN_NOP", nsmgrResponse)[0].InnerXml = "2020-02-28";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:LPTB_SO_QDMG", nsmgrResponse)[0].InnerXml = "";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:LPTB_NGAY_QD", nsmgrResponse)[0].InnerXml = "2020-02-11";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:LPTB_PHAI_NOP", nsmgrResponse)[0].InnerXml = "300000";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:LPTB_MIEN_GIAM", nsmgrResponse)[0].InnerXml = "0";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:LPTB_DA_NOP", nsmgrResponse)[0].InnerXml = "300000";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:LPTB_CON_PNOP", nsmgrResponse)[0].InnerXml = "0";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:LPTB_DULIEU", nsmgrResponse)[0].InnerXml = "";

                xmlDocumentResponse.SelectNodes("//NamespaceCode:TSDD_SO_THONG_BAO", nsmgrResponse)[0].InnerXml = "00010";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TSDD_NGAY_THONG_BAO", nsmgrResponse)[0].InnerXml = "2020-02-17";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TSDD_HAN_NOP", nsmgrResponse)[0].InnerXml = "2020-02-28";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TSDD_SO_QDMG", nsmgrResponse)[0].InnerXml = "";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TSDD_NGAY_QD", nsmgrResponse)[0].InnerXml = "2020-02-11";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TSDD_PHAI_NOP", nsmgrResponse)[0].InnerXml = "300000";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TSDD_MIEN_GIAM", nsmgrResponse)[0].InnerXml = "0";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TSDD_DA_NOP", nsmgrResponse)[0].InnerXml = "300000";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TSDD_CON_PNOP", nsmgrResponse)[0].InnerXml = "0";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TSDD_DULIEU", nsmgrResponse)[0].InnerXml = "";

                xmlDocumentResponse.SelectNodes("//NamespaceCode:TNCN_SO_THONG_BAO", nsmgrResponse)[0].InnerXml = "00010";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TNCN_NGAY_THONG_BAO", nsmgrResponse)[0].InnerXml = "2020-02-17";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TNCN_HAN_NOP", nsmgrResponse)[0].InnerXml = "2020-02-28";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TNCN_SO_QDMG", nsmgrResponse)[0].InnerXml = "";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TNCN_NGAY_QD", nsmgrResponse)[0].InnerXml = "2020-02-11";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TNCN_PHAI_NOP", nsmgrResponse)[0].InnerXml = "300000";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TNCN_MIEN_GIAM", nsmgrResponse)[0].InnerXml = "0";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TNCN_DA_NOP", nsmgrResponse)[0].InnerXml = "300000";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TNCN_CON_PNOP", nsmgrResponse)[0].InnerXml = "0";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TNCN_DULIEU", nsmgrResponse)[0].InnerXml = "";

                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMD_SO_THONG_BAO", nsmgrResponse)[0].InnerXml = "00010";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMD_NGAY_THONG_BAO", nsmgrResponse)[0].InnerXml = "2020-02-17";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMD_HAN_NOP", nsmgrResponse)[0].InnerXml = "2020-02-28";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMD_SO_QDMG", nsmgrResponse)[0].InnerXml = "";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMD_NGAY_QD", nsmgrResponse)[0].InnerXml = "2020-02-11";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMD_PHAI_NOP", nsmgrResponse)[0].InnerXml = "300000";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMD_MIEN_GIAM", nsmgrResponse)[0].InnerXml = "0";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMD_DA_NOP", nsmgrResponse)[0].InnerXml = "300000";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMD_CON_PNOP", nsmgrResponse)[0].InnerXml = "0";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMD_DULIEU", nsmgrResponse)[0].InnerXml = "";

                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMN_SO_THONG_BAO", nsmgrResponse)[0].InnerXml = "00010";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMN_NGAY_THONG_BAO", nsmgrResponse)[0].InnerXml = "2020-02-17";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMN_HAN_NOP", nsmgrResponse)[0].InnerXml = "2020-02-28";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMN_SO_QDMG", nsmgrResponse)[0].InnerXml = "";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMN_NGAY_QD", nsmgrResponse)[0].InnerXml = "2020-02-11";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMN_PHAI_NOP", nsmgrResponse)[0].InnerXml = "300000";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMN_MIEN_GIAM", nsmgrResponse)[0].InnerXml = "0";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMN_DA_NOP", nsmgrResponse)[0].InnerXml = "300000";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMN_CON_PNOP", nsmgrResponse)[0].InnerXml = "0";
                xmlDocumentResponse.SelectNodes("//NamespaceCode:TMN_DULIEU", nsmgrResponse)[0].InnerXml = "";

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
