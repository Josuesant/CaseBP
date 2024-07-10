namespace ContratosEventos;

public class CartaoEmitidoEvent
{
    public string DocumentoCliente { get; set; }
    public string Nome { get; set; }
    public decimal Limite { get; set; }
    public long NumeroCartao { get; set; }
    public DateTime DataValidade { get; set; }
    public int CodigoSeguranca { get; set; }
}