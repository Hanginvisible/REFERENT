using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;

namespace CMCLIS.GATEWAY.CORE
{
    public class UploadToServer
    {
        #region "Upload File To Server"


        public static string UploadFile(HtmlInputFile clientFile, string folderToUp, bool autoGenerateName,
                                        bool overwrite, string limitExtension)
        {
            if ((!(clientFile == null)) && (!(clientFile.PostedFile == null)) &&
                !string.IsNullOrEmpty(clientFile.PostedFile.FileName))
            {
                try
                {
                    HttpPostedFile postedFile = clientFile.PostedFile;
                    string sFolder = folderToUp;
                    if (postedFile != null)
                    {
                        //Check exist folder
                        try
                        {
                            if (Directory.Exists(sFolder) == false)
                            {
                                Directory.CreateDirectory(sFolder);
                            }
                        }
                        catch
                        {
                            throw new Exception("Thư mục upload chưa được chỉ định quyền ghi dữ liệu");
                        }

                        //Check validate file extension
                        string fileExtension = Path.GetExtension(postedFile.FileName.ToLower());
                        limitExtension = limitExtension.ToLower();
                        if (limitExtension.IndexOf("*.*") == -1 && limitExtension.IndexOf(fileExtension) == -1)
                        {
                            throw new Exception("Không cho upload định dạng file này");
                        }

                        //Generate file name and check overwrite
                        string fileName = Path.GetFileName(postedFile.FileName);
                        //var sFileName = Path.GetFileNameWithoutExtension(postedFile.FileName);
                        string vFileName = fileName;

                        if (autoGenerateName)
                        {
                            fileName = fileName.Substring(fileName.LastIndexOf("."));
                            vFileName = fileName.Insert(fileName.LastIndexOf("."),
                                                        DateTime.Now.ToString("yyyyMMdd_hhmmss"));
                        }

                        vFileName = vFileName.Replace(" ", string.Empty);

                        if (UploadFile(postedFile.InputStream, folderToUp, vFileName, false))
                            return vFileName;
                        throw new Exception("Upload file không thành công!");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return string.Empty;
        }

        public static string UploadFile(HttpPostedFile postedFile, string folderToUp, bool autoGenerateName,
                                      bool overwrite)
        {
            if ((!(postedFile == null)) &&
                !string.IsNullOrEmpty(postedFile.FileName))
            {
                try
                {
                    //HttpPostedFile postedFile = clientFile.PostedFile;
                    string sFolder = folderToUp;
                    if (postedFile != null)
                    {
                        //Check exist folder
                        try
                        {
                            if (Directory.Exists(sFolder) == false)
                            {
                                Directory.CreateDirectory(sFolder);
                            }
                        }
                        catch
                        {
                            throw new Exception("Thư mục upload chưa được chỉ định quyền ghi dữ liệu");
                        }

                        //Check validate file extension
                        string fileExtension = Path.GetExtension(postedFile.FileName.ToLower());
                        //limitExtension = limitExtension.ToLower();
                        //if (limitExtension.IndexOf("*.*") == -1 && limitExtension.IndexOf(fileExtension) == -1)
                        //{
                        //    throw new Exception("Không cho upload định dạng file này");
                        //}

                        //Generate file name and check overwrite
                        string fileName = Path.GetFileName(postedFile.FileName);
                        string vFileName = fileName;

                        if (autoGenerateName)
                        {
                            fileName = fileName.Substring(fileName.LastIndexOf("."));
                            vFileName = fileName.Insert(fileName.LastIndexOf("."),
                                                        DateTime.Now.ToString("yyyyMMdd_hhmmss") + DateTime.Now.Millisecond.ToString());
                        }

                        vFileName = vFileName.Replace(" ", string.Empty);

                        if (UploadFile(postedFile.InputStream, folderToUp, vFileName, false))
                            return vFileName;
                        throw new Exception("Upload file không thành công!");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return string.Empty;
        }

        public static string UploadFile(HttpPostedFile postedFile, string folderToUp, bool autoGenerateName,
                                      bool overwrite, string limitExtension)
        {
            if ((!(postedFile == null)) &&
                !string.IsNullOrEmpty(postedFile.FileName))
            {
                try
                {
                    //HttpPostedFile postedFile = clientFile.PostedFile;
                    string sFolder = folderToUp;
                    if (postedFile != null)
                    {
                        //Check exist folder
                        try
                        {
                            if (Directory.Exists(sFolder) == false)
                            {
                                Directory.CreateDirectory(sFolder);
                            }
                        }
                        catch
                        {
                            throw new Exception("Thư mục upload chưa được chỉ định quyền ghi dữ liệu");
                        }

                        //Check validate file extension
                        string fileExtension = Path.GetExtension(postedFile.FileName.ToLower());
                        limitExtension = limitExtension.ToLower();
                        if (limitExtension.IndexOf("*.*") == -1 && limitExtension.IndexOf(fileExtension) == -1)
                        {
                            throw new Exception("Không cho upload định dạng file này");
                        }

                        //Generate file name and check overwrite
                        string fileName = Path.GetFileName(postedFile.FileName);
                        string vFileName = fileName;

                        if (autoGenerateName)
                        {
                            fileName = fileName.Substring(fileName.LastIndexOf("."));
                            vFileName = fileName.Insert(fileName.LastIndexOf("."),
                                                        DateTime.Now.ToString("yyyyMMdd_hhmmss") + DateTime.Now.Millisecond.ToString());
                        }

                        vFileName = vFileName.Replace(" ", string.Empty);

                        if (UploadFile(postedFile.InputStream, folderToUp, vFileName, false))
                            return vFileName;
                        throw new Exception("Upload file không thành công!");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return string.Empty;
        }

        public static string UploadFile(HtmlInputFile clientFile, string strFileName, string folderToUp, bool overwrite,
                                        string limitExtension)
        {
            if ((clientFile != null) && (clientFile.PostedFile != null) &&
                !string.IsNullOrEmpty(clientFile.PostedFile.FileName))
            {
                try
                {
                    HttpPostedFile postedFile = clientFile.PostedFile;
                    //string ContentTypeFile = postedFile.ContentType;

                    {
                        string sFolder = folderToUp;
                        try
                        {
                            if (Directory.Exists(sFolder) == false)
                            {
                                Directory.CreateDirectory(sFolder);
                            }
                        }
                        catch
                        {
                            return string.Empty;
                        }

                        //Check validate file extension
                        string fileExtension = Path.GetExtension(postedFile.FileName.ToLower());
                        limitExtension = limitExtension.ToLower();
                        if (limitExtension.IndexOf("*.*") == -1 && limitExtension.IndexOf(fileExtension) == -1)
                            return "";

                        string vFileName = strFileName;

                        UploadFile(postedFile.InputStream, folderToUp, vFileName, overwrite);
                        return vFileName;
                    }
                }
                catch
                {
                    return string.Empty;
                }
            }
            return string.Empty;
        }

        private static bool UploadFile(Stream inputStream, string uploadPath, string fileName, bool overwrite)
        {
            if (overwrite)
            {
                if (File.Exists(Path.Combine(uploadPath, fileName)))
                {
                    File.Delete(Path.Combine(uploadPath, fileName));
                }
            }

            bool result = true;
            string filePath = Path.Combine(uploadPath, fileName);
            string dir = Path.GetDirectoryName(filePath);

            try
            {
                using (var outputStream = new FileStream(filePath, FileMode.Create))
                {
                    StreamCopyToStream(inputStream, outputStream);

                    inputStream.Flush();
                    outputStream.Flush();
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        private static void StreamCopyToStream(Stream input, Stream output)
        {
            const int bufferSize = 2048;
            var buffer = new byte[bufferSize];
            int bytes;
            input.Position = 0;
            while ((bytes = input.Read(buffer, 0, bufferSize)) > 0)
            {
                output.Write(buffer, 0, bytes);
            }
        }

        #endregion

    }
}
