using Application.Services.Users;
using ContratosEventos;
using MassTransit;

namespace Application.Consumers;

public abstract class ConsumerCartaoClienteEvent(IUserCard userCard) : IConsumer<CartaoEmitidoEvent>
{
    public async Task Consume(ConsumeContext<CartaoEmitidoEvent> context)
    {
        var cartao = context.Message;

        await userCard.CreateCardAsync(cartao);
    }
}