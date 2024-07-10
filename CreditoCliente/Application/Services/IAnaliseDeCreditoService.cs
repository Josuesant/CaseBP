using CreditoCliente.Dommain;

namespace CreditoCliente.Application.Services;

public interface IAnaliseDeCreditoService
{
    Task AnalisaCreditoCliente(DadosCliente dadosCliente);
}