
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Timers;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using System.Web;
using RabbitMQ.Client.Events;
using RabbitConsumer.MODEL;

namespace RabbitConsumer
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string rabbitmqconnection = $"amqp://{HttpUtility.UrlEncode("guest")}:{ HttpUtility.UrlEncode("guest")}@{ "localhost:5672"}";
                var factory = new ConnectionFactory();
                factory.Uri = new Uri(rabbitmqconnection);

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "inThing1",
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (sender, e) =>
                    {
                        var body = e.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        
                        var act = System.Text.Json.JsonSerializer.Deserialize<Activity>(message);
                        
                        if(act.participants >= 1 && act.accessibility > 0.3)
                        {
                            act.ShowActivity(act);
                        }


                        //var body = e.Body.ToString();
                        //var message = Encoding.UTF8.GetBytes((string)JsonConvert.DeserializeObject(body).ToString());

                    };

                    channel.BasicConsume("inThing1", true, consumer);

                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message not sent");
            }
        }
    }
}
