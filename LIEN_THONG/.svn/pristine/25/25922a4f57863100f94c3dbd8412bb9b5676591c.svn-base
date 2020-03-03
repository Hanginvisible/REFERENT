using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using Oracle.DataAccess.Client;

namespace CMCLIS.CVAN.SETTING
{
    [Serializable]
    public class LuceneIndexInfo
    {

        public bool IsUseLucene { get; set; }
        public bool IsUpdateLucene { get; set; }
        public string IndexLocation { get; set; }
        public int MaxFieldLength { get; set; }

        public LuceneIndexInfo()
        {
            IsUseLucene = false;
            IsUpdateLucene = false;
            IndexLocation = string.Empty;
            MaxFieldLength = 0;

        }
    }

    public sealed class Config
    {
        #region "Const"
        public static string cstExpectValue = "-1";
        #endregion

        private static Dictionary<string, string> _DictConnectionString;
        public static Dictionary<string, string> DictConnectionString
        {
            get
            {
                if (_DictConnectionString == null || _DictConnectionString.Count == 0)
                {
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    string[] arrayKeys = ConfigurationManager.AppSettings.AllKeys.Where(key => key.StartsWith("CONNECTION_STRING")).Select(key => key).ToArray();
                    foreach (string itemKey in arrayKeys)
                    {
                        dict.Add(itemKey, ConfigurationManager.AppSettings[itemKey]);
                    }
                    _DictConnectionString = dict;
                }
                return _DictConnectionString;
            }
        }

        private static string _PREFIX;
        public static string PREFIX
        {
            get
            {
                if (string.IsNullOrEmpty(_PREFIX))
                {
                    _PREFIX = ConfigurationManager.AppSettings[Constant.PREFIX];
                }
                return _PREFIX;
            }
        }

        private static string _API_KEY;
        public static string API_KEY
        {
            get
            {
                if (string.IsNullOrEmpty(_API_KEY))
                {
                    _API_KEY = ConfigurationManager.AppSettings[Constant.API_KEY];
                }
                return _API_KEY;
            }
        }

        private static string _USING_ENVIROMENT;
        public static string USING_ENVIROMENT
        {
            get
            {
                if (string.IsNullOrEmpty(_USING_ENVIROMENT))
                {
                    _USING_ENVIROMENT = ConfigurationManager.AppSettings[Constant.USING_ENVIROMENT];
                }
                return _USING_ENVIROMENT;
            }
        }

        private static string _SIGN_TYPE_FILE;
        public static string SIGN_TYPE_FILE
        {
            get
            {
                if (string.IsNullOrEmpty(_SIGN_TYPE_FILE))
                {
                    _SIGN_TYPE_FILE = ConfigurationManager.AppSettings[Constant.SIGN_TYPE_FILE];
                }
                return _SIGN_TYPE_FILE;
            }
        }

        private static string _SERVICE_NAME;
        public static string SERVICE_NAME
        {
            get
            {
                if (string.IsNullOrEmpty(_SERVICE_NAME))
                {
                    _SERVICE_NAME = ConfigurationManager.AppSettings[Constant.SERVICE_NAME];
                }
                return _SERVICE_NAME;
            }
        }

        private static string _KEY_AUTHORIZATION;
        public static string KEY_AUTHORIZATION
        {
            get
            {
                if (string.IsNullOrEmpty(_KEY_AUTHORIZATION))
                {
                    _KEY_AUTHORIZATION = ConfigurationManager.AppSettings[Constant.KEY_AUTHORIZATION];
                }
                return _KEY_AUTHORIZATION;
            }
        }

        private static string[] _LIST_HOST_REFERER;
        public static string[] LIST_HOST_REFERER
        {
            get
            {
                if (_LIST_HOST_REFERER == null || _LIST_HOST_REFERER.Length == 0)
                {
                    _LIST_HOST_REFERER = ConfigurationManager.AppSettings[Constant.LIST_HOST_REFERER].Split(','); ;
                }
                return _LIST_HOST_REFERER;
            }
        }

        private static string _PATH_DATA_PORTAL;
        public static string PATH_DATA_PORTAL
        {
            get
            {
                if (string.IsNullOrEmpty(_PATH_DATA_PORTAL))
                {
                    _PATH_DATA_PORTAL = ConfigurationManager.AppSettings[Constant.PATH_DATA_PORTAL];
                }
                return _PATH_DATA_PORTAL;
            }
        }

