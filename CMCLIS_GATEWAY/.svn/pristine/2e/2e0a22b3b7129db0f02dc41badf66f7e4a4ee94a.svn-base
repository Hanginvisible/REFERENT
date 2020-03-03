using System;
using System.ServiceModel.Activation;
using System.Text;
using System.Web.Routing;
using CMCLIS.GATEWAY.CORE;
using CMCLIS.GATEWAY.SETTING;

namespace CMCLIS.GATEWAY.HOST
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            try
            {
                #region Service Route
                RouteTable.Routes.Add(new ServiceRoute("REST/" + Constant.API_CORE_BASE, new WebServiceHostFactory(), typeof(CMCLIS.GATEWAY.SERVICES.API_CORE_BASE)));
                RouteTable.Routes.Add(new ServiceRoute("REST/" + Constant.API_AUTHENTICATION, new WebServiceHostFactory(), typeof(CMCLIS.GATEWAY.SERVICES.API_AUTHENTICATION)));                
                RouteTable.Routes.Add(new ServiceRoute("REST/" + Constant.API_SYSTEMS, new WebServiceHostFactory(), typeof(CMCLIS.GATEWAY.SERVICES.API_SYSTEMS)));
                RouteTable.Routes.Add(new ServiceRoute("REST/" + Constant.API_LIEN_THONG, new WebServiceHostFactory(), typeof(CMCLIS.GATEWAY.SERVICES.API_LIEN_THONG)));
                RouteTable.Routes.Add(new ServiceRoute("REST/" + Constant.API_TIM_KIEM, new WebServiceHostFactory(), typeof(CMCLIS.GATEWAY.SERVICES.API_TIM_KIEM)));
                RouteTable.Routes.Add(new ServiceRoute("REST/" + Constant.API_BAO_CAO, new WebServiceHostFactory(), typeof(CMCLIS.GATEWAY.SERVICES.API_BAO_CAO)));
                RouteTable.Routes.Add(new ServiceRoute("REST/" + Constant.API_LOG, new WebServiceHostFactory(), typeof(CMCLIS.GATEWAY.SERVICES.API_LOG)));
                RouteTable.Routes.Add(new ServiceRoute("REST/" + Constant.API_FILE_SERVER, new WebServiceHostFactory(), typeof(CMCLIS.GATEWAY.SERVICES.API_FILE_SERVER)));
                RouteTable.Routes.Add(new ServiceRoute("REST/" + Constant.API_CHIA_SE, new WebServiceHostFactory(), typeof(CMCLIS.GATEWAY.SERVICES.API_CHIA_SE)));
                RouteTable.Routes.Add(new ServiceRoute("REST/" + Constant.API_EMAIL, new WebServiceHostFactory(), typeof(CMCLIS.GATEWAY.SERVICES.API_EMAIL)));

                #endregion
                //#region Load config
                //if (Directory.Exists(HttpContext.Current.Server.MapPath("~") + "/Security/License"))
                //{
                //    string[] filePaths = Directory.GetFiles(HttpContext.Current.Server.MapPath("~") + "/Security/License", "*.xml", SearchOption.AllDirectories);
                //    foreach (string filePath in filePaths)
                //    {
                //        XmlDocument xmlDocument = new XmlDocument();
                //        xmlDocument.LoadXml(Utility.LoadFile(filePath));
                //        if (xmlDocument != null)
                //        {
                //            LICENSEInfo _LICENSEInfo = new LICENSEInfo()
                //            {
                //                CLIENT_ID = xmlDocument.SelectNodes("/DATA/CLIENT_ID").Count > 0 ? xmlDocument.SelectNodes("/DATA/CLIENT_ID")[0].InnerText : string.Empty,
                //                CLIENT_TYPE = xmlDocument.SelectNodes("/DATA/CLIENT_TYPE").Count > 0 ? xmlDocument.SelectNodes("/DATA/CLIENT_TYPE")[0].InnerText : string.Empty,
                //                DOMAIN = xmlDocument.SelectNodes("/DATA/DOMAIN").Count > 0 ? xmlDocument.SelectNodes("/DATA/DOMAIN")[0].InnerText : string.Empty,
                //                EXPIRE = xmlDocument.SelectNodes("/DATA/EXPIRE").Count > 0 ? xmlDocument.SelectNodes("/DATA/EXPIRE")[0].InnerText : string.Empty,
                //                LIST_SERVICE = new List<SERVICESInfo>()
                //            };
                //            foreach (XmlNode xmlNode in xmlDocument.SelectNodes("/DATA/SERVICES/ITEM"))
                //            {
                //                SERVICESInfo _SERVICESInfo = new SERVICESInfo()
                //                {
                //                    SERVICE_CODE = xmlNode["SERVICE_CODE"].InnerText,
                //                    SERVICE_NAME = xmlNode["SERVICE_NAME"].InnerText,
                //                    ACTIVE = xmlNode["ACTIVE"].InnerText
                //                };
                //                _LICENSEInfo.LIST_SERVICE.Add(_SERVICESInfo);
                //            }
                //            if (!CacheProvider.Exists(_LICENSEInfo.CLIENT_ID))
                //                CacheProvider.Add(_LICENSEInfo.CLIENT_ID, _LICENSEInfo);
                //        }
                //    }
                //}
                //#endregion
            }
            catch (Exception ex) {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Response.AppendHeader("Access-Control-Allow-Origin", "*");
            Response.CacheControl = "no-cache";
            Response.ContentType = "text/plain";
            Response.ContentType = "application/json";
            Response.ContentEncoding = Encoding.UTF8;
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}