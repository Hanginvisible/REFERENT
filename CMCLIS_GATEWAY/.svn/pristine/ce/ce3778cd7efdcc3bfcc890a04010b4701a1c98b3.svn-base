using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using CMCLIS.GATEWAY.SendMail.ExchangeWebServices;
using System.Configuration;
using System.IO;
using CMCLIS.GATEWAY.CORE;

namespace CMCLIS.GATEWAY.SendMail
{
    public class MailService
    {
       
        public static void SendMailFromExchange(string to, string subject, string body,ref bool result)
        {
            
            try
            {
                ServicePointManager.ServerCertificateValidationCallback =
                delegate(Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
                {
                    // Trust any certificate
                    return true;
                };
                String websvr = ConfigurationManager.AppSettings["WEB_SERVICE"];
                String domain = ConfigurationManager.AppSettings["DOMAIN"];
                String cmcsoftmail = ConfigurationManager.AppSettings["CMCSOFT_MAIL"];
                String username = ConfigurationManager.AppSettings["USERNAME"];
                String password = ConfigurationManager.AppSettings["PASSWORD"];

                // Xác định các ràng buộc dịch vụ và người sử dụng.
                ExchangeServiceBinding esb = new ExchangeServiceBinding();
                esb.Credentials = new NetworkCredential(username, password, domain);
                esb.Url = websvr;

                // Chỉ định phiên bản yêu cầu.
                esb.RequestServerVersionValue = new RequestServerVersion();
                esb.RequestServerVersionValue.Version = ExchangeVersionType.Exchange2010_SP1;

                // Tạo yêu cầu CreateItem.
                CreateItemType createEmailRequest = new CreateItemType();

                // Chỉ định các e-mail sẽ được xử lý như thế nào.
                createEmailRequest.MessageDisposition = MessageDispositionType.SendAndSaveCopy;
                createEmailRequest.MessageDispositionSpecified = true;

                // Xác định vị trí của item gửi. 
                createEmailRequest.SavedItemFolderId = new TargetFolderIdType();
                DistinguishedFolderIdType sentitems = new DistinguishedFolderIdType();
                sentitems.Id = DistinguishedFolderIdNameType.sentitems;
                createEmailRequest.SavedItemFolderId.Item = sentitems;

                // Tạo mảng chứa items.
                createEmailRequest.Items = new NonEmptyArrayOfAllItemsType();

                // Tạo 1 message.
                MessageType message = new MessageType();
                message.Subject = subject;
                message.Body = new BodyType();
                message.Body.BodyType1 = BodyTypeType.HTML;
                message.Body.Value = body;
                message.Sender = new SingleRecipientType();
                message.Sender.Item = new EmailAddressType();
                message.Sender.Item.EmailAddress = cmcsoftmail;
                //=== TO ===//

                string[] arrMailTo = to.Split(';');

                message.ToRecipients = new EmailAddressType[arrMailTo.Length];
                for (int i = 0; i < arrMailTo.Length; i++)
                {
                    message.ToRecipients[i] = new EmailAddressType();
                    message.ToRecipients[i].EmailAddress = arrMailTo[i];
                }
               

                //message.ToRecipients = new EmailAddressType[1];
                //message.ToRecipients[0] = new EmailAddressType();
                //message.ToRecipients[0].EmailAddress = to;
                //=== CC ===//
                //message.CcRecipients = new EmailAddressType[1];
                //message.CcRecipients[0] = new EmailAddressType();
                //message.CcRecipients[0].EmailAddress = cmcsoftmail;

                message.Sensitivity = SensitivityChoicesType.Normal;

                // Thêm masage vào mảng item.
                createEmailRequest.Items.Items = new ItemType[1];
                createEmailRequest.Items.Items[0] = message;


                CreateItemResponseType createItemResponse = esb.CreateItem(createEmailRequest);
                ArrayOfResponseMessagesType responses = createItemResponse.ResponseMessages;
                ResponseMessageType[] responseMessages = responses.Items;

                foreach (ResponseMessageType respMsg in responseMessages)
                {
                    if (respMsg.ResponseClass == ResponseClassType.Error)
                    {
                        throw new Exception("Error: " + respMsg.MessageText);
                    }
                    else if (respMsg.ResponseClass == ResponseClassType.Warning)
                    {
                        throw new Exception("Warning: " + respMsg.MessageText);
                    }

                    if (respMsg is ItemInfoResponseMessageType)
                    {
                        ItemInfoResponseMessageType createItemResp = (respMsg as ItemInfoResponseMessageType);
                        ArrayOfRealItemsType aorit = createItemResp.Items;

                        //foreach (ItemType item in aorit.Items)
                        //{
                        //    if (item is MessageType)
                        //    {
                        //        MessageType myMessage = (item as MessageType);
                        //        Console.WriteLine("Created item: " + myMessage.ItemId.Id);
                        //    }
                        //}
                    }
                }
                result = true;
               
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);                
            }
        }

