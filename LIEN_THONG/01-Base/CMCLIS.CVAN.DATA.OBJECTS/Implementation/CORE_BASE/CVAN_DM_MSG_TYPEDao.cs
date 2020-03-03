using System;
using System.Collections.Generic;
using SolrNet;
using Lucene.Net.QueryParsers;
using Lucene.Net.Analysis.Standard;
using Oracle.DataAccess.Client;
using CMCLIS.CVAN.ENTITY;
using CMCLIS.CVAN.SETTING;
using CMCLIS.CVAN.CORE;
using CMCLIS.CVAN.CORE.Provider;
using CMCLIS.CVAN.CORE.Solr;

namespace CMCLIS.CVAN.DATA.OBJECTS
{
	//------------------------------------------------------------------------------------------------------------------------
	//-- Created By: Ngô Văn Nghị
	//-- Date: 02/12/2020 9:19:03 AM
	//-- Todo: 
	//------------------------------------------------------------------------------------------------------------------------ 
    public class CVAN_DM_MSG_TYPEDao : OracleBaseImpl<CVAN_DM_MSG_TYPEInfo>
    {
        protected override void SetInfoDerivedClass()
        {
			TableName = "CVAN_DM_MSG_TYPE";
			PackageName = "PK_CVAN_DM_MSG_TYPE";
			ConnectionString = Config.DictConnectionString[Constant.CONNECTION_STRING_DATA_ORACLE];            
            LuceneIndexData = Config.ORACLEGetInfoIndexLucene.ContainsKey(TableName) ? Config.ORACLEGetInfoIndexLucene[TableName] : Config.ORACLESetIndexLucene(TableName)[TableName];			
        }

        #region relationship support
       
        #endregion

        #region Get List

        public List<CVAN_DM_MSG_TYPEInfo> CVAN_DM_MSG_TYPE_GetAllWithPadding(string _CVAN_CODE,string _CVAN_NAME,int _CVAN_STATUS,int pageIndex, int pageSize,ref int totalRecord)
        {
            OracleParameter[] sqlParam = {
                                        new OracleParameter("p_CVAN_CODE",_CVAN_CODE),
                                        new OracleParameter("p_CVAN_NAME",_CVAN_NAME),
                                        new OracleParameter("p_CVAN_STATUS",_CVAN_STATUS),
                                    };
            try
            {
                List<CVAN_DM_MSG_TYPEInfo> list = this.ExecuteQuery("usp_GET_ALL_WITH_PADDING", sqlParam, pageIndex, pageSize, ref totalRecord);
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
		
		 public List<CVAN_DM_MSG_TYPEInfo> CVAN_DM_MSG_TYPE_GetListByLucene(string keyword, int selectTop)
        {
            try
            {
                string[] fieldSelect = {"ID","CVAN_CODE","CVAN_NAME","CVAN_VERSION","CVAN_DESCRIPTION","CVAN_STATUS","CVAN_PARENT","CVAN_PARENT_NAME","CDATE","LDATE","CUSER","LUSER"};
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
		
		 public CVAN_DM_MSG_TYPEInfo CVAN_DM_MSG_TYPE_QuerySolr_GetInfo(string _CVAN_CODE)
		 {
		     try
		     {
		         List<ISolrQuery> lstFilter = new List<ISolrQuery>();
		         if (!string.IsNullOrEmpty(_CVAN_CODE))
		         {
		             lstFilter.Add(new SolrQuery("CVAN_CODE:" + _CVAN_CODE));
		         }
		         List<SortOrder> lstOrder = new List<SortOrder>();
		         lstOrder.Add(new SortOrder("ID", Order.DESC));
                string[] fieldSelect = {"ID","CVAN_CODE","CVAN_NAME","CVAN_VERSION","CVAN_DESCRIPTION","CVAN_STATUS","CVAN_PARENT","CVAN_PARENT_NAME","CDATE","LDATE","CUSER","LUSER"};
		         int totalRecord = 0;
		         List<CVAN_DM_MSG_TYPEInfo> results = QuerySolrBase<CVAN_DM_MSG_TYPEInfo>.QuerySolr_GetAllWithPadding(Config.SOLR_URL_CORE_BASE + "CVAN_DM_MSG_TYPE/", string.Empty, lstFilter, fieldSelect, lstOrder, 0, int.Parse(Config.SOLR_PAGE_SIZE), ref totalRecord);
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

		 public List<CVAN_DM_MSG_TYPEInfo> CVAN_DM_MSG_TYPE_QuerySolr_GetAllWithPadding(string keyword, string _CVAN_CODE,string _CVAN_NAME,int _CVAN_STATUS, int pageIndex, int pageSize,ref int totalRecord)
		 {
		     try
		     {
		         List<ISolrQuery> lstFilter = new List<ISolrQuery>();
		         if (!string.IsNullOrEmpty(_CVAN_CODE))
		         {
		             lstFilter.Add(new SolrQuery("CVAN_CODE:" + _CVAN_CODE));
		         }
		         if (!string.IsNullOrEmpty(_CVAN_NAME))
		         {
		             lstFilter.Add(new SolrQuery("CVAN_NAME:" + _CVAN_NAME));
		         }
		         if (_CVAN_STATUS != -1)
		         {
		            if(_CVAN_STATUS == 1)
		            {
		                lstFilter.Add(new SolrQuery("STATUS:true"));
		            }
		            else if (_CVAN_STATUS == 0)
		            {
		                lstFilter.Add(new SolrQuery("STATUS:false"));
		            }
		         }
		         List<SortOrder> lstOrder = new List<SortOrder>();
		         lstOrder.Add(new SortOrder("ID", Order.DESC));
                string[] fieldSelect = {"ID","CVAN_CODE","CVAN_NAME","CVAN_VERSION","CVAN_DESCRIPTION","CVAN_STATUS","CVAN_PARENT","CVAN_PARENT_NAME","CDATE","LDATE","CUSER","LUSER"};
		         List<CVAN_DM_MSG_TYPEInfo> results = QuerySolrBase<CVAN_DM_MSG_TYPEInfo>.QuerySolr_GetAllWithPadding(Config.SOLR_URL_CORE_BASE + "CVAN_DM_MSG_TYPE / ", keyword, lstFilter, fieldSelect, lstOrder, pageIndex - 1, pageSize, ref totalRecord);
		         List<CVAN_DM_MSG_TYPEInfo> listAddRange = new List<CVAN_DM_MSG_TYPEInfo>();
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
