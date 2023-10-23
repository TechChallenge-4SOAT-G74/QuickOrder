using Domain.Enums;

namespace Domain.Entities
{
    public class PedidoStatus : IEntity
    {
        public Guid Id { get; private set; }
        private readonly Pedido _pedido;

        public PedidoStatus(Pedido pedido, EStatusPedido statusPedidoEnum, DateTime dataAtualizacao)
        {
            Id = Guid.NewGuid();
            _pedido = pedido;
            StatusPedidoEnum = statusPedidoEnum;
            DataAtualizacao = dataAtualizacao;
        }

        public Pedido? Pedido => _pedido;
        public EStatusPedido StatusPedidoEnum { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
