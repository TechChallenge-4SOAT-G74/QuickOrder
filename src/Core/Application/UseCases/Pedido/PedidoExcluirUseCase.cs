using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Pagamento.Interfaces;
using QuickOrder.Core.Application.UseCases.Pedido.Interfaces;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Application.UseCases.Pedido
{
    public class PedidoExcluirUseCase : PedidoUseCase, IPedidoExcluirUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ICarrinhoRepository _carrinhoRepository;
        private readonly IPedidoStatusRepository _pedidoStatusRepository;

        public PedidoExcluirUseCase(IPagamentoUseCase pagamentoUseCase, IPedidoRepository pedidoRepository, ICarrinhoRepository carrinhoRepository, IPedidoStatusRepository pedidoStatusRepository) : base(pagamentoUseCase)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoRepository = carrinhoRepository;
            _pedidoStatusRepository = pedidoStatusRepository;
        }

        public async Task<ServiceResult> CancelarPedido(string carrinhoId)
        {
            var result = new ServiceResult();
            try
            {
                var pedido = await _pedidoRepository.GetFirst(x => x.CarrinhoId.Equals(carrinhoId));

                if (pedido == null)
                {
                    result.AddError("Pedido não encontrado.");
                    return result;
                }
                await _pedidoRepository.Delete(pedido.Id);

                if (pedido.CarrinhoId != null)
                {
                    var carrinho = await _carrinhoRepository.Get(pedido.CarrinhoId);
                    if (carrinho != null)
                        _carrinhoRepository.Delete(carrinho.Id.ToString());

                    var status = await _pedidoStatusRepository.GetValue("CarrinhoId", pedido.CarrinhoId);
                    if (status != null)
                        _pedidoStatusRepository.Delete(status.Id.ToString());
                }
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }
    }
}
