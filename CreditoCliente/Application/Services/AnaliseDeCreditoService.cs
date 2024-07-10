using ContratosEventos;
using CreditoCliente.Dommain;
using MassTransit;

namespace CreditoCliente.Application.Services;

public class AnaliseDeCreditoService : IAnaliseDeCreditoService
{
    private readonly IAnaliseDeCredito _analiseDeCredito;
    private readonly IPublishEndpoint _publish;

    public AnaliseDeCreditoService(IAnaliseDeCredito analiseDeCredito, IPublishEndpoint publish)
    {
        _analiseDeCredito = analiseDeCredito;
        _publish = publish;
    }

    public async Task AnalisaCreditoCliente(DadosCliente dadosCliente)
    {
        var analiseCompleta = _analiseDeCredito.Analise(dadosCliente);

        var resultadoAnaliseEvent = new DadosAnaliseClienteEvent()
        {
            DocumentoCliente = analiseCompleta.DocumentoCliente,
            StatusAnalise = analiseCompleta.StatusAnalise,
            LimiteMinimo = analiseCompleta.LiminiteMinimo,
            LimiteMaximo = analiseCompleta.LiminiteMaximo,
            Descricao = analiseCompleta.Descricao,
        };
        
        await _publish.Publish(resultadoAnaliseEvent);
    }
}