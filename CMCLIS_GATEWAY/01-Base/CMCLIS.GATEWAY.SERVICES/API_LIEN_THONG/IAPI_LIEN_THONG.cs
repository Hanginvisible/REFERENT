using CMCLIS.GATEWAY.ENTITY;
using CMCLIS.GATEWAY.ENTITY.LIEN_THONG;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace CMCLIS.GATEWAY.SERVICES
{
    [ServiceContract]
    public interface IAPI_LIEN_THONG
    {

        #region Create Functions of GATEWAY
        [OperationContract]
        [Description("Lấy tất cả thông tin bảng CVAN_MSGIInfo theo điều kiện  {CVAN_CODE}/{CVAN_MSGO_CODE}/{CVAN_MSG_TYPE_CODE}/{CVAN_STATUS_CODE}")]
        [WebGet(UriTemplate = "CVAN_MSGIInfo/{CVAN_CODE}/{CVAN_MSGO_CODE}/{CVAN_MSG_TYPE_CODE}/{CVAN_STATUS_CODE}", ResponseFormat = WebMessageFormat.Json)]
        ResponseList<CVAN_MSGIInfo> CVAN_MSGIInfo(string CVAN_CODE, string CVAN_MSGO_CODE, string CVAN_MSG_TYPE_CODE, string CVAN_STATUS_CODE);

        [OperationContract]
        [Description("Lấy tất cả thông tin bảng CVAN_MSGOInfo theo điều kiện  {CVAN_CODE}/{CVAN_MSG_TYPE_CODE}/{CVAN_SENDER_CODE}/{CVAN_STATUS_SEND}")]
        [WebGet(UriTemplate = "CVAN_MSGOInfo/{CVAN_CODE}/{CVAN_MSG_TYPE_CODE}/{CVAN_SENDER_CODE}/{CVAN_STATUS_SEND}", ResponseFormat = WebMessageFormat.Json)]
        ResponseList<CVAN_MSGOInfo> CVAN_MSGOInfo(string CVAN_CODE, string CVAN_MSG_TYPE_CODE, string CVAN_SENDER_CODE, string CVAN_STATUS_SEND);

        [OperationContract]
        [Description("Gửi nội dung thông tin message tới rabbit MQ")]
        [WebInvoke(UriTemplate = "CVAN_TIEP_NHAN_HO_SO", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response CVAN_TIEP_NHAN_HO_SO(SERVICE_REQUEST_INFO _SERVICE_REQUEST_INFO);
        #endregion
    }
}
