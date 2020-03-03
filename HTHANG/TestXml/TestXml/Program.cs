using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using TestXml.XmlProcess;

namespace TestXml
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dataTable = new DataTable();
            //ExportXml.ExportXML(null, null, dataTable);

            var factory = new ConnectionFactory()
            {
                HostName = ConfigurationManager.AppSettings["MQ_HOST"],
                UserName = ConfigurationManager.AppSettings["MQ_USER"],
                Password = ConfigurationManager.AppSettings["MQ_PASSWORD"],
                Port = int.Parse(ConfigurationManager.AppSettings["MQ_PORT"])
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: ConfigurationManager.AppSettings["MQ_NAME"],
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = ExportXml.ExportXML(null, null, dataTable);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
