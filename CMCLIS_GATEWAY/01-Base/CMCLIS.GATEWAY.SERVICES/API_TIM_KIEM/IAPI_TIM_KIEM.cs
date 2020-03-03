using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;
using CMCLIS.GATEWAY.ENTITY;

namespace CMCLIS.GATEWAY.SERVICES
{
    [ServiceContract]
    public interface IAPI_TIM_KIEM
    {
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
        ResponsePage<SHARE_DD_MO_TDInfo> SHARE_DD_MO_TD_GetAllWithPadding(string MA_DVI, string LOAIDAT, string SOTOGOC, string SOTOCU, string SOTHUACU, string MAKVUC, string MAHUYEN, string MAXA, string SOTO, string SOTHUA, string IS_DELETE, string pageIndex, string pageSize);

        [OperationContract]
        [Description("Xuất mẫu nhập bảng SHARE_DD_MO_TD theo điều kiện {extension}")]
        [WebGet(UriTemplate = "SHARE_DD_MO_TD_EXPORT_TEMPLATE/{extension}", ResponseFormat = WebMessageFormat.Json)]
        Response SHARE_DD_MO_TD_EXPORT_TEMPLATE(string extension);

        [OperationContract]
        [Description("Xuất dữ liệu bảng SHARE_DD_MO_TD theo điều kiện {MA_DVI}/{LOAIDAT}/{SOTOGOC}/{SOTOCU}/{SOTHUACU}/{MAKVUC}/{MAHUYEN}/{MAXA}/{SOTO}/{SOTHUA}/{IS_DELETE}")]
        [WebGet(UriTemplate = "SHARE_DD_MO_TD_EXPORT_DATA/{MA_DVI}/{LOAIDAT}/{SOTOGOC}/{SOTOCU}/{SOTHUACU}/{MAKVUC}/{MAHUYEN}/{MAXA}/{SOTO}/{SOTHUA}/{IS_DELETE}/{extension}", ResponseFormat = WebMessageFormat.Json)]
        Response SHARE_DD_MO_TD_EXPORT_DATA(string MA_DVI, string LOAIDAT, string SOTOGOC, string SOTOCU, string SOTHUACU, string MAKVUC, string MAHUYEN, string MAXA, string SOTO, string SOTHUA, string IS_DELETE, string extension);

        #endregion  
    }
}
