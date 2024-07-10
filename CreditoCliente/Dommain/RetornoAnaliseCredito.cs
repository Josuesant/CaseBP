using ContratosEventos.Enums;

namespace CreditoCliente.Dommain;

public class RetornoAnaliseCredito
{
    public string DocumentoCliente { get; set; }
    public StatusAnalise StatusAnalise { get; set; }
    public decimal LiminiteMinimo { get; set; }
    public decimal LiminiteMaximo { get; set; }
    public string? Descricao { get; set; }

    public RetornoAnaliseCredito( string documentoCliente,StatusAnalise statusAnalise, decimal liminiteMinimo, decimal liminiteMaximo, string? descricao)
    {
        DocumentoCliente = documentoCliente;
        StatusAnalise = statusAnalise;
        LiminiteMinimo = liminiteMinimo;
        LiminiteMaximo = liminiteMaximo;
        Descricao = descricao;
    }
}