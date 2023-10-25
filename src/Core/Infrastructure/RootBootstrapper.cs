using Application.UseCases.Pedido;
using Microsoft.Extensions.DependencyInjection;
using QuickOrder.Adapters.Driven.PostgresDB.Repositories;
using QuickOrder.Core.Application.UseCases.Pedido.Interfaces;
using QuickOrder.Core.Application.UseCases.Produto.Interfaces;
using QuickOrder.Core.Application.UseCases.Produto;
using QuickOrder.Core.Domain.Repositories;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Adapters.Driven.MongoDB.Repositories;

namespace QuickOrder.Core.Infrastructure
{
    public static class RootBootstrapper
    {
        public static void BootstrapperRegisterServices(this IServiceCollection services)
        {
            var assemblyTypes = typeof(InfrastructureBootstrapper).Assembly.GetNoAbstractTypes();

            services.AddImplementations(ServiceLifetime.Scoped, typeof(IBaseRepository), assemblyTypes);

            //Repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IFuncionalidadeRepository, FuncionalidadeRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            //services.AddScoped<IPedidoStatusRepository, PedidoStatusRepository>();
            services.AddScoped<IProdutoItemPedidoRepository, ProdutoItemPedidoRepository>();
            services.AddScoped<IProdutoItemRepository, ProdutoItemRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IPedidoUseCase, PedidoUseCase>();
            services.AddScoped<IProdutoCriarUseCase, ProdutoCriarUseCase>();
           
        }
    }
}
