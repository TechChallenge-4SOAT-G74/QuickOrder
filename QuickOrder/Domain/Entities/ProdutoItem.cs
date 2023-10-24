namespace Domain.Entities
{
    public class ProdutoItem
    {
        protected ProdutoItem() { }

        public ProdutoItem(Guid id, Guid produtoId, Produto produto, Guid itemId, Item item, int quantidade, int quantidadeMin, int quantidadeMax, bool permitidoAlterar)
        {
            Id = Guid.NewGuid();
            ProdutoId = produtoId;
            Produto = produto;
            ItemId = itemId;
            Item = item;
            Quantidade = quantidade;
            QuantidadeMin = quantidadeMin;
            QuantidadeMax = quantidadeMax;
            PermitidoAlterar = permitidoAlterar;
        }

        public Guid Id { get; set; }

        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeMin { get; set; }
        public int QuantidadeMax { get; set; }
        public bool PermitidoAlterar { get; set; }
    }
}
