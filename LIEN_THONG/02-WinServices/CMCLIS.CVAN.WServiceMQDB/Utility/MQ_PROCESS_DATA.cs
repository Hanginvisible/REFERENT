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
using CMCLIS.CVAN.DATA.OBJECTS;

namespace CMCLIS.CVAN.WServiceMQD
{
    public class MQ_PROCESS_DATA
    {
        public static object MSGO_INSERT_MSG_XML(string xmlMessage, byte[] file, string sender)
        {            
            object result = -1;
            try
            {               
                #region save file
                Console.WriteLine(" [->] {Save file...}");
                
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlMessage);
                string namespaceURIMSG = xmlDoc.DocumentElement.NamespaceURI;
                string MESSAGE_CODE = "";
                string SENDER_CODE = "";
                string SENDER_NAME = "";
                string MESSAGE_TYPE = "";
                string xmlHOSOTHUEDTU = "";
                if (!string.IsNullOrEmpty(namespaceURIMSG))
                {
                    XmlNamespaceManager nsmgrMSG = new XmlNamespaceManager(xmlDoc.NameTable);
                    nsmgrMSG.AddNamespace("NamespaceCode", namespaceURIMSG);
                    MESSAGE_CODE = Utility.GetNodeValue(xmlDoc,"MESSAGE_CODE");
                    if (string.IsNullOrWhiteSpace(MESSAGE_CODE))
                    {
                        MESSAGE_CODE= Utility.GetNodeValue(xmlDoc, "REQUEST_ID");
                    }
                    SENDER_CODE = Utility.GetNodeValue(xmlDoc, "SENDER_CODE");//.SelectNodes("//NamespaceCode:", nsmgrMSG)[0].InnerXml;
                    SENDER_NAME = Utility.GetNodeValue(xmlDoc, "SENDER_NAME");// xmlDoc.SelectNodes("//NamespaceCode:SENDER_NAME", nsmgrMSG)[0].InnerXml;
                    MESSAGE_TYPE = Utility.GetNodeValue(xmlDoc, "MESSAGE_TYPE"); //xmlDoc.SelectNodes("//NamespaceCode:MESSAGE_TYPE", nsmgrMSG)[0].InnerXml;
                    if (string.IsNullOrWhiteSpace(MESSAGE_TYPE))
                    {
                        MESSAGE_TYPE = Utility.GetNodeValue(xmlDoc, "MSG_TYPE");
                    }
                    xmlHOSOTHUEDTU = xmlMessage;
                }
                else
                {
                     MESSAGE_CODE = xmlDoc.SelectNodes("/DATA/HEADER/MESSAGE_CODE")[0].InnerText;
                     SENDER_CODE = xmlDoc.SelectNodes("/DATA/HEADER/SENDER_CODE")[0].InnerText;
                     SENDER_NAME = xmlDoc.SelectNodes("/DATA/HEADER/SENDER_NAME")[0].InnerText;
                     MESSAGE_TYPE = xmlDoc.SelectNodes("/DATA/HEADER/MESSAGE_TYPE")[0].InnerText;
                     xmlHOSOTHUEDTU = xmlDoc.SelectNodes("/DATA/BODY/HOSO_THUE")[0].InnerXml;
                }

