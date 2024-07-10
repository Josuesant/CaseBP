using ContratosEventos;

namespace Application.Services.Users;

public interface IUserCredit
{
    Task CreateCerditAsync(DadosAnaliseClienteEvent dadosAnaliseClienteEvent);
}