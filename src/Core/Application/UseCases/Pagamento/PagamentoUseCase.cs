using QuickOrder.Adapters.Driven.MercadoPago.Interfaces;
using QuickOrder.Adapters.Driven.MercadoPago.Requests;
using QuickOrder.Adapters.Driven.MercadoPago.Responses;
using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Pagamento.Interfaces;
using QuickOrder.Core.Application.UseCases.Pedido.Interfaces;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Enums;
using ItemRequest = QuickOrder.Adapters.Driven.MercadoPago.Requests.Item;

namespace QuickOrder.Core.Application.UseCases.Pagamento
{
    public class PagamentoUseCase : IPagamentoUseCase
    {
        private readonly IPagamentoStatusRepository _statusRepository;
        private readonly IPedidoObterUseCase _pedidoObterUseCase;
        private readonly IMercadoPagoApi _mercadoPagoApi;

        public PagamentoUseCase(IPagamentoStatusRepository statusRepository, IPedidoObterUseCase pedidoObterUseCase, IMercadoPagoApi mercadoPagoApi)
        {
            _statusRepository = statusRepository;
            _pedidoObterUseCase = pedidoObterUseCase;
            _mercadoPagoApi = mercadoPagoApi;
        }

        public async Task<bool> ConfirmarPagamento(SacolaDto sacolaDto)
        {
            var pedido = await _statusRepository.GetValue("NumeroPedido", sacolaDto.NumeroPedido);

            if (pedido != null)
            {
                var pagamentoStatus = new PagamentoStatus
                {
                    Id = pedido.Id,
                    NumeroPedido = pedido.NumeroPedido,
                    clienteId = pedido.clienteId,
                    StatusPagamento = EStatusPagamentoExtensions.ToDescriptionString(EStatusPagamento.Aprovado),
                    DataAtualizacao = DateTime.Now
                };
                _statusRepository.Update(pagamentoStatus);
            }

            return true;
        }

        private async Task EnviarPedidoPagamento(SacolaDto sacolaDto)
        {
            var pagamentoStatus = new PagamentoStatus
            {
                clienteId = (int?)Convert.ToUInt32(sacolaDto.NumeroCliente),
                NumeroPedido = (int)Convert.ToUInt32(sacolaDto.NumeroPedido),
                DataAtualizacao = DateTime.Now,
                Valor = sacolaDto.Valor,
                StatusPagamento = EStatusPagamentoExtensions.ToDescriptionString(EStatusPagamento.aguardando),
            };
            await _statusRepository.Create(pagamentoStatus);
        }

        public async Task<ServiceResult<PaymentQrCodeResponse>> GerarQrCodePagamento(int idPedido)
        {
            var result = new ServiceResult<PaymentQrCodeResponse>();

            try
            {
                var pedido = await _pedidoObterUseCase.ConsultarPedido(idPedido);

                var request = new PaymentQrCodeRequest
                {
                    description = $"Pedido {pedido.Data.NumeroCliente}",
                    external_reference = pedido.Data.NumeroPedido.ToString(),
                    items = new List<ItemRequest>()
                    {
                        new ItemRequest
                        {
                            title = $"Pedido {pedido.Data.NumeroCliente}",
                            unit_price = Convert.ToInt32(pedido.Data.ValorPedido),
                            quantity = 1,
                            unit_measure = "unit",
                            total_amount = Convert.ToInt32(pedido.Data.ValorPedido),
                        },
                    },
                    title = "Product order",
                    total_amount = Convert.ToInt32(pedido.Data.ValorPedido)
                };

                var response = _mercadoPagoApi.GeraQrCodePagamento(request);

                var sacolaDto = new SacolaDto
                {
                    NumeroCliente = pedido.Data.NumeroCliente.ToString(),
                    NumeroPedido = pedido.Data.NumeroPedido.ToString(),
                    Valor = Convert.ToInt32(pedido.Data.ValorPedido)
                };

                await EnviarPedidoPagamento(sacolaDto);

                result.Data = response.Result;
            }
            catch (Exception ex)
            {
                result.AddError(400, ex.Message);
            }

            return result;
        }
    }
}
