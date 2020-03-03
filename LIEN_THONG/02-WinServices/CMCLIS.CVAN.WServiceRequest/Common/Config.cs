using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using CMCLIS.CVAN.ENTITY;
using CMCLIS.CVAN.DATA.OBJECTS;

namespace CMCLIS.CVAN.WServiceRequest
{
    
    public sealed class Config
    {
        /// <summary>
        /// Danh mục MSG_TYPE
        /// </summary>
        /// created by: ntkien5 14.02.2020 
        private static List<CVAN_DM_MSG_TYPEInfo> _CVAN_DM_MSG_TYPEInfos;
        public static List<CVAN_DM_MSG_TYPEInfo> CVAN_DM_MSG_TYPEInfos
        {
            get
            {
                if (_CVAN_DM_MSG_TYPEInfos == null || _CVAN_DM_MSG_TYPEInfos.Count == 0)
                {
                    _CVAN_DM_MSG_TYPEInfos = DataObjectFactory.GetInstanceCVAN_DM_MSG_TYPE().GetList();
                    return _CVAN_DM_MSG_TYPEInfos;
                }
                return null;
            }
        }

        /// <summary>
        /// Danh mục trạng thái 
        /// </summary>
        // created by: ntkien 17.02.2020
        private static List<CVAN_DM_STATUSInfo> _CVAN_DM_STATUSInfos;
        public static List<CVAN_DM_STATUSInfo> CVAN_DM_STATUSInfos
        {
            get
            {
                if (_CVAN_DM_STATUSInfos == null || _CVAN_DM_STATUSInfos.Count == 0)
                {
                    _CVAN_DM_STATUSInfos = DataObjectFactory.GetInstanceCVAN_DM_STATUS().GetList();
                }
                return null;
            }
        }

        private static string _ALLOW_MOCK_UP_SUCCESS;
        public static string ALLOW_MOCK_UP_SUCCESS
        {
            get
            {
                if (string.IsNullOrEmpty(_ALLOW_MOCK_UP_SUCCESS))
                {
                    _ALLOW_MOCK_UP_SUCCESS = ConfigurationManager.AppSettings[Constant.ALLOW_MOCK_UP_SUCCESS];
                }
                return _ALLOW_MOCK_UP_SUCCESS;
            }
        }
    }
    
}
