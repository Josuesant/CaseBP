using System.ComponentModel;

namespace Domain.Enuns;

public enum EstadoCivil
{
    [Description("Casado")]
    Casado = 0,
    [Description("Solteiro")]
    Solteiro = 1,
    [Description("Separado")]
    Separado = 2,
    [Description("Viuvo")]
    Viuvo = 3,
}