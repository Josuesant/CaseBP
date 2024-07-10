using ContratosEventos;
using Domain.Entities;
using Domain.Entities.Credit;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Application.Services.Users;

public class UserCredit(IBaseEntityRepository<CreditAnalysis> repository, ILogger<UserCredit> logger, IPublishEndpoint publishEndpoint)
    : IUserCredit
{
    public async Task CreateCerditAsync(DadosAnaliseClienteEvent dadosAnaliseClienteEvent)
    {
        var credit = new CreditAnalysis()
        {
            DocumentoCliente = dadosAnaliseClienteEvent.DocumentoCliente,
            StatusAnalise = dadosAnaliseClienteEvent.StatusAnalise,
            LimiteMinimo = dadosAnaliseClienteEvent.LimiteMinimo,
            LimiteMaximo = dadosAnaliseClienteEvent.LimiteMaximo,
            Descricao = dadosAnaliseClienteEvent.Descricao
        };

        await repository.InsertOneAsync(credit);

        if (dadosAnaliseClienteEvent.LimiteMinimo >= 1000)
        {
            var requestCard = new SolicitaCartaoCreditoEvent()
            {
                DocumentoCiente = dadosAnaliseClienteEvent.DocumentoCliente,
                Nome = "",
                LimiteMaximo = dadosAnaliseClienteEvent.LimiteMaximo
            };
            await publishEndpoint.Publish(requestCard);
        }
    }
}