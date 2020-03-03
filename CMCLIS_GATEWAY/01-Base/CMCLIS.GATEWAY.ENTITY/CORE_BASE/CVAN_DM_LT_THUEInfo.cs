﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using SolrNet.Attributes;
using CMCLIS.GATEWAY.CORE.AILucene;

namespace CMCLIS.GATEWAY.ENTITY
{
	//------------------------------------------------------------------------------------------------------------------------
	//-- Created By: Ngô Văn Nghị
	//-- Date: 02/20/2020 9:30:38 AM
	//-- Todo: 
	//------------------------------------------------------------------------------------------------------------------------ 
    [Serializable]
    [DataContract]
    public class CVAN_DM_LT_THUEInfo
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
        [SolrField("CVAN_NAME")]
        [AIField("CVAN_NAME")]
        [DisplayName("CVAN_NAME")]
        public string CVAN_NAME { get; set; }
        [DataMember]
        [SolrField("CVAN_PARENT")]
        [AIField("CVAN_PARENT")]
        [DisplayName("CVAN_PARENT")]
        public string CVAN_PARENT { get; set; }
        [DataMember]
        [SolrField("CVAN_PARENT_NAME")]
        [AIField("CVAN_PARENT_NAME")]
        [DisplayName("CVAN_PARENT_NAME")]
        public string CVAN_PARENT_NAME { get; set; }
        [DataMember]
        [SolrField("CVAN_DESCRIPTION")]
        [AIField("CVAN_DESCRIPTION")]
        [DisplayName("CVAN_DESCRIPTION")]
        public string CVAN_DESCRIPTION { get; set; }
        [DataMember]
        [SolrField("CVAN_STATUS")]
        [AIField("CVAN_STATUS")]
        [DisplayName("CVAN_STATUS")]
        public bool? CVAN_STATUS { get; set; }
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
