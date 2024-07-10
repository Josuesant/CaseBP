using ContratosEventos;

namespace Application.Services.Users;

public interface IUserCard
{
    Task CreateCardAsync(CartaoEmitidoEvent cartaoEmitidoEvent);
}