using Flunt.Notifications;
using Flunt.Validations;

namespace QuickOrder.Core.Domain.ValueObjects
{
    public class NomeUsuarioVo : Notifiable, IValidatable
    {
        public NomeUsuarioVo(string primeiroNome, string ultimoNome)
        {
            PrimerioNome = primeiroNome;
            UltimoNome = ultimoNome;
            Validate();
        }
        public string PrimerioNome { get; private set; }
        public string UltimoNome { get; private set; }

        public override string ToString()
        {
            return $"{PrimerioNome} {UltimoNome}";
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(PrimerioNome, 3, "PrimerioNome", "Primerio nome deve conter pelo menos 3 caracteres")
            .HasMaxLen(PrimerioNome, 30, "PrimerioNome", "Primerio nome deve conter no máximo 30 caracteres")
            .HasMinLen(UltimoNome, 3, "UltimoNome", "Ultimo deve conter pelo menos 3 caracteres")
            .HasMaxLen(UltimoNome, 150, "UltimoNome", "Ultimo deve conter no máximo 150 caracteres"));
        }
    }
}
