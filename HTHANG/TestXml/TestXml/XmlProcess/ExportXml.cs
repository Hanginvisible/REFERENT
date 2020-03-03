using System;
using System.Xml;
using System.Data;
using System.IO;

namespace TestXml.XmlProcess
{
    public class ExportXml
    {
        public static int GetMaGiaoDich(string[] listXml)
        {
            return 1;
        }


        public static string ExportXML(string connectString, string maGD, DataTable dataTable)
        {
            try
            {
                DataTable dt = CreateDataTable();
                string fileName = "E:\\CMCLIS\\XML\\GuiPhieuChuyen_Request.xml";
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);
                XmlNodeList itemNodes = xmlDoc.SelectNodes("//BODY/ROW/SYSTEM_INFO");
                foreach (XmlNode itemNode in itemNodes)
                {
                    string msgType = itemNode.SelectSingleNode("MSG_TYPE").InnerText;
                    if (msgType != null) return msgType;
                    //Console.WriteLine(msgType.InnerText);
                    string seqID = itemNode.SelectSingleNode("SEQ_ID").InnerText;
                    if (seqID != null) return seqID;

                    //Console.WriteLine(seqID.InnerText);
                    string seqREFID = itemNode.SelectSingleNode("SEQ_REFID").InnerText;
                    if (seqID != null) return seqID;
                    //Console.WriteLine(seqREFID.InnerText);
                }


                XmlNodeList ttChungList = xmlDoc.SelectNodes("//BODY/ROW/TT_CHUNG");
                foreach (XmlNode itemNode in ttChungList)
                {
                    string maHS = itemNode.SelectSingleNode("MA_HS").InnerText;
                    if (maHS != null) return maHS;
                    //Console.WriteLine(maHS.InnerText);
                    string maGCN = itemNode.SelectSingleNode("MA_GCN").InnerText;
                    if (maGCN != null) return maGCN;
                    //Console.WriteLine(maGCN.InnerText);
                    string soPhieu = itemNode.SelectSingleNode("SO_PHIEU").InnerText;
                    if (soPhieu != null) return soPhieu;
                    //Console.WriteLine(soPhieu.InnerText);
                    string ngayDuyet = itemNode.SelectSingleNode("NGAY_DUYET").InnerText;
                    if (ngayDuyet != null) return ngayDuyet;
                    //Console.WriteLine(ngayDuyet.InnerText);
                    string nguoiDuyet = itemNode.SelectSingleNode("NGUOI_DUYET").InnerText;
                    if (nguoiDuyet != null) return nguoiDuyet;
                    //Console.WriteLine(nguoiDuyet.InnerText);
                    string loaiDeNghi = itemNode.SelectSingleNode("LOAI_DENGHI").InnerText;
                    if (loaiDeNghi != null) return loaiDeNghi;
                    //Console.WriteLine(loaiDeNghi.InnerText);
                    string loaiHoSo = itemNode.SelectSingleNode("LOAI_HOSO").InnerText;
                    if (loaiHoSo != null) return loaiHoSo;
                    //Console.WriteLine(loaiHoSo.InnerText);

                    //XmlNode dkGhiNoNVTC = itemNode.SelectSingleNode("DK_GHINO_NVTC");
                    //XmlNode ttNoNVTC = itemNode.SelectSingleNode("TT_NO_NVTC");
                    //XmlNode ttSoHuu = itemNode.SelectSingleNode("TT_SOHUU");
                    //XmlNode htplVeDat = itemNode.SelectSingleNode("HSPL_VEDAT");
                    //XmlNode thoidiemNoPHS = itemNode.SelectSingleNode("THOIDIEM_NOPHS");
                    //XmlNode soGCNQSD = itemNode.SelectSingleNode("SO_GCN_QSD");
                    //XmlNode ngayCapGCN = itemNode.SelectSingleNode("NGAYCAP_GCN");
                    //XmlNode noiCapGCN = itemNode.SelectSingleNode("NOI_CAP_GCN");
                }
                SaveXml(xmlDoc.InnerText, connectString, true);
                return xmlDoc.InnerText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SaveXml(string strXml, string contentXml, bool isSign)
        {
            try
            {
                string folder = Directory.GetCurrentDirectory() + "\\EXPORT";
                if (isSign)
                {
                    folder += "\\XML_SIGN\\" + DateTime.Now.ToString("yyyy/MM/dd").Replace("/", "");
                }
                else
                {
                    folder += "\\XML_DATA\\" + DateTime.Now.ToString("yyyy/MM/dd").Replace("/", "");
                }
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                    contentXml = "exportXML";
                    string file = folder + "/" + contentXml + ".xml";
                    using (FileStream stream = new FileStream(file, FileMode.Create, FileAccess.Write))
                    {
                        byte[] binary = System.Text.UTF8Encoding.UTF8.GetBytes(strXml);
                        stream.Write(binary, 0, binary.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable CreateDataTable()
        {
            try
            {
                DataTable dt = new DataTable();


                dt.Columns.Add("MSG_TYPE", typeof(int));
                dt.Columns.Add("SEQ_ID", typeof(string));
                dt.Columns.Add("SEQ_REFID", typeof(string));
                dt.Columns.Add("ERROR_NOTE", typeof(string));

                dt.Columns.Add("TT_CHUNG");
                dt.Columns.Add("MA_HS", typeof(string));
                dt.Columns.Add("MA_GCN", typeof(string));
                dt.Columns.Add("SO_PHIEU", typeof(string));
                dt.Columns.Add("NGAY_DUYET", typeof(DateTime));
                dt.Columns.Add("NGUOI_DUYET", typeof(string));
                dt.Columns.Add("LOAI_DENGHI", typeof(string));
                dt.Columns.Add("LOAI_HOSO", typeof(string));


                dt.Columns.Add("TT_NSD");
                dt.Columns.Add("TT_THUADAT");
                dt.Columns.Add("TT_NHA");
                dt.Columns.Add("TT_CHUYENNHUONG");
                dt.Columns.Add("TT_MIENGIAM");
                dt.Columns.Add("NVTC");
                dt.Columns.Add("SECURITY");

                DataRow dr = dt.NewRow();
                dr["MSG_TYPE"] = 1;
                dt.Rows.Add(dr);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
