using CreditoCliente.Dommain.Enuns;

namespace CreditoCliente.Dommain;

public class RetornoAnaliseCredito
{
    public StatusAnalise StatusAnalise { get; set; }
    public decimal LiminiteMinimo { get; set; }
    public decimal LiminiteMaximo { get; set; }
    public string? Descricao { get; set; }

    public RetornoAnaliseCredito(StatusAnalise statusAnalise, decimal liminiteMinimo, decimal liminiteMaximo, string? descricao)
    {
        StatusAnalise = statusAnalise;
        LiminiteMinimo = liminiteMinimo;
        LiminiteMaximo = liminiteMaximo;
        Descricao = descricao;
    }
}