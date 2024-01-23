using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Pagamento.Interfaces;
using QuickOrder.Core.Application.UseCases.Pedido.Interfaces;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Enums;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Application.UseCases.Pedido
{
    public class PedidoAtualizarUseCase : IPedidoAtualizarUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ICarrinhoRepository _carrinhoRepository;
        private readonly IPedidoStatusRepository _pedidoStatusRepository;
        public readonly IPagamentoUseCase _pagamentoUseCase;

        public PedidoAtualizarUseCase(IPedidoRepository pedidoRepository, ICarrinhoRepository carrinhoRepository, IPedidoStatusRepository pedidoStatusRepository, IPagamentoUseCase pagamentoUseCase)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoRepository = carrinhoRepository;
            _pedidoStatusRepository = pedidoStatusRepository;
            _pagamentoUseCase = pagamentoUseCase;
        }

        public async Task<ServiceResult> AlterarItemAoPedido(string id, PedidoDto pedidoDto)
        {
            var result = new ServiceResult();
            try
            {
                var produtoCarrinho = new List<ProdutoCarrinho>();
                if (pedidoDto.ProdutosItemsPedido != null)
                {
                    foreach (var item in pedidoDto.ProdutosItemsPedido)
                    {
                        produtoCarrinho.Add(new ProdutoCarrinho
                        (
                            ECategoriaExtensions.ToDescriptionString((ECategoria)item.ProdutoItem.Produto.CategoriaId),
                            item.ProdutoItem.Produto.Nome.Nome,
                            item.ProdutoItem.ProdutoId,
                            item.ProdutoItem.Produto.Preco,
                            null
                        ));
                    }

                }

                var carrinho = await _carrinhoRepository.Get(id);

                carrinho.DataAtualizacao = DateTime.Now;
                carrinho.Valor = pedidoDto.ValorPedido;
                carrinho.ProdutosCarrinho = produtoCarrinho;

                _carrinhoRepository.Update(carrinho);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult> AlterarStatusPedido(string id, PedidoStatusDto pedidoStatusDto)
        {
            var result = new ServiceResult();
            try
            {
                var pedido = await _pedidoStatusRepository.Get(id);
                pedido.StatusPedido = pedidoStatusDto.StatusPedido;
                pedido.DataAtualizacao = DateTime.Now;
                _pedidoStatusRepository.Update(pedido);

            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult> ConfirmarPagamentoPedido(int id)
        {
            var result = new ServiceResult();
            try
            {
                var pedido = await _pedidoRepository.GetFirst(id);
                pedido.PedidoPago = true;

                await _pedidoRepository.Update(pedido);

                var pagamento = new SacolaDto { NumeroCliente = pedido.ClienteId.ToString(), NumeroPedido = pedido.NumeroPedido.ToString(), CarrinhoId = pedido.CarrinhoId, Valor = pedido.ValorPedido };
                await _pagamentoUseCase.ConfirmarPagamento(pagamento);

            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult> ConfirmarPedido(int id)
        {
            var result = new ServiceResult();
            try
            {
                var pedido = await _pedidoRepository.GetFirst(id);

                var pedidoStatus = new PedidoStatus
                {
                    StatusPedido = EStatusPedidoExtensions.ToDescriptionString(EStatusPedido.PendentePagamento),
                    DataAtualizacao = DateTime.Now,
                    NumeroPedido = pedido.NumeroPedido
                };

                await _pedidoStatusRepository.Create(pedidoStatus);

                var pagamento = new SacolaDto { NumeroCliente = pedido.ClienteId.ToString(), NumeroPedido = pedido.NumeroPedido.ToString(), CarrinhoId = pedido.CarrinhoId, Valor = pedido.ValorPedido };
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }
    }
}
