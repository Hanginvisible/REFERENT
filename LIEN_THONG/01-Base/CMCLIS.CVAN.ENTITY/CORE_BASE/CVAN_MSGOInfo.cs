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
	//-- Date: 02/12/2020 9:19:02 AM
	//-- Todo: 
	//------------------------------------------------------------------------------------------------------------------------ 
    [Serializable]
    [DataContract]
    public class CVAN_MSGOInfo
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
        [SolrField("CVAN_MSG_TYPE_CODE")]
        [AIField("CVAN_MSG_TYPE_CODE")]
        [DisplayName("CVAN_MSG_TYPE_CODE")]
        public string CVAN_MSG_TYPE_CODE { get; set; }
        [DataMember]
        [SolrField("CVAN_MSG_TYPE_NAME")]
        [AIField("CVAN_MSG_TYPE_NAME")]
        [DisplayName("CVAN_MSG_TYPE_NAME")]
        public string CVAN_MSG_TYPE_NAME { get; set; }
        [DataMember]
        [SolrField("CVAN_CONTENT_XML")]
        [AIField("CVAN_CONTENT_XML")]
        [DisplayName("CVAN_CONTENT_XML")]
        public string CVAN_CONTENT_XML { get; set; }
        [DataMember]
        [SolrField("CVAN_SENDER_CODE")]
        [AIField("CVAN_SENDER_CODE")]
        [DisplayName("CVAN_SENDER_CODE")]
        public string CVAN_SENDER_CODE { get; set; }
        [DataMember]
        [SolrField("CVAN_STATUS_SEND")]
        [AIField("CVAN_STATUS_SEND")]
        [DisplayName("CVAN_STATUS_SEND")]
        public decimal? CVAN_STATUS_SEND { get; set; }
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