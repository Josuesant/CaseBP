using Application.Exceptions;
using Domain.DTOs.Users;
using Domain.Entities;
using Domain.Entities.Users;
using Infrastructure.RabbitMq;
using Microsoft.Extensions.Logging;

namespace Application.Services.Users;

public class UserCreator(IBaseEntityRepository<User> repository, ILogger<UserCreator> logger, BasePublisher publisher)
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

        publisher.Publish(nameof(ExchangeEnum.UserEntityRequestsExchange), 1);
    }
}