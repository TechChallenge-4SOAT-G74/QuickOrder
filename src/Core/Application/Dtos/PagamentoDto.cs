namespace QuickOrder.Core.Application.Dtos
{
    public class PagamentoDto
    {
        public string NumeroPedido { get; set; }
        public string? NumeroCliente { get; set; }
        public string CarrinhoId { get; set; }
        public double Valor { get; set; }
    }
}
