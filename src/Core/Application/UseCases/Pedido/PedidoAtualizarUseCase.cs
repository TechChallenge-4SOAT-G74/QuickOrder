using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Pagamento.Interfaces;
using QuickOrder.Core.Application.UseCases.Pedido.Interfaces;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Application.UseCases.Pedido
{
    public class PedidoAtualizarUseCase : PedidoUseCase, IPedidoAtualizarUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ICarrinhoRepository _carrinhoRepository;
        private readonly IPedidoStatusRepository _pedidoStatusRepository;

        public PedidoAtualizarUseCase(
            IPagamentoUseCase pagamentoUseCase, 
            IPedidoRepository pedidoRepository, 
            ICarrinhoRepository carrinhoRepository, 
            IPedidoStatusRepository pedidoStatusRepository) : base(pagamentoUseCase)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoRepository = carrinhoRepository;
            _pedidoStatusRepository = pedidoStatusRepository;
        }

        public Task<ServiceResult> AdicionarItemAoPedido(int id, PedidoDto pedidoDto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> AlterarStatusPedido(int id, string status)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> ConfirmarPagamentoPedido(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> ConfirmarPedido(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> RemoverItemDoPedido(int id, PedidoDto pedidoDto)
        {
            throw new NotImplementedException();
        }
    }
}
