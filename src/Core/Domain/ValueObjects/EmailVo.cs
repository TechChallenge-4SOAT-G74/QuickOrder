using System.Text.RegularExpressions;

namespace QuickOrder.Core.Domain.ValueObjects
{
    public class EmailVo
    {
        public string Endereco { get; private set; }

        public EmailVo(string endereco)
        {
            Endereco = endereco;
            Validar();
        }

        protected EmailVo() { }

        private void Validar()
        {
            string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            if (Regex.IsMatch(Endereco, pattern, RegexOptions.IgnoreCase))
                throw new Exception("E-mail Inválido! Não é possível criar Usuário");
        }
    }
}
