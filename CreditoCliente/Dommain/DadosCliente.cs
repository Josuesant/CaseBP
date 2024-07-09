using CreditoCliente.Dommain.Enuns;

namespace CreditoCliente.Dommain;

public sealed class DadosCliente
{
    public string DocumentoCliente { get; set; }
    public decimal Renda { get; set; }
    public EstadoCivil EstadoCivil { get; set; }
    public int Dependentes { get; set; }
    public Genero Genero { get; set; }
    public int Idade { get; set; }
}