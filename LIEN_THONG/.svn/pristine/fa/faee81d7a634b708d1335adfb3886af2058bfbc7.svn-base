using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Lucene.Net.Index;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Store;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Lucene.Net.Highlight;
using System.Text.RegularExpressions;
using CMCLIS.CVAN.CORE.AILucene;
using System.ComponentModel;
using Oracle.DataAccess.Client;
using CMCLIS.CVAN.SETTING;

namespace CMCLIS.CVAN.CORE.Provider
{
    public abstract class OracleBaseImpl<T> where T : new()
    {
        protected string ConnectionString;
        protected LuceneIndexInfo LuceneIndexData = null;
        protected string PackageName;
        protected string TableName;
        private string[] fieldLucene;

        protected OracleBaseImpl()
        {
            SetInfoDerivedClass();
            if (LuceneIndexData.IsUseLucene)
            {
                DataFullindexLucene();
            }
        }

        /// <summary>
        /// Kiểm tra và full index
        /// </summary>
        private void DataFullindexLucene()
        {
            //Get FieldSearch
            string s = string.Empty;
            var p = typeof(T).GetProperties();

            List<string> lst = new List<string>();
            foreach (var pitem in p)
            {
                if (Type.GetTypeCode(pitem.PropertyType) == TypeCode.String)
                {
                    var attCustom = pitem.GetCustomAttributes(typeof(AIFieldAttribute), true);

                    if (attCustom.Length > 0)
                    {
                        var objKey = attCustom[0] as AIFieldAttribute;
                        if (objKey != null)
                        {
                            if (objKey.FieldIndexLucene == Lucene.Net.Documents.Field.Index.ANALYZED
                                && objKey.FieldStoreLucene == Lucene.Net.Documents.Field.Store.YES)
                            {
                                if (objKey.IsKoDau)
                                    lst.Add(pitem.Name + "_INDEX_LUCENE");
                                lst.Add(pitem.Name);
                            }
                        }
                    }
                }
            }
            fieldLucene = lst.ToArray();

            string PathIndexLocation = Path.Combine(Config.PATH_INDEX_LUCENE_ORACLE, TableName) + @"\";

            //Nếu chưa tồn tại thư mục thì tạo
            if (!System.IO.Directory.Exists(PathIndexLocation))
            {
                System.IO.Directory.CreateDirectory(PathIndexLocation);
            }
            Lucene.Net.Store.Directory dir = FSDirectory.Open(new DirectoryInfo(PathIndexLocation));

            //Nếu chưa index thì index
            if (!IsIndexExists(dir))
            {
                if (IsLooked(dir))
                {
                    IndexWriter.Unlock(dir);
                }

                FullindexLucene();
            }
            else if (!File.Exists(Path.Combine(Config.PATH_INDEX_LUCENE_ORACLE, string.Format(@"{0}\Fullimport\{1}", TableName, DateTime.Now.ToString("yyyyMMdd")))))
            {
                if (!dir.FileExists(Config.FILE_NAME_LOCK_LUCENE))
                {

                    this.FullindexLucene();
                }
            }
        }

        /// <summary>
        /// set một số thuộc tính chung của class kế thừa: table name, id name trong db
        /// </summary>
        /// <returns></returns>
        protected abstract void SetInfoDerivedClass();

        #region Utility
        //----------
        /// <summary>
        /// convert attribute trước khi insert,update vào db, nếu null thì trả về DBNull.Value
        /// </summary>
        /// <param name="atrr"></param>
        /// <returns></returns>
        protected object AttrToDb(object atrr)
        {
            return atrr ?? DBNull.Value;
        }

        //----------
        /// <summary>
        /// lấy giá trị từ db ra, trả về null nếu là dbnull
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="colName"></param>
        /// <returns></returns>
        protected object AttrFromDb(IDataReader reader, string colName)
        {
            return reader[reader.GetOrdinal(colName)] == DBNull.Value ? null : reader[reader.GetOrdinal(colName)];
        }

        //----------
        /// <summary>
        /// convert 1 reader sang 1 item. reader phải read() trước khi truyền vào
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>trả về null nếu exception</returns>
        public virtual T ConvertReaderToData(IDataReader reader)
        {
            var item = new T();
            string colName = string.Empty;
            try
            {
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    colName = reader.GetName(i);
                    var type = reader.GetFieldType(i);
                    var datatype = reader.GetDataTypeName(i);
                    var value = AttrFromDb(reader, colName);
                    if (value != null)
                    {
                        if ("CHAR".Equals(datatype.ToUpper()) && "1".Equals(value.ToString()))
                            value = true;
                        else if ("CHAR".Equals(datatype.ToUpper()) && "0".Equals(value.ToString()))
                            value = false;
                        if (typeof(T).GetProperty(colName) != null)
                            typeof(T).GetProperty(colName).SetValue(item, value, null);
                    }
                }
            }
            catch (Exception ex) { LogEventError.LogEvent("Column name: " + colName, ex); throw ex; }

            return item;
        }


