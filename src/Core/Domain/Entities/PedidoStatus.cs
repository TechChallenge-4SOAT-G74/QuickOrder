using QuickOrder.Core.Domain.Enums;

namespace QuickOrder.Core.Domain.Entities
{
    public class PedidoStatus : EntityMongoBase
    {
        public int NumeroPedido { get; set; }
        public string StatusPedido { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
