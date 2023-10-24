using QuickOrder.Core.Domain.Enums;

namespace QuickOrder.Core.Domain.Entities
{
    public class PedidoStatus : EntityBase
    {
        private readonly Pedido _pedido;
        public Pedido? Pedido => _pedido;
        public EStatusPedido StatusPedidoEnum { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
