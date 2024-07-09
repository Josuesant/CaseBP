using Domain.Entities.Users;
using Domain.Enuns;
using FluentAssertions;

namespace Unit.Domain.Entities.Users;

public class UserTests
{
    private const string Nome = "Jose Franscisco";
    private const string Documento = "028.478.970-48";
    private const DateTime DataNascimento = DateTime.UtcNow;
    private const string Telefone = "47 991793056";
    private const Decimal Renda = 6.500;
    private EstadoCivil EstadoCivil = EstadoCivil.Casado;
    private int Dependentes = 1;
    private Genero Genero = Genero.Masculino;
    private int Idade = 36;
    private readonly DateTime _dateTime = DateTime.UtcNow;
    private readonly User _user = new(Nome, Documento, DataNascimento, Telefone, Renda, EstadoCivil, Dependentes, Genero, Idade);

    [Fact]
    public void Should_create_an_user()
    {
        _user.Id.Should().NotBeEmpty();
        _user.Nome.Should().Be(Nome);
        _user.Documento.Should().Be(Documento);
        _user.DataNascimento.Should().BeCloseTo(_dateTime, TimeSpan.FromSeconds(60));
        _user.Telefone.Should().Be(Telefone);
        _user.Renda.Should().Be(Renda);
        _user.EstadoCivil.Should().Be(EstadoCivil);
        _user.Dependentes.Should().Be(Dependentes);
        _user.Genero.Should().Be(Genero);
        _user.Idade.Should().Be(Idade);
        _user.UltomaAtualizacao.Should().BeCloseTo(_dateTime, TimeSpan.FromSeconds(1));
        _user.UpdatedBy.Should().Be(Email);
        _user.Active.Should().BeTrue();
    }
}