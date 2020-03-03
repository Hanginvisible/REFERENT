namespace CMCLIS.GATEWAY.DATA.OBJECTS
{
    //------------------------------------------------------------------------------------------------------------------------
    //-- Created By: <<DAO_AUTHOR>>
    //-- Date: <<DAO_CREATE_DATE>>
    //-- Todo: 
    //------------------------------------------------------------------------------------------------------------------------ 
    public class DataObjectFactory
    {
        private static CVAN_DM_LT_THUEDao _CVAN_DM_LT_THUEDao;
        public static CVAN_DM_LT_THUEDao GetInstanceCVAN_DM_LT_THUE()
        {
            return _CVAN_DM_LT_THUEDao ?? (_CVAN_DM_LT_THUEDao = new CVAN_DM_LT_THUEDao());
        }

        private static CVAN_DM_MSG_TYPEDao _CVAN_DM_MSG_TYPEDao;
        public static CVAN_DM_MSG_TYPEDao GetInstanceCVAN_DM_MSG_TYPE()
        {
            return _CVAN_DM_MSG_TYPEDao ?? (_CVAN_DM_MSG_TYPEDao = new CVAN_DM_MSG_TYPEDao());
        }

        private static CVAN_DM_STATUSDao _CVAN_DM_STATUSDao;
        public static CVAN_DM_STATUSDao GetInstanceCVAN_DM_STATUS()
        {
            return _CVAN_DM_STATUSDao ?? (_CVAN_DM_STATUSDao = new CVAN_DM_STATUSDao());
        }

        private static CVAN_EXCHANGEDao _CVAN_EXCHANGEDao;
        public static CVAN_EXCHANGEDao GetInstanceCVAN_EXCHANGE()
        {
            return _CVAN_EXCHANGEDao ?? (_CVAN_EXCHANGEDao = new CVAN_EXCHANGEDao());
        }

        private static CVAN_MAILDao _CVAN_MAILDao;
        public static CVAN_MAILDao GetInstanceCVAN_MAIL()
        {
            return _CVAN_MAILDao ?? (_CVAN_MAILDao = new CVAN_MAILDao());
        }

        private static CVAN_MSGIDao _CVAN_MSGIDao;
        public static CVAN_MSGIDao GetInstanceCVAN_MSGI()
        {
            return _CVAN_MSGIDao ?? (_CVAN_MSGIDao = new CVAN_MSGIDao());
        }

        private static CVAN_MSGODao _CVAN_MSGODao;
        public static CVAN_MSGODao GetInstanceCVAN_MSGO()
        {
            return _CVAN_MSGODao ?? (_CVAN_MSGODao = new CVAN_MSGODao());
        }

        private static FILE_SERVER_DATADao _FILE_SERVER_DATADao;
        public static FILE_SERVER_DATADao GetInstanceFILE_SERVER_DATA()
        {
            return _FILE_SERVER_DATADao ?? (_FILE_SERVER_DATADao = new FILE_SERVER_DATADao());
        }

        private static LOG_CHUC_NANGDao _LOG_CHUC_NANGDao;
        public static LOG_CHUC_NANGDao GetInstanceLOG_CHUC_NANG()
        {
            return _LOG_CHUC_NANGDao ?? (_LOG_CHUC_NANGDao = new LOG_CHUC_NANGDao());
        }

        private static LOG_DATADao _LOG_DATADao;
        public static LOG_DATADao GetInstanceLOG_DATA()
        {
            return _LOG_DATADao ?? (_LOG_DATADao = new LOG_DATADao());
        }

        private static LOG_DU_LIEU_DBDao _LOG_DU_LIEU_DBDao;
        public static LOG_DU_LIEU_DBDao GetInstanceLOG_DU_LIEU_DB()
        {
            return _LOG_DU_LIEU_DBDao ?? (_LOG_DU_LIEU_DBDao = new LOG_DU_LIEU_DBDao());
        }

        private static LOG_TRUY_CAPDao _LOG_TRUY_CAPDao;
        public static LOG_TRUY_CAPDao GetInstanceLOG_TRUY_CAP()
        {
            return _LOG_TRUY_CAPDao ?? (_LOG_TRUY_CAPDao = new LOG_TRUY_CAPDao());
        }

        private static LOG_XL_HANG_LOATDao _LOG_XL_HANG_LOATDao;
        public static LOG_XL_HANG_LOATDao GetInstanceLOG_XL_HANG_LOAT()
        {
            return _LOG_XL_HANG_LOATDao ?? (_LOG_XL_HANG_LOATDao = new LOG_XL_HANG_LOATDao());
        }

        private static LOG_XL_QUY_TRINHDao _LOG_XL_QUY_TRINHDao;
        public static LOG_XL_QUY_TRINHDao GetInstanceLOG_XL_QUY_TRINH()
        {
            return _LOG_XL_QUY_TRINHDao ?? (_LOG_XL_QUY_TRINHDao = new LOG_XL_QUY_TRINHDao());
        }

        private static SHARE_DD_MO_TDDao _SHARE_DD_MO_TDDao;
        public static SHARE_DD_MO_TDDao GetInstanceSHARE_DD_MO_TD()
        {
            return _SHARE_DD_MO_TDDao ?? (_SHARE_DD_MO_TDDao = new SHARE_DD_MO_TDDao());
        }


    }
}
