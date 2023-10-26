using QuickOrder.Core.Domain.Enums;

namespace QuickOrder.Core.Domain.Entities
{
    public class PedidoStatus : EntityMongoBase
    {
        public virtual int NumeroPedido { get; set; }
        public virtual EStatusPedido StatusPedidoEnum { get; set; }
        public virtual DateTime DataAtualizacao { get; set; }
    }
}
