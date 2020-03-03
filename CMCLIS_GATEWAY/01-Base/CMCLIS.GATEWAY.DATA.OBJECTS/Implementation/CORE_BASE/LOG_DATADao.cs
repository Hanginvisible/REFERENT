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
	//-- Date: 02/21/2020 9:29:03 AM
	//-- Todo: 
	//------------------------------------------------------------------------------------------------------------------------ 
    public class LOG_DATADao : OracleBaseImpl<LOG_DATAInfo>
    {
        protected override void SetInfoDerivedClass()
        {
			TableName = "LOG_DATA";
			PackageName = "PK_LOG_DATA";
			ConnectionString = Config.DictConnectionString[Constant.CONNECTION_STRING_DATA_ORACLE];            
            LuceneIndexData = Config.ORACLEGetInfoIndexLucene.ContainsKey(TableName) ? Config.ORACLEGetInfoIndexLucene[TableName] : Config.ORACLESetIndexLucene(TableName)[TableName];			
        }

        #region relationship support
       
        #endregion

        #region Get List

        public List<LOG_DATAInfo> LOG_DATA_GetAllWithPadding(string _IP,int _PORT,string _APPLICATION_NAME,string _MESSAGE,int _LOG_TYPE,int _IS_DELETE,DateTime _CDATE_START_DATE,DateTime _CDATE_END_DATE,int pageIndex, int pageSize,ref int totalRecord)
        {
            OracleParameter[] sqlParam = {
                                        new OracleParameter("p_IP",_IP),
                                        new OracleParameter("p_PORT",_PORT),
                                        new OracleParameter("p_APPLICATION_NAME",_APPLICATION_NAME),
                                        new OracleParameter("p_MESSAGE",_MESSAGE),
                                        new OracleParameter("p_LOG_TYPE",_LOG_TYPE),
                                        new OracleParameter("p_IS_DELETE",_IS_DELETE),
                                        new OracleParameter("p_CDATE_START_DATE",_CDATE_START_DATE),
                                        new OracleParameter("p_CDATE_END_DATE",_CDATE_END_DATE),
                                    };
            try
            {
                List<LOG_DATAInfo> list = this.ExecuteQuery("usp_GET_ALL_WITH_PADDING", sqlParam, pageIndex, pageSize, ref totalRecord);
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
		
		 public List<LOG_DATAInfo> LOG_DATA_GetListByLucene(string keyword, int selectTop)
        {
            try
            {
                string[] fieldSelect = {"ID","IP","PORT","APPLICATION_NAME","MESSAGE","LOG_TYPE","IS_DELETE","CDATE","LDATE","CUSER","LUSER"};
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
		
		 public LOG_DATAInfo LOG_DATA_QuerySolr_GetInfo()
		 {
		     try
		     {
		         List<ISolrQuery> lstFilter = new List<ISolrQuery>();
		         List<SortOrder> lstOrder = new List<SortOrder>();
		         lstOrder.Add(new SortOrder("ID", Order.DESC));
                string[] fieldSelect = {"ID","IP","PORT","APPLICATION_NAME","MESSAGE","LOG_TYPE","IS_DELETE","CDATE","LDATE","CUSER","LUSER"};
		         int totalRecord = 0;
		         List<LOG_DATAInfo> results = QuerySolrBase<LOG_DATAInfo>.QuerySolr_GetAllWithPadding(Config.SOLR_URL_CORE_BASE + "LOG_DATA/", string.Empty, lstFilter, fieldSelect, lstOrder, 0, int.Parse(Config.SOLR_PAGE_SIZE), ref totalRecord);
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

		 public List<LOG_DATAInfo> LOG_DATA_QuerySolr_GetAllWithPadding(string keyword, string _IP,int _PORT,string _APPLICATION_NAME,string _MESSAGE,int _LOG_TYPE,int _IS_DELETE,DateTime? _CDATE_START_DATE,DateTime? _CDATE_END_DATE, int pageIndex, int pageSize,ref int totalRecord)
		 {
		     try
		     {
		         List<ISolrQuery> lstFilter = new List<ISolrQuery>();
		         if (!string.IsNullOrEmpty(_IP))
		         {
		             lstFilter.Add(new SolrQuery("IP:" + _IP));
		         }
		         if (_PORT != -1)
		         {
		             lstFilter.Add(new SolrQuery("PORT:" + _PORT));
		         }
		         if (!string.IsNullOrEmpty(_APPLICATION_NAME))
		         {
		             lstFilter.Add(new SolrQuery("APPLICATION_NAME:" + _APPLICATION_NAME));
		         }
		         if (!string.IsNullOrEmpty(_MESSAGE))
		         {
		             lstFilter.Add(new SolrQuery("MESSAGE:" + _MESSAGE));
		         }
		         if (_LOG_TYPE != -1)
		         {
		            if(_LOG_TYPE == 1)
		            {
		                lstFilter.Add(new SolrQuery("LOG_TYPE:true"));
		            }
		            else if (_LOG_TYPE == 0)
		            {
		                lstFilter.Add(new SolrQuery("LOG_TYPE:false"));
		            }
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
		         if (_CDATE_START_DATE != null && _CDATE_END_DATE != null)
		         {
		             lstFilter.Add(new SolrQuery("CDATE:[" + Utility.GetJSONZFromUserDateTime(_CDATE_START_DATE.Value) + " TO " + Utility.GetJSONZFromUserDateTime(_CDATE_END_DATE.Value) + "]"));
		         }
		         List<SortOrder> lstOrder = new List<SortOrder>();
		         lstOrder.Add(new SortOrder("ID", Order.DESC));
                string[] fieldSelect = {"ID","IP","PORT","APPLICATION_NAME","MESSAGE","LOG_TYPE","IS_DELETE","CDATE","LDATE","CUSER","LUSER"};
		         List<LOG_DATAInfo> results = QuerySolrBase<LOG_DATAInfo>.QuerySolr_GetAllWithPadding(Config.SOLR_URL_CORE_BASE + "LOG_DATA/", keyword, lstFilter, fieldSelect, lstOrder, pageIndex - 1, pageSize, ref totalRecord);
		         List<LOG_DATAInfo> listAddRange = new List<LOG_DATAInfo>();
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
