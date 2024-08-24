using Mango.Services.EmailAPI.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Metadata;

namespace Mango.Services.EmailAPI.Extention
{
    public static class ApplicationBuilderExtentions
    {
        private static IRabbitMqServiceBusConsumer ServiceBusConsumer { get; set; }
        public static IApplicationBuilder UseRabbitMqBusConsumer(this IApplicationBuilder app)
        {
            ServiceBusConsumer = app.ApplicationServices.GetService<IRabbitMqServiceBusConsumer>();
            var hostApplicationLife = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            hostApplicationLife.ApplicationStarted.Register(OnStart);
            hostApplicationLife.ApplicationStopping.Register(OnStop);

            return app;
        }

        private static void OnStop()
        {
            ServiceBusConsumer.Stop();
        }

        private static void OnStart()
        {
            ServiceBusConsumer.Start();
        }
    }
}
