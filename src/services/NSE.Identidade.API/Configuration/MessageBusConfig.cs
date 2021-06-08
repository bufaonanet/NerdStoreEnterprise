using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.Core.Utils;
using NSE.MessageBus;

namespace NSE.Identidade.API.Configuration
{
    public static class MessageBusConfig
    {
        public static IServiceCollection AddMessageBusConfigurations(this IServiceCollection services,
            IConfiguration configurations)
        {
            services.AddMessageBus(configurations.GetMessageQueueConnection("MessageBus"));

            return services;
        }
    }
}
