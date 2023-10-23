using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Role : EntityBase
    {
       
        public Role(NomeVo nome, bool status, List<Funcionalidade> funcionalidades):base(nome)
        {
            Id = Guid.NewGuid();
            Status = status;
            Funcionalidades = funcionalidades;
        }

        public bool Status { get; set; }
        public List<Funcionalidade> Funcionalidades { get; set; }
    }
}
