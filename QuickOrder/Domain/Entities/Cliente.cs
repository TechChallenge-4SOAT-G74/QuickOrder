using Domain.ValueObjects;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Entities
{
    public class Cliente : EntityBase 
    {
        public int Id { get; private set; }
        private readonly Usuario _usuario;
        private readonly IList<Pedido> _pedidos;

        public TelefoneVo Telefone { get; set; }
        public DataVo DataNascimento { get; set; }
        public Usuario Usuario => _usuario;

        public IReadOnlyCollection<Pedido> Pedidos => _pedidos.ToArray();


        public void AddPedidos(Pedido pedido)
        {
            _pedidos.Add(pedido);
        }


        //public void Validate()
        //{
        //    AddNotifications(
        //      new Contract()
        //      .IsTrue(Telefone.Valid, "Telefone", "Telefone inválido")
        //      .IsTrue(DataNascimento.Valid, "DataNascimento", "Cpf inválido"));
        //}
    }
}
