using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CMCLIS.GATEWAY.CORE
{
    public class HttpWebRequestBase
    {
        public static T POST<T>(string jsonDataPost,string url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                //string json = new JavaScriptSerializer().Serialize(jsonDataPost);
                streamWriter.Write(jsonDataPost);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var jsonResponse = streamReader.ReadToEnd();
                T response = JsonConvert.DeserializeObject<T>(jsonResponse);
                return response;
            }
        }

        public static T GET<T>(string url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "application/json";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var jsonResponse = streamReader.ReadToEnd();
                T response = JsonConvert.DeserializeObject<T>(jsonResponse);
                return response;
            }
        }
    }
}
