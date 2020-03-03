using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;

namespace CMCLIS.CVAN.CORE.Sercurity
{
    public class CreateDigitalSignature
    {
        #region Excell

        public static bool ValidateSignatureExcel(string pathFileExcel)
        {
            try
            {
                Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook(pathFileExcel);
                ////wb.IsDigitallySigned is true when the workbook is signed already.
                //System.Console.WriteLine(wb.IsDigitallySigned);
                ////get digitalSignature collection from workbook
                //Aspose.Cells.DigitalSignatures.DigitalSignatureCollection dsc = wb.GetDigitalSignature();
                //foreach (Aspose.Cells.DigitalSignatures.DigitalSignature ds in dsc)
                //{
                //    System.Console.WriteLine(ds.Comments);
                //    System.Console.WriteLine(ds.SignTime);
                //    System.Console.WriteLine(ds.IsValid);
                //}
                return wb.IsDigitallySigned;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        public static bool SignSignatureExcel(X509Certificate2 cert, string pathInput, string pathOutput)
        {
            try
            {
                //dsc is signature collection contains one or more signature needed to sign
                Aspose.Cells.DigitalSignatures.DigitalSignatureCollection dsc = new Aspose.Cells.DigitalSignatures.DigitalSignatureCollection();
                //cert must contain private key, it can be contructed from cert file or windows certificate collection.
                //123456 is password of cert
                //X509Certificate2 cert = new X509Certificate2("c:\\mykey2.pfx", "123456");
                Aspose.Cells.DigitalSignatures.DigitalSignature ds = new Aspose.Cells.DigitalSignatures.DigitalSignature(cert, cert.Subject, DateTime.Now);
                dsc.Add(ds);
                Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook(pathInput);
                //wb.SetDigitalSignature sign all signatures in dsc
                wb.SetDigitalSignature(dsc);
                wb.Save(pathOutput);
                return true;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        #endregion

        #region Word

        public static bool ValidateSignatureWord(string pathFileWord)
        {
            try
            {
                bool value = false;
                Aspose.Words.Document doc = new Aspose.Words.Document(pathFileWord);
                foreach (Aspose.Words.DigitalSignature signature in doc.DigitalSignatures)
                {
                    value = signature.IsValid;
                    //Console.WriteLine("*** Signature Found ***");
                    //Console.WriteLine("Is valid: " + signature.IsValid);
                    //Console.WriteLine("Reason for signing: " + signature.Comments); // This property is available in MS Word documents only.
                    //Console.WriteLine("Time of signing: " + signature.SignTime);
                    //Console.WriteLine("Subject name: " + signature.Certificate.SubjectName.Name);
                    //Console.WriteLine("Issuer name: " + signature.Certificate.IssuerName.Name);
                    //Console.WriteLine();
                }
                return value;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        public static bool SignSignatureWord(X509Certificate2 cert, string pathInput, string pathOutput)
        {

            try
            {
                //X509Certificate2 cert = new X509Certificate2("c:\\mykey2.pfx", "123456");
                if (cert != null)
                {
                    Aspose.Words.DigitalSignatureUtil.Sign(pathInput, pathOutput, cert, cert.Subject, new DateTime());
                }
                return true;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        #endregion

        #region PDF

        public static bool SignSignaturePDF(X509Certificate2 cert,string titleReason,string pathImageSign,bool visibleSign, string pathInput, string pathOutput)
        {

            try
            {
                if (cert != null)
                {
                    Org.BouncyCastle.X509.X509CertificateParser cp = new Org.BouncyCastle.X509.X509CertificateParser();
                    Org.BouncyCastle.X509.X509Certificate[] chain = new Org.BouncyCastle.X509.X509Certificate[] { cp.ReadCertificate(cert.RawData) };

                    X509Chain x509chain = new X509Chain();
                    x509chain.Build(cert);

                    PdfReader reader = new PdfReader(pathInput);
                    FileStream resStream = new FileStream(pathOutput, FileMode.Create, FileAccess.ReadWrite);

                    PdfStamper stamper = PdfStamper.CreateSignature(reader, resStream, '\0', null, true);

                    PdfSignatureAppearance appearance = stamper.SignatureAppearance;
                    appearance.Reason = titleReason;
                    appearance.Location = cert.Subject;
                    //Cho Img vào
                    iTextSharp.text.Image signatureFieldImage = iTextSharp.text.Image.GetInstance(pathImageSign);
                    appearance.SignatureGraphic = signatureFieldImage;
                    appearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.GRAPHIC;
                    //end
                    if(visibleSign)
                        appearance.SetVisibleSignature(new iTextSharp.text.Rectangle(20, 10, 170, 60), 1, "Signed");
                    X509Certificate2Signature es = new X509Certificate2Signature(cert, "SHA-1");
                    MakeSignature.SignDetached(appearance, es, chain, null, null, null, 0, CryptoStandard.CMS);
                }
                return true;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        #endregion

        #region XML
        private static void SetPrefix(string prefix, XmlNode node)
        {
            node.Prefix = prefix;
            foreach (XmlNode n in node.ChildNodes)
            {
                SetPrefix(prefix, n);
            }
        }

        private static void ReplaceSignature(XmlElement signature, string newValue)
        {
            //if (signature == null) throw new ArgumentNullException(nameof(signature));
            //if (signature.OwnerDocument == null) throw new ArgumentException("No owner document", nameof(signature));

            XmlNamespaceManager nsm = new XmlNamespaceManager(signature.OwnerDocument.NameTable);
            nsm.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);

            XmlNode signatureValue = signature.SelectSingleNode("ds:SignatureValue", nsm);
            if (signatureValue == null)
                throw new Exception("Signature does not contain 'ds:SignatureValue'");

            signatureValue.InnerXml = newValue;
        }
        public static XmlDocument SignSignatureXml(XmlDocument Document, X509Certificate2 cert, string xpathSigned, bool signatureTransform)
        {
            try
            {
                Document.PreserveWhitespace = true;
                // transformation cert -> key omitted
                //RSACryptoServiceProvider key = (RSACryptoServiceProvider)cert.PublicKey.Key;
                //RSAKeyValue rkv = new RSAKeyValue(key);

                // Create a SignedXml object. 
                SignedXml signedXml = new SignedXml(Document);

                // Add the key to the SignedXml document. 
                //signedXml.SigningKey = key;
                signedXml.SigningKey = cert.PrivateKey ;
                //signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
                //signedXml.SignedInfo.CanonicalizationMethod = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315";// SignedXml.XmlDsigExcC14NTransformUrl;

                // Create a reference to be signed. 
                Reference reference = new Reference();
                reference.Uri = "#_NODE_TO_SIGN";
                //reference.DigestMethod = "http://www.w3.org/2000/09/xmldsig#sha1";
                //reference.DigestValue = Encoding.ASCII.GetBytes("eJmqtAgU5mdziKJvGQ0bQ5Nbn4I=");
                // Add an enveloped transformation to the reference. 
                reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
                //reference.AddTransform(new XmlDsigExcC14NTransform());
                signedXml.AddReference(reference);

                KeyInfo keyInfo = new KeyInfo();
                KeyInfoX509Data keyInfoData = new KeyInfoX509Data(cert);
                //keyInfoData.AddIssuerSerial(cert.IssuerName.Format(false), cert.SerialNumber);
                keyInfo.AddClause(keyInfoData);
                //keyInfo.AddClause(rkv);
                signedXml.KeyInfo = keyInfo;

                // Compute the signature. 
                signedXml.ComputeSignature();

                // Add prefix "ds:" to signature
                XmlElement signature = signedXml.GetXml();
                SetPrefix("ds", signature);

                // Load modified signature back
                signedXml.LoadXml(signature);

                // this is workaround for overcoming a bug in the library
                signedXml.SignedInfo.References.Clear();

                // Recompute the signature
                signedXml.ComputeSignature();
                string recomputedSignature = Convert.ToBase64String(signedXml.SignatureValue);

                // Replace value of the signature with recomputed one
                ReplaceSignature(signature, recomputedSignature);
                string namespaceURI = Document.DocumentElement.NamespaceURI;
                if (!string.IsNullOrEmpty(namespaceURI))
                {
                    XmlNamespaceManager nsmgr = new XmlNamespaceManager(Document.NameTable);
                    nsmgr.AddNamespace("NamespaceCode", namespaceURI);
                    Document.SelectSingleNode(xpathSigned, nsmgr).AppendChild(signature);
                }
                else
                {
                    Document.SelectSingleNode(xpathSigned).AppendChild(signature);
                }

                //Document.SelectSingleNode("//NamespaceCode:CKyDTu", nsmgr).AppendChild(xmlDigitalSignature);
                //Document.SelectSingleNode(xpathSigned).AppendChild(xmlDigitalSignature);


                return Document;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }

        //public static XmlDocument SignSignatureXml(XmlDocument Document, X509Certificate2 cer, string xpathSigned, bool signatureTransform)
        //{
        //    try
        //    {
        //        Document.PreserveWhitespace = true;
        //        SignedXml signedXml = new SignedXml(Document);
        //        signedXml.SigningKey = cer.PrivateKey;
        //        signedXml.Signature.Id = "sigid";
        //        KeyInfo keyInfo = new KeyInfo();
        //        RSACryptoServiceProvider rsaprovider = (RSACryptoServiceProvider)cer.PublicKey.Key;
        //        RSAKeyValue rkv = new RSAKeyValue(rsaprovider);
        //        keyInfo.AddClause(rkv);
        //        //keyInfo.AddClause(keyInfoData);
        //        KeyInfoX509Data keyInfoData = new KeyInfoX509Data(cer);
        //        string subjectName = cer.IssuerName.Name.ToString();
        //        keyInfoData.AddSubjectName(subjectName);

        //        keyInfo.AddClause(keyInfoData);
        //        signedXml.KeyInfo = keyInfo;
        //        XmlElement signaturePropertiesRoot = null;
        //        signaturePropertiesRoot = Document.CreateElement("SignatureProperties", "");
        //        signaturePropertiesRoot.SetAttribute("Id", "sigid");

        //        XmlElement signatureProperty = null;
        //        signatureProperty = Document.CreateElement("SignatureProperty", "");
        //        signatureProperty.SetAttribute("Target", "#sigid");

        //        XmlElement signingTime = null;
        //        signingTime = Document.CreateElement("SigningTime", "http://example.org/#signatureProperties");
        //        signingTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //        signatureProperty.AppendChild(signingTime);

        //        signaturePropertiesRoot.AppendChild(signatureProperty);

        //        DataObject signatureProperties = new DataObject();
        //        signatureProperties.Data = signaturePropertiesRoot.SelectNodes(".");
        //        signedXml.AddObject(signatureProperties);

        //        Reference reference = new Reference();
        //        reference.Uri = "";//#NODE_TO_SIGN

        //        // Create a reference to be signed.
        //        if (signatureTransform)
        //        {
        //            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform(true);
        //            reference.AddTransform(env);
        //        }
        //        signedXml.AddReference(reference);
        //        // Compute the signature.
        //        signedXml.ComputeSignature();
        //        // Get the XML representation of the signature and save 
        //        // it to an XmlElement object.
        //        XmlElement xmlDigitalSignature = signedXml.GetXml();
        //        Document.SelectSingleNode(xpathSigned).AppendChild(xmlDigitalSignature);


        //        return Document;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
        //        return null;
        //    }
        //}

        // Verify the signature of an XML file against an asymetric 
        // algorithm and return the result.
        public static bool VerifyXmlFile(XmlDocument xmlDocument, X509Certificate2 cer)
        {
            try
            {
                // Create a new SignedXml object and pass it
                // the XML document class.
                SignedXml signedXml = new SignedXml(xmlDocument);

                // Find the "Signature" node and create a new
                // XmlNodeList object.
                XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature");

                // Load the signature node.
                signedXml.LoadXml((XmlElement)nodeList[0]);

                // Check the signature and return the result.
                return signedXml.CheckSignature(cer, true);
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }

        }

        #endregion
    }
}
