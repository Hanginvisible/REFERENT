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
	//-- Date: 02/21/2020 9:28:59 AM
	//-- Todo: 
	//------------------------------------------------------------------------------------------------------------------------ 
    public class CVAN_EXCHANGEDao : OracleBaseImpl<CVAN_EXCHANGEInfo>
    {
        protected override void SetInfoDerivedClass()
        {
			TableName = "CVAN_EXCHANGE";
			PackageName = "PK_CVAN_EXCHANGE";
			ConnectionString = Config.DictConnectionString[Constant.CONNECTION_STRING_DATA_ORACLE];            
            LuceneIndexData = Config.ORACLEGetInfoIndexLucene.ContainsKey(TableName) ? Config.ORACLEGetInfoIndexLucene[TableName] : Config.ORACLESetIndexLucene(TableName)[TableName];			
        }

        #region relationship support
       
        #endregion

        #region Get List

        public List<CVAN_EXCHANGEInfo> CVAN_EXCHANGE_GetAllWithPadding(string _CVAN_CODE,string _CVAN_MSG_TYPE_CODE,string _CVAN_STATUS_CODE,string _CVAN_MA_GD,int _IS_DELETE,int pageIndex, int pageSize,ref int totalRecord)
        {
            OracleParameter[] sqlParam = {
                                        new OracleParameter("p_CVAN_CODE",_CVAN_CODE),
                                        new OracleParameter("p_CVAN_MSG_TYPE_CODE",_CVAN_MSG_TYPE_CODE),
                                        new OracleParameter("p_CVAN_STATUS_CODE",_CVAN_STATUS_CODE),
                                        new OracleParameter("p_CVAN_MA_GD",_CVAN_MA_GD),
                                        new OracleParameter("p_IS_DELETE",_IS_DELETE),
                                    };
            try
            {
                List<CVAN_EXCHANGEInfo> list = this.ExecuteQuery("usp_GET_ALL_WITH_PADDING", sqlParam, pageIndex, pageSize, ref totalRecord);
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
		
		 public List<CVAN_EXCHANGEInfo> CVAN_EXCHANGE_GetListByLucene(string keyword, int selectTop)
        {
            try
            {
                string[] fieldSelect = {"ID","CVAN_CODE","CVAN_MSG_TYPE_CODE","CVAN_MSG_TYPE_NAME","CVAN_CONTENT_XML","CVAN_STATUS_CODE","CVAN_LAN_GUI","CVAN_MA_GD","IS_DELETE","CDATE","LDATE","CUSER","LUSER"};
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
		
		 public CVAN_EXCHANGEInfo CVAN_EXCHANGE_QuerySolr_GetInfo(string _CVAN_CODE,string _CVAN_MSG_TYPE_CODE)
		 {
		     try
		     {
		         List<ISolrQuery> lstFilter = new List<ISolrQuery>();
		         if (!string.IsNullOrEmpty(_CVAN_CODE))
		         {
		             lstFilter.Add(new SolrQuery("CVAN_CODE:" + _CVAN_CODE));
		         }
		         if (!string.IsNullOrEmpty(_CVAN_MSG_TYPE_CODE))
		         {
		             lstFilter.Add(new SolrQuery("CVAN_MSG_TYPE_CODE:" + _CVAN_MSG_TYPE_CODE));
		         }
		         List<SortOrder> lstOrder = new List<SortOrder>();
		         lstOrder.Add(new SortOrder("ID", Order.DESC));
                string[] fieldSelect = {"ID","CVAN_CODE","CVAN_MSG_TYPE_CODE","CVAN_MSG_TYPE_NAME","CVAN_CONTENT_XML","CVAN_STATUS_CODE","CVAN_LAN_GUI","CVAN_MA_GD","IS_DELETE","CDATE","LDATE","CUSER","LUSER"};
		         int totalRecord = 0;
		         List<CVAN_EXCHANGEInfo> results = QuerySolrBase<CVAN_EXCHANGEInfo>.QuerySolr_GetAllWithPadding(Config.SOLR_URL_CORE_BASE + "CVAN_EXCHANGE/", string.Empty, lstFilter, fieldSelect, lstOrder, 0, int.Parse(Config.SOLR_PAGE_SIZE), ref totalRecord);
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

		 public List<CVAN_EXCHANGEInfo> CVAN_EXCHANGE_QuerySolr_GetAllWithPadding(string keyword, string _CVAN_CODE,string _CVAN_MSG_TYPE_CODE,string _CVAN_STATUS_CODE,string _CVAN_MA_GD,int _IS_DELETE, int pageIndex, int pageSize,ref int totalRecord)
		 {
		     try
		     {
		         List<ISolrQuery> lstFilter = new List<ISolrQuery>();
		         if (!string.IsNullOrEmpty(_CVAN_CODE))
		         {
		             lstFilter.Add(new SolrQuery("CVAN_CODE:" + _CVAN_CODE));
		         }
		         if (!string.IsNullOrEmpty(_CVAN_MSG_TYPE_CODE))
		         {
		             lstFilter.Add(new SolrQuery("CVAN_MSG_TYPE_CODE:" + _CVAN_MSG_TYPE_CODE));
		         }
		         if (!string.IsNullOrEmpty(_CVAN_STATUS_CODE))
		         {
		             lstFilter.Add(new SolrQuery("CVAN_STATUS_CODE:" + _CVAN_STATUS_CODE));
		         }
		         if (!string.IsNullOrEmpty(_CVAN_MA_GD))
		         {
		             lstFilter.Add(new SolrQuery("CVAN_MA_GD:" + _CVAN_MA_GD));
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
                string[] fieldSelect = {"ID","CVAN_CODE","CVAN_MSG_TYPE_CODE","CVAN_MSG_TYPE_NAME","CVAN_CONTENT_XML","CVAN_STATUS_CODE","CVAN_LAN_GUI","CVAN_MA_GD","IS_DELETE","CDATE","LDATE","CUSER","LUSER"};
		         List<CVAN_EXCHANGEInfo> results = QuerySolrBase<CVAN_EXCHANGEInfo>.QuerySolr_GetAllWithPadding(Config.SOLR_URL_CORE_BASE + "CVAN_EXCHANGE/", keyword, lstFilter, fieldSelect, lstOrder, pageIndex - 1, pageSize, ref totalRecord);
		         List<CVAN_EXCHANGEInfo> listAddRange = new List<CVAN_EXCHANGEInfo>();
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
