using Application.Services.Users;
using ContratosEventos;
using MassTransit;

namespace Application.Consumers;

public abstract class ConsumerDadosClienteEvent(IUserCredit userCredit) : IConsumer<DadosAnaliseClienteEvent>
{
    public async Task Consume(ConsumeContext<DadosAnaliseClienteEvent> context)
    {
        var analise = context.Message;
        
        await userCredit.CreateCerditAsync(analise);
    }
}