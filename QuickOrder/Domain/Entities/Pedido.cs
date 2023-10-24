namespace Domain.Entities
{
    public class Pedido : EntityBase
    {
        private readonly IList<ProdutoItemPedido> _produtoItemPedidos;
        private readonly Cliente? _cliente;

        public int NumeroPedido { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFinalizado { get; set; }
        public Cliente? Cliente => _cliente;
        public IReadOnlyCollection<ProdutoItemPedido> ProdutoItemPedidos => _produtoItemPedidos.ToArray();
        public string? Observacao { get; set; }
        public double ValorPedido { get; set; }
        public bool PedidoPago { get; set; }

        public void CalculaPrecoPedido()
        {
            //TODO: Calculo o ValorPedido
        }
    }
}
