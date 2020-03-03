using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMCLIS.CVAN.SETTING;

namespace CMCLIS.CVAN.CORE
{
    public class MQProcess
    {
        public static int SendDataToMQ(Byte[] body, string MQ_NAME)
        {
            try
            {
                int result = 0;
                var factory = new ConnectionFactory() 
                { 
                    HostName = Config.MQ_HOST ,
                    UserName = Config.MQ_USER,
                    Password = Config.MQ_PASSWORD,
                    Port = int.Parse(Config.MQ_PORT)
                };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: MQ_NAME,
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);


                    //var body = Encoding.UTF8.GetBytes(message);

                    //channel.BasicPublish(exchange: strAttach,
                    //                     routingKey: MQ_NAME,
                    //                     basicProperties: null,
                    //                     body: body);
                    channel.BasicPublish(exchange: "",
                                         routingKey: MQ_NAME,
                                         basicProperties: null,
                                         body: body);
                    result = 1;

                }
                return result;
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return -1;
            }

        }

        public static void GetDataFromMQ(string className, string methodName, Object[] stringParam)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = Config.MQ_HOST };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: Config.MQ_NAME,
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        var result = InvokeMethod.InvokeStringMethod(Config.ASSEMBLY_NAME, Config.NAMESPACE_NAME, className, methodName, stringParam);
                        //Console.WriteLine(" [x] Received {0}", message);
                    };
                    channel.BasicConsume(queue: Config.MQ_NAME,
                                         noAck: true,
                                         consumer: consumer);

                    //Console.WriteLine(" Press [enter] to exit.");
                    //Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                
            }
        }
    }
}
