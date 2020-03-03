using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CMCLIS.CVAN.CORE
{
    public class FileProcess
    {
        public static bool CopyFile(string sSourcePath, string sPathEnd)
        {
            try
            {
                File.SetAttributes(sSourcePath, FileAttributes.Normal);
                FileInfo f = new FileInfo(sSourcePath);
                f.CopyTo(sPathEnd, true);
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
            return true;
        }

        public static void CopyDirectory(string sourceDirectory, string targetDirectory)
        {
            try
            {
                DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
                DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

                CopyAll(diSource, diTarget);
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            try
            {

                Directory.CreateDirectory(target.FullName);

                // Copy each file into the new directory.
                foreach (FileInfo fi in source.GetFiles())
                {
                    Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                    fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                }

                // Copy each subdirectory using recursion.
                foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                {
                    DirectoryInfo nextTargetSubDir =
                        target.CreateSubdirectory(diSourceSubDir.Name);
                    CopyAll(diSourceSubDir, nextTargetSubDir);
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public static bool DeleteFile(string filePath)  
        {
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    stream.Dispose();
                    File.SetAttributes(filePath, FileAttributes.Normal);
                    File.Delete(filePath);
                }

                // delete your file.

            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
            return true;
        }

        public static void DeleteDirectory(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    //Delete all files from the Directory
                    foreach (string file in Directory.GetFiles(path))
                    {
                        File.Delete(file);
                    }
                    //Delete all child Directories
                    foreach (string directory in Directory.GetDirectories(path))
                    {
                        DeleteDirectory(directory);
                    }
                    //Delete a Directory
                    Directory.Delete(path);
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }        

        public static string LoadFile(string pathFile)
        {
            try
            {
                StreamReader streamReader = new StreamReader(pathFile);
                string value = streamReader.ReadToEnd();

                return value;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return string.Empty;
            }
        }

        public static bool WriteFileToNetwork(string networkSharePathShare,string pathSaveFile,XmlDocument contentFile,string networkIP,string userName,string passWord)
        {
            try
            {
                NetworkShare.DisconnectFromShare(networkSharePathShare, true); //Disconnect in case we are currently connected with our credentials;
                NetworkShare.ConnectToShare(networkSharePathShare, userName, passWord); //Connect with the new credentials    
                using (XmlTextWriter xmltw = new XmlTextWriter(pathSaveFile, new UTF8Encoding(false)))
                {
                    contentFile.WriteTo(xmltw);
                    xmltw.Close();
                }
                //File.WriteAllText(pathSaveFile, contentFile, Encoding.UTF8);      
                NetworkShare.DisconnectFromShare(networkSharePathShare, false); //Disconnect from the server.               
                return true;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
            
        }

        public static string GetContentFileFromNetwork(string networkSharePathShare, string pathFile, string networkIP, string userName, string passWord)
        {
            try
            {
                CMCLIS.CVAN.CORE.NetworkShare.DisconnectFromShare(networkSharePathShare, true); //Disconnect in case we are currently connected with our credentials;
                CMCLIS.CVAN.CORE.NetworkShare.ConnectToShare(networkSharePathShare, userName, passWord); //Connect with the new credentials                
                StreamReader streamReader = new StreamReader(pathFile);
                string value = streamReader.ReadToEnd();
                CMCLIS.CVAN.CORE.NetworkShare.DisconnectFromShare(networkSharePathShare, false); //Disconnect from the server.               
                return value;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }

        }

        public static byte[] FileToByteArrayFromNetwork(string networkSharePathShare, string pathFile, string networkIP, string userName, string passWord)
        {
            try
            {
                CMCLIS.CVAN.CORE.NetworkShare.DisconnectFromShare(networkSharePathShare, true); //Disconnect in case we are currently connected with our credentials;
                CMCLIS.CVAN.CORE.NetworkShare.ConnectToShare(networkSharePathShare, userName, passWord); //Connect with the new credentials                
                byte[] buff = null;
                FileStream fs = new FileStream(pathFile,
                                               FileMode.Open,
                                               FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                long numBytes = new FileInfo(pathFile).Length;
                buff = br.ReadBytes((int)numBytes);                
                CMCLIS.CVAN.CORE.NetworkShare.DisconnectFromShare(networkSharePathShare, false); //Disconnect from the server.               
                return buff;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }

        }

        public static byte[] FileToByteArray(string fileName)
        {
            try
            {
                byte[] buff = null;
                FileStream fs = new FileStream(fileName,
                                               FileMode.Open,
                                               FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                long numBytes = new FileInfo(fileName).Length;
                buff = br.ReadBytes((int)numBytes);
                return buff;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }

        public static void WriteFileXmlFromObject(string pathSaveFile, object objInfo)
        {
            try
            {
                XmlSerializer xsSubmit = new XmlSerializer(objInfo.GetType());
                using (StringWriter sww = new StringWriter())
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, objInfo);
                    var xml = sww.ToString(); // Your XML
                    File.WriteAllText(pathSaveFile, xml, Encoding.UTF8);

                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public static bool ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            try
            {
                // Open file for reading
                System.IO.FileStream _FileStream =
                   new System.IO.FileStream(_FileName, System.IO.FileMode.Create,
                                            System.IO.FileAccess.Write);
                // Writes a block of bytes to this stream using data from
                // a byte array.
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);

                // close file stream
                _FileStream.Close();

                return true;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }

            // error occured, return false
           
        }
    }
}
