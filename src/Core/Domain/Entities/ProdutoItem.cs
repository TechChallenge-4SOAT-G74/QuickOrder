namespace QuickOrder.Core.Domain.Entities
{
    public class ProdutoItem : EntityBase, IAggregateRoot
    {
        public virtual int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public virtual int Quantidade { get; set; }
        public virtual int QuantidadeMin { get; set; }
        public virtual int QuantidadeMax { get; set; }
        public virtual bool PermitidoAlterar { get; set; }
        public virtual List<ProdutoItemPedido>? ProdutosItemsPedido { get; set; }
    }
}
