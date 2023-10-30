using QuickOrder.Core.Application.UseCases.Pagamento.Interfaces;

namespace QuickOrder.Core.Application.UseCases.Pedido
{
    public abstract class PedidoUseCase
    {
        private readonly IPagamentoUseCase _pagamentoUseCase;

        public PedidoUseCase(IPagamentoUseCase pagamentoUseCase)
        {
            _pagamentoUseCase = pagamentoUseCase;
        }
    }
}
