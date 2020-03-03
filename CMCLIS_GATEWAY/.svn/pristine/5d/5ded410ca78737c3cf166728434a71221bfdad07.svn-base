using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMCLIS.GATEWAY.CORE;
using CMCLIS.GATEWAY.DATA.OBJECTS;
using CMCLIS.GATEWAY.ENTITY;
using CMCLIS.GATEWAY.SETTING;
using Newtonsoft.Json;

namespace CMCLIS.GATEWAY.WServiceMQMail
{
    public class MQ_PROCESS_DATA
    {
        /// <summary>
        /// hàm thực hiện xử lý đối tượng mail
        /// </summary>
        /// <param name="body">message đc lấy từ queue</param>
        /// created by: ntkien 21.02.2020
        public static int PROCESS_MAIL(byte[] body)
        {
            int result = 1;
            //mảng lưu trữ FILE_ID
            string[] file_ids;
            int index = 0;
            string list_file_id = string.Empty;
            Guid file_id = Guid.Empty;
            try
            {
                string msgValue = Encoding.UTF8.GetString(body);
                CVAN_MAIL objEmail = JsonConvert.DeserializeObject<CVAN_MAIL>(msgValue);
                if (objEmail != null)
                {
                    if (objEmail.Attachment != null && objEmail.Attachment.Count > 0)
                    {
                        file_ids = new string[objEmail.Attachment.Count];
                        for (int i = 0; i < file_ids.Length; i++)
                        {
                            file_id= Guid.NewGuid();
                            file_ids[i] = file_id.ToString();
                            list_file_id += file_id + ";";
                        }
                    }
                    DateTime currentDate = DateTime.Now;
                    KeyValuePair<string,string> keyValue = Config.MAIL_DICTIONARY_TYPE.Where(z => z.Key.EqualsValue(objEmail.TypeCode)).FirstOrDefault();
                    CVAN_MAILInfo objUpdate = new CVAN_MAILInfo();
                    objUpdate.CVAN_FROM = CMCLIS.GATEWAY.SETTING.Config.CMCSOFT_MAIL;
                    objUpdate.CVAN_TO = objEmail.EmailTo;
                    objUpdate.CVAN_CONTENT = objEmail.Content;
                    objUpdate.CVAN_SUBJECT = objEmail.Subject;
                    objUpdate.CVAN_TYPE_CODE = objEmail.TypeCode;
                    objUpdate.CVAN_TYPE_NAME = keyValue.Value;
                    objUpdate.CVAN_DESCRIPTION = list_file_id;
                    objUpdate.CUSER = objEmail.SenderName;
                    objUpdate.CDATE = currentDate;
                    objUpdate.CVAN_STATUS = 0;
                    objUpdate.IS_DELETE = false;
                    result = DataObjectFactory.GetInstanceCVAN_MAIL().Add(objUpdate);
                    //nếu thêm thành công thì thực hiện đẩy file attachment vào nếu có
                    if (result!=-1 && objEmail.Attachment!=null &&objEmail.Attachment.Count>0)
                    {
                        var directoryPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "TempFile", currentDate.ToString("yyyy-MM-dd"), result.ToString());
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        foreach (CVAN_MAIL_ATTACHMENT objAttachment in objEmail.Attachment)
                        {
                            string url = Config.FILE_SERVER_INFO_UPLOAD_API;
                            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new
                            {
                                FILE_ID = "",
                                FILE_CONTENT = objAttachment.Content,
                                EXTENSION = objAttachment.Extension,
                                DESCRIPTION = objAttachment.FileName,
                                DOC_TYPE = "EMAIL",
                            }); 
                            HttpWebRequestBase.POST<Response>(json, url);
                            //string filePath = Path.Combine(directoryPath, string.Format("{0}.{1}", objAttachment.FileName, objAttachment.Extension));
                            //File.WriteAllBytes(filePath, Convert.FromBase64String(objAttachment.Content));
                            //if (File.Exists(filePath))
                            //{
                            //    string ftpFolder = string.Format("Attachment_Email/{0}/{1}", currentDate.ToString("yyyy-MM-dd"), result);
                            //    if (!FTPClient.FtpDirectoryExists(CMCLIS.GATEWAY.SETTING.Config.FTP_SERVER_URI, CMCLIS.GATEWAY.SETTING.Config.FTP_USER, CMCLIS.GATEWAY.SETTING.Config.FTP_PASSWORD, ftpFolder))
                            //    {
                            //        FTPClient.CreateFolder(CMCLIS.GATEWAY.SETTING.Config.FTP_SERVER_URI, CMCLIS.GATEWAY.SETTING.Config.FTP_USER, CMCLIS.GATEWAY.SETTING.Config.FTP_PASSWORD, ftpFolder);
                            //    }
                            //    FTPClient.Upload(CMCLIS.GATEWAY.SETTING.Config.FTP_SERVER_URI + "/" + ftpFolder, CMCLIS.GATEWAY.SETTING.Config.FTP_USER, CMCLIS.GATEWAY.SETTING.Config.FTP_PASSWORD, filePath);

                            //}
                        }
                    }
                }
            }
            catch (Exception ex) {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                result = -1;
            }
            return result;
        }
    }
}
