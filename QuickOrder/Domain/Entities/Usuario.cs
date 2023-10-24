using Domain.ValueObjects;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Entities
{
    public abstract class Usuario : EntityBase
    {

        public NomeUsuarioVo Nome { get; set; }
        public CpfVo Cpf { get; set; }
        public EmailVo Email { get; set; }
        public bool Ativo { get; set; }
        public IList<Role> Roles { get; set; }


        //public override string ToString() => Nome.ToString();

        //public void Validate()
        //{
        //    AddNotifications(
        //      new Contract()
        //      .IsTrue(Nome.Valid, "Nome", "Nome inválido")
        //      .IsTrue(Cpf.Valid, "Cpf", "Cpf inválido")
        //      .IsTrue(Email.Valid, "Email", "Email inválido")
        //          );
        //}
    }
}
