using CMCLIS.GATEWAY.ENTITY;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace CMCLIS.GATEWAY.SERVICES
{
    [ServiceContract]
    public interface IAPI_AUTHENTICATION
    {
        [OperationContract]
        [WebGet(UriTemplate = "AUTHENTICATION", ResponseFormat = WebMessageFormat.Json)]
        Response GET_AUTHENTICATION();
    }
}
