﻿using System;
using System.Collections.Generic;
using SolrNet;
using Lucene.Net.QueryParsers;
using Lucene.Net.Analysis.Standard;
using Oracle.DataAccess.Client;
using CMCLIS.GATEWAY.ENTITY;
using CMCLIS.GATEWAY.SETTING;
using CMCLIS.GATEWAY.CORE;
using CMCLIS.GATEWAY.CORE.Provider;
using CMCLIS.GATEWAY.CORE.Solr;

namespace CMCLIS.GATEWAY.DATA.OBJECTS
{
	//------------------------------------------------------------------------------------------------------------------------
	//-- Created By: Ngô Văn Nghị
	//-- Date: 02/21/2020 9:29:02 AM
	//-- Todo: 
	//------------------------------------------------------------------------------------------------------------------------ 
    public class LOG_CHUC_NANGDao : OracleBaseImpl<LOG_CHUC_NANGInfo>
    {
        protected override void SetInfoDerivedClass()
        {
			TableName = "LOG_CHUC_NANG";
			PackageName = "PK_LOG_CHUC_NANG";
			ConnectionString = Config.DictConnectionString[Constant.CONNECTION_STRING_DATA_ORACLE];            
            LuceneIndexData = Config.ORACLEGetInfoIndexLucene.ContainsKey(TableName) ? Config.ORACLEGetInfoIndexLucene[TableName] : Config.ORACLESetIndexLucene(TableName)[TableName];			
        }

        #region relationship support
       
        #endregion

        #region Get List

        public List<LOG_CHUC_NANGInfo> LOG_CHUC_NANG_GetAllWithPadding(string _USER_NAME,string _FUNCTION_NAME,string _ACTION,DateTime _TIME_START_DATE,DateTime _TIME_END_DATE,int _IS_DELETE,int pageIndex, int pageSize,ref int totalRecord)
        {
            OracleParameter[] sqlParam = {
                                        new OracleParameter("p_USER_NAME",_USER_NAME),
                                        new OracleParameter("p_FUNCTION_NAME",_FUNCTION_NAME),
                                        new OracleParameter("p_ACTION",_ACTION),
                                        new OracleParameter("p_TIME_START_DATE",_TIME_START_DATE),
                                        new OracleParameter("p_TIME_END_DATE",_TIME_END_DATE),
                                        new OracleParameter("p_IS_DELETE",_IS_DELETE),
                                    };
            try
            {
                List<LOG_CHUC_NANGInfo> list = this.ExecuteQuery("usp_GET_ALL_WITH_PADDING", sqlParam, pageIndex, pageSize, ref totalRecord);
                return list;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }

        }

        #endregion
		
		#region Using Lucene
		
		 public List<LOG_CHUC_NANGInfo> LOG_CHUC_NANG_GetListByLucene(string keyword, int selectTop)
        {
            try
            {
                string[] fieldSelect = {"ID","USER_NAME","FUNCTION_NAME","ACTION","TIME","ERROR","IS_DELETE","CDATE","LDATE","CUSER","LUSER"};
                var parser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_29, fieldSelect, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
                parser.SetAllowLeadingWildcard(true);
                parser.SetDefaultOperator(QueryParser.Operator.OR);
                keyword = keyword + "*";
                var q = parser.Parse(keyword);
                return this.Search(q, null, null, selectTop, false);
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return null;
           }
        }
		#endregion
		
		#region Using Solr
		
		 public LOG_CHUC_NANGInfo LOG_CHUC_NANG_QuerySolr_GetInfo()
		 {
		     try
		     {
		         List<ISolrQuery> lstFilter = new List<ISolrQuery>();
		         List<SortOrder> lstOrder = new List<SortOrder>();
		         lstOrder.Add(new SortOrder("ID", Order.DESC));
                string[] fieldSelect = {"ID","USER_NAME","FUNCTION_NAME","ACTION","TIME","ERROR","IS_DELETE","CDATE","LDATE","CUSER","LUSER"};
		         int totalRecord = 0;
		         List<LOG_CHUC_NANGInfo> results = QuerySolrBase<LOG_CHUC_NANGInfo>.QuerySolr_GetAllWithPadding(Config.SOLR_URL_CORE_BASE + "LOG_CHUC_NANG/", string.Empty, lstFilter, fieldSelect, lstOrder, 0, int.Parse(Config.SOLR_PAGE_SIZE), ref totalRecord);
		         if (results != null && results.Count > 0)
		         {
		             return results[0];
		         }
		         return null;
		     }
		     catch (Exception ex)
		     {
		         LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
		         return null;
		     }
		 }

		 public List<LOG_CHUC_NANGInfo> LOG_CHUC_NANG_QuerySolr_GetAllWithPadding(string keyword, string _USER_NAME,string _FUNCTION_NAME,string _ACTION,DateTime? _TIME_START_DATE,DateTime? _TIME_END_DATE,int _IS_DELETE, int pageIndex, int pageSize,ref int totalRecord)
		 {
		     try
		     {
		         List<ISolrQuery> lstFilter = new List<ISolrQuery>();
		         if (!string.IsNullOrEmpty(_USER_NAME))
		         {
		             lstFilter.Add(new SolrQuery("USER_NAME:" + _USER_NAME));
		         }
		         if (!string.IsNullOrEmpty(_FUNCTION_NAME))
		         {
		             lstFilter.Add(new SolrQuery("FUNCTION_NAME:" + _FUNCTION_NAME));
		         }
		         if (!string.IsNullOrEmpty(_ACTION))
		         {
		             lstFilter.Add(new SolrQuery("ACTION:" + _ACTION));
		         }
		         if (_TIME_START_DATE != null && _TIME_END_DATE != null)
		         {
		             lstFilter.Add(new SolrQuery("TIME:[" + Utility.GetJSONZFromUserDateTime(_TIME_START_DATE.Value) + " TO " + Utility.GetJSONZFromUserDateTime(_TIME_END_DATE.Value) + "]"));
		         }
		         if (_IS_DELETE != -1)
		         {
		            if(_IS_DELETE == 1)
		            {
		                lstFilter.Add(new SolrQuery("IS_DELETE:true"));
		            }
		            else if (_IS_DELETE == 0)
		            {
		                lstFilter.Add(new SolrQuery("IS_DELETE:false"));
		            }
		         }
		         List<SortOrder> lstOrder = new List<SortOrder>();
		         lstOrder.Add(new SortOrder("ID", Order.DESC));
                string[] fieldSelect = {"ID","USER_NAME","FUNCTION_NAME","ACTION","TIME","ERROR","IS_DELETE","CDATE","LDATE","CUSER","LUSER"};
		         List<LOG_CHUC_NANGInfo> results = QuerySolrBase<LOG_CHUC_NANGInfo>.QuerySolr_GetAllWithPadding(Config.SOLR_URL_CORE_BASE + "LOG_CHUC_NANG/", keyword, lstFilter, fieldSelect, lstOrder, pageIndex - 1, pageSize, ref totalRecord);
		         List<LOG_CHUC_NANGInfo> listAddRange = new List<LOG_CHUC_NANGInfo>();
		         if (listAddRange != null)
		             listAddRange.AddRange(results);
		         return listAddRange;
		     }
		     catch (Exception ex)
		     {
		         LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
		         return null;
		     }
		 }
		#endregion
		
        #region User defined

        #endregion


    }
}