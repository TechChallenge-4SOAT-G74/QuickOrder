using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Pagamento.Interfaces;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Enums;

namespace QuickOrder.Core.Application.UseCases.Pagamento
{
    public class PagamentoUseCase : IPagamentoUseCase
    {
        private readonly IPagamentoStatusRepository _statusRepository;

        public PagamentoUseCase(IPagamentoStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public async Task<bool> ConfirmarPagamento(SacolaDto pagamentoDto)
        {
            var pedido = await _statusRepository.GetValue("NumeroPedido", pagamentoDto.NumeroPedido);

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

        public async Task EnviarPedidoPagamento(SacolaDto sacolaDto)
        {
            var pagamentoStatus = new PagamentoStatus
            {
                clienteId = (int?)Convert.ToUInt32(sacolaDto.NumeroCliente),
                NumeroPedido = (int)Convert.ToUInt32(sacolaDto.NumeroPedido),
                DataAtualizacao = DateTime.Now,
                Valor = sacolaDto.Valor,
                StatusPagamento = EStatusPagamentoExtensions.ToDescriptionString(EStatusPagamento.Aprovado),
            };
            await _statusRepository.Create(pagamentoStatus);
        }
    }
}
