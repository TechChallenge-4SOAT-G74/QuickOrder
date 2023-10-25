using QuickOrder.Core.Domain.ValueObjects;

namespace QuickOrder.Core.Domain.Entities
{
    public class Funcionalidade : EntityBase, IAggregateRoot
    {
        protected Funcionalidade() { }
        public Funcionalidade(string nome, bool status)
        {
            Nome = new NomeVo(nome);
            Status = status;
        }

        public virtual NomeVo Nome { get; set; }
        public virtual bool Status { get; set; }
        public virtual int RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}