                if (!Directory.Exists(CMCLIS.CVAN.SETTING.Config.PATH_DATA_SAVE_FILE + @"\TIEP_NHAN\" + sender))
                {
                    Directory.CreateDirectory(CMCLIS.CVAN.SETTING.Config.PATH_DATA_SAVE_FILE + @"\TIEP_NHAN\" + sender);
                }
                    
                File.WriteAllText(CMCLIS.CVAN.SETTING.Config.PATH_DATA_SAVE_FILE + @"\TIEP_NHAN\" + sender + @"\" + MESSAGE_CODE + ".xml", xmlMessage, Encoding.UTF8);
                Console.WriteLine(" [->] {Save file complete...}");
                #endregion
                #region Signature
                Console.WriteLine(" [->] {Loading X509Certificate2...}");
                System.Security.Cryptography.X509Certificates.X509Certificate2 cert = Certificate.GetStoreX509Certificate2BySerial(CMCLIS.CVAN.SETTING.Config.CA_TOKENT_SERIAL);
                if (cert != null)
                {
                    Console.WriteLine(" [->] {Loading X509Certificate2 complete...}");
                    if (File.Exists(CMCLIS.CVAN.SETTING.Config.PATH_DATA_SAVE_FILE + @"\TIEP_NHAN\" + CMCLIS.CVAN.SETTING.Config.MQ_NAME + @"\" + MESSAGE_CODE + ".xml"))
                    {
                        XmlDocument xmlDocumentHOSOTHUEDTU = new XmlDocument();
                        xmlDocumentHOSOTHUEDTU.LoadXml(xmlHOSOTHUEDTU);
                        string namespaceURI = xmlDocumentHOSOTHUEDTU.DocumentElement.NamespaceURI;
                        Console.WriteLine(" [->] {Sign Xml...}");
                        XmlDocument resultXmlHOSOTHUEDTU = CreateDigitalSignature.SignSignatureXml(xmlDocumentHOSOTHUEDTU, cert, "//NamespaceCode:SIGNATURE", true);
                        if (resultXmlHOSOTHUEDTU != null)
                        {
                            if (!Directory.Exists(CMCLIS.CVAN.SETTING.Config.PATH_DATA_SAVE_FILE + @"\DATA_SIGNATURE"))
                                Directory.CreateDirectory(CMCLIS.CVAN.SETTING.Config.PATH_DATA_SAVE_FILE + @"\DATA_SIGNATURE");
                            if (!Directory.Exists(CMCLIS.CVAN.SETTING.Config.PATH_DATA_SAVE_FILE + @"\DATA_SIGNATURE" + @"\" + DateTime.Now.ToString("yyyy-MM-dd")))
                                Directory.CreateDirectory(CMCLIS.CVAN.SETTING.Config.PATH_DATA_SAVE_FILE + @"\DATA_SIGNATURE" + @"\" + DateTime.Now.ToString("yyyy-MM-dd"));
                            string pathSaveFile = CMCLIS.CVAN.SETTING.Config.PATH_DATA_SAVE_FILE + @"\DATA_SIGNATURE" + @"\" + DateTime.Now.ToString("yyyy-MM-dd") + @"\" + MESSAGE_CODE + ".xml";
                            using (XmlTextWriter xmlTextWriter = new XmlTextWriter(pathSaveFile, new UTF8Encoding(false)))
                            {
                                resultXmlHOSOTHUEDTU.WriteTo(xmlTextWriter);
                                xmlTextWriter.Close();
                            }
                            Console.WriteLine(" [->] {Sign Xml complete...}");
                            CVAN_DM_MSG_TYPEInfo typeInfo = null;
                            int totalCount = 0;
                            List<CVAN_DM_MSG_TYPEInfo> typeInfos = DataObjectFactory.GetInstanceCVAN_DM_MSG_TYPE().CVAN_DM_MSG_TYPE_GetAllWithPadding(MESSAGE_TYPE, "", -1, 1, 1, ref totalCount);
                            if (typeInfos!=null)
                            {
                                typeInfo = typeInfos.FirstOrDefault();
                            }
                            CVAN_MSGOInfo cVAN_MSGOInfo = new CVAN_MSGOInfo
                            {
                                CVAN_CODE = MESSAGE_CODE,
                                CUSER = SENDER_CODE,
                                CVAN_CONTENT_XML = @"\DATA_SIGNATURE" + @"\" + DateTime.Now.ToString("yyyy-MM-dd") + @"\" + MESSAGE_CODE + ".xml",
                                CVAN_MSG_TYPE_CODE = MESSAGE_TYPE,
                                CVAN_MSG_TYPE_NAME = (typeInfo !=null &&!string.IsNullOrWhiteSpace(typeInfo.CVAN_NAME) ? typeInfo.CVAN_NAME:"Hồ sơ"),
                                CVAN_SENDER_CODE = SENDER_CODE,
                                CVAN_STATUS_SEND= 0
                            };
                            result = DataObjectFactory.GetInstanceCVAN_MSGO().Add(cVAN_MSGOInfo);
                            if (result == null || result.ToString() == "-1")
                                Console.WriteLine(" [->] {INSERT_MSGXML_2_MSGOUT ERROR...}");
                            else
                            {
                                Console.WriteLine(" [->] {INSERT_MSGXML_2_MSGOUT complete...}");
                                Console.WriteLine(" [->] Sender {" + SENDER_CODE + "}");
                                Console.WriteLine(" [->] Message {" + MESSAGE_TYPE + "}");
                                Console.WriteLine(" [->] Message code {" + MESSAGE_CODE + "}");
                            }
                        }
                        
                    }

                }
                else
                {
                    Console.WriteLine(" [->] {Loading X509Certificate2 error...}");
                }

                return result;
                #endregion

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
