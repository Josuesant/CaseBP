using ContratosEventos;
using MassTransit;

namespace CartaoCredito.Application.Services;

public class EmitiCartaoService : IEmitiCartaoService
{
    private readonly IPublishEndpoint _publish;

    public EmitiCartaoService(IPublishEndpoint publish)
    {
        _publish = publish;
    }
    
    public async Task EmitirCartao(SolicitaCartaoCreditoEvent solicitaCartao)
    {
        var limite = solicitaCartao.LimiteMaximo * (decimal)1.5;
        var data = DateTime.UtcNow;

        var cartao = new CartaoEmitidoEvent()
        {
            DocumentoCliente = solicitaCartao.DocumentoCiente,
            Nome = solicitaCartao.Nome,
            Limite = limite,
            NumeroCartao = GeradordeNumero(),
            DataValidade = data.AddYears(5),
            CodigoSeguranca = GeradordeCodigoSeguranca()
        };

        await _publish.Publish(cartao);
    }

    private long GeradordeNumero()
    {
        var numero = 0;
        Random randNun = new Random();
        for (int i = 0; i < 4 ; i++)
            numero += randNun.Next(1000,9999);
        return numero;
    }
    
    private int GeradordeCodigoSeguranca()
    {
        Random randNun = new Random();
        return randNun.Next(100,999);
    }
}