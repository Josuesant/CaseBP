using ContratosEventos;
using CreditoCliente.Application.Services;
using CreditoCliente.Dommain;
using MassTransit;

namespace CreditoCliente.Presentation.Consumers;

public abstract class ConsumerDadosClienteEvent(IAnaliseDeCreditoService analiseDeCreditoService)
    : IConsumer<DadosClienteEvent>
{
    public async Task Consume(ConsumeContext<DadosClienteEvent> context)
    {
        var analise = context.Message;
        DadosCliente dadosCliente = new()
        {
            DocumentoCliente = analise.DocumentoCliente,
            Renda = analise.Renda,
            EstadoCivil = analise.EstadoCivil,
            Dependentes = analise.Dependentes,
            Genero = analise.Genero,
            Idade = analise.Idade
        };

        await analiseDeCreditoService.AnalisaCreditoCliente(dadosCliente);
    }
}