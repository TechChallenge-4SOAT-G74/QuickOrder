namespace Domain.Entities
{
    public class Pedido : IEntity
    {
        public Guid Id { get; private set; }
        private readonly IList<ProdutoItemPedido> _produtoItemPedidos;
        private readonly Cliente? _cliente;

        public Pedido(int numeroPedido, DateTime dataHoraInicio, DateTime dataHoraFinalizado, Cliente? cliente, string? observacao, double valorPedido, bool pedidoPago)
        {
            Id = Guid.NewGuid();
            NumeroPedido = numeroPedido;
            DataHoraInicio = dataHoraInicio;
            DataHoraFinalizado = dataHoraFinalizado;
            _cliente = cliente;
            _produtoItemPedidos = new List<ProdutoItemPedido>();
            Observacao = observacao;
            ValorPedido = valorPedido;
            PedidoPago = pedidoPago;

            CalculaPrecoPedido();
        }

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
