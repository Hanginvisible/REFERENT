using CMCLIS.CVAN.CORE;
using CMCLIS.CVAN.CORE.Redis;
using CMCLIS.CVAN.CORE.Sercurity;
using CMCLIS.CVAN.ENTITY;
using CMCLIS.CVAN.SETTING;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace CTS.GATEWAY.SERVICES
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class API_RECEIVE : IAPI_RECEIVE
    {      

        #region Verify tokent       
        public ResponseInfo<CLIENT_SENDERInfo> VERIFY_TOKENT(string TOKENT_API)
        {
            try
            {
                bool result = false;
                string jsonTokent = TokenManager.Decode(TOKENT_API, Constant.ENCRYPT_KEY, ref result);
                if(!result)
                    return new ResponseInfo<CLIENT_SENDERInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR_TOKENT,
                        Data = null
                    };
                var REQUEST_CLIENT_SENDERInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<CLIENT_SENDERInfo>(jsonTokent);
                RedisCacheProvider _cacheProvider = new RedisCacheProvider("DB0");
                Dictionary<string, CLIENT_SENDERInfo> DICT_TOKENT_API = _cacheProvider.Get<Dictionary<string, CLIENT_SENDERInfo>>("TOKENT_API");                
                if (DICT_TOKENT_API == null)
                    DICT_TOKENT_API = new Dictionary<string, CLIENT_SENDERInfo>();
                CLIENT_SENDERInfo _CLIENT_SENDERInfo = DICT_TOKENT_API.ContainsKey(REQUEST_CLIENT_SENDERInfo.CLIENT_CODE) ? DICT_TOKENT_API[REQUEST_CLIENT_SENDERInfo.CLIENT_CODE] : null;
                if (_CLIENT_SENDERInfo == null)
                    return new ResponseInfo<CLIENT_SENDERInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR,
                        Data = null
                    };
                if (!_CLIENT_SENDERInfo.STATUS.Value)
                    return new ResponseInfo<CLIENT_SENDERInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR_ACTIVE,
                        Data = null
                    };
                if (int.Parse(_CLIENT_SENDERInfo.EXPIRE_DATE.Value.ToString("yyyyMMdd")) < int.Parse(DateTime.Now.ToString("yyyyMMdd")))
                    return new ResponseInfo<CLIENT_SENDERInfo>
                    {
                        ResultCode = Constant.RETURN_CODE_ERROR,
                        Message = Constant.MESSAGE_AUT_ERROR_EXPIRED,
                        Data = null
                    };
                return new ResponseInfo<CLIENT_SENDERInfo>
                {
                    ResultCode = result ? Constant.RETURN_CODE_SUCCESS : Constant.RETURN_CODE_ERROR,
                    Message = result ? Constant.MESSAGE_SUCCESS : Constant.MESSAGE_AUT_ERROR,
                    Data = _CLIENT_SENDERInfo
                };

            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return new ResponseInfo<CLIENT_SENDERInfo>
                {
                    ResultCode = Constant.RETURN_CODE_ERROR,
                    Message = Constant.MESSAGE_ERROR,
                    Data = null
                };
            }
        }       

        #endregion

    }
}
