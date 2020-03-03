using System.Collections.Generic;

namespace CMCLIS.GATEWAY.ENTITY
{
    /// <summary>
    /// nhtoan3: Cấu hình object mail
    /// </summary>
    public class CVAN_MAIL
    {
        public CVAN_MAIL()
        {

        }
        public string Subject { get; set; }
        public string EmailTo { get; set; }
        public string Content { get; set; }
        public List<CVAN_MAIL_ATTACHMENT> Attachment { get; set; }
        public string SenderName { get; set; }
        public string TypeCode { get; set; }
    }

    public class CVAN_MAIL_ATTACHMENT
    {
        public string FileName { get; set; }
        //base 64
        public string Content { get; set; }
        public string Extension { get; set; }
    }
}
