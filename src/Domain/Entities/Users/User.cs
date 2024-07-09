using Domain.Enuns;

namespace Domain.Entities.Users;

public class User : BaseEntity
{
    public string Nome { get; set; }
    public string Documento { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Telefone { get; set; }
    public decimal Renda { get; set; }
    public EstadoCivil EstadoCivil { get; set; }
    public int Dependentes { get; set; }
    public Genero Genero { get; set; }
    public int Idade { get; set; }
    public bool Ativo { get; set; }

    public void Deactivate()
    {
        Ativo = false;
    }
}