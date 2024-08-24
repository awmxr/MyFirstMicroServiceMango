using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Mango.MessageBus
{
    public class MessageBus : IMessageBus
    {
        public async Task PublishMessage(object message, string topic_queue_Name)
        {

            var factory = new ConnectionFactory {
                HostName = "localhost" ,
                UserName = "amir",
                Password = "pass",
                VirtualHost = "/"
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.ConfirmSelect();
            channel.QueueDeclare(queue: topic_queue_Name,
                                 durable: true,
                                 autoDelete:false,
                                 exclusive: false);

            
            var jsonMessage = JsonConvert.SerializeObject(message);

            var body = Encoding.UTF8.GetBytes(jsonMessage);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: topic_queue_Name,
                                 basicProperties: null,
                                 body: body);
            


            
        }
    }
}
