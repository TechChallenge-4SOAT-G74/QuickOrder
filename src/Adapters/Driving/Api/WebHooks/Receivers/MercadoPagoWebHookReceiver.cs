using Microsoft.AspNetCore.Mvc;
using QuickOrder.Adapters.Driven.MercadoPago.Requests;
using QuickOrder.Core.Application.UseCases.Pagamento.Interfaces;
using QuickOrder.Core.Domain.Enums;

namespace QuickOrder.Adapters.Driving.Api.WebHooks.Receivers
{
    [Route("api/webhook/receiver/mercadopago")]
    [ApiController]
    public class MercadoPagoWebHookReceiver : ControllerBase
    {
        public readonly IPagamentoUseCase _pagamentoUseCase;

        public MercadoPagoWebHookReceiver(IPagamentoUseCase pagamentoUseCase)
        {
            _pagamentoUseCase = pagamentoUseCase;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Post(WebHookData data)
        {
            Console.Write(data);

            if (data.Type == "payment")
                await _pagamentoUseCase.AtualizarStatusPagamento(data.Data.Id, (int)EStatusPagamento.Aprovado);

            return Ok(data);
        }
    }
}
