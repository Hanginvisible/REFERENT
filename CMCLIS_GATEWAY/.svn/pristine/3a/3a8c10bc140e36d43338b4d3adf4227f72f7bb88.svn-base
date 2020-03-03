using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCLIS.GATEWAY.CORE.Redis
{
    public class RedisConfigurationSection : ConfigurationSection
    {
        #region Constants

        private const string REDIS_HOST = "REDIS_HOST";
        private const string REDIS_PORT = "REDIS_PORT";
        private const string REDIS_PASSWORD = "REDIS_PASSWORD";
        private const string REDIS_DATABASEID = "REDIS_DATABASEID";

        #endregion

        #region Properties       

        private static Dictionary<string, long> _DICT_REDIS_DB;
        public static Dictionary<string, long> DICT_REDIS_DB
        {
            get
            {
                if (_DICT_REDIS_DB == null || _DICT_REDIS_DB.Count == 0)
                {
                    _DICT_REDIS_DB = new Dictionary<string, long>();
                    for(int i = 0;i<= 15; i++)
                        _DICT_REDIS_DB.Add("db" + i, i);                    
                }
                return _DICT_REDIS_DB;
            }
        }

        [ConfigurationProperty(REDIS_HOST, IsRequired = true)]
        public string Host
        {
            get { return ConfigurationManager.AppSettings[REDIS_HOST].ToString(); }
        }

        [ConfigurationProperty(REDIS_PORT, IsRequired = true)]
        public int Port
        {
            get { return int.Parse(ConfigurationManager.AppSettings[REDIS_PORT].ToString()); }
        }

        [ConfigurationProperty(REDIS_PASSWORD, IsRequired = false)]
        public string Password
        {
            get { return ConfigurationManager.AppSettings[REDIS_PASSWORD].ToString(); }
        }

        //[ConfigurationProperty(REDIS_DATABASEID, IsRequired = false)]
        //public long DatabaseID
        //{
        //    get { return long.Parse(ConfigurationManager.AppSettings[REDIS_DATABASEID].ToString()); }
        //}

        #endregion
    }
}
