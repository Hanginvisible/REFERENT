using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCLIS.CVAN.WServiceReponse
{
    public class MessageSenderInfo
    {
        public string VERSION { get; set; }
        public string SENDER_CODE { get; set; }
        public string SENDER_NAME { get; set; }
        public string RECEIVER_CODE { get; set; }
        public string RECEIVER_NAME { get; set; }
        public string TRAN_CODE { get; set; }
        public string MSG_ID { get; set; }
        public string MSG_REFID { get; set; }
        public string ID_LINK { get; set; }
        public string SEND_DATE { get; set; }
        public string ORIGINAL_CODE { get; set; }
        public string ORIGINAL_NAME { get; set; }
        public string ORIGINAL_DATE { get; set; }
        public string ERROR_CODE { get; set; }
        public string ERROR_DESC { get; set; }
        public string SPARE1 { get; set; }
        public string SPARE2 { get; set; }
        public string SPARE3 { get; set; }
        public string ROW { get; set; }

        public MessageSenderInfo()
        {
            VERSION = string.Empty;
            SENDER_CODE = string.Empty;
            SENDER_NAME = string.Empty;
            RECEIVER_CODE = string.Empty;
            RECEIVER_NAME = string.Empty;
            TRAN_CODE = string.Empty;
            MSG_ID = string.Empty;
            MSG_REFID = string.Empty;
            ID_LINK = string.Empty;
            SEND_DATE = string.Empty;
            ORIGINAL_CODE = string.Empty;
            ORIGINAL_NAME = string.Empty;
            ORIGINAL_DATE = string.Empty;
            ERROR_CODE = string.Empty;
            ERROR_DESC = string.Empty;
            SPARE1 = string.Empty;
            SPARE2 = string.Empty;
            SPARE3 = string.Empty;
            ROW = string.Empty;
        }
    }
}
