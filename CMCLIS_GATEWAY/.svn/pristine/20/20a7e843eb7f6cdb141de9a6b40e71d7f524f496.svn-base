using CMCLIS.GATEWAY.ENTITY;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace CMCLIS.GATEWAY.SERVICES
{
    [ServiceContract]
    public interface IAPI_FILE_SERVER
    {
        #region Create Functions "FILE_SERVER_DATA"
        [OperationContract]
        [Description("Thêm mới thông tin bảng FILE_SERVER_DATA")]
        [WebInvoke(UriTemplate = "FILE_SERVER_DATA", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response FILE_SERVER_DATA_Add(FILE_SERVER_DATAObject info);

        [OperationContract]
        [Description("Lấy thông tin bản ghi của bảng FILE_SERVER_DATA theo ID")]
        [WebInvoke(UriTemplate = "FILE_SERVER_DATA/{FILE_ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        ResponseInfo<FILE_SERVER_RESPONSE> FILE_SERVER_DATA_GetInfo(string FILE_ID);

        [OperationContract]
        [Description("Lấy tất cả thông tin của 1 trang trong bảng FILE_SERVER_DATA theo điều kiện {FILE_ID}/{DOC_TYPE}/{FILE_NAME}/{TRAN_ID}/{REGION_ID}/{IS_DELETE}")]
        [WebGet(UriTemplate = "FILE_SERVER_DATA/{FILE_ID}/{DOC_TYPE}/{FILE_NAME}/{TRAN_ID}/{REGION_ID}/{IS_DELETE}/{pageIndex}/{pageSize}", ResponseFormat = WebMessageFormat.Json)]
        ResponsePage<FILE_SERVER_DATAInfo> FILE_SERVER_DATA_GetAllWithPadding(string FILE_ID, string DOC_TYPE, string FILE_NAME, string TRAN_ID, string REGION_ID, string IS_DELETE, string pageIndex, string pageSize);
        #endregion
    }
}
