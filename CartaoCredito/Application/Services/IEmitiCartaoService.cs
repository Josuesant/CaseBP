using ContratosEventos;

namespace CartaoCredito.Application.Services;

public interface IEmitiCartaoService
{
    Task EmitirCartao(SolicitaCartaoCreditoEvent solicitaCartao);
}