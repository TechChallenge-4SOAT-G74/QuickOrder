using QuickOrder.Adapters.Driven.MercadoPago.Responses;
using QuickOrder.Core.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Pagamento.Interfaces
{
    public interface IPagamentoUseCase : IBaseUseCase
    {
        Task<bool> ConfirmarPagamento(SacolaDto sacolaDto);
        Task<ServiceResult<PaymentQrCodeResponse>> GerarQrCodePagamento(int idPedido);
    }
}
