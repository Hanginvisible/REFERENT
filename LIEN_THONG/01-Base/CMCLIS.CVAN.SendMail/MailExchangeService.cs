using CMCLIS.CVAN.CORE;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CMCLIS.CVAN.SendMail
{
    public class MailExchangeService
    {

        public static void SentEmail(string to, string subject, string body, ref bool result)
        {
            try
            {
                String websvr = ConfigurationManager.AppSettings["WEB_SERVICE"];
                String domain = ConfigurationManager.AppSettings["DOMAIN"];
                String cmcsoftmail = ConfigurationManager.AppSettings["CMCSOFT_MAIL"];
                String username = ConfigurationManager.AppSettings["USERNAME"];
                String password = ConfigurationManager.AppSettings["PASSWORD"];
                ServicePointManager.ServerCertificateValidationCallback = CertificateValidationCallBack;
                ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
                service.Credentials = new WebCredentials(username, password, domain);

                // service.AutodiscoverUrl("username@yourdomain.com", RedirectionUrlValidationCallback);
                service.Url = new System.Uri(websvr);

                EmailMessage email = new EmailMessage(service);
                email.ToRecipients.Add(to);
                email.Subject = subject;
                email.Body = new MessageBody(BodyType.HTML, body);

                email.Send();
                result = true;
                //return statusMsg;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }

        }

        public static string GetEmail()
        {
            try
            {
                string statusMsg = "emails grabbed!";
                String websvr = ConfigurationManager.AppSettings["WEB_SERVICE"];
                String domain = ConfigurationManager.AppSettings["DOMAIN"];
                String cmcsoftmail = ConfigurationManager.AppSettings["CMCSOFT_MAIL"];
                String username = ConfigurationManager.AppSettings["USERNAME"];
                String password = ConfigurationManager.AppSettings["PASSWORD"];
                ServicePointManager.ServerCertificateValidationCallback = CertificateValidationCallBack;

                ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
                service.Credentials = new WebCredentials(username, password, domain);
                // service.AutodiscoverUrl("username@yourdomain.com", RedirectionUrlValidationCallback);
                service.Url = new System.Uri(websvr);

                //filter
                // Add a search filter that searches on the body or subject.
                List<SearchFilter> searchFilterCollection = new List<SearchFilter>();
                searchFilterCollection.Add(new SearchFilter.ContainsSubstring(ItemSchema.Subject, "A Subject"));
                //searchFilterCollection.Add(new SearchFilter.ContainsSubstring(ItemSchema.Body, "Some Body"));

                // Create the search filter.
                SearchFilter searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.Or, searchFilterCollection.ToArray());

                var inbox = new FolderId(WellKnownFolderName.Inbox);
                var iv = new ItemView(10);

                var items = service.FindItems(inbox, searchFilter, iv);

                statusMsg = items.TotalCount.ToString();

                foreach (EmailMessage msg in items.Take(10))
                {

                    statusMsg = statusMsg + msg.Subject + " -- ";

                }

                return statusMsg;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return string.Empty;
            }

        }

        private static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            // The default for the validation callback is to reject the URL.
            bool result = false;

            Uri redirectionUri = new Uri(redirectionUrl);

            // Validate the contents of the redirection URL. In this simple validation
            // callback, the redirection URL is considered valid if it is using HTTPS
            // to encrypt the authentication credentials. 
            if (redirectionUri.Scheme == "https")
            {
                result = true;
            }
            return result;
        }

        private static bool CertificateValidationCallBack(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            // If the certificate is a valid, signed certificate, return true.
            if (sslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
            {
                return true;
            }

            // If there are errors in the certificate chain, look at each error to determine the cause.
            if ((sslPolicyErrors & System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors) != 0)
            {
                if (chain != null && chain.ChainStatus != null)
                {
                    foreach (System.Security.Cryptography.X509Certificates.X509ChainStatus status in chain.ChainStatus)
                    {
                        if ((certificate.Subject == certificate.Issuer) &&
                           (status.Status == System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.UntrustedRoot))
                        {
                            // Self-signed certificates with an untrusted root are valid. 
                            continue;
                        }
                        else
                        {
                            if (status.Status != System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.NoError)
                            {
                                // If there are any other errors in the certificate chain, the certificate is invalid,
                                // so the method returns false.
                                return false;
                            }
                        }
                    }
                }

                // When processing reaches this line, the only errors in the certificate chain are 
                // untrusted root errors for self-signed certificates. These certificates are valid
                // for default Exchange server installations, so return true.
                return true;
            }
            else
            {
                // In all other cases, return false.
                return false;
            }
        }
    }
}
