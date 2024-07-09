using System.ComponentModel;

namespace CreditoCliente.Dommain.Enuns;

public enum StatusAnalise
{
    [Description("Negado")]
    Negado = 0,
    [Description("Aprovado")]
    Aprovado = 1
}