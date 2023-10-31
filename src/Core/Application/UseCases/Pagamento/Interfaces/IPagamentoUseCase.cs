using QuickOrder.Core.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Pagamento.Interfaces
{
    public interface IPagamentoUseCase : IBaseUseCase
    {
        Task EnviarPedidoPagamento(PagamentoDto pagamentoDto);
        Task<bool> ConfirmarPagamento(PagamentoDto pagamentoDto);
    }
}
