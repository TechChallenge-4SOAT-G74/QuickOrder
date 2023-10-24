using Application.UseCases.Pedido;
using Microsoft.Extensions.DependencyInjection;
using QuickOrder.Adapters.Driven.PostgresDB.Repositories;
using QuickOrder.Core.Application.UseCases.Pedido.Interfaces;
using QuickOrder.Core.Application.UseCases.Produto;
using QuickOrder.Core.Application.UseCases.Produto.Interfaces;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Infrastructure
{
    internal class ApplicationBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IPedidoUseCase, PedidoUseCase>();
            services.AddScoped<IProdutoCriarUseCase, ProdutoCriarUseCase>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}
