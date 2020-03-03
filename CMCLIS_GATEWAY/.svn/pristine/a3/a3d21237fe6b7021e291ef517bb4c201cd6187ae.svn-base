using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using CMCLIS.GATEWAY.ENTITY;
using CMCLIS.GATEWAY.CORE;
using CMCLIS.GATEWAY.CORE.Redis;
using CMCLIS.GATEWAY.CORE.Sercurity;
using CMCLIS.GATEWAY.SETTING;
using System.ServiceModel.Channels;

namespace CMCLIS.GATEWAY.SERVICES
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class API_AUTHENTICATION : IAPI_AUTHENTICATION
    {
        private static string Authorization = string.Empty;
        protected API_AUTHENTICATION()
        {
            var request = OperationContext.Current.IncomingMessageProperties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            Authorization = request.Headers[Config.API_KEY];
            if (string.IsNullOrEmpty(Authorization))
            {
                Authorization = Config.KEY_AUTHORIZATION;
            }

        }

        public Response GET_AUTHENTICATION()
        {
            return new Response() { Message = "OK", ResultCode = "OK" };
        }
    }
}
