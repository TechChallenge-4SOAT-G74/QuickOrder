namespace QuickOrder.Core.Application.Dtos
{
    public class PagamentoDto
    {
        public int ClienteId { get; set; }
        public int PedidoId { get; set; }
        public double Valor { get; set; }
    }
}
