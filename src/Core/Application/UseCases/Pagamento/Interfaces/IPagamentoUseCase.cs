using QuickOrder.Core.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Pagamento.Interfaces
{
    public interface IPagamentoUseCase : IBaseUseCase
    {
        Task EnviarPedidoPagamento(SacolaDto pagamentoDto);
        Task<bool> ConfirmarPagamento(SacolaDto pagamentoDto);
    }
}
