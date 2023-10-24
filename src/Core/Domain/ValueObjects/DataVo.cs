using Flunt.Notifications;
using Flunt.Validations;

namespace QuickOrder.Core.Domain.ValueObjects
{
    public class DataVo : Notifiable, IValidatable
    {
        public DataVo(int dia, int mes, int ano)
        {
            Dia = dia;
            Mes = mes;
            Ano = ano;
            Validate();
        }
        public int Dia { get; private set; }
        public int Mes { get; private set; }
        public int Ano { get; private set; }

        public override string ToString()
        {
            return $"{Dia}/{Mes}/{Ano}";
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .IsBetween(1, 31, Dia, "Dia", "Dia inválido")
            .IsBetween(1, 12, Mes, "Mes", "Mês inválido")
            .IsBetween(1900, DateTime.Now.Year, Ano, "Ano", "Ano inválido"));
        }
    }
}
