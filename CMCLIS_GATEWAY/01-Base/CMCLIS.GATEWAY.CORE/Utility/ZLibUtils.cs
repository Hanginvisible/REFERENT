using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zlib;

namespace CMCLIS.GATEWAY.CORE
{
    public class ZLibUtils
    {
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

        public static void CompressFile(string inFile, string outFile)
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

        public static String CompressByteArray(byte[] inByte)
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

        public static String CompressString(string original)
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

        public static void DecompressFile(string inFile, string outFile)
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

        public static string DecompressBase64String(string base64String)
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

        #region Base64

        public static string EncodeTo64(string toEncode)
        {
            try
            {
                byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.UTF8.GetBytes(toEncode);

                string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);

                return returnValue;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return string.Empty;
            }
        }

        public static string DecodeFrom64(string encodedData)
        {
            try
            {
                byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);

                string returnValue = System.Text.ASCIIEncoding.UTF8.GetString(encodedDataAsBytes);

                return returnValue;
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
