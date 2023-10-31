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

        public async Task<bool> ConfirmarPagamento(PagamentoDto pagamentoDto)
        {
            var pedido = await _statusRepository.GetValue("NumeroPedido", pagamentoDto.NumeroPedido);

            if (pedido != null)
            {
                var pagamentoStatus = new PagamentoStatus
                {
                    Id = pedido.Id,
                    NumeroPedido = pedido.NumeroPedido,
                    NumeroCliente = pedido.NumeroCliente,
                    StatusPagamento = EStatusPagamentoExtensions.ToDescriptionString(EStatusPagamento.Aprovado),
                    DataAtualizacao = DateTime.Now
                };
                _statusRepository.Update(pagamentoStatus);
            }

            return true;
        }

        public async Task EnviarPedidoPagamento(PagamentoDto pagamentoDto)
        {
            var pagamentoStatus = new PagamentoStatus
            {
                NumeroCliente = pagamentoDto.NumeroCliente,
                NumeroPedido = pagamentoDto.NumeroPedido,
                DataAtualizacao = DateTime.Now,
                Valor = pagamentoDto.Valor,
                StatusPagamento = EStatusPagamentoExtensions.ToDescriptionString(EStatusPagamento.Aprovado),
            };

            await _statusRepository.Create(pagamentoStatus);
        }
    }
}
