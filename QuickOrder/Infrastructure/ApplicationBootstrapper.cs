using Application.UseCases.Pedido;
using Application.UseCases.Pedido.Interfaces;
using Application.UseCases.Produto;
using Application.UseCases.Produto.Interfaces;
using Domain.Repositories;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
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
