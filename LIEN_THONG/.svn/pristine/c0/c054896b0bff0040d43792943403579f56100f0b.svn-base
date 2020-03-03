using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;
using CTS.GATEWAY.ENTITY;

namespace CTS.GATEWAY.SERVICES
{
    [ServiceContract]
    public interface IAPI_SYSTEMS
    {
        [OperationContract]
        [Description("Get tokent to Authorization")]
        [WebInvoke(UriTemplate = "VERIFY_TOKENT/{TOKENT_API}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        ResponseInfo<CLIENT_SENDERInfo> VERIFY_TOKENT(string TOKENT_API);

        [OperationContract]
        [Description("Lấy thông tin phân quyền khu vực,trang hiển thị")]
        [WebInvoke(UriTemplate = "SYS_PERMISSION_PAGE/{ParentId}/{UserId}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        ResponseList<PERMISSION_PAGEInfo> SYS_PERMISSION_PAGE_GET_VIEW(string ParentId, string UserId);
    }
}
