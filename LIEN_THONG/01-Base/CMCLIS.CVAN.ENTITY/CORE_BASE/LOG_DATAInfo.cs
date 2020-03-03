using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using SolrNet.Attributes;
using CMCLIS.CVAN.CORE.AILucene;

namespace CMCLIS.CVAN.ENTITY
{
	//------------------------------------------------------------------------------------------------------------------------
	//-- Created By: Ngô Văn Nghị
	//-- Date: 02/13/2020 3:03:29 PM
	//-- Todo: 
	//------------------------------------------------------------------------------------------------------------------------ 
    [Serializable]
    [DataContract]
    public class LOG_DATAInfo
    {
        [DataMember]
        [SolrUniqueKey("ID")]
        [AIFieldUnikey("ID")]
        [DisplayName("ID")]
        public decimal? ID { get; set; }

        
        [DataMember]
        [SolrField("IP")]
        [AIField("IP")]
        [DisplayName("IP")]
        public string IP { get; set; }
        [DataMember]
        [SolrField("PORT")]
        [AIField("PORT")]
        [DisplayName("PORT")]
        public decimal? PORT { get; set; }
        [DataMember]
        [SolrField("APPLICATION_NAME")]
        [AIField("APPLICATION_NAME")]
        [DisplayName("APPLICATION_NAME")]
        public string APPLICATION_NAME { get; set; }
        [DataMember]
        [SolrField("MESSAGE")]
        [AIField("MESSAGE")]
        [DisplayName("MESSAGE")]
        public string MESSAGE { get; set; }
        [DataMember]
        [SolrField("LOG_TYPE")]
        [AIField("LOG_TYPE")]
        [DisplayName("LOG_TYPE")]
        public bool? LOG_TYPE { get; set; }
        [DataMember]
        [SolrField("CDATE")]
        [AIField("CDATE")]
        [DisplayName("CDATE")]
        public DateTime? CDATE { get; set; }
        [DataMember]
        [SolrField("LDATE")]
        [AIField("LDATE")]
        [DisplayName("LDATE")]
        public DateTime? LDATE { get; set; }
        [DataMember]
        [SolrField("CUSER")]
        [AIField("CUSER")]
        [DisplayName("CUSER")]
        public string CUSER { get; set; }
        [DataMember]
        [SolrField("LUSER")]
        [AIField("LUSER")]
        [DisplayName("LUSER")]
        public string LUSER { get; set; }
		
        [DataMember]
        [SolrField("STT")]
        [AIField("STT")]
        [DisplayName("STT")]
        public decimal STT { get; set; }

        
    }
}
