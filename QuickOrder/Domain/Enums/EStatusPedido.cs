namespace Domain.Enums
{
    public enum EStatusPedido
    {
        Criado = 1,
        PendentePagamento = 2,
        Pago = 3,
        AguardandoPreparo = 4,
        EmPreparacao = 5,
        ProntoParaRetirada = 6,
        Finalizado = 7
    }
}
