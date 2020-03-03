using CMCLIS.CVAN.ENTITY;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace CTS.GATEWAY.SERVICES
{
    [ServiceContract]
    public interface IAPI_AUTHENTICATION
    {
        [OperationContract]
        [Description("Get tokent to Authorization")]
        [WebInvoke(UriTemplate = "VERIFY_TOKENT/{TOKENT_API}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        ResponseInfo<CLIENT_SENDERInfo> VERIFY_TOKENT(string TOKENT_API);
        
    }
}
