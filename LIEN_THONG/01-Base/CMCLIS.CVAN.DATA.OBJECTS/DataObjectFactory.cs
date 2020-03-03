namespace CMCLIS.CVAN.DATA.OBJECTS
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

        private static LOG_DATADao _LOG_DATADao;
        public static LOG_DATADao GetInstanceLOG_DATA()
        {
            return _LOG_DATADao ?? (_LOG_DATADao = new LOG_DATADao());
        }
    }
}
