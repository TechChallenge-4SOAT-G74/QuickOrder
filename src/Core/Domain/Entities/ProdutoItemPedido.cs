namespace QuickOrder.Core.Domain.Entities
{
    public class ProdutoItemPedido : EntityBase, IAggregateRoot
    {
        public virtual int ProdutoItemId { get; set; }
        public virtual ProdutoItem ProdutoItem { get; set; }
        public virtual int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual int QuantidadeProduto { get; set; }
        public virtual List<Pedido> Pedidos { get; set; }
    }
}