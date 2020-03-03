using CMCLIS.GATEWAY.CORE;
using Microsoft.Practices.ServiceLocation;
using SolrNet;
using SolrNet.Commands.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCLIS.GATEWAY.CORE.Solr
{
    public class QuerySolrBase<T> where T : new()
    {
        private static void LoadSolr(string url)
        {
            Startup.InitContainer();

            Startup.Init<T>(url);
        }

        public static List<T> QuerySolr_GetAllWithPadding(string url, string keyword, List<ISolrQuery> lstFilter, string[] fieldSelect, List<SolrNet.SortOrder> lstOrder, int pageIndex, int pageSize, ref int totalRecord)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword))
                {
                    keyword = "*:*";
                }
                var queryOption = new QueryOptions();

                queryOption.Start = pageIndex * pageSize;
                queryOption.Rows = pageSize;
                if (fieldSelect != null && fieldSelect.Length > 0)
                {
                    var extraParam = new Dictionary<string, string>();
                    extraParam.Add("fl", string.Join(",", fieldSelect));
                    queryOption.ExtraParams = extraParam;
                }
                if (lstOrder != null && lstOrder.Count > 0)
                {
                    queryOption.OrderBy = lstOrder;
                }
                if (lstFilter != null && lstFilter.Count > 0)
                {
                    queryOption.FilterQueries = lstFilter;
                }
                var solrQuery = new SolrQuery(keyword);
                var results = QuerySolrBase<T>.QuerySolr(url, solrQuery, queryOption);
                totalRecord = results.NumFound;
                return (List<T>)results;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }

        }

        private static SolrQueryResults<T> QuerySolr(string urlLoad, AbstractSolrQuery query, QueryOptions queryOptions)
        {
            LoadSolr(urlLoad);

            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<T>>();

            var results = solr.Query(query, queryOptions);

            return results;
        }

        public static ResponseHeader Update(string urlLoad, List<T> lst)
        {
            LoadSolr(urlLoad);

            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<T>>();

            ResponseHeader response = solr.AddRange(lst);

            response = solr.Commit();

            return response;
        }


        public static ResponseHeader Update(string urlLoad, T item)
        {


            LoadSolr(urlLoad);


            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<T>>();



            ResponseHeader response = solr.Add(item);

            response.Params.Add("waitFlush", "false");

            response = solr.Commit();

            return response;
        }
    }
}
