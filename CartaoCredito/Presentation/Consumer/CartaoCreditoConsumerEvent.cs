using CartaoCredito.Application.Services;
using ContratosEventos;
using MassTransit;

namespace CartaoCredito.Presentation.Consumer;

public class CartaoCreditoConsumerEvent : IConsumer<SolicitaCartaoCreditoEvent>
{
    private readonly IEmitiCartaoService _emitiCartaoService;

    public CartaoCreditoConsumerEvent(IEmitiCartaoService emitiCartaoService)
    {
        _emitiCartaoService = emitiCartaoService;
    }
    
    public async Task Consume(ConsumeContext<SolicitaCartaoCreditoEvent> context)
    {
        var dadosCliente = context.Message;

        await _emitiCartaoService.EmitirCartao(dadosCliente);
    }
}