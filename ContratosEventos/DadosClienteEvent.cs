using ContratosEventos.Enums;

namespace ContratosEventos;

public class DadosClienteEvent
{
    public string DocumentoCliente { get; set; }
    public decimal Renda { get; set; }
    public EstadoCivil EstadoCivil { get; set; }
    public int Dependentes { get; set; }
    public Genero Genero { get; set; }
    public int Idade { get; set; }
}