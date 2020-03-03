using Aspose.Cells;
using CMCLIS.GATEWAY.CORE;
using CMCLIS.GATEWAY.CORE.Redis;
using CMCLIS.GATEWAY.CORE.Sercurity;
using CMCLIS.GATEWAY.DATA.OBJECTS;
using CMCLIS.GATEWAY.ENTITY;
using CMCLIS.GATEWAY.SETTING;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.Web;

namespace CMCLIS.GATEWAY.SERVICES
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class API_FILE_SERVER : IAPI_FILE_SERVER
    {
        private static string Authorization = string.Empty;
        protected API_FILE_SERVER()
        {
            var request = OperationContext.Current.IncomingMessageProperties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            Authorization = request.Headers[Config.API_KEY];
            if (string.IsNullOrEmpty(Authorization))
            {
                Authorization = Config.KEY_AUTHORIZATION;
            }
        }

        #region Create Functions "FILE_SERVER_DATA"
        public Response FILE_SERVER_DATA_Add(FILE_SERVER_DATAObject info)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    FILE_SERVER_DATAInfo fileInfo = CommonFunction.InitFileServerInfo(info);

                    var directoryPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "TempFile");
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                    
                    string filePath = Path.Combine(directoryPath, string.Format("{0}.{1}", fileInfo.FILE_NAME, fileInfo.EXTENSION));
                    File.WriteAllBytes(filePath, Convert.FromBase64String(info.FILE_CONTENT));
                    if (File.Exists(filePath))
                    {
                        //nếu file đẩy lên hợp lệ thì thực hiện đẩy vào database
                        DataObjectFactory.GetInstanceFILE_SERVER_DATA().Add(fileInfo);

                        //ntkien5: 24.02.2020 vì cơ chế của FTP đang hạn chế nên cần phải tạo lần lượt directory thì mới được
                        string doctype = (string.IsNullOrWhiteSpace(info.DOC_TYPE) ? "OTHER" : info.DOC_TYPE);
                        FTPClient.CreateFolder(Config.FTP_SERVER_URI, Config.FTP_USER, Config.FTP_PASSWORD, doctype);

                        string ftpFolder ="/"+ string.Format("{0}/{1}",doctype , DateTime.Now.ToString("yyyy-MM-dd"));
                        FTPClient.CreateFolder(Config.FTP_SERVER_URI, Config.FTP_USER, Config.FTP_PASSWORD, ftpFolder);

                        FTPClient.Upload(Config.FTP_SERVER_URI + "/" + ftpFolder, Config.FTP_USER, Config.FTP_PASSWORD, filePath);
                        return new Response
                        {
                            ResultCode = Constant.RETURN_CODE_SUCCESS,
                            Message = Constant.MESSAGE_SUCCESS,
                            ReturnValue = fileInfo.FILE_ID
                        };
                    }
                    return new Response
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_ERROR,
                        ReturnValue = ""
                    };

                    //int result = DataObjectFactory.GetInstanceFILE_SERVER_DATA().Add(fileInfo);
                    //if (result == 0)
                    //    return new Response
                    //    {
                    //        ResultCode = Constant.RETURN_CODE_WARNING,
                    //        Message = Constant.MESSAGE_ERROR_EXIST,
                    //        ReturnValue = result.ToString()
                    //    };
                    //return new Response
                    //{
                    //    ResultCode = result > 0 ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                    //    Message = result > 0 ? Constant.MESSAGE_SUCCESS_ADD : Constant.MESSAGE_ERROR_ADD,
                    //    ReturnValue = result.ToString()
                    //};
                }
                else
                {
                    return new Response
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        ReturnValue = string.Empty
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new Response
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR_ADD + ":" + ex.Message,
                    ReturnValue = string.Empty
                };
            }
        }
        public ResponsePage<FILE_SERVER_DATAInfo> FILE_SERVER_DATA_GetAllWithPadding(string FILE_ID, string DOC_TYPE, string FILE_NAME, string TRAN_ID, string REGION_ID, string IS_DELETE, string pageIndex, string pageSize)
        {
            try
            {
                if (!string.IsNullOrEmpty(Authorization))
                {
                    int totalRecords = 0;
                    FILE_ID = FILE_ID == "-1" ? string.Empty : FILE_ID;
                    DOC_TYPE = DOC_TYPE == "-1" ? string.Empty : DOC_TYPE;
                    FILE_NAME = FILE_NAME == "-1" ? string.Empty : FILE_NAME;
                    TRAN_ID = TRAN_ID == "-1" ? string.Empty : TRAN_ID;
                    REGION_ID = REGION_ID == "-1" ? string.Empty : REGION_ID;
                    List<FILE_SERVER_DATAInfo> result = DataObjectFactory.GetInstanceFILE_SERVER_DATA().FILE_SERVER_DATA_QuerySolr_GetAllWithPadding(string.Empty,FILE_ID, DOC_TYPE, FILE_NAME, TRAN_ID, REGION_ID, int.Parse(IS_DELETE), int.Parse(pageIndex), int.Parse(pageSize), ref totalRecords);
                    return new ResponsePage<FILE_SERVER_DATAInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_SUCCESS,
                        Message = Constant.MESSAGE_SUCCESS ,
                        PageIndex = int.Parse(pageIndex),
                        PageSize = int.Parse(pageSize),
                        TotalRecords = result != null ? totalRecords : 0,
                        Data = result
                    };
                }
                else
                {
                    return new ResponsePage<FILE_SERVER_DATAInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        PageIndex = int.Parse(pageIndex),
                        PageSize = int.Parse(pageSize),
                        TotalRecords = 0,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new ResponsePage<FILE_SERVER_DATAInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR + ":" + ex.Message,
                    PageIndex = int.Parse(pageIndex),
                    PageSize = int.Parse(pageSize),
                    TotalRecords = 0,
                    Data = null
                };
            }
        }
        public ResponseInfo<FILE_SERVER_RESPONSE> FILE_SERVER_DATA_GetInfo(string FILE_ID)
        {
            try
            {
                FILE_SERVER_RESPONSE responseData = null;
                string resultCode = Constant.RETURN_CODE_ERROR;
                string message = Constant.MESSAGE_ERROR;
                int totalcount = 0;
                List<FILE_SERVER_DATAInfo> fileInfos = DataObjectFactory.GetInstanceFILE_SERVER_DATA().FILE_SERVER_DATA_QuerySolr_GetAllWithPadding(string.Empty, FILE_ID, string.Empty, string.Empty, string.Empty, string.Empty, 0, 1, 1, ref totalcount);
                //NTKIEN5: 12.02.2020 version của file sẽ tương ứng với id của file vậy nên chỉ cần lấy top 1 thì luôn là file mới nhất
                var fileInfo = fileInfos.FirstOrDefault();
                if (fileInfo != null)
                {
                    FILE_SERVER_DATAObject fileObject = null;
                    fileObject = new FILE_SERVER_DATAObject();
                    fileObject.FILE_ID = fileInfo.FILE_ID;
                    fileObject.DOC_TYPE = fileInfo.DOC_TYPE;
                    fileObject.FILE_NAME = fileInfo.FILE_NAME;
                    fileObject.EXTENSION = fileInfo.EXTENSION;
                    fileObject.DESCRIPTION = fileInfo.DESCRIPTION;
                    fileObject.VERSION = fileInfo.VERSION;
                    fileObject.TRAN_ID = fileInfo.TRAN_ID;
                    fileObject.REGION_ID = fileInfo.REGION_ID;
                    fileObject.SOURCE = fileInfo.SOURCE;
                    fileObject.CUSER = fileInfo.CUSER;
                    fileObject.LUSER = fileInfo.LUSER;

                    string doctype = (string.IsNullOrWhiteSpace(fileInfo.DOC_TYPE) ? "OTHER" : fileInfo.DOC_TYPE);
                    string fileFolder =string.Format("{0}/{1}",doctype, fileInfo.CDATE.Value.ToString("yyyy-MM-dd"));
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
                            responseData = new FILE_SERVER_RESPONSE();
                            responseData.FILE_ID = fileInfo.FILE_ID;
                            responseData.FILE_CONTENT = Convert.ToBase64String(File.ReadAllBytes(downloadFilePath));
                            responseData.DATA = fileObject;
                            resultCode = Constant.RETURN_CODE_SUCCESS;
                            message = Constant.MESSAGE_SUCCESS;
                        }
                    }
                }

                return new ResponseInfo<FILE_SERVER_RESPONSE>
                {
                    ResultCode = resultCode,
                    Message = message,
                    Data = responseData
                };
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new ResponseInfo<FILE_SERVER_RESPONSE>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = ex.Message
                };
            }
        }


        #endregion

    }
}
