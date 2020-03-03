using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zlib;


namespace CMCLIS.CVAN.CORE
{
    public class ZipData
    {
        #region using ZLib Compress data

        private static void CopyStream(System.IO.Stream input, System.IO.Stream output)
        {
            try
            {
                byte[] buffer = new byte[2000];
                int len;
                while ((len = input.Read(buffer, 0, 2000)) > 0)
                {
                    output.Write(buffer, 0, len);
                }
                output.Flush();
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public static void ZLibCompressFile(string inFile, string outFile)
        {
            try
            {
                FileStream outFileStream = new FileStream(outFile, System.IO.FileMode.Create);
                ZOutputStream outZStream = new ZOutputStream(outFileStream, zlib.zlibConst.Z_DEFAULT_COMPRESSION);
                FileStream inFileStream = new FileStream(inFile, System.IO.FileMode.Open);
                try
                {
                    CopyStream(inFileStream, outZStream);
                }
                finally
                {
                    outZStream.Close();
                    outFileStream.Close();
                    inFileStream.Close();
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public static String ZLibCompressByteArray(byte[] inByte)
        {
            try
            {
                string base64String = string.Empty;
                MemoryStream input = new MemoryStream(inByte);
                MemoryStream output = new MemoryStream();
                ZOutputStream outZStream = new ZOutputStream(output, zlib.zlibConst.Z_DEFAULT_COMPRESSION);
                try
                {
                    CopyStream(input, outZStream);
                }
                finally
                {
                    outZStream.Close();
                    input.Close();
                }
                try
                {
                    base64String = Convert.ToBase64String(output.ToArray());
                }
                finally
                {
                    output.Close();
                }
                return base64String;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return string.Empty;
            }
        }

        public static String ZLibCompressString(string original)
        {
            try
            {
                string base64String = string.Empty;
                byte[] inByte = System.Text.Encoding.UTF8.GetBytes(original);
                MemoryStream input = new MemoryStream(inByte);
                MemoryStream output = new MemoryStream();
                ZOutputStream outZStream = new ZOutputStream(output, zlib.zlibConst.Z_DEFAULT_COMPRESSION);
                try
                {
                    CopyStream(input, outZStream);
                }
                finally
                {
                    outZStream.Close();
                    input.Close();
                }
                try
                {
                    base64String = Convert.ToBase64String(output.ToArray());
                }
                finally
                {
                    output.Close();
                }
                return base64String;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return string.Empty;
            }
        }

        public static void ZLibDecompressFile(string inFile, string outFile)
        {
            try
            {
                FileStream outFileStream = new FileStream(outFile, System.IO.FileMode.Create);
                ZOutputStream outZStream = new ZOutputStream(outFileStream);
                FileStream inFileStream = new FileStream(inFile, System.IO.FileMode.Open);
                try
                {
                    CopyStream(inFileStream, outZStream);
                }
                finally
                {
                    outZStream.Close();
                    outFileStream.Close();
                    inFileStream.Close();
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public static string ZLibDecompressBase64String(string base64String)
        {
            try
            {
                string result = string.Empty;
                byte[] inByte = Convert.FromBase64String(base64String);
                MemoryStream input = new MemoryStream(inByte);
                MemoryStream output = new MemoryStream();
                ZOutputStream outZStream = new ZOutputStream(output);
                try
                {
                    CopyStream(input, outZStream);
                }
                finally
                {
                    outZStream.Close();
                    input.Close();
                }
                try
                {
                    result = System.Text.Encoding.UTF8.GetString(output.ToArray());
                }
                finally
                {
                    output.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return string.Empty;
            }
        }

        #endregion

        #region Using Ionic.Zip Compress data

        public static string ZipDataString(string fileName,string content, string outFile)
        {
            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.StatusMessageTextWriter = System.Console.Out;
                    zip.AddEntry(fileName, content, Encoding.ASCII);              
                    zip.Save(outFile);
                    return outFile;
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return string.Empty;
            }
        }

        public static string ZipDataFile(string inFile, string outFile)
        {
            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.StatusMessageTextWriter = System.Console.Out;
                    zip.AddFile(inFile); // recurses subdirectories                
                    zip.Save(outFile);
                    return outFile;
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return string.Empty;
            }
        }

        public static string ZipDirectory(string inDirectory,string outFile)
        {
            try
            {
            using (ZipFile zip = new ZipFile())
            {
                zip.StatusMessageTextWriter = System.Console.Out;
                zip.AddDirectory(inDirectory); // recurses subdirectories                
                zip.Save(outFile);
                return outFile;
            }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return string.Empty;
            }
        }

        public static bool ZipExtractAll(string pathFileZip,string outDirectory)
        {
            try
            {
                using (ZipFile zip = ZipFile.Read(pathFileZip))
                {

                    zip.ExtractAll(outDirectory, ExtractExistingFileAction.OverwriteSilently);
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return false;

            }
        }

        public static string ZipFileToBase64String(string inFile, string outFile)
        {
            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    string result = string.Empty;
                    zip.StatusMessageTextWriter = System.Console.Out;
                    zip.AddFile(inFile); // recurses subdirectories                
                    zip.Save(outFile);
                    if (File.Exists(outFile))
                    {
                       result = Convert.ToBase64String(File.ReadAllBytes(outFile));
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return string.Empty;
            }
        }   

        #endregion

        
    }
}
