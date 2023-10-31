using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Pedido.Interfaces;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Repositories;
using PedidoEntity = QuickOrder.Core.Domain.Entities.Pedido;

namespace QuickOrder.Core.Application.UseCases.Pedido
{
    public class PedidoCriarUseCase : IPedidoCriarUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ICarrinhoRepository _carrinhoRepository;

        public PedidoCriarUseCase(IPedidoRepository pedidoRepository, IClienteRepository clienteRepository, ICarrinhoRepository carrinhoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _clienteRepository = clienteRepository;
            _carrinhoRepository = carrinhoRepository;
        }

        public async Task<ServiceResult> CriarPedido(int numeroCliente)
        {
            //TODO: Usaundo número do cliente como parametro até cria a autenticação.

            var result = new ServiceResult();
            try
            {
                var cliente = await _clienteRepository.GetFirst(numeroCliente);

                //TODO: Gerando número de pedido randônimo até a fila de pedido ser criada 
                var numeroPedido = new Random().Next(1, 3); 
                var carrinho = new Carrinho(numeroPedido, numeroCliente, 0, DateTime.Now, null);

                var pedido = new PedidoEntity(numeroPedido, DateTime.Now, null, cliente?.Id, carrinho.Id.ToString(), null, 0, false);
                

                await _carrinhoRepository.Create(carrinho);
                await _pedidoRepository.Insert(pedido);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }
    }
}
