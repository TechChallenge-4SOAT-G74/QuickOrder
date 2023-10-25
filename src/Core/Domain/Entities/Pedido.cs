namespace QuickOrder.Core.Domain.Entities
{
    public class Pedido : EntityBase, IAggregateRoot
    {
        protected Pedido() { } 
        public Pedido(int numeroPedido, 
                      DateTime dataHoraInicio, 
                      DateTime? dataHoraFinalizado, 
                      Cliente cliente, 
                      List<ProdutoItemPedido> produtosItemsPedido, 
                      double valorPedido,
                      bool pedidoPago,
                      string? observacao = null)
        {
            NumeroPedido = numeroPedido;
            DataHoraInicio = dataHoraInicio;
            DataHoraFinalizado = dataHoraFinalizado;
            Cliente = cliente;
            ProdutosItemsPedido = produtosItemsPedido;
            ValorPedido = valorPedido;
            PedidoPago = pedidoPago;
            Observacao = observacao;

            //CalculaPrecoPedido();
        }

        public virtual int NumeroPedido { get; set; }
        public virtual DateTime DataHoraInicio { get; set; }
        public virtual DateTime? DataHoraFinalizado { get; set; }
        public virtual int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual List<ProdutoItemPedido> ProdutosItemsPedido { get; set; }
        public virtual double ValorPedido { get; set; }
        public virtual string? Observacao { get; set; }
        public virtual bool PedidoPago { get; set; }

        public void CalculaPrecoPedido()
        {
            //TODO: Calculo o ValorPedido
        }
    }
}
