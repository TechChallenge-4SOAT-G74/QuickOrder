namespace QuickOrder.Core.Domain.Entities
{
    public class ProdutoItemPedido : EntityBase
    {
        private readonly IList<ProdutoItem> _produtoItem;

        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public ICollection<ProdutoItem>? ProdutoItems => _produtoItem.ToArray();
        public int QuantidadeProduto { get; set; }
    }
}
