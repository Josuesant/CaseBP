using ContratosEventos.Enums;

namespace Domain.DTOs.Users;

public class CreateUserRequestDto()
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

    public CreateUserRequestDto(string nome, string documento, DateTime dataNascimento, string telefone, decimal renda, EstadoCivil estadoCivil, int dependentes, Genero genero, int idade) : this()
    {
        Nome = nome;
        Documento = documento;
        DataNascimento = dataNascimento;
        Telefone = telefone;
        Renda = renda;
        EstadoCivil = estadoCivil;
        Dependentes = dependentes;
        Genero = genero;
        Idade = idade;
    }
}