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
	//-- Date: 02/20/2020 9:30:43 AM
	//-- Todo: 
	//------------------------------------------------------------------------------------------------------------------------ 
    [Serializable]
    [DataContract]
    public class LOG_TRUY_CAPInfo
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
        [SolrField("LOG_TIME")]
        [AIField("LOG_TIME")]
        [DisplayName("LOG_TIME")]
        public DateTime? LOG_TIME { get; set; }
        [DataMember]
        [SolrField("ACTION")]
        [AIField("ACTION")]
        [DisplayName("ACTION")]
        public string ACTION { get; set; }
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