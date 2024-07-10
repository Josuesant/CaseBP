using System.ComponentModel.DataAnnotations;
using ContratosEventos.Enums;
using Domain.DTOs.Users;

namespace Presentation.Contracts.Users;

/// <summary>
/// Create user request.
/// </summary>
public record CreateUserRequest
{
    [Required]
    public string Nome { get; init; }
    
    [Required]
    public string Documento { get; init; }
    
    [Required]
    public DateTime DataNascimento { get; init; }
    
    [Required]
    public string Telefone { get; init; }
    
    [Required]
    public decimal Renda { get; init; }
    
    [Required]
    public EstadoCivil EstadoCivil { get; init; }
    
    [Required]
    public int Dependentes { get; init; }
    
    [Required]
    public Genero Genero { get; set; }
    
    [Required]
    public int Idade { get; set; }

    public CreateUserRequestDto ConvertToDto() =>
        new(Nome, Documento, DataNascimento, Telefone, Renda, EstadoCivil, Dependentes, Genero, Idade);
}