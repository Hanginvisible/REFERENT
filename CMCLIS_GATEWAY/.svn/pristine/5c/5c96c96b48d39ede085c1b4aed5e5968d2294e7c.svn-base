using CMCLIS.GATEWAY.CORE;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CMCLIS.GATEWAY.WServiceMQMail
{
    public static class CommonFunction
    {
        private static ConnectionFactory factory=null;
        private static IConnection connection = null;
        private static IModel channel;
        public static void ConsumeQueue()
        {
            factory = new ConnectionFactory()
            {
                HostName = ConfigurationManager.AppSettings["MQ_HOST"],
                UserName = ConfigurationManager.AppSettings["MQ_USER"],
                Password = ConfigurationManager.AppSettings["MQ_PASSWORD"],
                Port = int.Parse(ConfigurationManager.AppSettings["MQ_PORT"])
            };
            try
            {
                connection = factory.CreateConnection();
                channel = connection.CreateModel();
                channel.QueueDeclare(queue: ConfigurationManager.AppSettings["CMCLIS_MAIL_INFO"],
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);

                    if (message == "CONNECT_MQ")
                        LogEventError.LogEvent(" [x] Received {" + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + " }---{" + message + "}");
                    else
                    {
                        Console.WriteLine("--------------------------------------------------");
                        var result = MQ_PROCESS_DATA.PROCESS_MAIL(ea.Body);
                        if (int.Parse(result.ToString()) != -1)
                        {
                            LogEventError.LogEvent(" [->] Received {" + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + "}");
                        }
                        else
                        {
                            LogEventError.LogEvent(" [->] Received {" + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + " }---{Error !}");
                        }
                        LogEventError.LogEvent("--------------------------------------------------");
                    }

                    //CMCLIS.GATEWAY.DataObjects.DataObjectFactory.GetInstanceCVAN_MSGO().CVAN_MSGI_INSERT_MSGXML_2_MSGOUT(ea.Exchange, ea.Body, ConfigurationManager.AppSettings["MQ_NAME"]);
                    //Console.WriteLine(" [x] Received {0}", Encoding.UTF8.GetString(ea.Body));
                };
                channel.BasicConsume(queue: ConfigurationManager.AppSettings["CMCLIS_MAIL_INFO"],
                                     noAck: true,
                                     consumer: consumer);
            }
            catch(Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
