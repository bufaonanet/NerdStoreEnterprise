using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.Clientes.API.Services;
using NSE.Core.Utils;
using NSE.MessageBus;

namespace NSE.Clientes.API.Configurations
{
    public static class MessageBusConfig
    {
        public static IServiceCollection AddMessageBusConfigurations(this IServiceCollection services, 
            IConfiguration configurations)
        {
            services
                .AddMessageBus(configurations.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<RegistroClienteIntegrationHandler>(); ;

            return services;
        }
    }
}
