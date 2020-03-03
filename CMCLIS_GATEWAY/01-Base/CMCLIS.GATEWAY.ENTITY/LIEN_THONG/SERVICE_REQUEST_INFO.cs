using System.ComponentModel;
using System.Runtime.Serialization;

namespace CMCLIS.GATEWAY.ENTITY.LIEN_THONG
{
    /// <summary>
    /// nhtoan3: Cấu hình object message gửi tới MQ 
    /// </summary>
    public class SERVICE_REQUEST_INFO
    {
        [DataMember]
        [DisplayName("MESSAGE_TYPE")]
        public string MESSAGE_TYPE { get; set; }
        [DataMember]
        [DisplayName("XML_CONTENT")]
        public string XML_CONTENT { get; set; }
        public SERVICE_REQUEST_INFO()
        {
            MESSAGE_TYPE = string.Empty;
            XML_CONTENT = string.Empty;
        }
    }
}
