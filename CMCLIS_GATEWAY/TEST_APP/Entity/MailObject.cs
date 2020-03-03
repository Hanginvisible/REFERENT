using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_APP
{
    public class MailObject
    {
        /// <summary>
        /// tiêu đề
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// email 
        /// </summary>
        public string EmailTo { get; set; }
        /// <summary>
        /// nội dung
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// file đính kèm
        /// </summary>
        public string AttachmentContent { get; set; }
    }
}
