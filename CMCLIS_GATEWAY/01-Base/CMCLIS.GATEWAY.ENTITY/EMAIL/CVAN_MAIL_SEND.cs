using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCLIS.GATEWAY.ENTITY
{
    /// <summary>
    /// nhtoan3: Cấu hình object mail gửi tới MQ 
    /// </summary>
    [Serializable]
    public class CVAN_MAIL_SEND
    {
        public string Subject { get; set; }
        public string EmailTo { get; set; }
        public string Content { get; set; }
        public List<CVAN_MAIL_ATTACHMENT> Attachment { get; set; }

    }

}
