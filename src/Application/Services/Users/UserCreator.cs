using Application.Exceptions;
using ContratosEventos;
using Domain.DTOs.Users;
using Domain.Entities;
using Domain.Entities.Users;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Application.Services.Users;

public class UserCreator(IBaseEntityRepository<User> repository, ILogger<UserCreator> logger, IPublishEndpoint publishEndpoint)
    : IUserCreator
{
    public async Task CreateAsync(CreateUserRequestDto request)
    {
        if (await repository.ExistsByAsync(x => x.Documento == request.Documento && x.Ativo))
        {
            logger.LogError("User {Documento} already created.", request.Documento);
            throw new EntityAlreadyExistsException($"User {request.Documento} already created.");
        }
        
        var cliente = new User()
        {
            Nome = request.Nome,
            Documento = request.Documento,
            DataNascimento = request.DataNascimento,
            Telefone = request.Telefone,
            Renda = request.Renda,
            EstadoCivil = request.EstadoCivil,
            Dependentes = request.Dependentes,
            Genero = request.Genero,
            Idade = request.Idade,
        };

        await repository.InsertOneAsync(cliente);

        var dados = new DadosClienteEvent()
        {
            DocumentoCliente = request.Documento,
            Renda = request.Renda,
            EstadoCivil = request.EstadoCivil,
            Dependentes = request.Dependentes,
            Genero = request.Genero,
            Idade = request.Idade
        };
        await publishEndpoint.Publish(dados);

    }
}