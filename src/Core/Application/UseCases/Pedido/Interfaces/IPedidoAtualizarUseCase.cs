using QuickOrder.Core.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Pedido.Interfaces
{
    public interface IPedidoAtualizarUseCase : IBaseUseCase
    {
        Task<ServiceResult> AdicionarItemAoPedido(int id, PedidoDto pedidoDto);
        Task<ServiceResult> RemoverItemDoPedido(int id, PedidoDto pedidoDto);
        Task<ServiceResult> ConfirmarPedido(int id);
        Task<ServiceResult> ConfirmarPagamentoPedido(int id);
        Task<ServiceResult> AlterarStatusPedido(int id, string status);
    }
}
