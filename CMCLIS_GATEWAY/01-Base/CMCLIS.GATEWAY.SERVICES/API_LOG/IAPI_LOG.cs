using CMCLIS.GATEWAY.ENTITY;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace CMCLIS.GATEWAY.SERVICES
{
    [ServiceContract]
    public interface IAPI_LOG
    {
        #region Create Functions "LOG_CHUC_NANG"
        [OperationContract]
        [Description("Thêm mới thông tin bảng LOG_CHUC_NANG")]
        [WebInvoke(UriTemplate = "LOG_CHUC_NANG", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response LOG_CHUC_NANG_Add(LOG_CHUC_NANGInfo info);

        [OperationContract]
        [Description("Lấy thông tin bản ghi của bảng LOG_CHUC_NANG theo ID")]
        [WebInvoke(UriTemplate = "LOG_CHUC_NANG/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        ResponseInfo<LOG_CHUC_NANGInfo> LOG_CHUC_NANG_GetInfo(string ID);

        [OperationContract]
        [Description("Lấy tất cả thông tin của 1 trang trong bảng LOG_CHUC_NANG theo điều kiện {USER_NAME}/{FUNCTION_NAME}/{ACTION}/{TIME_START_DATE}/{TIME_END_DATE}")]
        [WebGet(UriTemplate = "LOG_CHUC_NANG/{USER_NAME}/{FUNCTION_NAME}/{ACTION}/{TIME_START_DATE}/{TIME_END_DATE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
        ResponsePage<LOG_CHUC_NANGInfo> LOG_CHUC_NANG_GetAllWithPadding(string USER_NAME, string FUNCTION_NAME, string ACTION, string TIME_START_DATE, string TIME_END_DATE, string pageIndex, string pageSize);

        #endregion
        #region Create Functions "LOG_DATA"
        [OperationContract]
        [Description("Thêm mới thông tin bảng LOG_DATA")]
        [WebInvoke(UriTemplate = "LOG_DATA", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response LOG_DATA_Add(LOG_DATAInfo info);

        [OperationContract]
        [Description("Lấy thông tin bản ghi của bảng LOG_DATA theo ID")]
        [WebInvoke(UriTemplate = "LOG_DATA/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        ResponseInfo<LOG_DATAInfo> LOG_DATA_GetInfo(string ID);

        [OperationContract]
        [Description("Lấy tất cả thông tin của 1 trang trong bảng LOG_DATA theo điều kiện {IP}/{PORT}/{APPLICATION_NAME}/{MESSAGE}/{LOG_TYPE}/{CDATE_START_DATE}/{CDATE_END_DATE}")]
        [WebGet(UriTemplate = "LOG_DATA/{IP}/{PORT}/{APPLICATION_NAME}/{MESSAGE}/{LOG_TYPE}/{CDATE_START_DATE}/{CDATE_END_DATE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
        ResponsePage<LOG_DATAInfo> LOG_DATA_GetAllWithPadding(string IP, string PORT, string APPLICATION_NAME, string MESSAGE, string LOG_TYPE, string CDATE_START_DATE, string CDATE_END_DATE, string pageIndex, string pageSize);
        #endregion
        #region Create Functions "LOG_DU_LIEU_DB"
        [OperationContract]
        [Description("Thêm mới thông tin bảng LOG_DU_LIEU_DB")]
        [WebInvoke(UriTemplate = "LOG_DU_LIEU_DB", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response LOG_DU_LIEU_DB_Add(LOG_DU_LIEU_DBInfo info);

        [OperationContract]
        [Description("Lấy thông tin bản ghi của bảng LOG_DU_LIEU_DB theo ID")]
        [WebInvoke(UriTemplate = "LOG_DU_LIEU_DB/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        ResponseInfo<LOG_DU_LIEU_DBInfo> LOG_DU_LIEU_DB_GetInfo(string ID);

        [OperationContract]
        [Description("Lấy tất cả thông tin của 1 trang trong bảng LOG_DU_LIEU_DB theo điều kiện {USER_NAME}/{TABLE_NAME}/{ACTION}/{CDATE_START_DATE}/{CDATE_END_DATE}")]
        [WebGet(UriTemplate = "LOG_DU_LIEU_DB/{USER_NAME}/{TABLE_NAME}/{ACTION}/{CDATE_START_DATE}/{CDATE_END_DATE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
        ResponsePage<LOG_DU_LIEU_DBInfo> LOG_DU_LIEU_DB_GetAllWithPadding(string USER_NAME, string TABLE_NAME, string ACTION, string CDATE_START_DATE, string CDATE_END_DATE, string pageIndex, string pageSize);

        #endregion
        #region Create Functions "LOG_TRUY_CAP"
        [OperationContract]
        [Description("Thêm mới thông tin bảng LOG_TRUY_CAP")]
        [WebInvoke(UriTemplate = "LOG_TRUY_CAP", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response LOG_TRUY_CAP_Add(LOG_TRUY_CAPInfo info);

        [OperationContract]
        [Description("Lấy thông tin bản ghi của bảng LOG_TRUY_CAP theo ID")]
        [WebInvoke(UriTemplate = "LOG_TRUY_CAP/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        ResponseInfo<LOG_TRUY_CAPInfo> LOG_TRUY_CAP_GetInfo(string ID);

        [OperationContract]
        [Description("Lấy tất cả thông tin của 1 trang trong bảng LOG_TRUY_CAP theo điều kiện {USER_NAME}/{LOG_TIME_START_DATE}/{LOG_TIME_END_DATE}/{ACTION}/{IS_DELETE}")]
        [WebGet(UriTemplate = "LOG_TRUY_CAP/{USER_NAME}/{LOG_TIME_START_DATE}/{LOG_TIME_END_DATE}/{ACTION}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
        ResponsePage<LOG_TRUY_CAPInfo> LOG_TRUY_CAP_GetAllWithPadding(string USER_NAME, string LOG_TIME_START_DATE, string LOG_TIME_END_DATE, string ACTION, string pageIndex, string pageSize);

        #endregion
        #region Create Functions "LOG_XL_HANG_LOAT"
        [OperationContract]
        [Description("Thêm mới thông tin bảng LOG_XL_HANG_LOAT")]
        [WebInvoke(UriTemplate = "LOG_XL_HANG_LOAT", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response LOG_XL_HANG_LOAT_Add(LOG_XL_HANG_LOATInfo info);

        [OperationContract]
        [Description("Lấy thông tin bản ghi của bảng LOG_XL_HANG_LOAT theo ID")]
        [WebInvoke(UriTemplate = "LOG_XL_HANG_LOAT/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        ResponseInfo<LOG_XL_HANG_LOATInfo> LOG_XL_HANG_LOAT_GetInfo(string ID);

        [OperationContract]
        [Description("Lấy tất cả thông tin của 1 trang trong bảng LOG_XL_HANG_LOAT theo điều kiện {USER_NAME}/{FUNCTION_NAME}/{TIME_START_DATE}/{TIME_END_DATE}")]
        [WebGet(UriTemplate = "LOG_XL_HANG_LOAT/{USER_NAME}/{FUNCTION_NAME}/{TIME_START_DATE}/{TIME_END_DATE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
        ResponsePage<LOG_XL_HANG_LOATInfo> LOG_XL_HANG_LOAT_GetAllWithPadding(string USER_NAME, string FUNCTION_NAME, string TIME_START_DATE, string TIME_END_DATE, string pageIndex, string pageSize);

        #endregion
        #region Create Functions "LOG_XL_QUY_TRINH"
        [OperationContract]
        [Description("Thêm mới thông tin bảng LOG_XL_QUY_TRINH")]
        [WebInvoke(UriTemplate = "LOG_XL_QUY_TRINH", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response LOG_XL_QUY_TRINH_Add(LOG_XL_QUY_TRINHInfo info);

        [OperationContract]
        [Description("Lấy thông tin bản ghi của bảng LOG_XL_QUY_TRINH theo ID")]
        [WebInvoke(UriTemplate = "LOG_XL_QUY_TRINH/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        ResponseInfo<LOG_XL_QUY_TRINHInfo> LOG_XL_QUY_TRINH_GetInfo(string ID);

        [OperationContract]
        [Description("Lấy tất cả thông tin của 1 trang trong bảng LOG_XL_QUY_TRINH theo điều kiện {USER_NAME}/{STEP}/{LOG_TIME_START_DATE}/{LOG_TIME_END_DATE}/{ACTION}")]
        [WebGet(UriTemplate = "LOG_XL_QUY_TRINH/{USER_NAME}/{STEP}/{LOG_TIME_START_DATE}/{LOG_TIME_END_DATE}/{ACTION}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
        ResponsePage<LOG_XL_QUY_TRINHInfo> LOG_XL_QUY_TRINH_GetAllWithPadding(string USER_NAME, string STEP, string LOG_TIME_START_DATE, string LOG_TIME_END_DATE, string ACTION, string pageIndex, string pageSize);

        #endregion
    }
}
