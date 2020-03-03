using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CMCLIS.GATEWAY.CORE
{
    public class ProcessXml
    {
        public static string ObjectToXml(object objInfo)
        {
            try
            {
                string xmlDoccument = string.Empty;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(objInfo.GetType());
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                xs.Serialize(xmlTextWriter, objInfo);
                xmlDoccument = Encoding.UTF8.GetString(memoryStream.ToArray());
                xmlDoccument = xmlDoccument.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "");           
                return xmlDoccument;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return string.Empty;
            }
        }

        public static T Deserialize<T>(string xml)
        {
            
            var xs = new XmlSerializer(typeof(T));
            return (T)xs.Deserialize(new StringReader(xml));
        }

        public static string SelectNodeValuesByName(string sXml, string xPath, string nodeName)
        {
            string val = string.Empty;

            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(sXml);

                XmlNodeList xnList = xml.SelectNodes(xPath);
                foreach (XmlNode xn in xnList)
                {
                    val += xn[nodeName].InnerText + "###";
                }
                if (!string.IsNullOrEmpty(val))
                {
                    val = val.Substring(0, val.Length - 3);
                }
            }
            catch (Exception ex)
            {
               LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }

            return val;
        }

        public static string SelectNodeValueByName(string sXml, string xPath, string nodeName)
        {
            string val = string.Empty;

            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(sXml);

                XmlNode xn = xml.SelectSingleNode(xPath);
                val = xn[nodeName].InnerText;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }

            return val;
        }
    }
}