        private static string _PATH_DATA_SERVICE;
        public static string PATH_DATA_SERVICE
        {
            get
            {
                if (string.IsNullOrEmpty(_PATH_DATA_PORTAL))
                {
                    _PATH_DATA_SERVICE = ConfigurationManager.AppSettings[Constant.PATH_DATA_SERVICE];
                }
                return _PATH_DATA_SERVICE;
            }
        }

        private static string _PATH_DATA_SAVE_FILE;
        public static string PATH_DATA_SAVE_FILE
        {
            get
            {
                if (string.IsNullOrEmpty(_PATH_DATA_SAVE_FILE))
                {
                    _PATH_DATA_SAVE_FILE = ConfigurationManager.AppSettings[Constant.PATH_DATA_SAVE_FILE];
                }
                return _PATH_DATA_SAVE_FILE;
            }
        }

        

        private static string _LOG_PATH;
        public static string LOG_PATH
        {
            get
            {
                if (string.IsNullOrEmpty(_LOG_PATH))
                {
                    if (Config.USING_ENVIROMENT == "web")
                    {
                        if (!System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~") + @"\Log"))
                        {
                            System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~") + @"\Log");
                        }
                        _LOG_PATH = System.Web.HttpContext.Current.Server.MapPath("~") + @"\Log";
                    }
                    else
                    {
                        if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Log"))
                        {
                            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Log");
                        }
                        _LOG_PATH = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Log";
                    }

                }
                return _LOG_PATH;
            }
        }

        private static string _ASSEMBLY_NAME;
        public static string ASSEMBLY_NAME
        {
            get
            {
                if (string.IsNullOrEmpty(_ASSEMBLY_NAME))
                {
                    _ASSEMBLY_NAME = ConfigurationManager.AppSettings[Constant.ASSEMBLY_NAME];
                }
                return _ASSEMBLY_NAME;
            }
        }

        private static string _NAMESPACE_NAME;
        public static string NAMESPACE_NAME
        {
            get
            {
                if (string.IsNullOrEmpty(_NAMESPACE_NAME))
                {
                    _NAMESPACE_NAME = ConfigurationManager.AppSettings[Constant.NAMESPACE_NAME];
                }
                return _NAMESPACE_NAME;
            }
        }

        private static string _PAGE_SIZE;
        public static string PAGE_SIZE
        {
            get
            {
                if (string.IsNullOrEmpty(_PAGE_SIZE))
                {
                    _PAGE_SIZE = ConfigurationManager.AppSettings[Constant.PAGE_SIZE];
                }
                return _PAGE_SIZE;
            }
        }

        #region Product info
        private static string _SOFTWARE_NAME;
        public static string SOFTWARE_NAME
        {
            get
            {
                if (string.IsNullOrEmpty(_SOFTWARE_NAME))
                {
                    _SOFTWARE_NAME = ConfigurationManager.AppSettings[Constant.SOFTWARE_NAME];
                }
                return _SOFTWARE_NAME;
            }
        }

        private static string _VERSION;
        public static string VERSION
        {
            get
            {
                if (string.IsNullOrEmpty(_VERSION))
                {
                    _VERSION = ConfigurationManager.AppSettings[Constant.VERSION];
                }
                return _VERSION;
            }
        }

        private static string _SOFTWARE_CODE;
        public static string SOFTWARE_CODE
        {
            get
            {
                if (string.IsNullOrEmpty(_SOFTWARE_CODE))
                {
                    _SOFTWARE_CODE = ConfigurationManager.AppSettings[Constant.SOFTWARE_CODE];
                }
                return _SOFTWARE_CODE;
            }
        }

        private static string _LICENSE_SERVICE;
        public static string LICENSE_SERVICE
        {
            get
            {
                if (string.IsNullOrEmpty(_LICENSE_SERVICE))
                {
                    _LICENSE_SERVICE = ConfigurationManager.AppSettings[Constant.LICENSE_SERVICE];
                }
                return _LICENSE_SERVICE;
            }
        }

        private static string _LICENSE_KEY;
        public static string LICENSE_KEY
        {
            get
            {
                if (string.IsNullOrEmpty(_LICENSE_KEY))
                {
                    _LICENSE_KEY = ConfigurationManager.AppSettings[Constant.LICENSE_KEY];
                }
                return _LICENSE_KEY;
            }
        }

        #endregion

        #region config - infomation

        private static string _SUPPLIER_COMPANY_NAME;
        public static string SUPPLIER_COMPANY_NAME
        {
            get
            {
                if (string.IsNullOrEmpty(_SUPPLIER_COMPANY_NAME))
                {
                    _SUPPLIER_COMPANY_NAME = ConfigurationManager.AppSettings[Constant.SUPPLIER_COMPANY_NAME];
                }
                return _SUPPLIER_COMPANY_NAME;
            }
        }

        private static string _SUPPLIER_PHONE_SUPPORT;
        public static string SUPPLIER_PHONE_SUPPORT
        {
            get
            {
                if (string.IsNullOrEmpty(_SUPPLIER_PHONE_SUPPORT))
                {
                    _SUPPLIER_PHONE_SUPPORT = ConfigurationManager.AppSettings[Constant.SUPPLIER_PHONE_SUPPORT];
                }
                return _SUPPLIER_PHONE_SUPPORT;
            }
        }

        private static string _SUPPLIER_WEBSITE_SUPPORT;
        public static string SUPPLIER_WEBSITE_SUPPORT
        {
            get
            {
                if (string.IsNullOrEmpty(_SUPPLIER_WEBSITE_SUPPORT))
                {
                    _SUPPLIER_WEBSITE_SUPPORT = ConfigurationManager.AppSettings[Constant.SUPPLIER_WEBSITE_SUPPORT];
                }
                return _SUPPLIER_WEBSITE_SUPPORT;
            }
        }

        private static string _SUPPLIER_WEBSITE_SEARCH;
        public static string SUPPLIER_WEBSITE_SEARCH
        {
            get
            {
                if (string.IsNullOrEmpty(_SUPPLIER_WEBSITE_SEARCH))
                {
                    _SUPPLIER_WEBSITE_SEARCH = ConfigurationManager.AppSettings[Constant.SUPPLIER_WEBSITE_SEARCH];
                }
                return _SUPPLIER_WEBSITE_SEARCH;
            }
        }

        private static string _ROW_VIEW_INVOICE;
        public static string ROW_VIEW_INVOICE
        {
            get
            {
                if (string.IsNullOrEmpty(_ROW_VIEW_INVOICE))
                {
                    _ROW_VIEW_INVOICE = ConfigurationManager.AppSettings[Constant.ROW_VIEW_INVOICE];
                }
                return _ROW_VIEW_INVOICE;
            }
        }

        #endregion

        #region Lucene


        private static string _ORACLE_OWNER;
        public static string ORACLE_OWNER
        {
            get
            {
                if (string.IsNullOrEmpty(_ORACLE_OWNER))
                {
                    _ORACLE_OWNER = ConfigurationManager.AppSettings[Constant.ORACLE_OWNER];
                }
                return _ORACLE_OWNER;
            }
        }
        private static string _FILE_NAME_LOCK_LUCENE;
        public static string FILE_NAME_LOCK_LUCENE
        {
            get
            {
                if (string.IsNullOrEmpty(_FILE_NAME_LOCK_LUCENE))
                {
                    _FILE_NAME_LOCK_LUCENE = ConfigurationManager.AppSettings[Constant.FILE_NAME_LOCK_LUCENE];
                }
                return _FILE_NAME_LOCK_LUCENE;
            }
        }

        private static string _PATH_INDEX_LUCENE_MSSQL;
        public static string PATH_INDEX_LUCENE_MSSQL
        {
            get
            {
                if (string.IsNullOrEmpty(_PATH_INDEX_LUCENE_MSSQL))
                {
                    //_PATH_INDEX_LUCENE = ConfigurationManager.AppSettings[Constant.PATH_INDEX_LUCENE];
                    if (Config.USING_ENVIROMENT == "web")
                    {
                        if (!System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~") + @"\IndexLucene"))
                        {
                            System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~") + @"\IndexLucene");
                        }
                        if (!System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~") + @"\IndexLucene\MSSQL"))
                        {
                            System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~") + @"\IndexLucene\MSSQL");
                        }
                        _PATH_INDEX_LUCENE_MSSQL = System.Web.HttpContext.Current.Server.MapPath("~") + @"\IndexLucene\MSSQL";
                    }
                    else
                    {
                        if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\IndexLucene\MSSQL"))
                        {
                            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\IndexLucene\MSSQL");
                        }
                        _PATH_INDEX_LUCENE_MSSQL = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\IndexLucene\MSSQL";
                    }
                }
                return _PATH_INDEX_LUCENE_MSSQL;
            }
        }

        private static string _PATH_INDEX_LUCENE_ORACLE;
        public static string PATH_INDEX_LUCENE_ORACLE
        {
            get
            {
                if (string.IsNullOrEmpty(_PATH_INDEX_LUCENE_ORACLE))
                {
                    //_PATH_INDEX_LUCENE = ConfigurationManager.AppSettings[Constant.PATH_INDEX_LUCENE];
                    if (Config.USING_ENVIROMENT == "web")
                    {
                        if (!System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~") + @"\IndexLucene"))
                        {
                            System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~") + @"\IndexLucene");
                        }
                        if (!System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~") + @"\IndexLucene\ORACLE"))
                        {
                            System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~") + @"\IndexLucene\ORACLE");
                        }
                        _PATH_INDEX_LUCENE_ORACLE = System.Web.HttpContext.Current.Server.MapPath("~") + @"\IndexLucene\ORACLE";
                    }
                    else
                    {
                        if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\IndexLucene\ORACLE"))
                        {
                            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\IndexLucene\ORACLE");
                        }
                        _PATH_INDEX_LUCENE_ORACLE = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\IndexLucene\ORACLE";
                    }
                }
                return _PATH_INDEX_LUCENE_ORACLE;
            }
        }

        private static Dictionary<string, LuceneIndexInfo> _MSSQLGetInfoIndexLucene;
        public static Dictionary<string, LuceneIndexInfo> MSSQLGetInfoIndexLucene
        {
            get
            {
                if (_MSSQLGetInfoIndexLucene == null || _MSSQLGetInfoIndexLucene.Count == 0)
                {
                    Dictionary<string, LuceneIndexInfo> dictLuceneIndex = new Dictionary<string, LuceneIndexInfo>();
                    foreach (var pair in Config.DictConnectionString)
                    {
                        var arrItems = pair.Key.Split('_');
                        if (arrItems.Length > 0)
                        {
                            string type = arrItems[arrItems.Length - 1];
                            if (type.ToUpper() == "MSSQL")
                            {
                                System.Data.DataSet result = null;
                                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES");
                                var conn = new System.Data.SqlClient.SqlConnection(pair.Value);
                                command.Connection = conn;
                                try
                                {
                                    conn.Open();
                                    System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                                    result = new System.Data.DataSet();
                                    adapter.Fill(result);
                                }
                                catch (Exception ex)
                                {
                                    string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                                    if (!Directory.Exists(Config.LOG_PATH))
                                    {
                                        Directory.CreateDirectory(Config.LOG_PATH);
                                    }
                                    string Source = Path.Combine(Config.LOG_PATH, fileName);
                                    using (StreamWriter writer = new StreamWriter(Source, true))
                                    {
                                        string strValue = Environment.NewLine + "  \"Message\":" + "\"" + ex.Message.Replace(@"\", @"\\").Replace("\r\n", "\\r\\n").Replace("\"", "'") + "\"" + ",";
                                        strValue += Environment.NewLine + "  \"StackTrace\":" + "\"" + ex.StackTrace.Replace(@"\", @"\\").Replace("\r\n", "\\r\\n").Replace("\"", "'") + "\"" + ",";
                                        writer.WriteLine(strValue);
                                    }
                                    result = null;
                                }
                                finally { conn.Close(); }
                                if (result != null && result.Tables[0] != null)
                                {
                                    foreach (System.Data.DataRow row in result.Tables[0].Rows)
                                    {
                                        if (!dictLuceneIndex.ContainsKey(row["TABLE_NAME"].ToString()))
                                            dictLuceneIndex.Add(row["TABLE_NAME"].ToString(),
                                            new LuceneIndexInfo
                                            {
                                                IsUseLucene = Boolean.Parse(ConfigurationManager.AppSettings[Constant.IS_USE_LUCENE]),
                                                IsUpdateLucene = Boolean.Parse(ConfigurationManager.AppSettings[Constant.IS_UPDATE_LUCENE]),
                                                IndexLocation = Config.PATH_INDEX_LUCENE_MSSQL,
                                                MaxFieldLength = int.Parse(ConfigurationManager.AppSettings[Constant.MAX_FIELD_LENGTH])
                                            });
                                    }
                                }
                            }
                        }
                    }

                    string[] arrayKeys = ConfigurationManager.AppSettings.AllKeys.Where(key => key.StartsWith("LUCENE_INDEX_DATA_")).Select(key => key).ToArray();
                    foreach (string itemKey in arrayKeys)
                    {
                        if (!dictLuceneIndex.ContainsKey(itemKey.Replace("LUCENE_INDEX_DATA_", string.Empty)))
                            dictLuceneIndex.Add(itemKey.Replace("LUCENE_INDEX_DATA_", string.Empty),
                                new LuceneIndexInfo
                                {
                                    IsUseLucene = Boolean.Parse(ConfigurationManager.AppSettings[itemKey]),
                                    IsUpdateLucene = Boolean.Parse(ConfigurationManager.AppSettings[itemKey]),
                                    IndexLocation = Config.PATH_INDEX_LUCENE_MSSQL,
                                    MaxFieldLength = int.Parse(ConfigurationManager.AppSettings[Constant.MAX_FIELD_LENGTH])
                                });
                    }
                    _MSSQLGetInfoIndexLucene = dictLuceneIndex;

                }
                return _MSSQLGetInfoIndexLucene;
            }
        }
        public static Dictionary<string, LuceneIndexInfo> MSSQLSetIndexLucene(string dataTable)
        {
            if (!Config.MSSQLGetInfoIndexLucene.ContainsKey(dataTable))
                Config.MSSQLGetInfoIndexLucene.Add(dataTable,
                new LuceneIndexInfo
                {
                    IsUseLucene = Boolean.Parse(ConfigurationManager.AppSettings[Constant.IS_USE_LUCENE]),
                    IsUpdateLucene = Boolean.Parse(ConfigurationManager.AppSettings[Constant.IS_UPDATE_LUCENE]),
                    IndexLocation = Config.PATH_INDEX_LUCENE_MSSQL,
                    MaxFieldLength = int.Parse(ConfigurationManager.AppSettings[Constant.MAX_FIELD_LENGTH])
                });
            return Config.MSSQLGetInfoIndexLucene;
        }

        private static Dictionary<string, LuceneIndexInfo> _ORACLEGetInfoIndexLucene;
        public static Dictionary<string, LuceneIndexInfo> ORACLEGetInfoIndexLucene
        {
            get
            {
                if (_ORACLEGetInfoIndexLucene == null || _ORACLEGetInfoIndexLucene.Count == 0)
                {
                    Dictionary<string, LuceneIndexInfo> dictLuceneIndex = new Dictionary<string, LuceneIndexInfo>();
                    foreach (var pair in Config.DictConnectionString)
                    {                        
                        var arrItems = pair.Key.Split('_');
                        if (arrItems.Length > 0)
                        {
                            string type = arrItems[arrItems.Length - 1];
                            if (type.ToUpper() == "ORACLE")
                            {
                                DataSet result = new DataSet();
                                OracleConnection conn = new OracleConnection(pair.Value);
                                try
                                {
                                    conn.Open();
                                    OracleCommand command = new OracleCommand("SELECT owner, table_name FROM all_tables where owner ='" + Config.ORACLE_OWNER + "'", conn);
                                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                                    adapter.Fill(result);
                                }
                                catch (Exception ex)
                                {
                                    string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                                    if (!Directory.Exists(Config.LOG_PATH))
                                    {
                                        Directory.CreateDirectory(Config.LOG_PATH);
                                    }
                                    string Source = Path.Combine(Config.LOG_PATH, fileName);
                                    using (StreamWriter writer = new StreamWriter(Source, true))
                                    {
                                        string strValue = Environment.NewLine + "  \"Message\":" + "\"" + ex.Message.Replace(@"\", @"\\").Replace("\r\n", "\\r\\n").Replace("\"", "'") + "\"" + ",";
                                        strValue += Environment.NewLine + "  \"StackTrace\":" + "\"" + ex.StackTrace.Replace(@"\", @"\\").Replace("\r\n", "\\r\\n").Replace("\"", "'") + "\"" + ",";
                                        writer.WriteLine(strValue);
                                    }
                                    result = null;
                                }
                                finally { conn.Close(); }
                                if (result != null && result.Tables[0] != null)
                                {
                                    foreach (System.Data.DataRow row in result.Tables[0].Rows)
                                    {
                                        if (!dictLuceneIndex.ContainsKey(row["TABLE_NAME"].ToString()))
                                            dictLuceneIndex.Add(row["TABLE_NAME"].ToString(),
                                            new LuceneIndexInfo
                                            {
                                                IsUseLucene = Boolean.Parse(ConfigurationManager.AppSettings[Constant.IS_USE_LUCENE]),
                                                IsUpdateLucene = Boolean.Parse(ConfigurationManager.AppSettings[Constant.IS_UPDATE_LUCENE]),
                                                IndexLocation = Config.PATH_INDEX_LUCENE_ORACLE,
                                                MaxFieldLength = int.Parse(ConfigurationManager.AppSettings[Constant.MAX_FIELD_LENGTH])
                                            });
                                    }
                                }
                            }
                        }
                       
                    }

                    string[] arrayKeys = ConfigurationManager.AppSettings.AllKeys.Where(key => key.StartsWith("LUCENE_INDEX_DATA_")).Select(key => key).ToArray();
                    foreach (string itemKey in arrayKeys)
                    {
                        if (!dictLuceneIndex.ContainsKey(itemKey.Replace("LUCENE_INDEX_DATA_", string.Empty)))
                            dictLuceneIndex.Add(itemKey.Replace("LUCENE_INDEX_DATA_", string.Empty),
                                new LuceneIndexInfo
                                {
                                    IsUseLucene = Boolean.Parse(ConfigurationManager.AppSettings[itemKey]),
                                    IsUpdateLucene = Boolean.Parse(ConfigurationManager.AppSettings[itemKey]),
                                    IndexLocation = Config.PATH_INDEX_LUCENE_ORACLE,
                                    MaxFieldLength = int.Parse(ConfigurationManager.AppSettings[Constant.MAX_FIELD_LENGTH])
                                });
                    }
                    _ORACLEGetInfoIndexLucene = dictLuceneIndex;

                }
                return _ORACLEGetInfoIndexLucene;
            }
        }
        public static Dictionary<string, LuceneIndexInfo> ORACLESetIndexLucene(string dataTable)
        {
            if (!Config.ORACLEGetInfoIndexLucene.ContainsKey(dataTable))
                Config.ORACLEGetInfoIndexLucene.Add(dataTable,
                new LuceneIndexInfo
                {
                    IsUseLucene = Boolean.Parse(ConfigurationManager.AppSettings[Constant.IS_USE_LUCENE]),
                    IsUpdateLucene = Boolean.Parse(ConfigurationManager.AppSettings[Constant.IS_UPDATE_LUCENE]),
                    IndexLocation = Config.PATH_INDEX_LUCENE_ORACLE,
                    MaxFieldLength = int.Parse(ConfigurationManager.AppSettings[Constant.MAX_FIELD_LENGTH])
                });
            return Config.ORACLEGetInfoIndexLucene;
        }

        private static string _LUCENE_PAGE_SIZE;
        public static string LUCENE_PAGE_SIZE
        {
            get
            {
                if (string.IsNullOrEmpty(_LUCENE_PAGE_SIZE))
                {
                    _LUCENE_PAGE_SIZE = ConfigurationManager.AppSettings[Constant.LUCENE_PAGE_SIZE];
                }
                return _LUCENE_PAGE_SIZE;
            }
        }
        #endregion

        #region Solr
        private static string _SOLR_URL_CORE_BASE;
        public static string SOLR_URL_CORE_BASE
        {
            get
            {
                if (string.IsNullOrEmpty(_SOLR_URL_CORE_BASE))
                {
                    _SOLR_URL_CORE_BASE = ConfigurationManager.AppSettings[Constant.SOLR_URL_CORE_BASE];
                }
                return _SOLR_URL_CORE_BASE;
            }
        }

        private static string _SOLR_URL_REPORT;
        public static string SOLR_URL_REPORT
        {
            get
            {
                if (string.IsNullOrEmpty(_SOLR_URL_REPORT))
                {
                    _SOLR_URL_REPORT = ConfigurationManager.AppSettings[Constant.SOLR_URL_REPORT];
                }
                return _SOLR_URL_REPORT;
            }
        }

        private static string _SOLR_URL_SEARCH;
        public static string SOLR_URL_SEARCH
        {
            get
            {
                if (string.IsNullOrEmpty(_SOLR_URL_SEARCH))
                {
                    _SOLR_URL_SEARCH = ConfigurationManager.AppSettings[Constant.SOLR_URL_SEARCH];
                }
                return _SOLR_URL_SEARCH;
            }
        }

        private static string _SOLR_PAGE_SIZE;
        public static string SOLR_PAGE_SIZE
        {
            get
            {
                if (string.IsNullOrEmpty(_SOLR_PAGE_SIZE))
                {
                    _SOLR_PAGE_SIZE = ConfigurationManager.AppSettings[Constant.SOLR_PAGE_SIZE];
                }
                return _SOLR_PAGE_SIZE;
            }
        }
        #endregion

        #region FTP CONFIG

        private static string _FTP_USING;
        public static string FTP_USING
        {
            get
            {
                if (string.IsNullOrEmpty(_FTP_USING))
                {
                    _FTP_USING = ConfigurationManager.AppSettings[Constant.FTP_USING];
                }
                return _FTP_USING;
            }
        }

        private static string _FTP_SERVER_URI;
        public static string FTP_SERVER_URI
        {
            get
            {
                if (string.IsNullOrEmpty(_FTP_SERVER_URI))
                {
                    _FTP_SERVER_URI = ConfigurationManager.AppSettings[Constant.FTP_SERVER_URI];
                }
                return _FTP_SERVER_URI;
            }
        }

        private static string _FTP_USER;
        public static string FTP_USER
        {
            get
            {
                if (string.IsNullOrEmpty(_FTP_USER))
                {
                    _FTP_USER = ConfigurationManager.AppSettings[Constant.FTP_USER];
                }
                return _FTP_USER;
            }
        }

        private static string _FTP_PASSWORD;
        public static string FTP_PASSWORD
        {
            get
            {
                if (string.IsNullOrEmpty(_FTP_PASSWORD))
                {
                    _FTP_PASSWORD = ConfigurationManager.AppSettings[Constant.FTP_PASSWORD];
                }
                return _FTP_PASSWORD;
            }
        }

        private static string _FTP_DOWNLOAD_FILE;
        public static string FTP_DOWNLOAD_FILE
        {
            get
            {
                if (string.IsNullOrEmpty(_FTP_DOWNLOAD_FILE))
                {
                    _FTP_DOWNLOAD_FILE = ConfigurationManager.AppSettings[Constant.FTP_DOWNLOAD_FILE];
                }
                return _FTP_DOWNLOAD_FILE;
            }
        }

        #endregion

        #region RabbitMQ

        private static string _MQ_PORT;
        public static string MQ_PORT
        {
            get
            {
                if (string.IsNullOrEmpty(_MQ_PORT))
                {
                    _MQ_PORT = ConfigurationManager.AppSettings[Constant.MQ_PORT];
                }
                return _MQ_PORT;
            }
        }

        private static string _MQ_NAME;
        public static string MQ_NAME
        {
            get
            {
                if (string.IsNullOrEmpty(_MQ_NAME))
                {
                    _MQ_NAME = ConfigurationManager.AppSettings[Constant.MQ_NAME];
                }
                return _MQ_NAME;
            }
        }

        private static Dictionary<int, string> _DICT_MQ_NAME;
        public static Dictionary<int, string> DICT_MQ_NAME
        {
            get
            {
                if (_DICT_MQ_NAME == null || _DICT_MQ_NAME.Count == 0)
                {
                    Dictionary<int, string> dict = new Dictionary<int, string>();
                    string mqName = ConfigurationManager.AppSettings[Constant.MQ_NAME_LIST];
                    if (!string.IsNullOrEmpty(mqName))
                    {

                        var array = mqName.Split(',');

                        for (int i = 0; i < array.Length; i++)
                        {
                            dict.Add(i, array[i]);
                        }

                    }

                    _DICT_MQ_NAME = dict;

                }
                return _DICT_MQ_NAME;
            }
        }

        private static string _MQ_USER;
        public static string MQ_USER
        {
            get
            {
                if (string.IsNullOrEmpty(_MQ_USER))
                {
                    _MQ_USER = ConfigurationManager.AppSettings[Constant.MQ_USER];
                }
                return _MQ_USER;
            }
        }



        private static string _MQ_PASSWORD;
        public static string MQ_PASSWORD
        {
            get
            {
                if (string.IsNullOrEmpty(_MQ_PASSWORD))
                {
                    _MQ_PASSWORD = ConfigurationManager.AppSettings[Constant.MQ_PASSWORD];
                }
                return _MQ_PASSWORD;
            }
        }

        private static string _MQ_HOST;
        public static string MQ_HOST
        {
            get
            {
                if (string.IsNullOrEmpty(_MQ_HOST))
                {
                    _MQ_HOST = ConfigurationManager.AppSettings[Constant.MQ_HOST];
                }
                return _MQ_HOST;
            }
        }

        #endregion

        #region Network Share

        private static string _NETWORK_SAVE_USING;
        public static string NETWORK_SAVE_USING
        {
            get
            {
                if (string.IsNullOrEmpty(_NETWORK_SAVE_USING))
                {
                    _NETWORK_SAVE_USING = ConfigurationManager.AppSettings[Constant.NETWORK_SAVE_USING];
                }
                return _NETWORK_SAVE_USING;
            }
        }


        private static string _NETWORK_SHARE_IP;
        public static string NETWORK_SHARE_IP
        {
            get
            {
                if (string.IsNullOrEmpty(_NETWORK_SHARE_IP))
                {
                    _NETWORK_SHARE_IP = ConfigurationManager.AppSettings[Constant.NETWORK_SHARE_IP];
                }
                return _NETWORK_SHARE_IP;
            }
        }

        private static string _NETWORK_SHARE_ACCOUNT;
        public static string NETWORK_SHARE_ACCOUNT
        {
            get
            {
                if (string.IsNullOrEmpty(_NETWORK_SHARE_ACCOUNT))
                {
                    _NETWORK_SHARE_ACCOUNT = ConfigurationManager.AppSettings[Constant.NETWORK_SHARE_ACCOUNT];
                }
                return _NETWORK_SHARE_ACCOUNT;
            }
        }


        private static string _NETWORK_SHARE_PASSWORD;
        public static string NETWORK_SHARE_PASSWORD
        {
            get
            {
                if (string.IsNullOrEmpty(_NETWORK_SHARE_PASSWORD))
                {
                    _NETWORK_SHARE_PASSWORD = ConfigurationManager.AppSettings[Constant.NETWORK_SHARE_PASSWORD];
                }
                return _NETWORK_SHARE_PASSWORD;
            }
        }

        private static string _NETWORK_SHARE_DIRECTORY;
        public static string NETWORK_SHARE_DIRECTORY
        {
            get
            {
                if (string.IsNullOrEmpty(_NETWORK_SHARE_DIRECTORY))
                {
                    _NETWORK_SHARE_DIRECTORY = ConfigurationManager.AppSettings[Constant.NETWORK_SHARE_DIRECTORY];
                }
                return _NETWORK_SHARE_DIRECTORY;
            }
        }


        #endregion

        #region CA
        private static string _CA_TOKENT_SERIAL;
        public static string CA_TOKENT_SERIAL
        {
            get
            {
                if (string.IsNullOrEmpty(_CA_TOKENT_SERIAL))
                {
                    _CA_TOKENT_SERIAL = ConfigurationManager.AppSettings[Constant.CA_TOKENT_SERIAL];
                }
                return _CA_TOKENT_SERIAL;
            }
        }
        private static string _CA_FILE_NAME;
        public static string CA_FILE_NAME
        {
            get
            {
                if (string.IsNullOrEmpty(_CA_FILE_NAME))
                {
                    _CA_FILE_NAME = ConfigurationManager.AppSettings[Constant.CA_FILE_NAME];
                }
                return _CA_FILE_NAME;
            }
        }

        private static string _CA_PASSWORD;
        public static string CA_PASSWORD
        {
            get
            {
                if (string.IsNullOrEmpty(_CA_PASSWORD))
                {
                    _CA_PASSWORD = ConfigurationManager.AppSettings[Constant.CA_PASSWORD];
                }
                return _CA_PASSWORD;
            }
        }

        #endregion

        #region MICRO SERVICE
        private static string _MICRO_SERVICE_IP;
        public static string MICRO_SERVICE_IP
        {
            get
            {
                if (string.IsNullOrEmpty(_MICRO_SERVICE_IP))
                {
                    _MICRO_SERVICE_IP = ConfigurationManager.AppSettings[Constant.MICRO_SERVICE_IP];
                }
                return _MICRO_SERVICE_IP;
            }
        }
        private static string _MICRO_SERVICE_PORT;
        public static string MICRO_SERVICE_PORT
        {
            get
            {
                if (string.IsNullOrEmpty(_MICRO_SERVICE_PORT))
                {
                    _MICRO_SERVICE_PORT = ConfigurationManager.AppSettings[Constant.MICRO_SERVICE_PORT];
                }
                return _MICRO_SERVICE_PORT;
            }
        }

        private static string _MICRO_SERVICE_NAME;
        public static string MICRO_SERVICE_NAME
        {
            get
            {
                if (string.IsNullOrEmpty(_MICRO_SERVICE_NAME))
                {
                    _MICRO_SERVICE_NAME = ConfigurationManager.AppSettings[Constant.MICRO_SERVICE_NAME];
                }
                return _MICRO_SERVICE_NAME;
            }
        }

        private static string _MICRO_SERVICE_DISPLAY_NAME;
        public static string MICRO_SERVICE_DISPLAY_NAME
        {
            get
            {
                if (string.IsNullOrEmpty(_MICRO_SERVICE_DISPLAY_NAME))
                {
                    _MICRO_SERVICE_DISPLAY_NAME = ConfigurationManager.AppSettings[Constant.MICRO_SERVICE_DISPLAY_NAME];
                }
                return _MICRO_SERVICE_DISPLAY_NAME;
            }
        }

        private static string _MICRO_SERVICE_MAXLENGTH_MESSAGESIZE;
        public static string MICRO_SERVICE_MAXLENGTH_MESSAGESIZE
        {
            get
            {
                if (string.IsNullOrEmpty(_MICRO_SERVICE_MAXLENGTH_MESSAGESIZE))
                {
                    _MICRO_SERVICE_MAXLENGTH_MESSAGESIZE = ConfigurationManager.AppSettings[Constant.MICRO_SERVICE_MAXLENGTH_MESSAGESIZE];
                }
                return _MICRO_SERVICE_MAXLENGTH_MESSAGESIZE;
            }
        }
        #endregion



    }
}
