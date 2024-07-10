using CreditoCliente.Dommain;

namespace CreditoCliente.Application;

public interface IAnaliseDeCredito
{
    RetornoAnaliseCredito Analise(DadosCliente dadosCliente);
}