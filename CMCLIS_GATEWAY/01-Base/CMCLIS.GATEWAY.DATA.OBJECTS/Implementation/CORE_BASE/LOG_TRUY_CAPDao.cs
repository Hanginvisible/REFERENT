using System;
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
	//-- Date: 02/21/2020 9:29:04 AM
	//-- Todo: 
	//------------------------------------------------------------------------------------------------------------------------ 
    public class LOG_TRUY_CAPDao : OracleBaseImpl<LOG_TRUY_CAPInfo>
    {
        protected override void SetInfoDerivedClass()
        {
			TableName = "LOG_TRUY_CAP";
			PackageName = "PK_LOG_TRUY_CAP";
			ConnectionString = Config.DictConnectionString[Constant.CONNECTION_STRING_DATA_ORACLE];            
            LuceneIndexData = Config.ORACLEGetInfoIndexLucene.ContainsKey(TableName) ? Config.ORACLEGetInfoIndexLucene[TableName] : Config.ORACLESetIndexLucene(TableName)[TableName];			
        }

        #region relationship support
       
        #endregion

        #region Get List

        public List<LOG_TRUY_CAPInfo> LOG_TRUY_CAP_GetAllWithPadding(string _USER_NAME,DateTime _LOG_TIME_START_DATE,DateTime _LOG_TIME_END_DATE,string _ACTION,int _IS_DELETE,int pageIndex, int pageSize,ref int totalRecord)
        {
            OracleParameter[] sqlParam = {
                                        new OracleParameter("p_USER_NAME",_USER_NAME),
                                        new OracleParameter("p_LOG_TIME_START_DATE",_LOG_TIME_START_DATE),
                                        new OracleParameter("p_LOG_TIME_END_DATE",_LOG_TIME_END_DATE),
                                        new OracleParameter("p_ACTION",_ACTION),
                                        new OracleParameter("p_IS_DELETE",_IS_DELETE),
                                    };
            try
            {
                List<LOG_TRUY_CAPInfo> list = this.ExecuteQuery("usp_GET_ALL_WITH_PADDING", sqlParam, pageIndex, pageSize, ref totalRecord);
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
		
		 public List<LOG_TRUY_CAPInfo> LOG_TRUY_CAP_GetListByLucene(string keyword, int selectTop)
        {
            try
            {
                string[] fieldSelect = {"ID","USER_NAME","LOG_TIME","ACTION","IS_DELETE","CDATE","LDATE","CUSER","LUSER"};
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
		
		 public LOG_TRUY_CAPInfo LOG_TRUY_CAP_QuerySolr_GetInfo()
		 {
		     try
		     {
		         List<ISolrQuery> lstFilter = new List<ISolrQuery>();
		         List<SortOrder> lstOrder = new List<SortOrder>();
		         lstOrder.Add(new SortOrder("ID", Order.DESC));
                string[] fieldSelect = {"ID","USER_NAME","LOG_TIME","ACTION","IS_DELETE","CDATE","LDATE","CUSER","LUSER"};
		         int totalRecord = 0;
		         List<LOG_TRUY_CAPInfo> results = QuerySolrBase<LOG_TRUY_CAPInfo>.QuerySolr_GetAllWithPadding(Config.SOLR_URL_CORE_BASE + "LOG_TRUY_CAP/", string.Empty, lstFilter, fieldSelect, lstOrder, 0, int.Parse(Config.SOLR_PAGE_SIZE), ref totalRecord);
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

		 public List<LOG_TRUY_CAPInfo> LOG_TRUY_CAP_QuerySolr_GetAllWithPadding(string keyword, string _USER_NAME,DateTime? _LOG_TIME_START_DATE,DateTime? _LOG_TIME_END_DATE,string _ACTION,int _IS_DELETE, int pageIndex, int pageSize,ref int totalRecord)
		 {
		     try
		     {
		         List<ISolrQuery> lstFilter = new List<ISolrQuery>();
		         if (!string.IsNullOrEmpty(_USER_NAME))
		         {
		             lstFilter.Add(new SolrQuery("USER_NAME:" + _USER_NAME));
		         }
		         if (_LOG_TIME_START_DATE != null && _LOG_TIME_END_DATE != null)
		         {
		             lstFilter.Add(new SolrQuery("LOG_TIME:[" + Utility.GetJSONZFromUserDateTime(_LOG_TIME_START_DATE.Value) + " TO " + Utility.GetJSONZFromUserDateTime(_LOG_TIME_END_DATE.Value) + "]"));
		         }
		         if (!string.IsNullOrEmpty(_ACTION))
		         {
		             lstFilter.Add(new SolrQuery("ACTION:" + _ACTION));
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
                string[] fieldSelect = {"ID","USER_NAME","LOG_TIME","ACTION","IS_DELETE","CDATE","LDATE","CUSER","LUSER"};
		         List<LOG_TRUY_CAPInfo> results = QuerySolrBase<LOG_TRUY_CAPInfo>.QuerySolr_GetAllWithPadding(Config.SOLR_URL_CORE_BASE + "LOG_TRUY_CAP/", keyword, lstFilter, fieldSelect, lstOrder, pageIndex - 1, pageSize, ref totalRecord);
		         List<LOG_TRUY_CAPInfo> listAddRange = new List<LOG_TRUY_CAPInfo>();
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
