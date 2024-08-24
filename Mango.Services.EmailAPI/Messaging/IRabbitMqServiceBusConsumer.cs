namespace Mango.Services.EmailAPI.Messaging
{
    public interface IRabbitMqServiceBusConsumer
    {
        Task Start();
        Task Stop();
    }
}
