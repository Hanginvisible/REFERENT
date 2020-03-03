using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using SolrNet.Attributes;
using CMCLIS.GATEWAY.CORE.AILucene;

namespace CMCLIS.GATEWAY.ENTITY
{
	//------------------------------------------------------------------------------------------------------------------------
	//-- Created By: Ngô Văn Nghị
	//-- Date: 02/20/2020 9:30:43 AM
	//-- Todo: 
	//------------------------------------------------------------------------------------------------------------------------ 
    [Serializable]
    [DataContract]
    public class LOG_XL_HANG_LOATInfo
    {
        [DataMember]
        [SolrUniqueKey("ID")]
        [AIFieldUnikey("ID")]
        [DisplayName("ID")]
        public decimal? ID { get; set; }

        
        [DataMember]
        [SolrField("USER_NAME")]
        [AIField("USER_NAME")]
        [DisplayName("USER_NAME")]
        public string USER_NAME { get; set; }
        [DataMember]
        [SolrField("FUNCTION_NAME")]
        [AIField("FUNCTION_NAME")]
        [DisplayName("FUNCTION_NAME")]
        public string FUNCTION_NAME { get; set; }
        [DataMember]
        [SolrField("MASTER_DATA")]
        [AIField("MASTER_DATA")]
        [DisplayName("MASTER_DATA")]
        public string MASTER_DATA { get; set; }
        [DataMember]
        [SolrField("TIME")]
        [AIField("TIME")]
        [DisplayName("TIME")]
        public DateTime? TIME { get; set; }
        [DataMember]
        [SolrField("DATA_VOLUME")]
        [AIField("DATA_VOLUME")]
        [DisplayName("DATA_VOLUME")]
        public string DATA_VOLUME { get; set; }
        [DataMember]
        [SolrField("DETAIL")]
        [AIField("DETAIL")]
        [DisplayName("DETAIL")]
        public string DETAIL { get; set; }
        [DataMember]
        [SolrField("IS_DELETE")]
        [AIField("IS_DELETE")]
        [DisplayName("IS_DELETE")]
        public bool? IS_DELETE { get; set; }
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
