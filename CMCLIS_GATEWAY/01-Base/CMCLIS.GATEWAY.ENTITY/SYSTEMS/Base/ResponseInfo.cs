using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CMCLIS.GATEWAY.ENTITY
{
    [Serializable]
    [DataContract]
    public class ResponseInfo<T> where T : new()
    {
        [DataMember]
        [DisplayName("ResultCode")]
        public string ResultCode { get; set; }

        [DataMember]
        [DisplayName("Message")]
        public string Message { get; set; }

        [DataMember]
        [DisplayName("TotalRecords")]
        public int TotalRecords { get; set; }

        [DataMember]
        [DisplayName("Data")]
        public T Data { get; set; }

        public ResponseInfo()
        {
            ResultCode = string.Empty;           
            Message = string.Empty;
            TotalRecords = 0;
            //Data = null;
		}
    }

    //public class ReturnObjectT<T> where T : new()
    //{
    //    public string Message { get; set; }
    //    public T Data
    //    {
    //        get { return (T)Newtonsoft.Json.JsonConvert.DeserializeObject(Message, typeof(T)); }
    //        set;
    //    }
         
    
        
    //}
}