        //----------
        /// <summary>
        /// convert 1 reader sang list item. reader không cần read() trước khi truyền vào
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public virtual List<T> ConvertReaderToList(IDataReader reader)
        {
            var list = new List<T>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    list.Add(ConvertReaderToData(reader));
                }
            }

            return list;
        }

        /// <summary>
        /// Convert Datatable sang List item.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public virtual List<T> ToCollection(DataTable dt)
        {
            //List<T> lst = new System.Collections.Generic.List<T>();
            //Type tClass = typeof(T);
            //PropertyInfo[] pClass = tClass.GetProperties();
            //List<DataColumn> dc = dt.Columns.Cast<DataColumn>().ToList();
            //T cn;
            //foreach (DataRow item in dt.Rows)
            //{
            //    cn = (T)Activator.CreateInstance(tClass);
            //    foreach (PropertyInfo pc in pClass)
            //    {
            //        // Can comment try catch block. 
            //        try
            //        {
            //            DataColumn d = dc.Find(c => c.ColumnName == pc.Name);
            //            if (d != null)
            //            {
            //                pc.SetValue(cn, item[pc.Name].ToString(), null);
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            string a = string.Empty;
            //        }
            //    }
            //    lst.Add(cn);
            //}
            //return lst;
            List<T> list = new List<T>();
            var typeProperties = typeof(T).GetProperties().Select(propertyInfo => new
            {
                PropertyInfo = propertyInfo,
                Type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType
            }).ToList();

            foreach (var row in dt.Rows.Cast<DataRow>())
            {
                T obj = new T();
                foreach (var typeProperty in typeProperties)
                {
                    object value = row[typeProperty.PropertyInfo.Name];
                    if (typeProperty.Type.Name == "Boolean")
                    {
                        if (value.ToString() == "1")
                        {
                            object safeValue = value == null || DBNull.Value.Equals(value) ? null : Convert.ChangeType(true, typeProperty.Type);
                            typeProperty.PropertyInfo.SetValue(obj, safeValue, null);
                        }
                        else
                        {
                            object safeValue = value == null || DBNull.Value.Equals(value) ? null : Convert.ChangeType(false, typeProperty.Type);
                            typeProperty.PropertyInfo.SetValue(obj, safeValue, null);
                        }
                    }
                    else
                    {
                        object safeValue = value == null || DBNull.Value.Equals(value)
                        ? null
                        : Convert.ChangeType(value, typeProperty.Type);

                        typeProperty.PropertyInfo.SetValue(obj, safeValue, null);
                    }

                }
                list.Add(obj);
            }
            return list;
        }

        
        /// <summary>
        /// Convert our List to a DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns>DataTable</returns>
        public virtual DataTable ToDataTable(List<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            object[] values = new object[props.Count];
            using (DataTable table = new DataTable())
            {
                long _pCt = props.Count;
                for (int i = 0; i < _pCt; ++i)
                {
                    PropertyDescriptor prop = props[i];
                    table.Columns.Add(prop.Name, prop.PropertyType);
                }
                foreach (T item in data)
                {
                    long _vCt = values.Length;
                    for (int i = 0; i < _vCt; ++i)
                    {
                        values[i] = props[i].GetValue(item);
                    }
                    table.Rows.Add(values);
                }
                return table;
            }
        }

        /// <summary>
        /// Convert our List to a DataSet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns>DataSet</returns>
        public virtual DataSet ToDataSet(List<T> list)
        {
            Type elementType = typeof(T);
            using (DataSet ds = new DataSet())
            {
                using (DataTable t = new DataTable())
                {
                    ds.Tables.Add(t);
                    //add a column to table for each public property on T
                    PropertyInfo[] _props = elementType.GetProperties();
                    foreach (PropertyInfo propInfo in _props)
                    {
                        Type _pi = propInfo.PropertyType;
                        Type ColType = Nullable.GetUnderlyingType(_pi) ?? _pi;
                        t.Columns.Add(propInfo.Name, ColType);
                    }
                    //go through each property on T and add each value to the table
                    foreach (T item in list)
                    {
                        DataRow row = t.NewRow();
                        foreach (PropertyInfo propInfo in _props)
                        {
                            row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                        }
                        t.Rows.Add(row);
                    }
                }
                return ds;
            }
        }
        #endregion

        #region Các hàm Add, Update, Delete, GetInfo, GetPage

        //----------
        /// <summary>
        /// insert một item vào csdl, 
        /// </summary>
        /// <param name="item">item cần insert </param>
        /// <returns>trả về item vừa insert vào csld</returns>
        public virtual int Add(T item)
        {

            var conn = new OracleConnection(ConnectionString);

            var commandText = new StringBuilder(PackageName + ".usp_ADD");
            var dsCmd = new OracleCommand(commandText.ToString(), conn) { CommandType = CommandType.StoredProcedure };
            var result = 0;

            try
            {
                conn.Open();
                OracleCommandBuilder.DeriveParameters(dsCmd);

                foreach (OracleParameter parameter in dsCmd.Parameters)
                {
                    if (parameter.Direction == ParameterDirection.Input)
                    {
                        var paramName = parameter.ParameterName.Substring(2);
                        var field = typeof(T).GetProperty(paramName);
                        if (field != null)
                        {
                            var value = AttrToDb(field.GetValue(item, null));
                            dsCmd.Parameters[parameter.ParameterName].Value = value;
                        }
                    }
                    else
                    {
                        dsCmd.Parameters[parameter.ParameterName].Value = DBNull.Value;
                    }
                }
                //insert item vào db
                dsCmd.ExecuteNonQuery();
                result = int.Parse(dsCmd.Parameters["p_RESULT"].Value.ToString());
                if (result != -1)
                {
                    if (LuceneIndexData.IsUpdateLucene)
                        AddDoc(result);
                }
            }
            catch (OracleException se)
            {
                result = -1;
                LogEventError.LogEvent("Add " + TableName + ":ERROR SQL Exception:", se);
                throw new Exception(Constant.MESSAGE_SERVER_QUA_TAI, se);
            }
            catch (Exception ex)
            {
                result = -1;
                LogEventError.LogEvent("Add " + TableName + ":ERROR:", ex);
                throw new Exception(Constant.MESSAGE_DU_LIEU_CHUA_HOP_LE, ex);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        //----------
        /// <summary>
        /// update 1 item vào db, trả về số bản ghi bị ảnh hưởng. 
        /// </summary>
        /// <param name="item"></param>
        /// <returns>trả về -1 nếu exception</returns>
        public virtual int Update(T item)
        {

            int result = 0;
            var conn = new OracleConnection(ConnectionString);
            var commandText = new StringBuilder(PackageName + ".usp_UPDATE");
            var dsCmd = new OracleCommand(commandText.ToString(), conn);
            dsCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                OracleCommandBuilder.DeriveParameters(dsCmd);
                foreach (OracleParameter parameter in dsCmd.Parameters)
                {
                    if (parameter.Direction == ParameterDirection.Input)
                    {
                        var paramName = parameter.ParameterName.Substring(2);
                        var field = typeof(T).GetProperty(paramName);
                        if (field != null)
                        {
                            var value = AttrToDb(field.GetValue(item, null));
                            dsCmd.Parameters[parameter.ParameterName].Value = value;
                        }
                    }
                }
                //update item vào db
                dsCmd.ExecuteNonQuery();
                result = int.Parse(dsCmd.Parameters["p_RESULT"].Value.ToString());
                if (result != -1)
                {
                    if (LuceneIndexData.IsUpdateLucene)
                        UpdateDoc(item);
                }
            }
            catch (OracleException se)
            {
                result = -1;
                LogEventError.LogEvent("Update " + TableName + ":ERROR SQL Exception:", se);
                throw new Exception(Constant.MESSAGE_SERVER_QUA_TAI, se);
            }
            catch (Exception ex)
            {
                result = -1;
                LogEventError.LogEvent("Update " + TableName + ":ERROR:", ex);
                throw new Exception(Constant.MESSAGE_DU_LIEU_CHUA_HOP_LE, ex);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }


        //----------
        /// <summary>
        /// xóa item được truyền vào. chỉ cần giá trị của id. 
        /// </summary>
        /// <param name="item"></param>
        /// <returns>trả về số bản ghi bị xóa. -1 là exception</returns>
        public virtual int Delete(T item)
        {

            int result = 0;
            var conn = new OracleConnection(ConnectionString);
            try
            {
                var commandText = new StringBuilder(PackageName + ".usp_DELETE");
                var dsCmd = new OracleCommand(commandText.ToString(), conn);
                dsCmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                OracleCommandBuilder.DeriveParameters(dsCmd);
                foreach (OracleParameter parameter in dsCmd.Parameters)
                {
                    if (parameter.Direction == ParameterDirection.Input)
                    {
                        var paramName = parameter.ParameterName.Substring(1);
                        var field = typeof(T).GetProperty(paramName);
                        if (field != null)
                        {
                            var value = AttrToDb(field.GetValue(item, null));
                            dsCmd.Parameters[parameter.ParameterName].Value = value;
                        }
                    }
                }
                result = dsCmd.ExecuteNonQuery();

                if (LuceneIndexData.IsUpdateLucene)
                    DeleteDoc(item);
            }
            catch (OracleException se)
            {
                result = -1;
                LogEventError.LogEvent("Delete " + TableName + ":ERROR SQL Exception:", se);
                throw new Exception(Constant.MESSAGE_SERVER_QUA_TAI, se);
            }
            catch (Exception ex)
            {
                result = -1;
                LogEventError.LogEvent("Delete " + TableName + ":ERROR:", ex);
                throw new Exception(Constant.MESSAGE_DU_LIEU_CHUA_HOP_LE, ex);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        //----------
        /// <summary>
        /// xóa item được truyền vào. chỉ cần giá trị của id. 
        /// </summary>
        /// <param name="item"></param>
        /// <returns>trả về số bản ghi bị xóa. -1 là exception</returns>
        public virtual int Delete(int id)
        {

            int result = 0;
            var conn = new OracleConnection(ConnectionString);
            try
            {
                var commandText = new StringBuilder(PackageName + ".usp_DELETE");
                var dsCmd = new OracleCommand(commandText.ToString(), conn);
                dsCmd.CommandType = CommandType.StoredProcedure;
                dsCmd.Parameters.Add("p_ID", AttrToDb(id));
                conn.Open();

                result = dsCmd.ExecuteNonQuery();

                if (LuceneIndexData.IsUpdateLucene)
                    DeleteDoc(id);
            }
            catch (OracleException se)
            {
                result = -1;
                LogEventError.LogEvent("Delete " + TableName + ":ERROR SQL Exception:", se);
                throw new Exception(Constant.MESSAGE_SERVER_QUA_TAI, se);
            }
            catch (Exception ex)
            {
                result = -1;
                LogEventError.LogEvent("Delete " + TableName + ":ERROR:", ex);
                throw new Exception(Constant.MESSAGE_DU_LIEU_CHUA_HOP_LE, ex);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        //----------
        /// <summary>
        /// lấy về item theo id. truyền vào objec, chỉ cần giá trị id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual T GetInfo(T item)
        {
            var result = default(T);
            var conn = new OracleConnection(ConnectionString);
            try
            {
                var commandText = new StringBuilder(PackageName + ".usp_GET_INFO_BY_ID");
                var dsCmd = new OracleCommand(commandText.ToString(), conn);
                dsCmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                OracleCommandBuilder.DeriveParameters(dsCmd);
                foreach (SqlParameter parameter in dsCmd.Parameters)
                {
                    if (parameter.Direction == ParameterDirection.Input)
                    {
                        var paramName = parameter.ParameterName.Substring(1);
                        var field = typeof(T).GetProperty(paramName);
                        if (field != null)
                        {
                            var value = AttrToDb(field.GetValue(item, null));
                            dsCmd.Parameters[parameter.ParameterName].Value = value;
                        }
                    }
                }

                var reader = dsCmd.ExecuteReader();
                if (reader.Read())
                    result = ConvertReaderToData(reader);
            }
            catch (OracleException se)
            {
                LogEventError.LogEvent("GetInfo " + TableName + ":ERROR SQL Exception:", se);
                throw new Exception(Constant.MESSAGE_SERVER_QUA_TAI, se);
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent("GetInfo " + TableName + ":ERROR:", ex);
                throw new Exception(Constant.MESSAGE_DU_LIEU_CHUA_HOP_LE, ex);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        //----------
        /// <summary>
        /// lấy về item theo id. truyền vào objec, chỉ cần giá trị id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual T GetInfo(int id)
        {
            var result = default(T);
            var conn = new OracleConnection(ConnectionString);
            try
            {
                var commandText = new StringBuilder(PackageName + ".usp_GET_INFO_BY_ID");
                var dsCmd = new OracleCommand(commandText.ToString(), conn);
                dsCmd.CommandType = CommandType.StoredProcedure;
                dsCmd.Parameters.Add("p_ID", AttrToDb(id));
                dsCmd.Parameters.Add("p_RESULT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                conn.Open();

                var reader = dsCmd.ExecuteReader();
                while (reader.Read())
                {
                    result = ConvertReaderToData(reader);
                    Console.WriteLine(result);
                }
            }
            catch (OracleException se)
            {
                LogEventError.LogEvent("GetInfo " + TableName + ":ERROR SQL Exception:", se);
                throw new Exception(Constant.MESSAGE_SERVER_QUA_TAI, se);
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent("GetInfo " + TableName + ":ERROR:", ex);
                throw new Exception(Constant.MESSAGE_DU_LIEU_CHUA_HOP_LE, ex);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
        //----------
        /// <summary>
        /// lấy về toàn bộ item trong db
        /// </summary>
        /// <returns>trả về null nếu exception, 0 item nếu không có dữ liệu</returns>
        public virtual List<T> GetList()
        {
            List<T> result = null;
            var conn = new OracleConnection(ConnectionString);
            var commandText = new StringBuilder(PackageName + ".usp_GET_LIST_ALL");
            var dsCmd = new OracleCommand(commandText.ToString(), conn);
            dsCmd.CommandType = CommandType.StoredProcedure;

            try
            {
                dsCmd.Parameters.Add("p_RESULT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                conn.Open();
                var reader = dsCmd.ExecuteReader();
                result = ConvertReaderToList(reader);
            }
            catch (OracleException se)
            {
                LogEventError.LogEvent("GetList " + TableName + ":ERROR SQL Exception:", se);
                throw new Exception(Constant.MESSAGE_SERVER_QUA_TAI, se);
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent("GetList " + TableName + ":ERROR:", ex);
                throw new Exception(Constant.MESSAGE_DU_LIEU_CHUA_HOP_LE, ex);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        #endregion

        #region Excute
        public virtual int ExecuteNonQuery(string command, OracleParameter[] sqlparam)
        {
            int result = 0;
            var conn = new OracleConnection(ConnectionString);
            var commandText = new StringBuilder(PackageName + "." + command);
            var dsCmd = new OracleCommand(commandText.ToString(), conn);
            dsCmd.CommandType = CommandType.StoredProcedure;
            if (sqlparam != null)
                dsCmd.Parameters.AddRange(sqlparam);
            try
            {
                conn.Open();
                result = dsCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public virtual int ExecuteNonQuery(OracleCommand dsCmd)
        {
            int result = 0;
            var conn = new OracleConnection(ConnectionString);
            dsCmd.Connection = conn;

            try
            {
                conn.Open();
                result = dsCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public virtual List<T> ExecuteQuery(string command, OracleParameter[] sqlparam)
        {
            List<T> result = null;
            var conn = new OracleConnection(ConnectionString);
            var commandText = new StringBuilder(PackageName + "." + command);
            var dsCmd = new OracleCommand(commandText.ToString(), conn);
            dsCmd.CommandType = CommandType.StoredProcedure;
            if (sqlparam != null)
                dsCmd.Parameters.AddRange(sqlparam);
            dsCmd.Parameters.Add("p_RESULT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            try
            {
                conn.Open();
                var reader = dsCmd.ExecuteReader();
                result = ConvertReaderToList(reader);
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public virtual List<T> ExecuteQuery(string command, OracleParameter[] sqlparam, int pageIndex, int pageSize, ref int totalRecord)
        {
            List<T> result = null;
            var conn = new OracleConnection(ConnectionString);
            var commandText = new StringBuilder(PackageName + "." + command);
            var dsCmd = new OracleCommand(commandText.ToString(), conn);
            dsCmd.CommandType = CommandType.StoredProcedure;
            if (sqlparam != null)
                dsCmd.Parameters.AddRange(sqlparam);
            dsCmd.Parameters.Add("p_PAGE_INDEX", AttrToDb(pageIndex));
            dsCmd.Parameters.Add("p_PAGE_SIZE", AttrToDb(pageSize));
            dsCmd.Parameters.Add("p_RESULT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            try
            {
                conn.Open();
                OracleDataAdapter adapter = new OracleDataAdapter(dsCmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                result = ToCollection(ds.Tables[0]);
                totalRecord = ds.Tables[0].Rows.Count > 0 ? int.Parse(ds.Tables[0].Rows[0]["TOTAL_RECORD"].ToString()) : 0;
                //totalRecord = int.Parse(dsCmd.Parameters["p_TotalRecord"].Value.ToString());
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public virtual DataSet ExecuteQueryToDataSet(string command, OracleParameter[] sqlparam)
        {
            DataSet result = null;
            var conn = new OracleConnection(ConnectionString);
            var commandText = new StringBuilder(PackageName + "." + command);
            var dsCmd = new OracleCommand(commandText.ToString(), conn);
            dsCmd.CommandType = CommandType.StoredProcedure;
            if (sqlparam != null)
                dsCmd.Parameters.AddRange(sqlparam);
            try
            {
                conn.Open();

                OracleDataAdapter adapter = new OracleDataAdapter(dsCmd);
                result = new DataSet();
                adapter.Fill(result);
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public virtual DataSet ExecuteQueryToDataSet(OracleCommand command)
        {
            DataSet result = null;
            var conn = new OracleConnection(ConnectionString);
            command.Connection = conn;
            try
            {
                conn.Open();

                OracleDataAdapter adapter = new OracleDataAdapter(command);
                result = new DataSet();
                adapter.Fill(result);
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public virtual DataSet ExecuteQueryToDataSet(string queryString)
        {

            DataSet result = null;
            var conn = new OracleConnection(ConnectionString);
            var commandText = new StringBuilder(queryString);
            var dsCmd = new OracleCommand(commandText.ToString(), conn);
            dsCmd.CommandType = CommandType.Text;
            try
            {
                conn.Open();

                OracleDataAdapter adapter = new OracleDataAdapter(dsCmd);
                result = new DataSet();
                adapter.Fill(result);
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public virtual DataTable ExecuteQueryToDataTable(string command, OracleParameter[] sqlparam)
        {
            DataTable result = new DataTable();
            var conn = new OracleConnection(ConnectionString);
            var commandText = new StringBuilder(PackageName + "." + command);
            var dsCmd = new OracleCommand(commandText.ToString(), conn);
            dsCmd.CommandType = CommandType.StoredProcedure;
            if (sqlparam != null)
                dsCmd.Parameters.AddRange(sqlparam);
            dsCmd.Parameters.Add("p_RESULT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            try
            {
                conn.Open();

                OracleDataAdapter adapter = new OracleDataAdapter(dsCmd);
                adapter.Fill(result);
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public virtual DataTable ExecuteQueryToDataTable(string command, OracleParameter[] sqlparam, int pageIndex, int pageSize, ref int totalRecord)
        {
            DataTable result = new DataTable();
            var conn = new OracleConnection(ConnectionString);
            var commandText = new StringBuilder(PackageName + "." + command);
            var dsCmd = new OracleCommand(commandText.ToString(), conn);
            dsCmd.CommandType = CommandType.StoredProcedure;
            if (sqlparam != null)
                dsCmd.Parameters.AddRange(sqlparam);
            dsCmd.Parameters.Add("@PageIndex", AttrToDb(pageIndex));
            dsCmd.Parameters.Add("@PageSize", AttrToDb(pageSize));
            dsCmd.Parameters.Add("@TotalRecord", SqlDbType.Int);
            dsCmd.Parameters["@TotalRecord"].Direction = ParameterDirection.Output;
            try
            {
                conn.Open();

                OracleDataAdapter adapter = new OracleDataAdapter(dsCmd);
                adapter.Fill(result);
                totalRecord = int.Parse(dsCmd.Parameters["@TotalRecord"].Value.ToString());
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public virtual object ExecuteScalar(string command, OracleParameter[] sqlparam)
        {
            object result = null;
            var conn = new OracleConnection(ConnectionString);
            var commandText = new StringBuilder(PackageName + "." + command);
            var dsCmd = new OracleCommand(commandText.ToString(), conn);
            dsCmd.CommandType = CommandType.StoredProcedure;
            if (sqlparam != null)
                dsCmd.Parameters.AddRange(sqlparam);
            try
            {
                conn.Open();
                result = dsCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public virtual object ExecuteScalar(OracleCommand sqlCmd)
        {
            object result = null;
            var conn = new OracleConnection(ConnectionString);
            sqlCmd.Connection = conn;

            try
            {
                conn.Open();
                result = sqlCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }



        #endregion


        #region Lucene
        public virtual void FullindexLucene()
        {
            IndexWriter writer = null;
            OracleConnection conn = null;
            try
            {
                Lucene.Net.Store.Directory dir = FSDirectory.Open(new DirectoryInfo(Config.PATH_INDEX_LUCENE_ORACLE));
                var maxFieldLeng = new IndexWriter.MaxFieldLength(LuceneIndexData.MaxFieldLength);
                writer = new IndexWriter(dir, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29), true, maxFieldLeng);

                conn = new OracleConnection(ConnectionString);
                var commandText = new StringBuilder(PackageName + ".usp_GET_LIST_ALL");
                var dsCmd = new OracleCommand(commandText.ToString(), conn);
                dsCmd.CommandType = CommandType.StoredProcedure;
                dsCmd.Parameters.Add("p_RESULT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                conn.Open();
                var reader = dsCmd.ExecuteReader();

                IndexListToLucene(writer, reader);

                if (!System.IO.Directory.Exists(Path.Combine(Config.PATH_INDEX_LUCENE_ORACLE, string.Format(@"{0}\Fullimport", TableName))))
                {
                    System.IO.Directory.CreateDirectory(Path.Combine(Config.PATH_INDEX_LUCENE_ORACLE, string.Format(@"{0}\Fullimport", TableName)));
                }

                File.Create(Path.Combine(Config.PATH_INDEX_LUCENE_ORACLE, string.Format(@"{0}\Fullimport\{1}", TableName, DateTime.Now.ToString("yyyyMMdd"))));
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
                if (writer != null)
                {
                    writer.Optimize();
                    writer.Close();
                }
            }
        }

        public int CountDoc()
        {
            int result = 0;
            try
            {
                Lucene.Net.Store.Directory dir = FSDirectory.Open(new DirectoryInfo(Config.PATH_INDEX_LUCENE_ORACLE));
                var searcher = new Lucene.Net.Search.IndexSearcher(dir, true);

                result = searcher.MaxDoc();
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            return result;
        }

        public bool AddDoc(int id)
        {
            var conn = new OracleConnection(ConnectionString);
            bool flag = false;
            IndexWriter writer = null;
            try
            {
                Lucene.Net.Store.Directory dir = FSDirectory.Open(new DirectoryInfo(Config.PATH_INDEX_LUCENE_ORACLE));
                var maxFieldLeng = new IndexWriter.MaxFieldLength(LuceneIndexData.MaxFieldLength);
                writer = new IndexWriter(dir, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29), false, maxFieldLeng);

                var commandText = new StringBuilder(PackageName + ".usp_GET_INFO_BY_ID");
                var dsCmd = new OracleCommand(commandText.ToString(), conn);
                dsCmd.CommandType = CommandType.StoredProcedure;
                dsCmd.Parameters.Add("p_ID", AttrToDb(id));
                dsCmd.Parameters.Add("p_RESULT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                conn.Open();

                var reader = dsCmd.ExecuteReader();
                while (reader.Read())
                {
                    IndexDocument(writer, reader);
                }
                writer.Commit();
                flag = true;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                conn.Close();
                if (writer != null)
                {
                    writer.Close();
                }
            }

            return flag;
        }

        public bool AddDoc(T item)
        {
            bool flag = false;
            IndexWriter writer = null;
            try
            {
                Lucene.Net.Store.Directory dir = FSDirectory.Open(new DirectoryInfo(Config.PATH_INDEX_LUCENE_ORACLE));
                var maxFieldLeng = new IndexWriter.MaxFieldLength(LuceneIndexData.MaxFieldLength);
                writer = new IndexWriter(dir, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29), false, maxFieldLeng);

                var doc = ConvertItemToDocument(item);

                writer.AddDocument(doc);
                writer.Commit();
                flag = true;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            return flag;
        }

        public bool UpdateDoc(int id)
        {
            var conn = new OracleConnection(ConnectionString);
            bool flag = false;
            IndexWriter writer = null;
            try
            {
                Lucene.Net.Store.Directory dir = FSDirectory.Open(new DirectoryInfo(Config.PATH_INDEX_LUCENE_ORACLE));
                var maxFieldLeng = new IndexWriter.MaxFieldLength(LuceneIndexData.MaxFieldLength);
                writer = new IndexWriter(dir, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29), false, maxFieldLeng);

                var oParserDel = new Lucene.Net.QueryParsers.QueryParser(Lucene.Net.Util.Version.LUCENE_29, "Id", new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
                var queryDel = oParserDel.Parse(id.ToString());
                writer.DeleteDocuments(queryDel);

                var commandText = new StringBuilder(PackageName + ".usp_GET_INFO_BY_ID");
                var dsCmd = new OracleCommand(commandText.ToString(), conn);
                dsCmd.CommandType = CommandType.StoredProcedure;
                dsCmd.Parameters.Add("p_ID", AttrToDb(id));
                dsCmd.Parameters.Add("p_RESULT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                conn.Open();

                var reader = dsCmd.ExecuteReader();
                while (reader.Read())
                {
                    IndexDocument(writer, reader);
                }
                writer.Commit();
                flag = true;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                conn.Close();
                if (writer != null)
                {
                    writer.Close();
                }
            }
            return flag;
        }

        public bool UpdateDoc(T item)
        {
            bool flag = false;
            IndexWriter writer = null;
            try
            {
                Lucene.Net.Store.Directory dir = FSDirectory.Open(new DirectoryInfo(Config.PATH_INDEX_LUCENE_ORACLE));
                var maxFieldLeng = new IndexWriter.MaxFieldLength(LuceneIndexData.MaxFieldLength);
                writer = new IndexWriter(dir, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29), false, maxFieldLeng);

                string keyValue = string.Empty;
                string fieldName = string.Empty;
                var doc = ConvertItemToDocument(item);
                var p = typeof(T).GetProperties();
                foreach (var pItem in p)
                {
                    var attCustom = pItem.GetCustomAttributes(typeof(AIFieldAttribute), true);
                    if (attCustom.Length > 0)
                    {
                        var objKey = attCustom[0] as AIFieldUnikeyAttribute;
                        if (objKey != null)
                        {
                            fieldName = objKey.FieldName;
                            keyValue = pItem.GetValue(item, null).ToString();
                            break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(keyValue))
                {
                    writer.UpdateDocument(new Term(fieldName, keyValue), doc);
                    writer.Commit();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            return flag;
        }

        public bool UpdateDoc(List<T> lst)
        {
            bool flag = false;
            IndexWriter writer = null;
            try
            {
                Lucene.Net.Store.Directory dir = FSDirectory.Open(new DirectoryInfo(Config.PATH_INDEX_LUCENE_ORACLE));
                var maxFieldLeng = new IndexWriter.MaxFieldLength(LuceneIndexData.MaxFieldLength);
                writer = new IndexWriter(dir, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29), false, maxFieldLeng);

                string keyValue = string.Empty;
                string fieldName = string.Empty;
                foreach (T item in lst)
                {
                    keyValue = string.Empty;

                    var doc = ConvertItemToDocument(item);
                    var p = typeof(T).GetProperties();
                    foreach (var pItem in p)
                    {
                        var attCustom = pItem.GetCustomAttributes(typeof(AIFieldAttribute), true);
                        if (attCustom.Length > 0)
                        {
                            var objKey = attCustom[0] as AIFieldUnikeyAttribute;
                            if (objKey != null)
                            {
                                fieldName = objKey.FieldName;
                                keyValue = pItem.GetValue(item, null).ToString();
                                break;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        writer.UpdateDocument(new Term(fieldName, keyValue), doc);
                    }
                }
                writer.Commit();
                flag = true;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            return flag;
        }

        public bool UpdateDoc(int id, T item)
        {
            bool flag = false;
            IndexWriter writer = null;
            try
            {
                Lucene.Net.Store.Directory dir = FSDirectory.Open(new DirectoryInfo(Config.PATH_INDEX_LUCENE_ORACLE));
                var maxFieldLeng = new IndexWriter.MaxFieldLength(LuceneIndexData.MaxFieldLength);
                writer = new IndexWriter(dir, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29), false, maxFieldLeng);

                var doc = ConvertItemToDocument(item);

                writer.UpdateDocument(new Term("Id", id.ToString()), doc);
                writer.Commit();
                flag = true;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            return flag;
        }

        public bool DeleteDoc(T item)
        {
            bool flag = false;
            IndexWriter writer = null;
            try
            {
                Lucene.Net.Store.Directory dir = FSDirectory.Open(new DirectoryInfo(Config.PATH_INDEX_LUCENE_ORACLE));
                var maxFieldLeng = new IndexWriter.MaxFieldLength(LuceneIndexData.MaxFieldLength);
                writer = new IndexWriter(dir, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29), false, maxFieldLeng);

                string keyValue = string.Empty;
                string fieldName = string.Empty;
                var doc = ConvertItemToDocument(item);
                var p = typeof(T).GetProperties();
                foreach (var pItem in p)
                {
                    var attCustom = pItem.GetCustomAttributes(typeof(AIFieldAttribute), true);
                    if (attCustom.Length > 0)
                    {
                        var objKey = attCustom[0] as AIFieldUnikeyAttribute;
                        if (objKey != null)
                        {
                            fieldName = objKey.FieldName;
                            keyValue = pItem.GetValue(item, null).ToString();
                            break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var oParserDel = new Lucene.Net.QueryParsers.QueryParser(Lucene.Net.Util.Version.LUCENE_29, fieldName, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
                    var queryDel = oParserDel.Parse(keyValue);
                    writer.DeleteDocuments(queryDel);
                    writer.Commit();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            return flag;
        }

        public bool DeleteDoc(List<T> lst)
        {
            bool flag = false;
            IndexWriter writer = null;
            try
            {
                Lucene.Net.Store.Directory dir = FSDirectory.Open(new DirectoryInfo(Config.PATH_INDEX_LUCENE_ORACLE));
                var maxFieldLeng = new IndexWriter.MaxFieldLength(LuceneIndexData.MaxFieldLength);
                writer = new IndexWriter(dir, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29), false, maxFieldLeng);

                string keyValue = string.Empty;
                string fieldName = string.Empty;
                foreach (T item in lst)
                {
                    keyValue = string.Empty;
                    var doc = ConvertItemToDocument(item);
                    var p = typeof(T).GetProperties();
                    foreach (var pItem in p)
                    {
                        var attCustom = pItem.GetCustomAttributes(typeof(AIFieldAttribute), true);
                        if (attCustom.Length > 0)
                        {
                            var objKey = attCustom[0] as AIFieldUnikeyAttribute;
                            if (objKey != null)
                            {
                                fieldName = objKey.FieldName;
                                keyValue = pItem.GetValue(item, null).ToString();
                                break;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        var oParserDel = new Lucene.Net.QueryParsers.QueryParser(Lucene.Net.Util.Version.LUCENE_29, fieldName, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
                        var queryDel = oParserDel.Parse(keyValue);
                        writer.DeleteDocuments(queryDel);
                    }
                }
                writer.Commit();
                flag = true;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            return flag;
        }

        public bool DeleteDoc(int id)
        {
            bool flag = false;
            IndexWriter writer = null;
            try
            {
                Lucene.Net.Store.Directory dir = FSDirectory.Open(new DirectoryInfo(Config.PATH_INDEX_LUCENE_ORACLE));
                var maxFieldLeng = new IndexWriter.MaxFieldLength(LuceneIndexData.MaxFieldLength);
                writer = new IndexWriter(dir, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29), false, maxFieldLeng);

                var oParserDel = new Lucene.Net.QueryParsers.QueryParser(Lucene.Net.Util.Version.LUCENE_29, "Id", new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
                var queryDel = oParserDel.Parse(id.ToString());
                writer.DeleteDocuments(queryDel);
                writer.Commit();
                flag = true;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            return flag;
        }

        public T GetDoc(int id)
        {
            T result = new T();
            try
            {
                Lucene.Net.Store.Directory dir = FSDirectory.Open(new DirectoryInfo(Config.PATH_INDEX_LUCENE_ORACLE));
                var searcher = new Lucene.Net.Search.IndexSearcher(dir, true);

                var oParser = new Lucene.Net.QueryParsers.QueryParser(Lucene.Net.Util.Version.LUCENE_29, "Id", new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
                var query = oParser.Parse(id.ToString());

                var topDocs = searcher.Search(query, null, 1);
                if (topDocs != null && topDocs.totalHits > 0)
                {
                    result = ConvertDocumentToItem(searcher.Doc(topDocs.scoreDocs[0].doc));
                }

            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            return result;
        }

        public List<T> Search(Query query)
        {
            return Search(query, null, null, 0, false);
        }

        public List<T> Search(Query query, bool hightlight)
        {
            return Search(query, null, null, 0, hightlight);
        }

        public List<T> Search(Query query, int top)
        {
            return Search(query, null, null, top, false);
        }

        public List<T> Search(string keyword)
        {
            Lucene.Net.QueryParsers.MultiFieldQueryParser parser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_29, fieldLucene, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
            parser.SetDefaultOperator(QueryParser.Operator.OR);
            var q = parser.Parse(keyword);
            return Search(q, null, null, 20, false);
        }

        public List<T> Search(string keyword, bool hightlight)
        {
            Lucene.Net.QueryParsers.MultiFieldQueryParser parser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_29, fieldLucene, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
            parser.SetDefaultOperator(QueryParser.Operator.OR);
            var q = parser.Parse(keyword);
            return Search(q, null, null, 20, hightlight);
        }

        public List<T> Search(string keyword, int top)
        {
            Lucene.Net.QueryParsers.MultiFieldQueryParser parser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_29, fieldLucene, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
            parser.SetDefaultOperator(QueryParser.Operator.OR);
            var q = parser.Parse(keyword);
            return Search(q, null, null, top, false);
        }

        public List<T> Search(string keyword, int top, bool hightlight)
        {
            Lucene.Net.QueryParsers.MultiFieldQueryParser parser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_29, fieldLucene, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
            parser.SetDefaultOperator(QueryParser.Operator.OR);
            var q = parser.Parse(keyword);
            return Search(q, null, null, top, hightlight);
        }

        public List<T> Search(Query query, Filter filter)
        {
            return Search(query, filter, null, 0, false);
        }

        public List<T> Search(Query query, Filter filter, Sort sort)
        {
            return Search(query, filter, sort, 0, false);
        }

        public List<T> Search(Query query, Filter filter, Sort sort, bool hightlight)
        {
            return Search(query, filter, sort, 0, false);
        }

        /// <summary>
        /// Hàm search
        /// </summary>
        /// <param name="query">Câu query. Ex:
        /// <para>Lấy 1 trường: Id:1</para>
        /// <para>Điều kiện 'và': Id:1 && Status:2</para>
        /// <para>Điều kiện 'hoặc': Id:1 || Status:1</para>
        /// </param>
        /// <param name="filter">Điều kiện lọc: HightLight...</param>
        /// <param name="sort">Sắp xếp</param>
        /// <param name="top">Số bản ghi lấy</param>
        /// <returns></returns>
        public List<T> Search(Query query, Filter filter, Sort sort, int top, bool hightlight)
        {
            List<T> result = null;
            try
            {
                Lucene.Net.Store.Directory dir = FSDirectory.Open(new DirectoryInfo(Config.PATH_INDEX_LUCENE_ORACLE));
                var searcher = new Lucene.Net.Search.IndexSearcher(dir, true);

                if (top == 0)
                    top = 100;

                Hits hits = searcher.Search(query, filter, sort);

                Lucene.Net.Analysis.Standard.StandardAnalyzer analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29);
                // code highlighting
                Formatter formatter = new Lucene.Net.Highlight.SimpleHTMLFormatter("<em>", "</em>");
                Lucene.Net.Highlight.SimpleFragmenter fragmenter = new Lucene.Net.Highlight.SimpleFragmenter(500);
                Lucene.Net.Highlight.QueryScorer scorer = new Lucene.Net.Highlight.QueryScorer(query);
                Highlighter highlighter = new Lucene.Net.Highlight.Highlighter(formatter, scorer);
                highlighter.SetTextFragmenter(fragmenter);

                //for (int i = 0; i < hits.Length(); i++)
                //{
                //    Lucene.Net.Documents.Document doc = hits.Doc(i);
                //    Lucene.Net.Analysis.TokenStream stream = analyzer.TokenStream("", new StringReader(doc.Get("text")));
                //    string highlightedText = highlighter.GetBestFragments(stream, doc.Get("text"), 1, "...");
                //}

                if (hits != null)
                {
                    result = new List<T>();
                    if (hightlight)
                    {
                        for (int i = 0; i < top && i < hits.Length(); i++)
                        {
                            Document oDoc = hits.Doc(i);
                            result.Add(ConvertDocumentToItemHightLight(oDoc, highlighter, analyzer));
                        }
                    }
                    else
                    {
                        for (int i = 0; i < top && i < hits.Length(); i++)
                        {
                            Document oDoc = hits.Doc(i);
                            result.Add(ConvertDocumentToItem(oDoc));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent("Search error " + TableName, ex);
            }
            return result;
        }

        /// <summary>
        /// Hàm search và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm</param>
        /// <param name="pageIndex">Trang bắt đầu từ 1</param>
        /// <param name="pageSize">Số bản ghi trên trang: Default Config.RecordPerPage</param>
        /// <param name="totalRecord">Tổng số bản ghi tìm kiếm được</param>
        /// <returns></returns>
        public List<T> GetPage(string keyword, int pageIndex, int pageSize, ref int totalRecord)
        {
            Lucene.Net.QueryParsers.MultiFieldQueryParser parser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_29, fieldLucene, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
            parser.SetDefaultOperator(QueryParser.Operator.OR);
            var q = parser.Parse(keyword);
            return GetPage(q, null, null, pageIndex, pageSize, ref totalRecord);
        }

        /// <summary>
        /// Hàm phân trang
        /// </summary>
        /// <param name="query">Câu query. Ex:
        /// <para>Lấy 1 trường: Id:1</para>
        /// <para>Điều kiện 'và': Id:1 && Status:2</para>
        /// <para>Điều kiện 'hoặc': Id:1 || Status:1</para>
        /// </param>
        /// <param name="filter">Điều kiện lọc: HightLight...</param>
        /// <param name="sort">Sắp xếp</param>
        /// <param name="pageIndex">Trang bắt đầu từ 1</param>
        /// <param name="pageSize">Số bản ghi trên trang: Default Config.RecordPerPage</param>
        /// <param name="totalRecord">Tổng số bản ghi tìm kiếm được</param>
        /// <returns></returns>
        public List<T> GetPage(Query query, Filter filter, Sort sort, int pageIndex, int pageSize, ref int totalRecord)
        {
            List<T> result = null;
            try
            {
                Lucene.Net.Store.Directory dir = FSDirectory.Open(new DirectoryInfo(Config.PATH_INDEX_LUCENE_ORACLE));
                var searcher = new Lucene.Net.Search.IndexSearcher(dir, true);

                Hits hits = searcher.Search(query, filter, sort);
                if (hits != null)
                {
                    totalRecord = hits.Length();

                    if (pageIndex == 0)
                        pageIndex = 1;
                    if (pageSize == 0)
                        pageSize = 10;

                    int first = (pageIndex - 1) * pageSize, last = pageSize + first;

                    result = new List<T>();
                    for (int i = first; i < last && i < totalRecord; i++)
                    {
                        Document oDoc = hits.Doc(i);
                        result.Add(ConvertDocumentToItem(oDoc));
                    }
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent("GetPage Lucene " + TableName, ex);
            }
            return result;
        }

        public List<T> MoreLikeThis(string text, int top)
        {
            List<T> result = null;
            Lucene.Net.Search.IndexSearcher searcher = null;
            IndexReader reader = null;
            try
            {
                Lucene.Net.Store.Directory dir = FSDirectory.Open(new DirectoryInfo(Config.PATH_INDEX_LUCENE_ORACLE));
                searcher = new Lucene.Net.Search.IndexSearcher(dir, true);

                var oParser = new Lucene.Net.QueryParsers.QueryParser(Lucene.Net.Util.Version.LUCENE_29, "Id", new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
                var query = oParser.Parse("102");

                var hitsTemp = searcher.Search(query, null, 1);
                int docNum = hitsTemp.scoreDocs[0].doc;

                reader = IndexReader.Open(dir, true);

                //Similarity.Net.SimilarityQueries sq = new Similarity.Net.SimilarityQueries();

                Similarity.Net.MoreLikeThis mlt = new Similarity.Net.MoreLikeThis(reader);
                mlt.SetFieldNames(fieldLucene);
                mlt.SetMinTermFreq(1);
                mlt.SetMinDocFreq(1);

                //Stream stream;

                //convert string to stream
                byte[] byteArray = Encoding.UTF8.GetBytes(text);
                MemoryStream stream = new MemoryStream(byteArray);
                var q = mlt.Like(docNum);

                var hits = searcher.Search(q);

                if (hits != null)
                {
                    result = new List<T>();

                    for (int i = 0; i < top && i < hits.Length(); i++)
                    {
                        Document oDoc = hits.Doc(i);
                        result.Add(ConvertDocumentToItem(oDoc));
                    }
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent("Search error ", ex);
            }
            finally
            {
                if (searcher != null)
                {
                    searcher.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return result;
        }

        public List<T> Similarity(string text, int top)
        {
            List<T> result = null;
            Lucene.Net.Search.IndexSearcher searcher = null;
            IndexReader reader = null;
            try
            {
                Lucene.Net.Store.Directory dir = FSDirectory.Open(new DirectoryInfo(Config.PATH_INDEX_LUCENE_ORACLE));
                searcher = new Lucene.Net.Search.IndexSearcher(dir, true);

                var oParser = new Lucene.Net.QueryParsers.QueryParser(Lucene.Net.Util.Version.LUCENE_29, "Id", new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
                var query = oParser.Parse("102");

                var hitsTemp = searcher.Search(query, null, 1);
                int docNum = hitsTemp.scoreDocs[0].doc;

                reader = IndexReader.Open(dir, true);


                Similarity.Net.MoreLikeThis mlt = new Similarity.Net.MoreLikeThis(reader);
                mlt.SetFieldNames(fieldLucene);
                mlt.SetMinTermFreq(1);
                mlt.SetMinDocFreq(1);

                //Stream stream;

                //convert string to stream
                byte[] byteArray = Encoding.UTF8.GetBytes(text);
                MemoryStream stream = new MemoryStream(byteArray);
                var q = mlt.Like(docNum);

                var hits = searcher.Search(q);

                if (hits != null)
                {
                    result = new List<T>();

                    for (int i = 0; i < top && i < hits.Length(); i++)
                    {
                        Document oDoc = hits.Doc(i);
                        result.Add(ConvertDocumentToItem(oDoc));
                    }
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent("Search error ", ex);
            }
            finally
            {
                if (searcher != null)
                {
                    searcher.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return result;
        }

        #region Utility Lucene
        private bool IsIndexExists(Lucene.Net.Store.Directory dir)
        {
            return IndexReader.IndexExists(dir);
        }

        private bool IsLooked(Lucene.Net.Store.Directory dir)
        {
            return IndexWriter.IsLocked(dir);
        }

        private void IndexListToLucene(IndexWriter writer, IDataReader reader)
        {
            if (reader != null)
            {
                while (reader.Read())
                {
                    IndexDocument(writer, reader);
                }
            }
        }

        private void IndexDocument(IndexWriter writer, IDataReader reader)
        {
            string colName = string.Empty;
            try
            {
                Document doc = new Document();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    colName = reader.GetName(i);
                    var valueCheckNull = AttrFromDb(reader, colName);
                    if (valueCheckNull == null)
                        continue;

                    var value = valueCheckNull.ToString();
                    value = System.Web.HttpUtility.HtmlDecode(value);
                    value = RemoveTagComment(value);
                    value = RemoveAllTag(value);
                    if (value != null)
                    {
                        var p = typeof(T).GetProperty(colName);
                        var attCustom = p.GetCustomAttributes(typeof(AIFieldAttribute), true);
                        if (attCustom.Length > 0)
                        {
                            var objKey = attCustom[0] as AIFieldAttribute;
                            if (objKey != null)
                            {
                                doc.Add(new Field(colName, value.ToString(), objKey.FieldStoreLucene, objKey.FieldIndexLucene));
                                if (objKey.IsKoDau)
                                {
                                    string keyKoDau = colName + "_LONGLX";
                                    string valueKoDau = ConvertToKhongDau(value.ToString());
                                    doc.Add(new Field(keyKoDau, valueKoDau, objKey.FieldStoreLucene, objKey.FieldIndexLucene));
                                }
                            }
                        }
                    }
                }

                writer.AddDocument(doc);
            }
            catch (Exception ex) { LogEventError.LogEvent("Lucene index document error Column name: " + colName, ex); throw ex; }
        }

        private string RemoveAllTag(string str)
        {
            string strReturn = str.Replace("TEXT:", "");
            List<string> listTag = GetTag(str);
            if (listTag != null && listTag.Count > 0)
                foreach (string item in listTag)
                {
                    if (item.ToLower().Contains("<br"))
                        strReturn = strReturn.Replace(item, Environment.NewLine);
                    else if (item.ToLower().Contains("<p>"))
                        strReturn = strReturn.Replace(item, Environment.NewLine);
                    else if (item.ToLower().Contains("</p>"))
                        strReturn = strReturn.Replace(item, Environment.NewLine);
                    else if (strReturn.Contains(item))
                        strReturn = strReturn.Replace(item, "");
                }
            strReturn = strReturn.Replace(Environment.NewLine + Environment.NewLine + Environment.NewLine, Environment.NewLine + Environment.NewLine);
            return strReturn.Trim();
        }

        private List<string> GetTag(string str)
        {
            string strRegex = "<(?<tag>.*?)>";
            Match mt = (new Regex(strRegex)).Match(str);
            List<string> listTag = new List<string>();
            while (mt.Success)
            {
                listTag.Add(mt.Value);
                mt = mt.NextMatch();
            }
            if (listTag.Count > 0)
                return listTag;
            else
                return null;
        }

        private string RemoveTagComment(string str)
        {
            if (str != null && str.Trim() != "")
            {
                string strReturn = str;
                string strRegex = "<!--(?<tag>.*?)-->|<script.*[^CR]*?</script>|<SCRIPT.*[^CR]*?</SCRIPT>";
                Match mt = (new Regex(strRegex)).Match(str);
                while (mt.Success)
                {
                    strReturn = strReturn.Replace(mt.Value, "");
                    mt = mt.NextMatch();
                }
                return strReturn.Trim();
            }
            return "";
        }

        private void IndexDocumentFromEntity(IndexWriter writer, T item)
        {
            string colName = string.Empty;
            try
            {
                Document doc = new Document();

                var p = typeof(T).GetProperties();
                foreach (var pItem in p)
                {
                    var attCustom = pItem.GetCustomAttributes(typeof(AIFieldAttribute), true);
                    if (attCustom.Length > 0)
                    {
                        var objKey = attCustom[0] as AIFieldAttribute;
                        if (objKey != null)
                        {
                            string value = pItem.GetValue(item, null).ToString();
                            Field f = new Field(pItem.Name, pItem.GetValue(item, null).ToString(), objKey.FieldStoreLucene, objKey.FieldIndexLucene);
                            doc.Add(f);
                            if (objKey.IsKoDau)
                            {
                                string keyKoDau = colName + "_LONGLX";
                                string valueKoDau = ConvertToKhongDau(value.ToString());
                                doc.Add(new Field(keyKoDau, valueKoDau, objKey.FieldStoreLucene, objKey.FieldIndexLucene));
                            }
                        }
                    }
                }
                writer.AddDocument(doc);
            }
            catch (Exception ex) { LogEventError.LogEvent("Lucene index document error Column name: " + colName, ex); throw ex; }
        }

        private Document ConvertItemToDocument(T item)
        {
            string colName = string.Empty;
            Document doc = null;
            try
            {
                doc = new Document();

                var p = typeof(T).GetProperties();
                foreach (var pItem in p)
                {
                    var attCustom = pItem.GetCustomAttributes(typeof(AIFieldAttribute), true);

                    if (attCustom.Length > 0)
                    {
                        var objKey = attCustom[0] as AIFieldAttribute;
                        if (objKey != null)
                        {
                            string value = pItem.GetValue(item, null).ToString();
                            Field f = new Field(pItem.Name, value, objKey.FieldStoreLucene, objKey.FieldIndexLucene);
                            doc.Add(f);
                            if (objKey.IsKoDau)
                            {
                                string keyKoDau = colName + "_LONGLX";
                                string valueKoDau = ConvertToKhongDau(value.ToString());
                                doc.Add(new Field(keyKoDau, valueKoDau, objKey.FieldStoreLucene, objKey.FieldIndexLucene));
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { LogEventError.LogEvent("Lucene error ConvertItemToDocument: " + colName, ex); throw ex; }
            return doc;
        }

        private T ConvertDocumentToItem(Document doc)
        {
            var item = new T();
            string colName = string.Empty;
            try
            {
                var properties = typeof(T).GetProperties();

                foreach (var p in properties)
                {
                    Field f = doc.GetField(p.Name);

                    if (f != null)
                    {
                        switch (Type.GetTypeCode(p.PropertyType))
                        {
                            case TypeCode.Boolean:
                                typeof(T).GetProperty(p.Name).SetValue(item, Convert.ToBoolean(f.StringValue()), null);
                                break;
                            case TypeCode.Byte:
                                typeof(T).GetProperty(p.Name).SetValue(item, Convert.ToByte(f.StringValue()), null);
                                break;
                            case TypeCode.Char:
                                typeof(T).GetProperty(p.Name).SetValue(item, Convert.ToChar(f.StringValue()), null);
                                break;
                            case TypeCode.DateTime:
                                typeof(T).GetProperty(p.Name).SetValue(item, Convert.ToDateTime(f.StringValue()), null);
                                break;
                            case TypeCode.Decimal:
                                typeof(T).GetProperty(p.Name).SetValue(item, Convert.ToDecimal(f.StringValue()), null);
                                break;
                            case TypeCode.Double:
                                typeof(T).GetProperty(p.Name).SetValue(item, Convert.ToDouble(f.StringValue()), null);
                                break;
                            case TypeCode.Int16:
                                typeof(T).GetProperty(p.Name).SetValue(item, Convert.ToInt16(f.StringValue()), null);
                                break;
                            case TypeCode.Int32:
                                typeof(T).GetProperty(p.Name).SetValue(item, Convert.ToInt32(f.StringValue()), null);
                                break;
                            case TypeCode.Int64:
                                typeof(T).GetProperty(p.Name).SetValue(item, Convert.ToInt64(f.StringValue()), null);
                                break;
                            case TypeCode.String:
                                typeof(T).GetProperty(p.Name).SetValue(item, f.StringValue(), null);
                                break;
                            default:
                                typeof(T).GetProperty(p.Name).SetValue(item, f.StringValue(), null);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex) { LogEventError.LogEvent("Lucene convert to Entity error Column name: " + colName, ex); throw ex; }

            return item;
        }

        private T ConvertDocumentToItemHightLight(Document doc, Highlighter highlighter, Lucene.Net.Analysis.Standard.StandardAnalyzer analyzer)
        {
            var item = new T();
            string colName = string.Empty;
            try
            {
                var properties = typeof(T).GetProperties();
                foreach (var p in properties)
                {
                    Field f = doc.GetField(p.Name);

                    if (f != null)
                    {
                        string value = f.StringValue();
                        if (fieldLucene.Contains(p.Name))
                        {
                            var attCustom = p.GetCustomAttributes(typeof(AIFieldAttribute), true);

                            if (attCustom.Length > 0)
                            {
                                var objKey = attCustom[0] as AIFieldAttribute;
                                if (objKey != null)
                                {
                                    if (objKey.IsKoDau)
                                    {
                                        Lucene.Net.Analysis.TokenStream stream = analyzer.TokenStream("", new StringReader(doc.Get(p.Name + "_LONGLX")));
                                        string[] t = highlighter.GetBestFragments(stream, doc.Get(p.Name + "_LONGLX"), 10);
                                        string valueHightlight = highlighter.GetBestFragments(stream, doc.Get(p.Name + "_LONGLX"), 10, "");
                                        if (!string.IsNullOrEmpty(valueHightlight))
                                        {
                                            int indexStart = valueHightlight.IndexOf("<em>");
                                            int indexEnd = 0;

                                            while (indexStart != -1)
                                            {
                                                indexEnd = valueHightlight.IndexOf("</em>", indexStart);
                                                value = value.Insert(indexStart, "<em>");
                                                value = value.Insert(indexEnd, "</em>");
                                                indexStart = valueHightlight.IndexOf("<em>", indexStart + 1);
                                            }
                                        }
                                        else
                                            value = valueHightlight;
                                    }
                                    else
                                    {
                                        Lucene.Net.Analysis.TokenStream stream = analyzer.TokenStream("", new StringReader(doc.Get(p.Name)));
                                        value = highlighter.GetBestFragments(stream, doc.Get(p.Name), 1, "...");
                                        if (string.IsNullOrEmpty(value))
                                            value = f.StringValue();
                                    }
                                }
                            }
                        }
                        switch (Type.GetTypeCode(p.PropertyType))
                        {
                            case TypeCode.Boolean:
                                typeof(T).GetProperty(p.Name).SetValue(item, Convert.ToBoolean(value), null);
                                break;
                            case TypeCode.Byte:
                                typeof(T).GetProperty(p.Name).SetValue(item, Convert.ToByte(value), null);
                                break;
                            case TypeCode.Char:
                                typeof(T).GetProperty(p.Name).SetValue(item, Convert.ToChar(value), null);
                                break;
                            case TypeCode.DateTime:
                                typeof(T).GetProperty(p.Name).SetValue(item, Convert.ToDateTime(value), null);
                                break;
                            case TypeCode.Decimal:
                                typeof(T).GetProperty(p.Name).SetValue(item, Convert.ToDecimal(value), null);
                                break;
                            case TypeCode.Double:
                                typeof(T).GetProperty(p.Name).SetValue(item, Convert.ToDouble(value), null);
                                break;
                            case TypeCode.Int16:
                                typeof(T).GetProperty(p.Name).SetValue(item, Convert.ToInt16(value), null);
                                break;
                            case TypeCode.Int32:
                                typeof(T).GetProperty(p.Name).SetValue(item, Convert.ToInt32(value), null);
                                break;
                            case TypeCode.Int64:
                                typeof(T).GetProperty(p.Name).SetValue(item, Convert.ToInt64(value), null);
                                break;
                            case TypeCode.String:
                                typeof(T).GetProperty(p.Name).SetValue(item, value, null);
                                break;
                            default:
                                typeof(T).GetProperty(p.Name).SetValue(item, value, null);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex) { LogEventError.LogEvent("Lucene convert to Entity error Column name: " + colName, ex); throw ex; }

            return item;
        }

        public string ConvertToKhongDau(string chucodau)
        {
            const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
            const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
            int index = -1;
            char[] arrChar = FindText.ToCharArray();
            while ((index = chucodau.IndexOfAny(arrChar)) != -1)
            {
                int index2 = FindText.IndexOf(chucodau[index]);
                chucodau = chucodau.Replace(chucodau[index], ReplText[index2]);
            }
            return chucodau;
        }
        #endregion
        #endregion
    }
}
