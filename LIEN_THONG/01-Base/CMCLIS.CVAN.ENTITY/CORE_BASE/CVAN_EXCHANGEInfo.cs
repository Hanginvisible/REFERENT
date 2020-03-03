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
	//-- Date: 02/12/2020 9:19:01 AM
	//-- Todo: 
	//------------------------------------------------------------------------------------------------------------------------ 
    [Serializable]
    [DataContract]
    public class CVAN_EXCHANGEInfo
    {
        [DataMember]
        [SolrUniqueKey("ID")]
        [AIFieldUnikey("ID")]
        [DisplayName("ID")]
        public decimal? ID { get; set; }

        
        [DataMember]
        [SolrField("CVAN_CODE")]
        [AIField("CVAN_CODE")]
        [DisplayName("CVAN_CODE")]
        public string CVAN_CODE { get; set; }
        [DataMember]
        [SolrField("CVAN_CONTENT_XML")]
        [AIField("CVAN_CONTENT_XML")]
        [DisplayName("CVAN_CONTENT_XML")]
        public string CVAN_CONTENT_XML { get; set; }
        [DataMember]
        [SolrField("CVAN_STATUS_CODE")]
        [AIField("CVAN_STATUS_CODE")]
        [DisplayName("CVAN_STATUS_CODE")]
        public string CVAN_STATUS_CODE { get; set; }
        [DataMember]
        [SolrField("CVAN_LAN_GUI")]
        [AIField("CVAN_LAN_GUI")]
        [DisplayName("CVAN_LAN_GUI")]
        public decimal? CVAN_LAN_GUI { get; set; }
        [DataMember]
        [SolrField("CVAN_MA_GD")]
        [AIField("CVAN_MA_GD")]
        [DisplayName("CVAN_MA_GD")]
        public string CVAN_MA_GD { get; set; }
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
