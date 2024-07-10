using ContratosEventos.Enums;

namespace ContratosEventos;

public class DadosAnaliseClienteEvent
{
    public string DocumentoCliente { get; set; }
    public StatusAnalise StatusAnalise { get; set; }
    public decimal LimiteMinimo { get; set; }
    public decimal LimiteMaximo { get; set; }
    public string? Descricao { get; set; }
}