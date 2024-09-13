using _NEXUS.Repository;
using _NEXUS.Repository.Interfaces;
using _NEXUS.Service;
using _NEXUS.Service.InterfacesService;

namespace Nexus.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPedidosRepository, PedidosRepository>();
            services.AddScoped<IProdutosRepository, ProdutosRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPedidosService, PedidosService>();
            services.AddScoped<IProdutosService, ProdutosService>();

            return services;
        }
    }
}
