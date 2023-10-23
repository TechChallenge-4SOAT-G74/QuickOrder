namespace Domain.Entities
{
    public class ProdutoItemPedido : IEntity
    {
        private readonly IList<ProdutoItem> _produtoItem;

        public ProdutoItemPedido(int pedidoId, int produtoId, int quantidadeProduto)
        {
            Id = Guid.NewGuid();
            PedidoId = pedidoId;
            ProdutoId = produtoId;
            _produtoItem = new List<ProdutoItem>();
            QuantidadeProduto = quantidadeProduto;
        }

        public Guid Id { get; private set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public ICollection<ProdutoItem>? ProdutoItems => _produtoItem.ToArray();
        public int QuantidadeProduto { get; set; }
    }
}
