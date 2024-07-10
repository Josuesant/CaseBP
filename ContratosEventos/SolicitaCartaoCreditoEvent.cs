namespace ContratosEventos;

public class SolicitaCartaoCreditoEvent
{
    public string? DocumentoCiente { get; set; }
    public string? Nome { get; set; }
    public decimal LimiteMaximo { get; set; }
}