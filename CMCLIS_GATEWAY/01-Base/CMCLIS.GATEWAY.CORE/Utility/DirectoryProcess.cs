using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CMCLIS.GATEWAY.CORE
{
    public class DirectoryProcess
    {
        #region Base
        public static bool CreateDirectory(string path, string folder)
        {
            bool value = false;
            try
            {
                if (!Directory.Exists(path + @"\" + folder))
                {
                    Directory.CreateDirectory(path + @"\" + folder);
                    value = true;
                }
                return value;
            }
            catch
            {
                return false;
            }
        }
        public static bool CoppyDirectory(string sSourcePath, string sPathEnd)
        {
            try
            {
                String[] Files;
                if (sPathEnd[sPathEnd.Length - 1] != Path.DirectorySeparatorChar)
                    sPathEnd += Path.DirectorySeparatorChar;
                if (!Directory.Exists(sPathEnd)) Directory.CreateDirectory(sPathEnd);
                Files = Directory.GetFileSystemEntries(sSourcePath);
                foreach (string Element in Files)
                {
                    // Sub directories

                    if (Directory.Exists(Element))
                        CoppyDirectory(Element, sPathEnd + Path.GetFileName(Element));
                    // Files in directory

                    else
                        File.Copy(Element, sPathEnd + Path.GetFileName(Element), true);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
        public static bool DeleteDirectory(string sPathDirectoryName)
        {
            try
            {
                DirectoryInfo dInfo = new DirectoryInfo(sPathDirectoryName);
                dInfo.Delete(true);
            }
            catch
            {

                return false;
            }
            return true;
        }
        public static bool RenameDirectory(string strOldDirectoryName, string strNewDirectoryName)
        {
            try
            {
                Directory.Move(strOldDirectoryName, strNewDirectoryName);
            }
            catch { return false; }
            return true;
        }
        public static bool EmptyDirectory(DirectoryInfo directoryInfo)
        {
            try
            {
                foreach (FileInfo file in directoryInfo.GetFiles())
                {

                    file.Delete();
                }
                foreach (DirectoryInfo subfolder in directoryInfo.GetDirectories())
                {
                    EmptyDirectory(subfolder);
                }
            }
            catch { return false; }
            return true;
        }
        public static void SetPermissionFolder(string Folder, string Account)
        {
            DirectorySecurity dSecurity = Directory.GetAccessControl(Folder, AccessControlSections.All);
            dSecurity.AddAccessRule(new FileSystemAccessRule(Account, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            Directory.SetAccessControl(Folder, dSecurity);
        }
        public static void MakeFolderWritable(string Folder)
        {
            if (IsFolderReadOnly(Folder))
            {
                System.IO.DirectoryInfo oDir = new System.IO.DirectoryInfo(Folder);
                oDir.Attributes = oDir.Attributes & ~System.IO.FileAttributes.ReadOnly;
            }
        }
        public static bool IsFolderReadOnly(string Folder)
        {
            System.IO.DirectoryInfo oDir = new System.IO.DirectoryInfo(Folder);
            return ((oDir.Attributes & System.IO.FileAttributes.ReadOnly) > 0);
        }
        public static bool CreateDirectoryToNetwork(string networkSharePathShare, string folder, string networkIP, string userName, string passWord)
        {
            try
            {
                bool value = false;
                
                NetworkShare.DisconnectFromShare(networkSharePathShare, true); //Disconnect in case we are currently connected with our credentials;
                NetworkShare.ConnectToShare(networkSharePathShare, userName, passWord); //Connect with the new credentials
                if (!Directory.Exists(networkSharePathShare + "\\" + folder + "\\"))
                    Directory.CreateDirectory(networkSharePathShare + "\\" + folder);                
                NetworkShare.DisconnectFromShare(networkSharePathShare, false); //Disconnect from the server.
                return value;               
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }

        }
        #endregion
        #region Process
        #region Process File
        public static ArrayList GetArrayListFileInDirectory(string sDirPath)
        {
            ArrayList arr = new ArrayList();
            string[] sFiles = Directory.GetFiles(sDirPath);
            foreach (string sFileName in sFiles)
            {
                arr.Add(sFileName);
            }
            return arr;
        }
       
        #endregion
        #endregion
        #region Tính toán
        public static int CountFileDirectory(string dirPath)
        {
            Int32 fileCount = 0;
            try
            {
                DirectoryInfo dirinfo = new DirectoryInfo(dirPath);
                DirectoryInfo[] subdirinfo = dirinfo.GetDirectories("*.*");
                FileInfo[] files = dirinfo.GetFiles();
                if (files.Length > 0)
                {
                    fileCount = files.Length + fileCount;
                }
                foreach (DirectoryInfo directory in subdirinfo)
                {
                    CountFileDirectory(directory.FullName.ToString());
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return fileCount;
        }
        #endregion
        #region Get List

        public static List<FileInfo> GetFileInDirectory(string sPathDirectoryName, string FileType)
        {
            DirectoryInfo dInfo = new DirectoryInfo(sPathDirectoryName);
            FileInfo[] fArrInfo = dInfo.GetFiles();
            List<FileInfo> fList = new List<FileInfo>();
            foreach (FileInfo fInfo in fArrInfo)
            {
                FileInfo afInfo = new FileInfo(fInfo.Name);
                string fy = afInfo.Extension;
                if (FileType.IndexOf(fy) > -1)
                {
                    fList.Add(afInfo);
                }

            }//end foreach
            return fList;
        }//end GetFileInDirectory
        public static List<FileInfo> GetFileInDirectory(string sPathDirectoryName)
        {
            DirectoryInfo dInfo = new DirectoryInfo(sPathDirectoryName);
            FileInfo[] fArrInfo = dInfo.GetFiles();
            List<FileInfo> fList = new List<FileInfo>();
            foreach (FileInfo fInfo in fArrInfo)
            {
                FileInfo afInfo = new FileInfo(fInfo.Name);
                fList.Add(afInfo);

            }//end foreach
            return fList;
        }//end GetFileInDirectory
        public static List<DirectoryInfo> GetDirectoryInDirectory(string sPathDirectoryName)
        {
            DirectoryInfo dInfo = new DirectoryInfo(sPathDirectoryName);
            DirectoryInfo[] dArrInfo = dInfo.GetDirectories();
            List<DirectoryInfo> dList = new List<DirectoryInfo>();
            foreach (DirectoryInfo dSubInfo in dArrInfo)
            {
                DirectoryInfo adInfo = new DirectoryInfo(dSubInfo.Name);
                dList.Add(adInfo);
            }//end foreach
            return dList;
        }//end GetDirectoryInDirectory

        #endregion
    }
}
