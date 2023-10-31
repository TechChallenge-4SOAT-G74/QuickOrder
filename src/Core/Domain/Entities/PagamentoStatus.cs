namespace QuickOrder.Core.Domain.Entities
{
    public class PagamentoStatus : EntityMongoBase
    {
        public string NumeroPedido { get; set; }
        public string? NumeroCliente { get; set; }
        public  double Valor { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public string StatusPagamento { get; set; }
    }
}
