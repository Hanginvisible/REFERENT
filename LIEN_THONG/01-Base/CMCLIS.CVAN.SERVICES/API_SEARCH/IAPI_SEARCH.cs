using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;
using CTS.GATEWAY.ENTITY;

namespace CTS.GATEWAY.SERVICES
{
    [ServiceContract]
    public interface IAPI_SEARCH
    {
        [OperationContract]
        [Description("Get tokent to Authorization")]
        [WebInvoke(UriTemplate = "VERIFY_TOKENT/{TOKENT_API}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        ResponseInfo<CLIENT_SENDERInfo> VERIFY_TOKENT(string TOKENT_API);
        
    }
}
