using Flurl.Http;
using QuickOrder.Adapters.Driven.MercadoPago.Interfaces;
using QuickOrder.Adapters.Driven.MercadoPago.Requests;
using QuickOrder.Adapters.Driven.MercadoPago.Responses;

namespace QuickOrder.Adapters.Driven.MercadoPago
{
    public class MercadoPagoApi : IMercadoPagoApi
    {
        private const string accessToken = "Bearer TEST-1167291272855659-012110-d246e58a055d1d29de3c408e19a46e69-1646738091";
        private const int user_id = 1646738091;
        private const string external_pos_id = "CAIXA01";

        public async Task<PaymentQrCodeResponse> GeraQrCodePagamento(PaymentQrCodeRequest request)
        {
            try
            {
                string url = $"https://api.mercadopago.com/instore/orders/qr/seller/collectors/{user_id}/pos/{external_pos_id}/qrs";

                var result = await url
                       .WithHeader("Content-Type", "application/json")
                       .WithHeader("Authorization", accessToken)
                       .PostJsonAsync(request)
                       .ReceiveJson<PaymentQrCodeResponse>();

                return result;
            }
            catch (FlurlHttpException ex)
            {
                var error = await ex.GetResponseJsonAsync<object>();
                Console.Write($"Error returned from {ex.Call.Request.Url}: {error}");
                return null;
            }
        }
    }
}
