using CMCLIS.CVAN.SETTING;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CMCLIS.CVAN.CORE.Sercurity
{
    public class Encrypt
    {
        /// <summary>
        /// take any string and encrypt it using SHA1 then
        /// return the encrypted data
        /// </summary>
        /// <param name="data">input text you will enterd to encrypt it</param>
        /// <returns>return the encrypted text as hexadecimal string</returns>
        public static string GetSHA1HashData(string data)
        {
            ////create new instance of md5
            //SHA1 sha1 = SHA1.Create();

            ////convert the input text to array of bytes
            //byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));

            ////create new instance of StringBuilder to save hashed data
            //StringBuilder returnValue = new StringBuilder();

            ////loop for each byte and add it to StringBuilder
            //for (int i = 0; i < hashData.Length; i++)
            //{
            //    returnValue.Append(hashData[i].ToString());
            //}

            //// return hexadecimal string
            //return returnValue.ToString();

            System.Security.Cryptography.SHA1 sha = System.Security.Cryptography.SHA1.Create();
            byte[] preHash = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] hash = sha.ComputeHash(preHash);

            // string returnValue = System.Convert.ToBase64String(hash);

            // return hexadecimal string
            return System.Convert.ToBase64String(hash);
        }
        /// <summary>
        /// Byte sang 32 ky1 tu
        /// </summary>
        /// <param name="objectAsBytes"></param>
        /// <returns></returns>
        public static string ComputeHash(byte[] objectAsBytes)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            try
            {
                byte[] result = md5.ComputeHash(objectAsBytes);

                // Build the final string by converting each byte
                // into hex and appending it to a StringBuilder
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    sb.Append(result[i].ToString("X2"));
                }

                // And return it
                return sb.ToString();
            }
            catch (ArgumentNullException ane)
            {
                //If something occured during serialization, this method is called with an null argument. 
                Console.WriteLine("Hash has not been generated." + ane.Message);
                return null;
            }
        }

        public static string MD5(string s)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = Encoding.Default.GetBytes(s);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes).ToLower().Replace("-", "");
        }

        public static string EncryptText(string str,string key)
        {
            var rijndaelKey = new Cryptography.RijndaelEnhanced(key, "@1B2c3D4e5F6g7H8");
            return rijndaelKey.Encrypt(str);
        }

        public static string DecryptText(string str,string key)
        {
            var rijndaelKey = new Cryptography.RijndaelEnhanced(key, "@1B2c3D4e5F6g7H8");
            return rijndaelKey.Decrypt(str);
        }

        /// <summary>
        /// Mã hóa sử dụng phương pháp mã hóa 2 chiều.
        /// </summary>
        /// <param name="toEncrypt">Xâu muốn mã hóa</param>
        /// <returns></returns>
        public static string EncryptText(string source)
        {
            try
            {
                byte[] keyArray;
                byte[] sourceArray = UTF8Encoding.UTF8.GetBytes(source);

                //Sử dụng Hashing
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Constant.ENCRYPT_KEY));
                hashmd5.Clear();

                //Không sử dụng Hashing
                //keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(sourceArray, 0, sourceArray.Length);
                tdes.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return string.Empty;
            }
        }

        /// <summary>
        /// Giải mã sử dụng phương pháp mã hóa 2 chiều.
        /// </summary>
        /// <param name="cipherString">Xâu muốn mã hóa</param>
        /// <returns></returns>
        public static string DecryptText(string source)
        {
            try
            {
                byte[] keyArray;
                byte[] sourceArray = Convert.FromBase64String(source);

                //Sử dụng Hashing
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Constant.ENCRYPT_KEY));
                hashmd5.Clear();

                //Không sử dụng Hashing
                //keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(sourceArray, 0, sourceArray.Length);

                tdes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return string.Empty;
            }
        }

        public static string DecryptStringAES(string cipherText)
        {
            try
            {
                var keybytes = Encoding.UTF8.GetBytes(Constant.ENCRYPT_KEY);
                var iv = Encoding.UTF8.GetBytes(Constant.ENCRYPT_KEY);

                var encrypted = Convert.FromBase64String(cipherText);
                var decriptedFromJavascript = DecryptStringFromBytes(encrypted, keybytes, iv);
                return string.Format(decriptedFromJavascript);
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return string.Empty;
            }
        }

        private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            try
            {
                // Check arguments.
                if (cipherText == null || cipherText.Length <= 0)
                {
                    throw new ArgumentNullException("cipherText");
                }
                if (key == null || key.Length <= 0)
                {
                    throw new ArgumentNullException("key");
                }
                if (iv == null || iv.Length <= 0)
                {
                    throw new ArgumentNullException("key");
                }

                // Declare the string used to hold
                // the decrypted text.
                string plaintext = null;

                // Create an RijndaelManaged object
                // with the specified key and IV.
                using (var rijAlg = new RijndaelManaged())
                {
                    //Settings
                    rijAlg.Mode = CipherMode.CBC;
                    rijAlg.Padding = PaddingMode.PKCS7;
                    rijAlg.FeedbackSize = 128;

                    rijAlg.Key = key;
                    rijAlg.IV = iv;

                    // Create a decrytor to perform the stream transform.
                    var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                    try
                    {
                        // Create the streams used for decryption.
                        using (var msDecrypt = new MemoryStream(cipherText))
                        {
                            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                            {

                                using (var srDecrypt = new StreamReader(csDecrypt))
                                {
                                    // Read the decrypted bytes from the decrypting stream
                                    // and place them in a string.
                                    plaintext = srDecrypt.ReadToEnd();

                                }

                            }
                        }
                    }
                    catch
                    {
                        plaintext = "keyError";
                    }
                }

                return plaintext;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return "keyError";
            }
        }

        private static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            try
            {
                // Check arguments.
                if (plainText == null || plainText.Length <= 0)
                {
                    throw new ArgumentNullException("plainText");
                }
                if (key == null || key.Length <= 0)
                {
                    throw new ArgumentNullException("key");
                }
                if (iv == null || iv.Length <= 0)
                {
                    throw new ArgumentNullException("key");
                }
                byte[] encrypted;
                // Create a RijndaelManaged object
                // with the specified key and IV.
                using (var rijAlg = new RijndaelManaged())
                {
                    rijAlg.Mode = CipherMode.CBC;
                    rijAlg.Padding = PaddingMode.PKCS7;
                    rijAlg.FeedbackSize = 128;

                    rijAlg.Key = key;
                    rijAlg.IV = iv;

                    // Create a decrytor to perform the stream transform.
                    var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                    // Create the streams used for encryption.
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (var swEncrypt = new StreamWriter(csEncrypt))
                            {
                                //Write all data to the stream.
                                swEncrypt.Write(plainText);
                            }
                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }

                // Return the encrypted bytes from the memory stream.
                return encrypted;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }

        

    }
}
