using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CMCLIS.CVAN.ENTITY
{
    [Serializable]
    [DataContract]
    public class Response
    {
        [DataMember]
        [DisplayName("ResultCode")]
        public string ResultCode { get; set; }

        [DataMember]
        [DisplayName("Message")]
        public string Message { get; set; }

        [DataMember]
        [DisplayName("ReturnValue")]
        public string ReturnValue { get; set; }

        public Response()
        {
            ResultCode = string.Empty;           
            Message = string.Empty;
            ReturnValue = string.Empty;            
		}
    }
}
