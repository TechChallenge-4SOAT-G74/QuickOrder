using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Pedido.Interfaces;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Enums;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Application.UseCases.Pedido
{
    public class PedidoObterUseCase : IPedidoObterUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoStatusRepository _pedidoStatusRepository;
        private readonly IPagamentoStatusRepository _pagamentoStatusRepository;

        public PedidoObterUseCase(IPedidoRepository pedidoRepository, IPedidoStatusRepository pedidoStatusRepository, IPagamentoStatusRepository pagamentoStatusRepository)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoStatusRepository = pedidoStatusRepository;
            _pagamentoStatusRepository = pagamentoStatusRepository;
        }

        public async Task<ServiceResult<List<PedidoStatus>>> ConsultarFilaPedidos()
        {
            var result = new ServiceResult<List<PedidoStatus>>();
            try
            {
                var fila = await _pedidoStatusRepository.GetAll();
                fila = fila.Where(x => !x.StatusPedido.Equals(EStatusPedido.Pago)
                       || !x.StatusPedido.Equals(EStatusPedido.PendentePagamento)
                       || !x.StatusPedido.Equals(EStatusPedido.Finalizado))
                        .OrderByDescending(x => (int)(EStatusPedido)Enum.Parse(typeof(EStatusPedido), x.StatusPedido)).OrderByDescending(x => x.DataAtualizacao);
                
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
                var pedido = await _pedidoRepository.GetFirst(id);

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

        public async Task<ServiceResult<PagamentoDto>> ConsultarStatusPagamentoPedido(int id)
        {
            var result = new ServiceResult<PagamentoDto>();
            try
            {
                var pagamento = await _pagamentoStatusRepository.GetValue("NumeroPedido", id.ToString());


                var pagamentoDto = new PagamentoDto
                {
                    NumeroPedido = pagamento.NumeroPedido,
                    DataHora = pagamento.DataAtualizacao,
                    StatusPagamento = pagamento.StatusPagamento,
                };

                result.Data = pagamentoDto;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }
    }
}
