using Microsoft.Extensions.DependencyInjection;
using NSE.Clientes.API.Data;

namespace NSE.Clientes.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
           
            services.AddScoped<ClientesContext>();
        }
    }
}
