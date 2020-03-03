using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;
using CMCLIS.GATEWAY.ENTITY;

namespace CMCLIS.GATEWAY.SERVICES
{
	//------------------------------------------------------------------------------------------------------------------------
	//-- Created By: Ngô Văn Nghị
	//-- Date: 02/20/2020 9:31:39 AM
	//-- Todo: 
	//------------------------------------------------------------------------------------------------------------------------ 
    [ServiceContract]
    public interface IAPI_CORE_BASE
    {
        
		#region Create Functions "CVAN_DM_LT_THUE"
		[OperationContract]
		[Description("Thêm mới thông tin bảng CVAN_DM_LT_THUE")]
		[WebInvoke(UriTemplate = "CVAN_DM_LT_THUE", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_DM_LT_THUE_Add(CVAN_DM_LT_THUEInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng CVAN_DM_LT_THUE")]
		[WebInvoke(UriTemplate = "CVAN_DM_LT_THUE", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_DM_LT_THUE_Update(CVAN_DM_LT_THUEInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng CVAN_DM_LT_THUE theo ID")]
		[WebInvoke(UriTemplate = "CVAN_DM_LT_THUE/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_DM_LT_THUE_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng CVAN_DM_LT_THUE theo ID")]
		[WebInvoke(UriTemplate = "CVAN_DM_LT_THUE/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<CVAN_DM_LT_THUEInfo> CVAN_DM_LT_THUE_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng CVAN_DM_LT_THUE")]
		[WebGet(UriTemplate = "CVAN_DM_LT_THUE", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<CVAN_DM_LT_THUEInfo> CVAN_DM_LT_THUE_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng CVAN_DM_LT_THUE theo điều kiện {CVAN_CODE}/{CVAN_NAME}/{CVAN_PARENT}/{CVAN_STATUS}/{IS_DELETE}")]
		[WebGet(UriTemplate = "CVAN_DM_LT_THUE/{CVAN_CODE}/{CVAN_NAME}/{CVAN_PARENT}/{CVAN_STATUS}/{IS_DELETE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<CVAN_DM_LT_THUEInfo> CVAN_DM_LT_THUE_GetAllWithPadding(string  CVAN_CODE,string  CVAN_NAME,string  CVAN_PARENT,string  CVAN_STATUS,string IS_DELETE, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng CVAN_DM_LT_THUE theo điều kiện {extension}")]
		[WebGet(UriTemplate = "CVAN_DM_LT_THUE_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_DM_LT_THUE_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng CVAN_DM_LT_THUE theo điều kiện {CVAN_CODE}/{CVAN_NAME}/{CVAN_PARENT}/{CVAN_STATUS}/{IS_DELETE}")]
		[WebGet(UriTemplate = "CVAN_DM_LT_THUE_EXPORT_DATA/{CVAN_CODE}/{CVAN_NAME}/{CVAN_PARENT}/{CVAN_STATUS}/{IS_DELETE}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_DM_LT_THUE_EXPORT_DATA(string  CVAN_CODE,string  CVAN_NAME,string  CVAN_PARENT,string  CVAN_STATUS,string IS_DELETE, string extension);

		#endregion
		#region Create Functions "CVAN_DM_MSG_TYPE"
		[OperationContract]
		[Description("Thêm mới thông tin bảng CVAN_DM_MSG_TYPE")]
		[WebInvoke(UriTemplate = "CVAN_DM_MSG_TYPE", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_DM_MSG_TYPE_Add(CVAN_DM_MSG_TYPEInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng CVAN_DM_MSG_TYPE")]
		[WebInvoke(UriTemplate = "CVAN_DM_MSG_TYPE", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_DM_MSG_TYPE_Update(CVAN_DM_MSG_TYPEInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng CVAN_DM_MSG_TYPE theo ID")]
		[WebInvoke(UriTemplate = "CVAN_DM_MSG_TYPE/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_DM_MSG_TYPE_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng CVAN_DM_MSG_TYPE theo ID")]
		[WebInvoke(UriTemplate = "CVAN_DM_MSG_TYPE/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<CVAN_DM_MSG_TYPEInfo> CVAN_DM_MSG_TYPE_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng CVAN_DM_MSG_TYPE")]
		[WebGet(UriTemplate = "CVAN_DM_MSG_TYPE", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<CVAN_DM_MSG_TYPEInfo> CVAN_DM_MSG_TYPE_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng CVAN_DM_MSG_TYPE theo điều kiện {CVAN_CODE}/{CVAN_NAME}/{CVAN_STATUS}/{IS_DELETE}")]
		[WebGet(UriTemplate = "CVAN_DM_MSG_TYPE/{CVAN_CODE}/{CVAN_NAME}/{CVAN_STATUS}/{IS_DELETE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<CVAN_DM_MSG_TYPEInfo> CVAN_DM_MSG_TYPE_GetAllWithPadding(string  CVAN_CODE,string  CVAN_NAME,string  CVAN_STATUS,string IS_DELETE, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng CVAN_DM_MSG_TYPE theo điều kiện {extension}")]
		[WebGet(UriTemplate = "CVAN_DM_MSG_TYPE_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_DM_MSG_TYPE_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng CVAN_DM_MSG_TYPE theo điều kiện {CVAN_CODE}/{CVAN_NAME}/{CVAN_STATUS}/{IS_DELETE}")]
		[WebGet(UriTemplate = "CVAN_DM_MSG_TYPE_EXPORT_DATA/{CVAN_CODE}/{CVAN_NAME}/{CVAN_STATUS}/{IS_DELETE}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_DM_MSG_TYPE_EXPORT_DATA(string  CVAN_CODE,string  CVAN_NAME,string  CVAN_STATUS,string IS_DELETE, string extension);

		#endregion
		#region Create Functions "CVAN_DM_STATUS"
		[OperationContract]
		[Description("Thêm mới thông tin bảng CVAN_DM_STATUS")]
		[WebInvoke(UriTemplate = "CVAN_DM_STATUS", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_DM_STATUS_Add(CVAN_DM_STATUSInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng CVAN_DM_STATUS")]
		[WebInvoke(UriTemplate = "CVAN_DM_STATUS", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_DM_STATUS_Update(CVAN_DM_STATUSInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng CVAN_DM_STATUS theo ID")]
		[WebInvoke(UriTemplate = "CVAN_DM_STATUS/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_DM_STATUS_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng CVAN_DM_STATUS theo ID")]
		[WebInvoke(UriTemplate = "CVAN_DM_STATUS/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<CVAN_DM_STATUSInfo> CVAN_DM_STATUS_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng CVAN_DM_STATUS")]
		[WebGet(UriTemplate = "CVAN_DM_STATUS", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<CVAN_DM_STATUSInfo> CVAN_DM_STATUS_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng CVAN_DM_STATUS theo điều kiện {CVAN_CODE}/{CVAN_NAME}/{CVAN_STATUS}/{IS_DELETE}")]
		[WebGet(UriTemplate = "CVAN_DM_STATUS/{CVAN_CODE}/{CVAN_NAME}/{CVAN_STATUS}/{IS_DELETE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<CVAN_DM_STATUSInfo> CVAN_DM_STATUS_GetAllWithPadding(string  CVAN_CODE,string  CVAN_NAME,string  CVAN_STATUS,string IS_DELETE, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng CVAN_DM_STATUS theo điều kiện {extension}")]
		[WebGet(UriTemplate = "CVAN_DM_STATUS_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_DM_STATUS_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng CVAN_DM_STATUS theo điều kiện {CVAN_CODE}/{CVAN_NAME}/{CVAN_STATUS}/{IS_DELETE}")]
		[WebGet(UriTemplate = "CVAN_DM_STATUS_EXPORT_DATA/{CVAN_CODE}/{CVAN_NAME}/{CVAN_STATUS}/{IS_DELETE}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_DM_STATUS_EXPORT_DATA(string  CVAN_CODE,string  CVAN_NAME,string  CVAN_STATUS,string IS_DELETE, string extension);

		#endregion
		#region Create Functions "CVAN_EXCHANGE"
		[OperationContract]
		[Description("Thêm mới thông tin bảng CVAN_EXCHANGE")]
		[WebInvoke(UriTemplate = "CVAN_EXCHANGE", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_EXCHANGE_Add(CVAN_EXCHANGEInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng CVAN_EXCHANGE")]
		[WebInvoke(UriTemplate = "CVAN_EXCHANGE", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_EXCHANGE_Update(CVAN_EXCHANGEInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng CVAN_EXCHANGE theo ID")]
		[WebInvoke(UriTemplate = "CVAN_EXCHANGE/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_EXCHANGE_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng CVAN_EXCHANGE theo ID")]
		[WebInvoke(UriTemplate = "CVAN_EXCHANGE/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<CVAN_EXCHANGEInfo> CVAN_EXCHANGE_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng CVAN_EXCHANGE")]
		[WebGet(UriTemplate = "CVAN_EXCHANGE", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<CVAN_EXCHANGEInfo> CVAN_EXCHANGE_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng CVAN_EXCHANGE theo điều kiện {CVAN_CODE}/{CVAN_MSG_TYPE_CODE}/{CVAN_STATUS_CODE}/{CVAN_MA_GD}/{IS_DELETE}")]
		[WebGet(UriTemplate = "CVAN_EXCHANGE/{CVAN_CODE}/{CVAN_MSG_TYPE_CODE}/{CVAN_STATUS_CODE}/{CVAN_MA_GD}/{IS_DELETE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<CVAN_EXCHANGEInfo> CVAN_EXCHANGE_GetAllWithPadding(string  CVAN_CODE,string  CVAN_MSG_TYPE_CODE,string  CVAN_STATUS_CODE,string  CVAN_MA_GD,string IS_DELETE, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng CVAN_EXCHANGE theo điều kiện {extension}")]
		[WebGet(UriTemplate = "CVAN_EXCHANGE_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_EXCHANGE_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng CVAN_EXCHANGE theo điều kiện {CVAN_CODE}/{CVAN_MSG_TYPE_CODE}/{CVAN_STATUS_CODE}/{CVAN_MA_GD}/{IS_DELETE}")]
		[WebGet(UriTemplate = "CVAN_EXCHANGE_EXPORT_DATA/{CVAN_CODE}/{CVAN_MSG_TYPE_CODE}/{CVAN_STATUS_CODE}/{CVAN_MA_GD}/{IS_DELETE}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_EXCHANGE_EXPORT_DATA(string  CVAN_CODE,string  CVAN_MSG_TYPE_CODE,string  CVAN_STATUS_CODE,string  CVAN_MA_GD,string IS_DELETE, string extension);

		#endregion
		#region Create Functions "CVAN_MAIL"
		[OperationContract]
		[Description("Thêm mới thông tin bảng CVAN_MAIL")]
		[WebInvoke(UriTemplate = "CVAN_MAIL", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_MAIL_Add(CVAN_MAILInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng CVAN_MAIL")]
		[WebInvoke(UriTemplate = "CVAN_MAIL", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_MAIL_Update(CVAN_MAILInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng CVAN_MAIL theo ID")]
		[WebInvoke(UriTemplate = "CVAN_MAIL/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_MAIL_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng CVAN_MAIL theo ID")]
		[WebInvoke(UriTemplate = "CVAN_MAIL/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<CVAN_MAILInfo> CVAN_MAIL_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng CVAN_MAIL")]
		[WebGet(UriTemplate = "CVAN_MAIL", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<CVAN_MAILInfo> CVAN_MAIL_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng CVAN_MAIL theo điều kiện {CVAN_FROM}/{CVAN_TO}/{CVAN_SUBJECT}/{CVAN_TYPE_CODE}/{CVAN_STATUS}/{IS_DELETE}")]
		[WebGet(UriTemplate = "CVAN_MAIL/{CVAN_FROM}/{CVAN_TO}/{CVAN_SUBJECT}/{CVAN_TYPE_CODE}/{CVAN_STATUS}/{IS_DELETE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<CVAN_MAILInfo> CVAN_MAIL_GetAllWithPadding(string  CVAN_FROM,string  CVAN_TO,string  CVAN_SUBJECT,string  CVAN_TYPE_CODE,string  CVAN_STATUS,string IS_DELETE, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng CVAN_MAIL theo điều kiện {extension}")]
		[WebGet(UriTemplate = "CVAN_MAIL_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_MAIL_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng CVAN_MAIL theo điều kiện {CVAN_FROM}/{CVAN_TO}/{CVAN_SUBJECT}/{CVAN_TYPE_CODE}/{CVAN_STATUS}/{IS_DELETE}")]
		[WebGet(UriTemplate = "CVAN_MAIL_EXPORT_DATA/{CVAN_FROM}/{CVAN_TO}/{CVAN_SUBJECT}/{CVAN_TYPE_CODE}/{CVAN_STATUS}/{IS_DELETE}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_MAIL_EXPORT_DATA(string  CVAN_FROM,string  CVAN_TO,string  CVAN_SUBJECT,string  CVAN_TYPE_CODE,string  CVAN_STATUS,string IS_DELETE, string extension);

		#endregion
		#region Create Functions "CVAN_MSGI"
		[OperationContract]
		[Description("Thêm mới thông tin bảng CVAN_MSGI")]
		[WebInvoke(UriTemplate = "CVAN_MSGI", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_MSGI_Add(CVAN_MSGIInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng CVAN_MSGI")]
		[WebInvoke(UriTemplate = "CVAN_MSGI", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_MSGI_Update(CVAN_MSGIInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng CVAN_MSGI theo ID")]
		[WebInvoke(UriTemplate = "CVAN_MSGI/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_MSGI_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng CVAN_MSGI theo ID")]
		[WebInvoke(UriTemplate = "CVAN_MSGI/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<CVAN_MSGIInfo> CVAN_MSGI_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng CVAN_MSGI")]
		[WebGet(UriTemplate = "CVAN_MSGI", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<CVAN_MSGIInfo> CVAN_MSGI_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng CVAN_MSGI theo điều kiện {CVAN_CODE}/{CVAN_MSGO_CODE}/{CVAN_MSG_TYPE_CODE}/{CVAN_STATUS_CODE}/{IS_DELETE}")]
		[WebGet(UriTemplate = "CVAN_MSGI/{CVAN_CODE}/{CVAN_MSGO_CODE}/{CVAN_MSG_TYPE_CODE}/{CVAN_STATUS_CODE}/{IS_DELETE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<CVAN_MSGIInfo> CVAN_MSGI_GetAllWithPadding(string  CVAN_CODE,string  CVAN_MSGO_CODE,string  CVAN_MSG_TYPE_CODE,string  CVAN_STATUS_CODE,string IS_DELETE, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng CVAN_MSGI theo điều kiện {extension}")]
		[WebGet(UriTemplate = "CVAN_MSGI_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_MSGI_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng CVAN_MSGI theo điều kiện {CVAN_CODE}/{CVAN_MSGO_CODE}/{CVAN_MSG_TYPE_CODE}/{CVAN_STATUS_CODE}/{IS_DELETE}")]
		[WebGet(UriTemplate = "CVAN_MSGI_EXPORT_DATA/{CVAN_CODE}/{CVAN_MSGO_CODE}/{CVAN_MSG_TYPE_CODE}/{CVAN_STATUS_CODE}/{IS_DELETE}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_MSGI_EXPORT_DATA(string  CVAN_CODE,string  CVAN_MSGO_CODE,string  CVAN_MSG_TYPE_CODE,string  CVAN_STATUS_CODE,string IS_DELETE, string extension);

		#endregion
		#region Create Functions "CVAN_MSGO"
		[OperationContract]
		[Description("Thêm mới thông tin bảng CVAN_MSGO")]
		[WebInvoke(UriTemplate = "CVAN_MSGO", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_MSGO_Add(CVAN_MSGOInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng CVAN_MSGO")]
		[WebInvoke(UriTemplate = "CVAN_MSGO", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_MSGO_Update(CVAN_MSGOInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng CVAN_MSGO theo ID")]
		[WebInvoke(UriTemplate = "CVAN_MSGO/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_MSGO_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng CVAN_MSGO theo ID")]
		[WebInvoke(UriTemplate = "CVAN_MSGO/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<CVAN_MSGOInfo> CVAN_MSGO_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng CVAN_MSGO")]
		[WebGet(UriTemplate = "CVAN_MSGO", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<CVAN_MSGOInfo> CVAN_MSGO_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng CVAN_MSGO theo điều kiện {CVAN_CODE}/{CVAN_MSG_TYPE_CODE}/{CVAN_SENDER_CODE}/{CVAN_STATUS_SEND}/{IS_DELETE}")]
		[WebGet(UriTemplate = "CVAN_MSGO/{CVAN_CODE}/{CVAN_MSG_TYPE_CODE}/{CVAN_SENDER_CODE}/{CVAN_STATUS_SEND}/{IS_DELETE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<CVAN_MSGOInfo> CVAN_MSGO_GetAllWithPadding(string  CVAN_CODE,string  CVAN_MSG_TYPE_CODE,string  CVAN_SENDER_CODE,string  CVAN_STATUS_SEND,string IS_DELETE, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng CVAN_MSGO theo điều kiện {extension}")]
		[WebGet(UriTemplate = "CVAN_MSGO_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_MSGO_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng CVAN_MSGO theo điều kiện {CVAN_CODE}/{CVAN_MSG_TYPE_CODE}/{CVAN_SENDER_CODE}/{CVAN_STATUS_SEND}/{IS_DELETE}")]
		[WebGet(UriTemplate = "CVAN_MSGO_EXPORT_DATA/{CVAN_CODE}/{CVAN_MSG_TYPE_CODE}/{CVAN_SENDER_CODE}/{CVAN_STATUS_SEND}/{IS_DELETE}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response CVAN_MSGO_EXPORT_DATA(string  CVAN_CODE,string  CVAN_MSG_TYPE_CODE,string  CVAN_SENDER_CODE,string  CVAN_STATUS_SEND,string IS_DELETE, string extension);

		#endregion
		#region Create Functions "FILE_SERVER_DATA"
		[OperationContract]
		[Description("Thêm mới thông tin bảng FILE_SERVER_DATA")]
		[WebInvoke(UriTemplate = "FILE_SERVER_DATA", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response FILE_SERVER_DATA_Add(FILE_SERVER_DATAInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng FILE_SERVER_DATA")]
		[WebInvoke(UriTemplate = "FILE_SERVER_DATA", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response FILE_SERVER_DATA_Update(FILE_SERVER_DATAInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng FILE_SERVER_DATA theo ID")]
		[WebInvoke(UriTemplate = "FILE_SERVER_DATA/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response FILE_SERVER_DATA_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng FILE_SERVER_DATA theo ID")]
		[WebInvoke(UriTemplate = "FILE_SERVER_DATA/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<FILE_SERVER_DATAInfo> FILE_SERVER_DATA_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng FILE_SERVER_DATA")]
		[WebGet(UriTemplate = "FILE_SERVER_DATA", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<FILE_SERVER_DATAInfo> FILE_SERVER_DATA_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng FILE_SERVER_DATA theo điều kiện {FILE_ID}/{DOC_TYPE}/{FILE_NAME}/{TRAN_ID}/{REGION_ID}/{IS_DELETE}")]
		[WebGet(UriTemplate = "FILE_SERVER_DATA/{FILE_ID}/{DOC_TYPE}/{FILE_NAME}/{TRAN_ID}/{REGION_ID}/{IS_DELETE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<FILE_SERVER_DATAInfo> FILE_SERVER_DATA_GetAllWithPadding(string  FILE_ID,string  DOC_TYPE,string  FILE_NAME,string  TRAN_ID,string  REGION_ID,string IS_DELETE, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng FILE_SERVER_DATA theo điều kiện {extension}")]
		[WebGet(UriTemplate = "FILE_SERVER_DATA_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response FILE_SERVER_DATA_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng FILE_SERVER_DATA theo điều kiện {FILE_ID}/{DOC_TYPE}/{FILE_NAME}/{TRAN_ID}/{REGION_ID}/{IS_DELETE}")]
		[WebGet(UriTemplate = "FILE_SERVER_DATA_EXPORT_DATA/{FILE_ID}/{DOC_TYPE}/{FILE_NAME}/{TRAN_ID}/{REGION_ID}/{IS_DELETE}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response FILE_SERVER_DATA_EXPORT_DATA(string  FILE_ID,string  DOC_TYPE,string  FILE_NAME,string  TRAN_ID,string  REGION_ID,string IS_DELETE, string extension);

		#endregion
		#region Create Functions "LOG_CHUC_NANG"
		[OperationContract]
		[Description("Thêm mới thông tin bảng LOG_CHUC_NANG")]
		[WebInvoke(UriTemplate = "LOG_CHUC_NANG", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_CHUC_NANG_Add(LOG_CHUC_NANGInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng LOG_CHUC_NANG")]
		[WebInvoke(UriTemplate = "LOG_CHUC_NANG", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_CHUC_NANG_Update(LOG_CHUC_NANGInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng LOG_CHUC_NANG theo ID")]
		[WebInvoke(UriTemplate = "LOG_CHUC_NANG/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_CHUC_NANG_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng LOG_CHUC_NANG theo ID")]
		[WebInvoke(UriTemplate = "LOG_CHUC_NANG/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<LOG_CHUC_NANGInfo> LOG_CHUC_NANG_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng LOG_CHUC_NANG")]
		[WebGet(UriTemplate = "LOG_CHUC_NANG", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<LOG_CHUC_NANGInfo> LOG_CHUC_NANG_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng LOG_CHUC_NANG theo điều kiện {USER_NAME}/{FUNCTION_NAME}/{ACTION}/{TIME_START_DATE}/{TIME_END_DATE}/{IS_DELETE}")]
		[WebGet(UriTemplate = "LOG_CHUC_NANG/{USER_NAME}/{FUNCTION_NAME}/{ACTION}/{TIME_START_DATE}/{TIME_END_DATE}/{IS_DELETE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<LOG_CHUC_NANGInfo> LOG_CHUC_NANG_GetAllWithPadding(string  USER_NAME,string  FUNCTION_NAME,string  ACTION,string TIME_START_DATE,string TIME_END_DATE,string IS_DELETE, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng LOG_CHUC_NANG theo điều kiện {extension}")]
		[WebGet(UriTemplate = "LOG_CHUC_NANG_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_CHUC_NANG_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng LOG_CHUC_NANG theo điều kiện {USER_NAME}/{FUNCTION_NAME}/{ACTION}/{TIME_START_DATE}/{TIME_END_DATE}/{IS_DELETE}")]
		[WebGet(UriTemplate = "LOG_CHUC_NANG_EXPORT_DATA/{USER_NAME}/{FUNCTION_NAME}/{ACTION}/{TIME_START_DATE}/{TIME_END_DATE}/{IS_DELETE}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_CHUC_NANG_EXPORT_DATA(string  USER_NAME,string  FUNCTION_NAME,string  ACTION,string TIME_START_DATE,string TIME_END_DATE,string IS_DELETE, string extension);

		#endregion
		#region Create Functions "LOG_DATA"
		[OperationContract]
		[Description("Thêm mới thông tin bảng LOG_DATA")]
		[WebInvoke(UriTemplate = "LOG_DATA", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_DATA_Add(LOG_DATAInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng LOG_DATA")]
		[WebInvoke(UriTemplate = "LOG_DATA", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_DATA_Update(LOG_DATAInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng LOG_DATA theo ID")]
		[WebInvoke(UriTemplate = "LOG_DATA/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_DATA_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng LOG_DATA theo ID")]
		[WebInvoke(UriTemplate = "LOG_DATA/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<LOG_DATAInfo> LOG_DATA_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng LOG_DATA")]
		[WebGet(UriTemplate = "LOG_DATA", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<LOG_DATAInfo> LOG_DATA_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng LOG_DATA theo điều kiện {IP}/{PORT}/{APPLICATION_NAME}/{MESSAGE}/{LOG_TYPE}/{IS_DELETE}/{CDATE_START_DATE}/{CDATE_END_DATE}")]
		[WebGet(UriTemplate = "LOG_DATA/{IP}/{PORT}/{APPLICATION_NAME}/{MESSAGE}/{LOG_TYPE}/{IS_DELETE}/{CDATE_START_DATE}/{CDATE_END_DATE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<LOG_DATAInfo> LOG_DATA_GetAllWithPadding(string  IP,string  PORT,string  APPLICATION_NAME,string  MESSAGE,string  LOG_TYPE,string  IS_DELETE,string CDATE_START_DATE,string CDATE_END_DATE, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng LOG_DATA theo điều kiện {extension}")]
		[WebGet(UriTemplate = "LOG_DATA_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_DATA_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng LOG_DATA theo điều kiện {IP}/{PORT}/{APPLICATION_NAME}/{MESSAGE}/{LOG_TYPE}/{IS_DELETE}/{CDATE_START_DATE}/{CDATE_END_DATE}")]
		[WebGet(UriTemplate = "LOG_DATA_EXPORT_DATA/{IP}/{PORT}/{APPLICATION_NAME}/{MESSAGE}/{LOG_TYPE}/{IS_DELETE}/{CDATE_START_DATE}/{CDATE_END_DATE}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_DATA_EXPORT_DATA(string  IP,string  PORT,string  APPLICATION_NAME,string  MESSAGE,string  LOG_TYPE,string  IS_DELETE,string CDATE_START_DATE,string CDATE_END_DATE, string extension);

		#endregion
		#region Create Functions "LOG_DU_LIEU_DB"
		[OperationContract]
		[Description("Thêm mới thông tin bảng LOG_DU_LIEU_DB")]
		[WebInvoke(UriTemplate = "LOG_DU_LIEU_DB", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_DU_LIEU_DB_Add(LOG_DU_LIEU_DBInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng LOG_DU_LIEU_DB")]
		[WebInvoke(UriTemplate = "LOG_DU_LIEU_DB", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_DU_LIEU_DB_Update(LOG_DU_LIEU_DBInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng LOG_DU_LIEU_DB theo ID")]
		[WebInvoke(UriTemplate = "LOG_DU_LIEU_DB/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_DU_LIEU_DB_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng LOG_DU_LIEU_DB theo ID")]
		[WebInvoke(UriTemplate = "LOG_DU_LIEU_DB/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<LOG_DU_LIEU_DBInfo> LOG_DU_LIEU_DB_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng LOG_DU_LIEU_DB")]
		[WebGet(UriTemplate = "LOG_DU_LIEU_DB", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<LOG_DU_LIEU_DBInfo> LOG_DU_LIEU_DB_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng LOG_DU_LIEU_DB theo điều kiện {USER_NAME}/{TABLE_NAME}/{ACTION}/{IS_DELETE}/{CDATE_START_DATE}/{CDATE_END_DATE}")]
		[WebGet(UriTemplate = "LOG_DU_LIEU_DB/{USER_NAME}/{TABLE_NAME}/{ACTION}/{IS_DELETE}/{CDATE_START_DATE}/{CDATE_END_DATE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<LOG_DU_LIEU_DBInfo> LOG_DU_LIEU_DB_GetAllWithPadding(string  USER_NAME,string  TABLE_NAME,string  ACTION,string  IS_DELETE,string CDATE_START_DATE,string CDATE_END_DATE, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng LOG_DU_LIEU_DB theo điều kiện {extension}")]
		[WebGet(UriTemplate = "LOG_DU_LIEU_DB_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_DU_LIEU_DB_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng LOG_DU_LIEU_DB theo điều kiện {USER_NAME}/{TABLE_NAME}/{ACTION}/{IS_DELETE}/{CDATE_START_DATE}/{CDATE_END_DATE}")]
		[WebGet(UriTemplate = "LOG_DU_LIEU_DB_EXPORT_DATA/{USER_NAME}/{TABLE_NAME}/{ACTION}/{IS_DELETE}/{CDATE_START_DATE}/{CDATE_END_DATE}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_DU_LIEU_DB_EXPORT_DATA(string  USER_NAME,string  TABLE_NAME,string  ACTION,string  IS_DELETE,string CDATE_START_DATE,string CDATE_END_DATE, string extension);

		#endregion
		#region Create Functions "LOG_TRUY_CAP"
		[OperationContract]
		[Description("Thêm mới thông tin bảng LOG_TRUY_CAP")]
		[WebInvoke(UriTemplate = "LOG_TRUY_CAP", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_TRUY_CAP_Add(LOG_TRUY_CAPInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng LOG_TRUY_CAP")]
		[WebInvoke(UriTemplate = "LOG_TRUY_CAP", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_TRUY_CAP_Update(LOG_TRUY_CAPInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng LOG_TRUY_CAP theo ID")]
		[WebInvoke(UriTemplate = "LOG_TRUY_CAP/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_TRUY_CAP_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng LOG_TRUY_CAP theo ID")]
		[WebInvoke(UriTemplate = "LOG_TRUY_CAP/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<LOG_TRUY_CAPInfo> LOG_TRUY_CAP_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng LOG_TRUY_CAP")]
		[WebGet(UriTemplate = "LOG_TRUY_CAP", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<LOG_TRUY_CAPInfo> LOG_TRUY_CAP_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng LOG_TRUY_CAP theo điều kiện {USER_NAME}/{LOG_TIME_START_DATE}/{LOG_TIME_END_DATE}/{ACTION}/{IS_DELETE}")]
		[WebGet(UriTemplate = "LOG_TRUY_CAP/{USER_NAME}/{LOG_TIME_START_DATE}/{LOG_TIME_END_DATE}/{ACTION}/{IS_DELETE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<LOG_TRUY_CAPInfo> LOG_TRUY_CAP_GetAllWithPadding(string  USER_NAME,string LOG_TIME_START_DATE,string LOG_TIME_END_DATE,string  ACTION,string IS_DELETE, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng LOG_TRUY_CAP theo điều kiện {extension}")]
		[WebGet(UriTemplate = "LOG_TRUY_CAP_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_TRUY_CAP_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng LOG_TRUY_CAP theo điều kiện {USER_NAME}/{LOG_TIME_START_DATE}/{LOG_TIME_END_DATE}/{ACTION}/{IS_DELETE}")]
		[WebGet(UriTemplate = "LOG_TRUY_CAP_EXPORT_DATA/{USER_NAME}/{LOG_TIME_START_DATE}/{LOG_TIME_END_DATE}/{ACTION}/{IS_DELETE}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_TRUY_CAP_EXPORT_DATA(string  USER_NAME,string LOG_TIME_START_DATE,string LOG_TIME_END_DATE,string  ACTION,string IS_DELETE, string extension);

		#endregion
		#region Create Functions "LOG_XL_HANG_LOAT"
		[OperationContract]
		[Description("Thêm mới thông tin bảng LOG_XL_HANG_LOAT")]
		[WebInvoke(UriTemplate = "LOG_XL_HANG_LOAT", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_XL_HANG_LOAT_Add(LOG_XL_HANG_LOATInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng LOG_XL_HANG_LOAT")]
		[WebInvoke(UriTemplate = "LOG_XL_HANG_LOAT", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_XL_HANG_LOAT_Update(LOG_XL_HANG_LOATInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng LOG_XL_HANG_LOAT theo ID")]
		[WebInvoke(UriTemplate = "LOG_XL_HANG_LOAT/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_XL_HANG_LOAT_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng LOG_XL_HANG_LOAT theo ID")]
		[WebInvoke(UriTemplate = "LOG_XL_HANG_LOAT/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<LOG_XL_HANG_LOATInfo> LOG_XL_HANG_LOAT_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng LOG_XL_HANG_LOAT")]
		[WebGet(UriTemplate = "LOG_XL_HANG_LOAT", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<LOG_XL_HANG_LOATInfo> LOG_XL_HANG_LOAT_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng LOG_XL_HANG_LOAT theo điều kiện {USER_NAME}/{FUNCTION_NAME}/{TIME_START_DATE}/{TIME_END_DATE}/{IS_DELETE}")]
		[WebGet(UriTemplate = "LOG_XL_HANG_LOAT/{USER_NAME}/{FUNCTION_NAME}/{TIME_START_DATE}/{TIME_END_DATE}/{IS_DELETE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<LOG_XL_HANG_LOATInfo> LOG_XL_HANG_LOAT_GetAllWithPadding(string  USER_NAME,string  FUNCTION_NAME,string TIME_START_DATE,string TIME_END_DATE,string IS_DELETE, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng LOG_XL_HANG_LOAT theo điều kiện {extension}")]
		[WebGet(UriTemplate = "LOG_XL_HANG_LOAT_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_XL_HANG_LOAT_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng LOG_XL_HANG_LOAT theo điều kiện {USER_NAME}/{FUNCTION_NAME}/{TIME_START_DATE}/{TIME_END_DATE}/{IS_DELETE}")]
		[WebGet(UriTemplate = "LOG_XL_HANG_LOAT_EXPORT_DATA/{USER_NAME}/{FUNCTION_NAME}/{TIME_START_DATE}/{TIME_END_DATE}/{IS_DELETE}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_XL_HANG_LOAT_EXPORT_DATA(string  USER_NAME,string  FUNCTION_NAME,string TIME_START_DATE,string TIME_END_DATE,string IS_DELETE, string extension);

		#endregion
		#region Create Functions "LOG_XL_QUY_TRINH"
		[OperationContract]
		[Description("Thêm mới thông tin bảng LOG_XL_QUY_TRINH")]
		[WebInvoke(UriTemplate = "LOG_XL_QUY_TRINH", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_XL_QUY_TRINH_Add(LOG_XL_QUY_TRINHInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng LOG_XL_QUY_TRINH")]
		[WebInvoke(UriTemplate = "LOG_XL_QUY_TRINH", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_XL_QUY_TRINH_Update(LOG_XL_QUY_TRINHInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng LOG_XL_QUY_TRINH theo ID")]
		[WebInvoke(UriTemplate = "LOG_XL_QUY_TRINH/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_XL_QUY_TRINH_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng LOG_XL_QUY_TRINH theo ID")]
		[WebInvoke(UriTemplate = "LOG_XL_QUY_TRINH/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<LOG_XL_QUY_TRINHInfo> LOG_XL_QUY_TRINH_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng LOG_XL_QUY_TRINH")]
		[WebGet(UriTemplate = "LOG_XL_QUY_TRINH", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<LOG_XL_QUY_TRINHInfo> LOG_XL_QUY_TRINH_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng LOG_XL_QUY_TRINH theo điều kiện {USER_NAME}/{STEP}/{LOG_TIME_START_DATE}/{LOG_TIME_END_DATE}/{ACTION}/{IS_DELETE}")]
		[WebGet(UriTemplate = "LOG_XL_QUY_TRINH/{USER_NAME}/{STEP}/{LOG_TIME_START_DATE}/{LOG_TIME_END_DATE}/{ACTION}/{IS_DELETE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<LOG_XL_QUY_TRINHInfo> LOG_XL_QUY_TRINH_GetAllWithPadding(string  USER_NAME,string  STEP,string LOG_TIME_START_DATE,string LOG_TIME_END_DATE,string  ACTION,string IS_DELETE, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng LOG_XL_QUY_TRINH theo điều kiện {extension}")]
		[WebGet(UriTemplate = "LOG_XL_QUY_TRINH_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_XL_QUY_TRINH_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng LOG_XL_QUY_TRINH theo điều kiện {USER_NAME}/{STEP}/{LOG_TIME_START_DATE}/{LOG_TIME_END_DATE}/{ACTION}/{IS_DELETE}")]
		[WebGet(UriTemplate = "LOG_XL_QUY_TRINH_EXPORT_DATA/{USER_NAME}/{STEP}/{LOG_TIME_START_DATE}/{LOG_TIME_END_DATE}/{ACTION}/{IS_DELETE}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response LOG_XL_QUY_TRINH_EXPORT_DATA(string  USER_NAME,string  STEP,string LOG_TIME_START_DATE,string LOG_TIME_END_DATE,string  ACTION,string IS_DELETE, string extension);

		#endregion
		#region Create Functions "SHARE_DD_MO_TD"
		[OperationContract]
		[Description("Thêm mới thông tin bảng SHARE_DD_MO_TD")]
		[WebInvoke(UriTemplate = "SHARE_DD_MO_TD", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response SHARE_DD_MO_TD_Add(SHARE_DD_MO_TDInfo info);

		[OperationContract]
		[Description("Cập nhật thông tin thông tin bảng SHARE_DD_MO_TD")]
		[WebInvoke(UriTemplate = "SHARE_DD_MO_TD", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		Response SHARE_DD_MO_TD_Update(SHARE_DD_MO_TDInfo info);

		[OperationContract]
		[Description("Xóa thông tin bảng SHARE_DD_MO_TD theo ID")]
		[WebInvoke(UriTemplate = "SHARE_DD_MO_TD/{ID}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
		Response SHARE_DD_MO_TD_Delete(string ID);

		[OperationContract]
		[Description("Lấy thông tin bản ghi của bảng SHARE_DD_MO_TD theo ID")]
		[WebInvoke(UriTemplate = "SHARE_DD_MO_TD/{ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		ResponseInfo<SHARE_DD_MO_TDInfo> SHARE_DD_MO_TD_GetInfo(string ID);

		[OperationContract]
		[Description("Lấy tất cả thông tin bảng SHARE_DD_MO_TD")]
		[WebGet(UriTemplate = "SHARE_DD_MO_TD", ResponseFormat = WebMessageFormat.Json)]
		ResponseList<SHARE_DD_MO_TDInfo> SHARE_DD_MO_TD_GetList();

		[OperationContract]
		[Description("Lấy tất cả thông tin của 1 trang trong bảng SHARE_DD_MO_TD theo điều kiện {MA_DVI}/{LOAIDAT}/{SOTOGOC}/{SOTOCU}/{SOTHUACU}/{MAKVUC}/{MAHUYEN}/{MAXA}/{SOTO}/{SOTHUA}/{IS_DELETE}")]
		[WebGet(UriTemplate = "SHARE_DD_MO_TD/{MA_DVI}/{LOAIDAT}/{SOTOGOC}/{SOTOCU}/{SOTHUACU}/{MAKVUC}/{MAHUYEN}/{MAXA}/{SOTO}/{SOTHUA}/{IS_DELETE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
		ResponsePage<SHARE_DD_MO_TDInfo> SHARE_DD_MO_TD_GetAllWithPadding(string  MA_DVI,string  LOAIDAT,string  SOTOGOC,string  SOTOCU,string  SOTHUACU,string  MAKVUC,string  MAHUYEN,string  MAXA,string  SOTO,string  SOTHUA,string IS_DELETE, string pageIndex, string pageSize);

		[OperationContract]
		[Description("Xuất mẫu nhập bảng SHARE_DD_MO_TD theo điều kiện {extension}")]
		[WebGet(UriTemplate = "SHARE_DD_MO_TD_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response SHARE_DD_MO_TD_EXPORT_TEMPLATE(string extension);

		[OperationContract]
		[Description("Xuất dữ liệu bảng SHARE_DD_MO_TD theo điều kiện {MA_DVI}/{LOAIDAT}/{SOTOGOC}/{SOTOCU}/{SOTHUACU}/{MAKVUC}/{MAHUYEN}/{MAXA}/{SOTO}/{SOTHUA}/{IS_DELETE}")]
		[WebGet(UriTemplate = "SHARE_DD_MO_TD_EXPORT_DATA/{MA_DVI}/{LOAIDAT}/{SOTOGOC}/{SOTOCU}/{SOTHUACU}/{MAKVUC}/{MAHUYEN}/{MAXA}/{SOTO}/{SOTHUA}/{IS_DELETE}/{extension}", ResponseFormat = WebMessageFormat.Json)]
		Response SHARE_DD_MO_TD_EXPORT_DATA(string  MA_DVI,string  LOAIDAT,string  SOTOGOC,string  SOTOCU,string  SOTHUACU,string  MAKVUC,string  MAHUYEN,string  MAXA,string  SOTO,string  SOTHUA,string IS_DELETE, string extension);

		#endregion        
    }
}



