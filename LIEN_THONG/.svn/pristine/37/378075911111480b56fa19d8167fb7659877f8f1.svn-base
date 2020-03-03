using CMCLIS.CVAN.ENTITY;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace CTS.GATEWAY.SERVICES
{
    //------------------------------------------------------------------------------------------------------------------------
    //-- Created By: Ngô Văn Nghị
    //-- Date: 01/05/2020 12:37:05 AM
    //-- Todo: 
    //------------------------------------------------------------------------------------------------------------------------ 
    [ServiceContract]
    public interface IAPI_CORE_BASE
    {
        
		#region Create Functions "CLIENT_SENDER"
		[OperationContract]
		[Description("Thêm mới thông tin bảng CLIENT_SENDER")]
		[WebInvoke(UriTemplate = "CLIENT_SENDER", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response CLIENT_SENDER_Add(CLIENT_SENDERInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng CLIENT_SENDER")]
		[WebInvoke(UriTemplate = "CLIENT_SENDER", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response CLIENT_SENDER_Update(CLIENT_SENDERInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng CLIENT_SENDER theo ID")]
		[WebInvoke(UriTemplate = "CLIENT_SENDER/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response CLIENT_SENDER_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng CLIENT_SENDER theo ID")]
		[WebInvoke(UriTemplate = "CLIENT_SENDER/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<CLIENT_SENDERInfo> CLIENT_SENDER_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng CLIENT_SENDER")]
		[WebGet(UriTemplate = "CLIENT_SENDER", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<CLIENT_SENDERInfo> CLIENT_SENDER_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng CLIENT_SENDER theo điều kiện {CLIENT_CODE}/{CLIENT_NAME}/{CLIENT_TYPE}/{CLIENT_DOMAIN}/{STATUS}")]
		[WebGet(UriTemplate = "CLIENT_SENDER/{CLIENT_CODE}/{CLIENT_NAME}/{CLIENT_TYPE}/{CLIENT_DOMAIN}/{STATUS}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<CLIENT_SENDERInfo> CLIENT_SENDER_GetAllWithPadding(string  CLIENT_CODE,string  CLIENT_NAME,string  CLIENT_TYPE,string  CLIENT_DOMAIN,string STATUS, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng CLIENT_SENDER theo điều kiện {extension}")]
		[WebGet(UriTemplate = "CLIENT_SENDER_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CLIENT_SENDER_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng CLIENT_SENDER theo điều kiện {CLIENT_CODE}/{CLIENT_NAME}/{CLIENT_TYPE}/{CLIENT_DOMAIN}/{STATUS}")]
		[WebGet(UriTemplate = "CLIENT_SENDER_EXPORT_DATA/{CLIENT_CODE}/{CLIENT_NAME}/{CLIENT_TYPE}/{CLIENT_DOMAIN}/{STATUS}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CLIENT_SENDER_EXPORT_DATA(string  CLIENT_CODE,string  CLIENT_NAME,string  CLIENT_TYPE,string  CLIENT_DOMAIN,string STATUS, string extension);

		#endregion
		#region Create Functions "CONFIG"
		[OperationContract]
		[Description("Thêm mới thông tin bảng CONFIG")]
		[WebInvoke(UriTemplate = "CONFIG", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response CONFIG_Add(CONFIGInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng CONFIG")]
		[WebInvoke(UriTemplate = "CONFIG", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response CONFIG_Update(CONFIGInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng CONFIG theo ID")]
		[WebInvoke(UriTemplate = "CONFIG/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response CONFIG_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng CONFIG theo ID")]
		[WebInvoke(UriTemplate = "CONFIG/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<CONFIGInfo> CONFIG_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng CONFIG")]
		[WebGet(UriTemplate = "CONFIG", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<CONFIGInfo> CONFIG_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng CONFIG theo điều kiện {CONFIG_KEY}/{CONFIG_VALUE}/{CONFIG_TYPE}/{STATUS}")]
		[WebGet(UriTemplate = "CONFIG/{CONFIG_KEY}/{CONFIG_VALUE}/{CONFIG_TYPE}/{STATUS}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<CONFIGInfo> CONFIG_GetAllWithPadding(string  CONFIG_KEY,string  CONFIG_VALUE,string  CONFIG_TYPE,string STATUS, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng CONFIG theo điều kiện {extension}")]
		[WebGet(UriTemplate = "CONFIG_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CONFIG_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng CONFIG theo điều kiện {CONFIG_KEY}/{CONFIG_VALUE}/{CONFIG_TYPE}/{STATUS}")]
		[WebGet(UriTemplate = "CONFIG_EXPORT_DATA/{CONFIG_KEY}/{CONFIG_VALUE}/{CONFIG_TYPE}/{STATUS}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CONFIG_EXPORT_DATA(string  CONFIG_KEY,string  CONFIG_VALUE,string  CONFIG_TYPE,string STATUS, string extension);

		#endregion
		#region Create Functions "CONFIG_MESSAGE"
		[OperationContract]
		[Description("Thêm mới thông tin bảng CONFIG_MESSAGE")]
		[WebInvoke(UriTemplate = "CONFIG_MESSAGE", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response CONFIG_MESSAGE_Add(CONFIG_MESSAGEInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng CONFIG_MESSAGE")]
		[WebInvoke(UriTemplate = "CONFIG_MESSAGE", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response CONFIG_MESSAGE_Update(CONFIG_MESSAGEInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng CONFIG_MESSAGE theo ID")]
		[WebInvoke(UriTemplate = "CONFIG_MESSAGE/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response CONFIG_MESSAGE_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng CONFIG_MESSAGE theo ID")]
		[WebInvoke(UriTemplate = "CONFIG_MESSAGE/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<CONFIG_MESSAGEInfo> CONFIG_MESSAGE_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng CONFIG_MESSAGE")]
		[WebGet(UriTemplate = "CONFIG_MESSAGE", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<CONFIG_MESSAGEInfo> CONFIG_MESSAGE_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng CONFIG_MESSAGE theo điều kiện {MESSAGE_CODE}/{MESSAGE_NAME}/{KEY_CODE}/{TARGET_COLUMN_NAME}/{STATUS}")]
		[WebGet(UriTemplate = "CONFIG_MESSAGE/{MESSAGE_CODE}/{MESSAGE_NAME}/{KEY_CODE}/{TARGET_COLUMN_NAME}/{STATUS}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<CONFIG_MESSAGEInfo> CONFIG_MESSAGE_GetAllWithPadding(string  MESSAGE_CODE,string  MESSAGE_NAME,string  KEY_CODE,string  TARGET_COLUMN_NAME,string STATUS, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng CONFIG_MESSAGE theo điều kiện {extension}")]
		[WebGet(UriTemplate = "CONFIG_MESSAGE_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CONFIG_MESSAGE_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng CONFIG_MESSAGE theo điều kiện {MESSAGE_CODE}/{MESSAGE_NAME}/{KEY_CODE}/{TARGET_COLUMN_NAME}/{STATUS}")]
		[WebGet(UriTemplate = "CONFIG_MESSAGE_EXPORT_DATA/{MESSAGE_CODE}/{MESSAGE_NAME}/{KEY_CODE}/{TARGET_COLUMN_NAME}/{STATUS}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CONFIG_MESSAGE_EXPORT_DATA(string  MESSAGE_CODE,string  MESSAGE_NAME,string  KEY_CODE,string  TARGET_COLUMN_NAME,string STATUS, string extension);

		#endregion
		#region Create Functions "DM_API_SERVICE"
		[OperationContract]
		[Description("Thêm mới thông tin bảng DM_API_SERVICE")]
		[WebInvoke(UriTemplate = "DM_API_SERVICE", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response DM_API_SERVICE_Add(DM_API_SERVICEInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng DM_API_SERVICE")]
		[WebInvoke(UriTemplate = "DM_API_SERVICE", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response DM_API_SERVICE_Update(DM_API_SERVICEInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng DM_API_SERVICE theo ID")]
		[WebInvoke(UriTemplate = "DM_API_SERVICE/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response DM_API_SERVICE_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng DM_API_SERVICE theo ID")]
		[WebInvoke(UriTemplate = "DM_API_SERVICE/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<DM_API_SERVICEInfo> DM_API_SERVICE_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng DM_API_SERVICE")]
		[WebGet(UriTemplate = "DM_API_SERVICE", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<DM_API_SERVICEInfo> DM_API_SERVICE_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng DM_API_SERVICE theo điều kiện {CODE}/{NAME}/{STATUS}")]
		[WebGet(UriTemplate = "DM_API_SERVICE/{CODE}/{NAME}/{STATUS}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<DM_API_SERVICEInfo> DM_API_SERVICE_GetAllWithPadding(string  CODE,string  NAME,string STATUS, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng DM_API_SERVICE theo điều kiện {extension}")]
		[WebGet(UriTemplate = "DM_API_SERVICE_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response DM_API_SERVICE_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng DM_API_SERVICE theo điều kiện {CODE}/{NAME}/{STATUS}")]
		[WebGet(UriTemplate = "DM_API_SERVICE_EXPORT_DATA/{CODE}/{NAME}/{STATUS}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response DM_API_SERVICE_EXPORT_DATA(string  CODE,string  NAME,string STATUS, string extension);

		#endregion
		#region Create Functions "DM_MESSAGE"
		[OperationContract]
		[Description("Thêm mới thông tin bảng DM_MESSAGE")]
		[WebInvoke(UriTemplate = "DM_MESSAGE", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response DM_MESSAGE_Add(DM_MESSAGEInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng DM_MESSAGE")]
		[WebInvoke(UriTemplate = "DM_MESSAGE", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response DM_MESSAGE_Update(DM_MESSAGEInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng DM_MESSAGE theo ID")]
		[WebInvoke(UriTemplate = "DM_MESSAGE/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response DM_MESSAGE_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng DM_MESSAGE theo ID")]
		[WebInvoke(UriTemplate = "DM_MESSAGE/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<DM_MESSAGEInfo> DM_MESSAGE_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng DM_MESSAGE")]
		[WebGet(UriTemplate = "DM_MESSAGE", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<DM_MESSAGEInfo> DM_MESSAGE_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng DM_MESSAGE theo điều kiện {CODE}/{MESSAGE_NAME}/{PARENT_CODE}/{STATUS}")]
		[WebGet(UriTemplate = "DM_MESSAGE/{CODE}/{MESSAGE_NAME}/{PARENT_CODE}/{STATUS}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<DM_MESSAGEInfo> DM_MESSAGE_GetAllWithPadding(string  CODE,string  MESSAGE_NAME,string  PARENT_CODE,string STATUS, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng DM_MESSAGE theo điều kiện {extension}")]
		[WebGet(UriTemplate = "DM_MESSAGE_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response DM_MESSAGE_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng DM_MESSAGE theo điều kiện {CODE}/{MESSAGE_NAME}/{PARENT_CODE}/{STATUS}")]
		[WebGet(UriTemplate = "DM_MESSAGE_EXPORT_DATA/{CODE}/{MESSAGE_NAME}/{PARENT_CODE}/{STATUS}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response DM_MESSAGE_EXPORT_DATA(string  CODE,string  MESSAGE_NAME,string  PARENT_CODE,string STATUS, string extension);

		#endregion
		#region Create Functions "DM_MESSAGE_STATUS"
		[OperationContract]
		[Description("Thêm mới thông tin bảng DM_MESSAGE_STATUS")]
		[WebInvoke(UriTemplate = "DM_MESSAGE_STATUS", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response DM_MESSAGE_STATUS_Add(DM_MESSAGE_STATUSInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng DM_MESSAGE_STATUS")]
		[WebInvoke(UriTemplate = "DM_MESSAGE_STATUS", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response DM_MESSAGE_STATUS_Update(DM_MESSAGE_STATUSInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng DM_MESSAGE_STATUS theo ID")]
		[WebInvoke(UriTemplate = "DM_MESSAGE_STATUS/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response DM_MESSAGE_STATUS_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng DM_MESSAGE_STATUS theo ID")]
		[WebInvoke(UriTemplate = "DM_MESSAGE_STATUS/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<DM_MESSAGE_STATUSInfo> DM_MESSAGE_STATUS_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng DM_MESSAGE_STATUS")]
		[WebGet(UriTemplate = "DM_MESSAGE_STATUS", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<DM_MESSAGE_STATUSInfo> DM_MESSAGE_STATUS_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng DM_MESSAGE_STATUS theo điều kiện {CODE}/{NAME}/{PARENT_CODE}/{STATUS}")]
		[WebGet(UriTemplate = "DM_MESSAGE_STATUS/{CODE}/{NAME}/{PARENT_CODE}/{STATUS}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<DM_MESSAGE_STATUSInfo> DM_MESSAGE_STATUS_GetAllWithPadding(string  CODE,string  NAME,string  PARENT_CODE,string STATUS, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng DM_MESSAGE_STATUS theo điều kiện {extension}")]
		[WebGet(UriTemplate = "DM_MESSAGE_STATUS_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response DM_MESSAGE_STATUS_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng DM_MESSAGE_STATUS theo điều kiện {CODE}/{NAME}/{PARENT_CODE}/{STATUS}")]
		[WebGet(UriTemplate = "DM_MESSAGE_STATUS_EXPORT_DATA/{CODE}/{NAME}/{PARENT_CODE}/{STATUS}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response DM_MESSAGE_STATUS_EXPORT_DATA(string  CODE,string  NAME,string  PARENT_CODE,string STATUS, string extension);

		#endregion
		#region Create Functions "LOG_ERROR"
		[OperationContract]
		[Description("Thêm mới thông tin bảng LOG_ERROR")]
		[WebInvoke(UriTemplate = "LOG_ERROR", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_ERROR_Add(LOG_ERRORInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng LOG_ERROR")]
		[WebInvoke(UriTemplate = "LOG_ERROR", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_ERROR_Update(LOG_ERRORInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng LOG_ERROR theo ID")]
		[WebInvoke(UriTemplate = "LOG_ERROR/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_ERROR_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng LOG_ERROR theo ID")]
		[WebInvoke(UriTemplate = "LOG_ERROR/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<LOG_ERRORInfo> LOG_ERROR_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng LOG_ERROR")]
		[WebGet(UriTemplate = "LOG_ERROR", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<LOG_ERRORInfo> LOG_ERROR_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng LOG_ERROR theo điều kiện {CODE}/{FUNC_NAME}/{TYPE_CODE}/{ERROR_CODE}/{CDATE_START_DATE}/{CDATE_END_DATE}")]
		[WebGet(UriTemplate = "LOG_ERROR/{CODE}/{FUNC_NAME}/{TYPE_CODE}/{ERROR_CODE}/{CDATE_START_DATE}/{CDATE_END_DATE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<LOG_ERRORInfo> LOG_ERROR_GetAllWithPadding(string  CODE,string  FUNC_NAME,string  TYPE_CODE,string  ERROR_CODE,string CDATE_START_DATE,string CDATE_END_DATE, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng LOG_ERROR theo điều kiện {extension}")]
		[WebGet(UriTemplate = "LOG_ERROR_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_ERROR_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng LOG_ERROR theo điều kiện {CODE}/{FUNC_NAME}/{TYPE_CODE}/{ERROR_CODE}/{CDATE_START_DATE}/{CDATE_END_DATE}")]
		[WebGet(UriTemplate = "LOG_ERROR_EXPORT_DATA/{CODE}/{FUNC_NAME}/{TYPE_CODE}/{ERROR_CODE}/{CDATE_START_DATE}/{CDATE_END_DATE}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_ERROR_EXPORT_DATA(string  CODE,string  FUNC_NAME,string  TYPE_CODE,string  ERROR_CODE,string CDATE_START_DATE,string CDATE_END_DATE, string extension);

		#endregion
		#region Create Functions "MSGI"
		[OperationContract]
		[Description("Thêm mới thông tin bảng MSGI")]
		[WebInvoke(UriTemplate = "MSGI", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response MSGI_Add(MSGIInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng MSGI")]
		[WebInvoke(UriTemplate = "MSGI", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response MSGI_Update(MSGIInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng MSGI theo ID")]
		[WebInvoke(UriTemplate = "MSGI/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response MSGI_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng MSGI theo ID")]
		[WebInvoke(UriTemplate = "MSGI/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<MSGIInfo> MSGI_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng MSGI")]
		[WebGet(UriTemplate = "MSGI", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<MSGIInfo> MSGI_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng MSGI theo điều kiện {CODE}/{MESSAGE_CODE}/{SEND_DATE_START_DATE}/{SEND_DATE_END_DATE}/{SENDER_CODE}/{STATUS}")]
		[WebGet(UriTemplate = "MSGI/{CODE}/{MESSAGE_CODE}/{SEND_DATE_START_DATE}/{SEND_DATE_END_DATE}/{SENDER_CODE}/{STATUS}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<MSGIInfo> MSGI_GetAllWithPadding(string  CODE,string  MESSAGE_CODE,string SEND_DATE_START_DATE,string SEND_DATE_END_DATE,string  SENDER_CODE,string STATUS, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng MSGI theo điều kiện {extension}")]
		[WebGet(UriTemplate = "MSGI_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response MSGI_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng MSGI theo điều kiện {CODE}/{MESSAGE_CODE}/{SEND_DATE_START_DATE}/{SEND_DATE_END_DATE}/{SENDER_CODE}/{STATUS}")]
		[WebGet(UriTemplate = "MSGI_EXPORT_DATA/{CODE}/{MESSAGE_CODE}/{SEND_DATE_START_DATE}/{SEND_DATE_END_DATE}/{SENDER_CODE}/{STATUS}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response MSGI_EXPORT_DATA(string  CODE,string  MESSAGE_CODE,string SEND_DATE_START_DATE,string SEND_DATE_END_DATE,string  SENDER_CODE,string STATUS, string extension);

		#endregion
		#region Create Functions "MSGO"
		[OperationContract]
		[Description("Thêm mới thông tin bảng MSGO")]
		[WebInvoke(UriTemplate = "MSGO", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response MSGO_Add(MSGOInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng MSGO")]
		[WebInvoke(UriTemplate = "MSGO", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response MSGO_Update(MSGOInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng MSGO theo ID")]
		[WebInvoke(UriTemplate = "MSGO/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response MSGO_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng MSGO theo ID")]
		[WebInvoke(UriTemplate = "MSGO/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<MSGOInfo> MSGO_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng MSGO")]
		[WebGet(UriTemplate = "MSGO", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<MSGOInfo> MSGO_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng MSGO theo điều kiện {MSGI_CODE}/{MESSAGE_CODE}/{SEND_DATE_START_DATE}/{SEND_DATE_END_DATE}/{SENDER_CODE}/{STATUS}")]
		[WebGet(UriTemplate = "MSGO/{MSGI_CODE}/{MESSAGE_CODE}/{SEND_DATE_START_DATE}/{SEND_DATE_END_DATE}/{SENDER_CODE}/{STATUS}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<MSGOInfo> MSGO_GetAllWithPadding(string  MSGI_CODE,string  MESSAGE_CODE,string SEND_DATE_START_DATE,string SEND_DATE_END_DATE,string  SENDER_CODE,string STATUS, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng MSGO theo điều kiện {extension}")]
		[WebGet(UriTemplate = "MSGO_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response MSGO_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng MSGO theo điều kiện {MSGI_CODE}/{MESSAGE_CODE}/{SEND_DATE_START_DATE}/{SEND_DATE_END_DATE}/{SENDER_CODE}/{STATUS}")]
		[WebGet(UriTemplate = "MSGO_EXPORT_DATA/{MSGI_CODE}/{MESSAGE_CODE}/{SEND_DATE_START_DATE}/{SEND_DATE_END_DATE}/{SENDER_CODE}/{STATUS}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response MSGO_EXPORT_DATA(string  MSGI_CODE,string  MESSAGE_CODE,string SEND_DATE_START_DATE,string SEND_DATE_END_DATE,string  SENDER_CODE,string STATUS, string extension);

		#endregion        
    }
}



