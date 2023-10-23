using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Funcionalidade : EntityBase
    {
        public Funcionalidade(NomeVo nome) : base(nome)
        {
        }

        public bool Status { get; set; }
    }
}
