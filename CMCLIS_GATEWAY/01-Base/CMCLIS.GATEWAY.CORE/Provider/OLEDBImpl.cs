
using CMCLIS.GATEWAY.SETTING;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCLIS.GATEWAY.CORE.Provider
{
    public class OLEDBImpl
    {        

        #region "Dynamic SQL"

        public static DataSet GetDataSet(string TSQL, string maSoThue, string maTinhThanh)
        {
            CMCLIS.GATEWAY.CORE.NetworkShare.DisconnectFromShare(Config.NETWORK_SHARE_DIRECTORY, true); //Disconnect in case we are currently connected with our credentials;
            CMCLIS.GATEWAY.CORE.NetworkShare.ConnectToShare(Config.NETWORK_SHARE_DIRECTORY, Config.NETWORK_SHARE_ACCOUNT, Config.NETWORK_SHARE_PASSWORD); //Connect with the new credentials 
            DataSet dataSet = GetDataSet(TSQL, maSoThue, maTinhThanh, null);
            CMCLIS.GATEWAY.CORE.NetworkShare.DisconnectFromShare(Config.NETWORK_SHARE_DIRECTORY, false); //Disconnect from the server.    
            return dataSet;
        }

        private static DataSet GetDataSet(string TSQL, string maSoThue, string maTinhThanh, IDbConnection myConn)
        {
            return GetDataSet(TSQL, maSoThue, maTinhThanh, myConn, null);
        }

        private static DataSet GetDataSet(string TSQL, string maSoThue, string maTinhThanh, IDbConnection myConn, IDbTransaction myTrans)
        {
            DataSet myDS = new DataSet();
            try
            {                    
                bool mustClose = false;
                if (myConn == null)
                {
                    mustClose = true;
                    myConn = OLEDBConnectionString(maSoThue, maTinhThanh);
                }
                if (myConn.State != ConnectionState.Open)
                    myConn.Open();
                OleDbCommand myCMD = new OleDbCommand(TSQL, myConn as OleDbConnection);
                OleDbDataAdapter myAD = new OleDbDataAdapter(myCMD);
                // 
                myCMD.CommandType = CommandType.Text;
                myCMD.CommandTimeout = 180000;//3 phut             
                if (myTrans != null)
                    myCMD.Transaction = myTrans as OleDbTransaction;
                // 
                myAD.Fill(myDS);
                //
                if (mustClose) { myConn.Close(); }
                
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);

            }
            return myDS;
        }

        private static OleDbConnection OLEDBConnectionString(string maSoThue, string maTinhThanh)
        {

            try
            {
                string connString = string.Empty;
                //if (Config.NETWORK_SAVE_USING == "True")
                //    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path.Combine(Config.NETWORK_SHARE_DIRECTORY, maTinhThanh) + "\\" + maSoThue + ".mdb;User Id=admin;Password=khongbiet@123456;";
                connString = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}\{1};Mode=Share Deny None;Persist Security Info=True;Jet OLEDB:Database Password={2}", Path.Combine(Config.NETWORK_SHARE_DIRECTORY, maTinhThanh), maSoThue + ".db2", "khongbiet@123456");
                OleDbConnection myConn = new OleDbConnection(connString);
                myConn.Open();
                return myConn;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }

        #endregion




    }
}
