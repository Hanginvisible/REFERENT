using CMCLIS.CVAN.CORE;
using CMCLIS.CVAN.DATA.OBJECTS;
using CMCLIS.CVAN.ENTITY;
using CMCLIS.CVAN.SETTING;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CMCLIS.CVAN.UPLOADFILE
{
    [EnableCors("*", "*", "*")]
    public class UploadController : ApiController
    {
        [Route("UploadApi/Check/{id}"), HttpGet]
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
        /// <param name="FileObject">đối tượng file</param>
        /// <returns></returns> 
        /// created by: ntkien5 07.02.2020
        [Route("UploadApi/Post")]
        public Response  SERVICE_UPLOAD_File(FileObject fileObject)
        {
            try
            {
                var directoryPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "TempFile");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                FILE_SERVER_DATAInfo updateFileObject = CommonFunction.InitFileServerInfo(fileObject);
                string filePath = Path.Combine(directoryPath, string.Format("{0}.{1}", updateFileObject.FILE_NAME, updateFileObject.EXTENSION));
                File.WriteAllBytes(filePath, Convert.FromBase64String(fileObject.FILE_CONTENT));
                if (File.Exists(filePath))
                {
                    //nếu file đẩy lên hợp lệ thì thực hiện đẩy vào database
                    DataObjectFactory.GetInstanceFILE_SERVER_DATA().Add(updateFileObject);
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
                        ReturnValue = updateFileObject.FILE_ID
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
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
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
        [Route("UploadApi/{fileID}"), HttpGet]
        public ResponseInfo<ResponseFileInfo> SERVICE_Load_File(string fileID)
        {
            try
            {
                ResponseFileInfo responseData = null;
                string resultCode = Constant.RETURN_CODE_ERROR;
                string message = Constant.MESSAGE_ERROR;
                int totalcount = 0;
                List<FILE_SERVER_DATAInfo> fileInfos = DataObjectFactory.GetInstanceFILE_SERVER_DATA().FILE_SERVER_DATA_QuerySolr_GetAllWithPadding(string.Empty, fileID, string.Empty, string.Empty, string.Empty, string.Empty, 1, 1, ref totalcount);
                //NTKIEN5: 12.02.2020 version của file sẽ tương ứng với id của file vậy nên chỉ cần lấy top 1 thì luôn là file mới nhất
                var fileInfo = fileInfos.FirstOrDefault();
                if (fileInfo != null)
                {
                    string fileFolder = fileInfo.CDATE.Value.ToString("yyyy-MM-dd");
                    string fileName = string.Format("{0}.{1}", fileInfo.FILE_NAME, fileInfo.EXTENSION);
                    string pathFileFTP = Path.Combine(fileFolder, fileName);

                    //tạo đường dẫn để download file về
                    var directoryPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "DownloadFile");
                    string directoryFullPath = Path.Combine(directoryPath, fileFolder);
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
                            responseData.FILE_ID = fileInfo.FILE_ID;
                            responseData.FILE_CONTENT = Convert.ToBase64String(File.ReadAllBytes(downloadFilePath));
                            responseData.DATA = fileInfo;

                            resultCode = Constant.RETURN_CODE_SUCCESS;
                            message = Constant.MESSAGE_SUCCESS;
                        }
                    }
                }

                return new ResponseInfo<ResponseFileInfo>
                {
                    ResultCode = resultCode,
                    Message = message,
                    Data = responseData
                };
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new ResponseInfo<ResponseFileInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = ex.Message
                };
            }
        }
    }
}
