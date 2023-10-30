using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Pagamento.Interfaces;
using QuickOrder.Core.Application.UseCases.Pedido.Interfaces;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Application.UseCases.Pedido
{
    public  class PedidoObterUseCase : PedidoUseCase, IPedidoObterUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoObterUseCase(IPagamentoUseCase pagamentoUseCase, IPedidoRepository pedidoRepository) : base(pagamentoUseCase)
        {
            _pedidoRepository = pedidoRepository;
        }

        public Task<ServiceResult<PedidoStatus>> ConsultarFilaPedidos()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<PedidoDto>> ConsultarPedido(int id)
        {
            throw new NotImplementedException();
        }
    }
}
