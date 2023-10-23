using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.ValueObjects
{
    public class TelefoneVo : Notifiable, IValidatable
    {
        public TelefoneVo(string ddd, string numero)
        {
            DDD = ddd;
            Numero = numero;
            Validate();
        }
        public string DDD { get; private set; }
        public string Numero { get; private set; }

        public override string ToString()
        {
            return $"({DDD}){Numero}";
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .HasLen(DDD, 3, "DDD", "DDD deve conter 2 números")
            .HasMaxLen(Numero, 8, "Numero", "Numero deve conter no mímino 8 caracteres")
            .HasMaxLen(Numero, 9, "Numero", "Numero deve conter no máximo 9 caracteres"));
        }
    }
}
