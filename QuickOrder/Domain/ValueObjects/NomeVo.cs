using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.ValueObjects
{
    public class NomeVo : Notifiable, IValidatable
    {
        public NomeVo(string nome)
        {
            Nome = nome;
            Validate();
        }
        public string Nome { get; private set; }

        public override string ToString()
        {
            return $"{Nome}";
        }
        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(Nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
            .HasMaxLen(Nome, 150, "Nome", "Nome deve conter no máximo 50 caracteres"));
        }

    }
}