        public static void SendEmailAttachment(string to, string subject, string body, byte[] attachmentAsBytes, string attachmentName, ref bool result)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback =
                delegate(Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
                {
                    // Trust any certificate
                    return true;
                };
                String websvr = ConfigurationManager.AppSettings["WEB_SERVICE"];
                String domain = ConfigurationManager.AppSettings["DOMAIN"];
                String cmcsoftmail = ConfigurationManager.AppSettings["CMCSOFT_MAIL"];
                String username = ConfigurationManager.AppSettings["USERNAME"];
                String password = ConfigurationManager.AppSettings["PASSWORD"];

                // Xác định các ràng buộc dịch vụ và người sử dụng.
                ExchangeServiceBinding esb = new ExchangeServiceBinding();
                esb.Credentials = new NetworkCredential(username, password, domain);
                esb.Url = websvr;

                // Chỉ định phiên bản yêu cầu.
                esb.RequestServerVersionValue = new RequestServerVersion();
                esb.RequestServerVersionValue.Version = ExchangeVersionType.Exchange2007_SP1;

                //Create an email message and initialize it with the from address, to address, subject and the body of the email.
                MessageType email = new MessageType();

                email.From = new SingleRecipientType();
                email.From.Item = new EmailAddressType();
                email.From.Item.EmailAddress = cmcsoftmail;
                string[] arrMailTo = to.Split(';');

                email.ToRecipients = new EmailAddressType[arrMailTo.Length];
                for (int i = 0; i < arrMailTo.Length; i++)
                {
                    email.ToRecipients[i] = new EmailAddressType();
                    email.ToRecipients[i].EmailAddress = arrMailTo[i];
                }
               
                email.Subject = subject;

                email.Body = new BodyType();
                email.Body.BodyType1 = BodyTypeType.Text;
                email.Body.Value = body;

                //Save the created email to the drafts folder so that we can attach a file to it.
                CreateItemType emailToSave = new CreateItemType();
                emailToSave.Items = new NonEmptyArrayOfAllItemsType();
                emailToSave.Items.Items = new ItemType[1];
                emailToSave.Items.Items[0] = email;
                emailToSave.MessageDisposition = MessageDispositionType.SaveOnly;
                emailToSave.MessageDispositionSpecified = true;

                CreateItemResponseType response = esb.CreateItem(emailToSave);
                ResponseMessageType[] rmta = response.ResponseMessages.Items;
                ItemInfoResponseMessageType emailResponseMessage = (ItemInfoResponseMessageType)rmta[0];

                //Create the file attachment.
                FileAttachmentType fileAttachment = new FileAttachmentType();
                fileAttachment.Content = attachmentAsBytes;
                fileAttachment.Name = attachmentName;
                fileAttachment.ContentType = "application/octet-stream";

                CreateAttachmentType attachmentRequest = new CreateAttachmentType();
                attachmentRequest.Attachments = new AttachmentType[1];
                attachmentRequest.Attachments[0] = fileAttachment;
                attachmentRequest.ParentItemId = emailResponseMessage.Items.Items[0].ItemId;

                //Attach the file to the message.
                CreateAttachmentResponseType attachmentResponse = (CreateAttachmentResponseType)esb.CreateAttachment(attachmentRequest);
                AttachmentInfoResponseMessageType attachmentResponseMessage = (AttachmentInfoResponseMessageType)attachmentResponse.ResponseMessages.Items[0];

                //Create a new item id type using the change key and item id of the email message so that we know what email to send.
                ItemIdType attachmentItemId = new ItemIdType();
                attachmentItemId.ChangeKey = attachmentResponseMessage.Attachments[0].AttachmentId.RootItemChangeKey;
                attachmentItemId.Id = attachmentResponseMessage.Attachments[0].AttachmentId.RootItemId;

                //Send the email.
                SendItemType si = new SendItemType();
                si.ItemIds = new BaseItemIdType[1];
                si.SavedItemFolderId = new TargetFolderIdType();
                si.ItemIds[0] = attachmentItemId;
                DistinguishedFolderIdType siSentItemsFolder = new DistinguishedFolderIdType();
                siSentItemsFolder.Id = DistinguishedFolderIdNameType.sentitems;
                si.SavedItemFolderId.Item = siSentItemsFolder;
                si.SaveItemToFolder = true;

                SendItemResponseType siSendItemResponse = esb.SendItem(si);

                result = true;

            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }


        private static bool CertificateValidationCallBack(
         object sender,
         System.Security.Cryptography.X509Certificates.X509Certificate certificate,
         System.Security.Cryptography.X509Certificates.X509Chain chain,
         System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            try
            {
                if (sslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
                {
                    return true;
                }
                if ((sslPolicyErrors & System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors) != 0)
                {
                    if (chain != null && chain.ChainStatus != null)
                    {
                        foreach (System.Security.Cryptography.X509Certificates.X509ChainStatus status in chain.ChainStatus)
                        {
                            if ((certificate.Subject == certificate.Issuer) &&
                               (status.Status == System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.UntrustedRoot))
                            {
                                continue;
                            }
                            else
                            {
                                if (status.Status != System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.NoError)
                                {
                                    return false;
                                }
                            }
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }
    }
}
