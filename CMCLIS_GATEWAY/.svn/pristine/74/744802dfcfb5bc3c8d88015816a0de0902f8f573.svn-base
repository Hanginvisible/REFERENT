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
	//-- Date: 02/21/2020 9:29:02 AM
	//-- Todo: 
	//------------------------------------------------------------------------------------------------------------------------ 
    public class FILE_SERVER_DATADao : OracleBaseImpl<FILE_SERVER_DATAInfo>
    {
        protected override void SetInfoDerivedClass()
        {
			TableName = "FILE_SERVER_DATA";
			PackageName = "PK_FILE_SERVER_DATA";
			ConnectionString = Config.DictConnectionString[Constant.CONNECTION_STRING_DATA_ORACLE];            
            LuceneIndexData = Config.ORACLEGetInfoIndexLucene.ContainsKey(TableName) ? Config.ORACLEGetInfoIndexLucene[TableName] : Config.ORACLESetIndexLucene(TableName)[TableName];			
        }

        #region relationship support
       
        #endregion

        #region Get List

        public List<FILE_SERVER_DATAInfo> FILE_SERVER_DATA_GetAllWithPadding(string _FILE_ID,string _DOC_TYPE,string _FILE_NAME,string _TRAN_ID,string _REGION_ID,int _IS_DELETE,int pageIndex, int pageSize,ref int totalRecord)
        {
            OracleParameter[] sqlParam = {
                                        new OracleParameter("p_FILE_ID",_FILE_ID),
                                        new OracleParameter("p_DOC_TYPE",_DOC_TYPE),
                                        new OracleParameter("p_FILE_NAME",_FILE_NAME),
                                        new OracleParameter("p_TRAN_ID",_TRAN_ID),
                                        new OracleParameter("p_REGION_ID",_REGION_ID),
                                        new OracleParameter("p_IS_DELETE",_IS_DELETE),
                                    };
            try
            {
                List<FILE_SERVER_DATAInfo> list = this.ExecuteQuery("usp_GET_ALL_WITH_PADDING", sqlParam, pageIndex, pageSize, ref totalRecord);
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
		
		 public List<FILE_SERVER_DATAInfo> FILE_SERVER_DATA_GetListByLucene(string keyword, int selectTop)
        {
            try
            {
                string[] fieldSelect = {"ID","FILE_ID","DOC_TYPE","FILE_NAME","EXTENSION","DESCRIPTION","VERSION","TRAN_ID","REGION_ID","SOURCE","IS_DELETE","CDATE","LDATE","CUSER","LUSER"};
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
		
		 public FILE_SERVER_DATAInfo FILE_SERVER_DATA_QuerySolr_GetInfo()
		 {
		     try
		     {
		         List<ISolrQuery> lstFilter = new List<ISolrQuery>();
		         List<SortOrder> lstOrder = new List<SortOrder>();
		         lstOrder.Add(new SortOrder("ID", Order.DESC));
                string[] fieldSelect = {"ID","FILE_ID","DOC_TYPE","FILE_NAME","EXTENSION","DESCRIPTION","VERSION","TRAN_ID","REGION_ID","SOURCE","IS_DELETE","CDATE","LDATE","CUSER","LUSER"};
		         int totalRecord = 0;
		         List<FILE_SERVER_DATAInfo> results = QuerySolrBase<FILE_SERVER_DATAInfo>.QuerySolr_GetAllWithPadding(Config.SOLR_URL_CORE_BASE + "FILE_SERVER_DATA/", string.Empty, lstFilter, fieldSelect, lstOrder, 0, int.Parse(Config.SOLR_PAGE_SIZE), ref totalRecord);
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

		 public List<FILE_SERVER_DATAInfo> FILE_SERVER_DATA_QuerySolr_GetAllWithPadding(string keyword, string _FILE_ID,string _DOC_TYPE,string _FILE_NAME,string _TRAN_ID,string _REGION_ID,int _IS_DELETE, int pageIndex, int pageSize,ref int totalRecord)
		 {
		     try
		     {
		         List<ISolrQuery> lstFilter = new List<ISolrQuery>();
		         if (!string.IsNullOrEmpty(_FILE_ID))
		         {
		             lstFilter.Add(new SolrQuery("FILE_ID:" + _FILE_ID));
		         }
		         if (!string.IsNullOrEmpty(_DOC_TYPE))
		         {
		             lstFilter.Add(new SolrQuery("DOC_TYPE:" + _DOC_TYPE));
		         }
		         if (!string.IsNullOrEmpty(_FILE_NAME))
		         {
		             lstFilter.Add(new SolrQuery("FILE_NAME:" + _FILE_NAME));
		         }
		         if (!string.IsNullOrEmpty(_TRAN_ID))
		         {
		             lstFilter.Add(new SolrQuery("TRAN_ID:" + _TRAN_ID));
		         }
		         if (!string.IsNullOrEmpty(_REGION_ID))
		         {
		             lstFilter.Add(new SolrQuery("REGION_ID:" + _REGION_ID));
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
                string[] fieldSelect = {"ID","FILE_ID","DOC_TYPE","FILE_NAME","EXTENSION","DESCRIPTION","VERSION","TRAN_ID","REGION_ID","SOURCE","IS_DELETE","CDATE","LDATE","CUSER","LUSER"};
		         List<FILE_SERVER_DATAInfo> results = QuerySolrBase<FILE_SERVER_DATAInfo>.QuerySolr_GetAllWithPadding(Config.SOLR_URL_CORE_BASE + "FILE_SERVER_DATA/", keyword, lstFilter, fieldSelect, lstOrder, pageIndex - 1, pageSize, ref totalRecord);
		         List<FILE_SERVER_DATAInfo> listAddRange = new List<FILE_SERVER_DATAInfo>();
		         if (results != null)
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
