using CreditoCliente.Dommain;
using CreditoCliente.Dommain.Enuns;

namespace CreditoCliente.Application;

public class AnaliseDeCredito
{
    public RetornoAnaliseCredito Analise(DadosCliente dadosCliente)
    {
        if (dadosCliente.Renda < 600)
        {
            RetornoAnaliseCredito analise = new(StatusAnalise.Negado, 0, 0, "Renda baixa");
            return analise;
        }
        
        //Variáveis de Pontuação quando inicializadas
        int poRenda = 0, poEstadoCivil = 0, poIdade = 0, poGenero = 0, poDependentes = 0;
        
        //Pesos fixos para cada variável
        int peRenda = 5, peEstadoCivil = 2, peIdade = 1, peGenero = 1, peDependentes = 1;

        poRenda = PontuacaoRenda(dadosCliente.Renda, peRenda);
        poEstadoCivil = PontuacaoEstadoCivil(dadosCliente.EstadoCivil, peEstadoCivil);
        poIdade = PontuacaoIdade(dadosCliente.Idade, peIdade);
        poGenero = PontuacaoGenero(dadosCliente.Genero, peGenero);
        poDependentes = PontuacaoDependentes(dadosCliente.Dependentes, peDependentes);

        var pontuacaoGeral = PontuacaoDependentes(poRenda, poEstadoCivil, poIdade, poGenero, poDependentes, peRenda,
            peEstadoCivil, peIdade, peGenero, peDependentes);

        if (pontuacaoGeral <= 3) return new RetornoAnaliseCredito(StatusAnalise.Negado, 0, 0, "Reprovado pela política de crédito");
        else if (pontuacaoGeral == 4) return new RetornoAnaliseCredito(StatusAnalise.Aprovado, 100, 500, "");
        else if (pontuacaoGeral == 5) return new RetornoAnaliseCredito(StatusAnalise.Aprovado, 500, 1000, "");
        else if (pontuacaoGeral == 6) return new RetornoAnaliseCredito(StatusAnalise.Aprovado, 1000, 1500, "");
        else if (pontuacaoGeral == 7) return new RetornoAnaliseCredito(StatusAnalise.Aprovado, 1500, 2000, "");
        else
        {
             return new RetornoAnaliseCredito(StatusAnalise.Aprovado, 2000, 2500, "");
        }
    }

    private int PontuacaoRenda( decimal renda, int peRenda)
    {
        var poRenda = renda <= 2200 ? 2 :
            renda <= 2800 ? 4 :
            renda <= 5000 ? 9 : 12;

        return poRenda * peRenda;
    }
    
    private int PontuacaoEstadoCivil(EstadoCivil estadoCivil, int peEstadoCivil)
    {
        var poEstadoCivil = estadoCivil.Equals(EstadoCivil.Separado) ? 9 :
            estadoCivil.Equals(EstadoCivil.Viuvo) ? 5 :
            estadoCivil.Equals(EstadoCivil.Solteiro) ? 7 :
            estadoCivil.Equals(EstadoCivil.Casado) ? 4 : 0;
        
        return poEstadoCivil * peEstadoCivil;
    }
    
    private int PontuacaoGenero(Genero genero, int peGenero)
    {
        var poGenero = genero.Equals(Genero.Feminino) ? 5 :
            genero.Equals(Genero.Masculino) ? 7 : 0;

        return poGenero * peGenero;
    }
    
    private int PontuacaoIdade(int idade, int peIdade)
    {
        var poIdade = idade <= 20 ? 9 : 
            idade <= 30 ? 3 :
            idade <= 40 ? 6 :
            idade <= 50 ? 5 : 7;

        return poIdade * peIdade;
    }
    
    private int PontuacaoDependentes(int dependentes, int peDependentes)
    {
        var poDependentes = dependentes == 0 ?  8 :
            dependentes == 1 ?  5 :
            dependentes == 2 ?  5 :
            dependentes == 3 ?  4 : 1;
        
        return poDependentes * peDependentes;
    }

    private int PontuacaoDependentes(int poRenda, int poEstadoCivil, int poIdade, int poGenero, int poDependentes, int peRenda, int peEstadoCivil, int peIdade, int peGenero, int peDependentes)
    {
        return (poRenda + poEstadoCivil + poIdade + poGenero + poDependentes) /
               (peRenda + peEstadoCivil + peIdade + peGenero + peDependentes);
    }
}