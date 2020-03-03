using CMCLIS.CVAN.CORE;
using CMCLIS.CVAN.ENTITY;
using CMCLIS.CVAN.SETTING;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CMCLIST.CVAN.UPLOADFILE
{
    [EnableCors("*", "*", "*")]
    public class UploadController : ApiController
    {
        [Route("WebApi/{id}"), HttpGet]
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
        /// upload file
        /// </summary>
        /// <param name="SendMail">đối tượng mail</param>
        /// <returns></returns> 
        /// created by: ntkien5 07.02.2020
        [Route("Upload/File")]
        public Response SERVICE_UPLOAD_File(FileObject fileObject)
        {
            try
            {

                //string directoryPath = Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location, "TempFile");
                var directoryPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "TempFile");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string filePath = Path.Combine(directoryPath, string.Format("{0}.{1}", fileObject.FileName, fileObject.Extension));
                File.WriteAllBytes(filePath, Convert.FromBase64String(fileObject.FileContent));
                if (File.Exists(filePath))
                {
                    string ftpFolder = DateTime.Now.ToString("yyyy-MM-dd");
                    if (!FTPClient.FtpDirectoryExists(Config.FTP_SERVER_URI, Config.FTP_USER, Config.FTP_PASSWORD, ftpFolder))
                    {
                        FTPClient.CreateFolder(Config.FTP_SERVER_URI, Config.FTP_USER, Config.FTP_PASSWORD, ftpFolder);
                    }
                    FTPClient.Upload(Config.FTP_SERVER_URI + "/" + ftpFolder, Config.FTP_USER, Config.FTP_PASSWORD, filePath);
                    return new Response
                    {
                        ResultCode = Constant.RETURN_CODE_SUCCESS,
                        Message = Constant.MESSAGE_SUCCESS,
                        ReturnValue = fileObject.FileName
                    };
                }
                return new Response
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR,
                    ReturnValue = ""
                };
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

        /// <summary>
        /// upload file
        /// </summary>
        /// <param name="SendMail">đối tượng mail</param>
        /// <returns></returns> 
        /// created by: ntkien5 07.02.2020
        [Route("File/{fileID}"), HttpGet]
        public ResponseInfo<ResponseFileInfo> SERVICE_Load_File(string fileID)
        {
            try
            {
                ResponseFileInfo responseData = null;
                string resultCode = Constant.RETURN_CODE_ERROR;
                string message = Constant.MESSAGE_ERROR;
                //CVAN_FILEInfo fileInfo = null;//lấy trong database
                CVAN_FILEInfo fileInfo = new CVAN_FILEInfo();
                fileInfo.FileID = "cuộc đời";
                fileInfo.Extension = "doc";
                fileInfo.DateCreate = new DateTime(2020,2,10);


                string fileFolder = fileInfo.DateCreate.ToString("yyyy-MM-dd");
                string fileName = string.Format("{0}.{1}", fileInfo.FileID, fileInfo.Extension);
                string pathFileFTP = Path.Combine(fileFolder, fileName);

                //tạo đường dẫn để download file về
                string directoryPath = Path.Combine(Config.FTP_DOWNLOAD_FILE);
                string directoryFullPath = Path.Combine(Config.FTP_DOWNLOAD_FILE,fileFolder);
                if (!Directory.Exists(directoryFullPath))
                {
                    Directory.CreateDirectory(directoryFullPath);
                }

                if (FTPClient.Download(Config.FTP_SERVER_URI, Config.FTP_USER, Config.FTP_PASSWORD, directoryPath, pathFileFTP))
                {
                    string downloadFilePath = Path.Combine(directoryPath, pathFileFTP);
                    if (File.Exists(downloadFilePath))
                    {
                        responseData = new ResponseFileInfo();
                        responseData.FileID = fileInfo.FileID;
                        responseData.Content = Convert.ToBase64String(File.ReadAllBytes(downloadFilePath));
                        responseData.Data = fileInfo;

                        resultCode = Constant.RETURN_CODE_SUCCESS;
                        message = Constant.MESSAGE_ERROR;
                    }
                }
                return new ResponseInfo<ResponseFileInfo>
                {
                    ResultCode = resultCode,
                    Message = message,
                    Data= responseData
                };
            }
            catch (Exception ex)
            {
                return new ResponseInfo<ResponseFileInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = ex.Message
                };
            }
        }
    }
}
