using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using CMCLIS.GATEWAY.SETTING;

namespace CMCLIS.GATEWAY.CORE.Sercurity
{
    public class Certificate
    {
        public X509Certificate2 GetCertificate()
        {
            try
            {
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certificates = store.Certificates;
                X509Certificate2 current = null;
                X509Certificate2Collection certificates2 = X509Certificate2UI.SelectFromCollection(certificates, "Danh s\x00e1ch chứng thư số", "H\x00e3y chọn chứng thư số của bạn", X509SelectionFlag.SingleSelection);
                if (certificates2.Count > 0)
                {
                    X509Certificate2Enumerator enumerator = certificates2.GetEnumerator();
                    enumerator.MoveNext();
                    current = enumerator.Current;
                }
                store.Close();
                return current;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }

        #region Certificate
        public static List<String> GetX509CertificatedNames()
        {
            try
            {
                List<String> l = new List<string>();
                X509Store oStore;
                oStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                oStore.Open(OpenFlags.ReadOnly);
                foreach (X509Certificate2 x509 in oStore.Certificates)
                {
                    string na = x509.SubjectName.Name.ToString();
                    if (na != "")
                    {
                        l.Add(na);
                    }
                }
                return l;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }
        public static X509Certificate2 GetStoreX509Certificate2(string name)
        {
            try
            {
                X509Certificate2 oX509;
                oX509 = null;
                X509Store oStore;
                oStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                oStore.Open(OpenFlags.ReadOnly);
                foreach (X509Certificate2 x509 in oStore.Certificates)
                {
                    if (x509.SubjectName.Name.ToString() == name)
                    {
                        oX509 = x509;

                    }
                }
                return oX509;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }
        public static X509Certificate2 GetStoreX509Certificate2BySerial(string strSerialNumber)
        {
            try
            {
                X509Certificate2 oX509;
                oX509 = null;
                X509Store oStore;
                oStore = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                oStore.Open(OpenFlags.ReadOnly);
                foreach (X509Certificate2 x509 in oStore.Certificates)
                {
                    if (x509.SerialNumber == strSerialNumber)
                    {
                        oX509 = x509;
                    }
                }
                return oX509;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }

        public static X509Certificate2 GetStoreX509Certificate2ByPathFile(string pathFile)
        {
            
            try
            {                
                X509Certificate2 oX509 = null;
                if (File.Exists(pathFile))
                {
                    oX509 = new X509Certificate2(pathFile, Config.CA_PASSWORD,X509KeyStorageFlags.Exportable | X509KeyStorageFlags.MachineKeySet |X509KeyStorageFlags.PersistKeySet);
                    //oX509 = new X509Certificate2(pathFile,Config.CA_PASSWORD);                   
                }
                return oX509;
            }
            catch (Exception ex)
            {                
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }

        #endregion
    }
}
