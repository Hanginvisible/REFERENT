﻿using System;
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
    public class CVAN_MAILInfo
    {
        [DataMember]
        [SolrUniqueKey("ID")]
        [AIFieldUnikey("ID")]
        [DisplayName("ID")]
        public decimal? ID { get; set; }

        
        [DataMember]
        [SolrField("CVAN_FROM")]
        [AIField("CVAN_FROM")]
        [DisplayName("CVAN_FROM")]
        public string CVAN_FROM { get; set; }
        [DataMember]
        [SolrField("CVAN_TO")]
        [AIField("CVAN_TO")]
        [DisplayName("CVAN_TO")]
        public string CVAN_TO { get; set; }
        [DataMember]
        [SolrField("CVAN_SUBJECT")]
        [AIField("CVAN_SUBJECT")]
        [DisplayName("CVAN_SUBJECT")]
        public string CVAN_SUBJECT { get; set; }
        [DataMember]
        [SolrField("CVAN_CONTENT")]
        [AIField("CVAN_CONTENT")]
        [DisplayName("CVAN_CONTENT")]
        public string CVAN_CONTENT { get; set; }
        [DataMember]
        [SolrField("CVAN_TYPE_CODE")]
        [AIField("CVAN_TYPE_CODE")]
        [DisplayName("CVAN_TYPE_CODE")]
        public string CVAN_TYPE_CODE { get; set; }
        [DataMember]
        [SolrField("CVAN_TYPE_NAME")]
        [AIField("CVAN_TYPE_NAME")]
        [DisplayName("CVAN_TYPE_NAME")]
        public string CVAN_TYPE_NAME { get; set; }
        [DataMember]
        [SolrField("CVAN_DESCRIPTION")]
        [AIField("CVAN_DESCRIPTION")]
        [DisplayName("CVAN_DESCRIPTION")]
        public string CVAN_DESCRIPTION { get; set; }
        [DataMember]
        [SolrField("CVAN_STATUS")]
        [AIField("CVAN_STATUS")]
        [DisplayName("CVAN_STATUS")]
        public decimal? CVAN_STATUS { get; set; }
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
