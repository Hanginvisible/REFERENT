using CMCLIS.GATEWAY.SETTING;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCLIS.GATEWAY.WServiceMQMail
{
    public class Config
    {
        private static Dictionary<string, string> _MAIL_DICTIONARY_TYPE;
        public static Dictionary<string,string> MAIL_DICTIONARY_TYPE
        {
            get
            {
                if (_MAIL_DICTIONARY_TYPE==null)
                {
                    _MAIL_DICTIONARY_TYPE = new Dictionary<string, string>();
                    _MAIL_DICTIONARY_TYPE.Add("HO_SO_DIA_CHINH", "Hồ sơ địa chính");
                }
                return _MAIL_DICTIONARY_TYPE;
            }
        }

        private static string _FILE_SERVER_INFO_UPLOAD_API;
        public static string FILE_SERVER_INFO_UPLOAD_API
        {
            get
            {
                if (string.IsNullOrEmpty(_FILE_SERVER_INFO_UPLOAD_API))
                {
                    _FILE_SERVER_INFO_UPLOAD_API = ConfigurationManager.AppSettings[Constant.FILE_SERVER_INFO_UPLOAD_API];
                }
                return _FILE_SERVER_INFO_UPLOAD_API;
            }
        }
    }
}
