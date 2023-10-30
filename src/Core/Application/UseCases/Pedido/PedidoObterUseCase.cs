using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Pedido.Interfaces;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Enums;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Application.UseCases.Pedido
{
    public  class PedidoObterUseCase : IPedidoObterUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoStatusRepository _pedidoStatusRepository;

        public PedidoObterUseCase(IPedidoRepository pedidoRepository, IPedidoStatusRepository pedidoStatusRepository)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoStatusRepository = pedidoStatusRepository;
        }

        public async Task<ServiceResult<List<PedidoStatus>>> ConsultarFilaPedidos()
        {
            var result = new ServiceResult<List<PedidoStatus>>();
            try
            {
                var fila = await _pedidoStatusRepository.GetAll();
                fila = fila.Where(x => !x.StatusPedido.Equals(EStatusPedido.Pago) 
                       || !x.StatusPedido.Equals(EStatusPedido.PendentePagamento)
                       || !x.StatusPedido.Equals(EStatusPedido.Finalizado));

                result.Data = fila.ToList();
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult<PedidoDto>> ConsultarPedido(int id)
        {
            var result = new ServiceResult<PedidoDto>();
            try
            {
                var pedido =  await _pedidoRepository.GetFirst(id);

                var fila = await _pedidoStatusRepository.Get(pedido?.CarrinhoId);

                var pedidoDto = new PedidoDto
                {
                    NumeroCliente = (int)pedido?.ClienteId,
                    NumeroPedido = pedido.NumeroPedido,
                    DataHoraInicio = pedido.DataHoraInicio,
                    DataHoraFinalizado = pedido.DataHoraFinalizado,
                    Observacao = pedido.Observacao,
                    PedidoPago = pedido.PedidoPago,
                    ValorPedido = pedido.ValorPedido,
                    ProdutosItemsPedido = pedido?.ProdutosItemsPedido ?? null,
                    StatusPedido = fila.StatusPedido
                };

                result.Data = pedidoDto;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }
    }
}
