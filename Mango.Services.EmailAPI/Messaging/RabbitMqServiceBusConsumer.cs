using Mango.Services.EmailAPI.Data;
using Mango.Services.EmailAPI.Models;
using Mango.Services.EmailAPI.Models.Dto;
using Mango.Services.EmailAPI.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
namespace Mango.Services.EmailAPI.Messaging
{
    public class RabbitMqServiceBusConsumer : IRabbitMqServiceBusConsumer
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName;
        private readonly EmailService _emailService;
        //private readonly AppDbContext _db;

        public RabbitMqServiceBusConsumer(EmailService emailService)
        {
            _queueName = "emailshoppingcart";
            _emailService = emailService;
            //_db = db;
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "amir",
                Password = "pass",
                VirtualHost = "/"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: _queueName,
                                  durable: true,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);
        }

        public async Task Start()
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                // Deserialize the message if needed
                var cart = JsonConvert.DeserializeObject<CartDto>(message);

                // Process the message (implement your logic here)
                HandleMessage(cart);

                // Acknowledge the message
                _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            };

            _channel.BasicConsume(queue: _queueName,
                                  autoAck: false,
                                  consumer: consumer);
        }

        public async Task Stop()
        {
            _channel.Close();
            _connection.Close();
        }

        private async void HandleMessage(CartDto cart)
        {
            
             await _emailService.EmailCartAndLog(cart);
            
        }
    }

    // Define your message type here
    public class MyMessageType
    {
        public string Property1 { get; set; }
        public int Property2 { get; set; }
    }

}
