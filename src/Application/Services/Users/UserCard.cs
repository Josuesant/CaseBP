using ContratosEventos;
using Domain.Entities;
using Domain.Entities.Card;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Application.Services.Users;

public class UserCard(IBaseEntityRepository<CardUser> repository, ILogger<UserCard> logger, IPublishEndpoint publishEndpoint)
    : IUserCard
{
    public async Task CreateCardAsync(CartaoEmitidoEvent cartaoEmitidoEvent)
    {
        var Card = new CardUser()
        {
            DocumentoCliente = cartaoEmitidoEvent.DocumentoCliente,
            Nome = cartaoEmitidoEvent.Nome,
            Limite = cartaoEmitidoEvent.Limite,
            NumeroCartao = cartaoEmitidoEvent.NumeroCartao,
            DataValidade = cartaoEmitidoEvent.DataValidade,
            CodigoSeguranca = cartaoEmitidoEvent.CodigoSeguranca
        };

        await repository.InsertOneAsync(Card);
    }
}