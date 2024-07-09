using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.PostgreSql.Mappings;

public class UserMapping(EntityTypeBuilder<User> builder) : BaseEntityMapping<User>(builder)
{
    protected override string TableName => "users";

    protected override void MapProperties()
    {
        Builder.Property(x => x.Nome).HasColumnName("nome").IsRequired();
        Builder.Property(x => x.Documento).HasColumnName("documento").IsRequired();
        Builder.Property(x => x.DataNascimento).HasColumnName("data_nascimento").IsRequired();
        Builder.Property(x => x.Telefone).HasColumnName("telefone").IsRequired();
        Builder.Property(x => x.Renda).HasColumnName("renda").IsRequired();
        Builder.Property(x => x.EstadoCivil).HasColumnName("estadoCivil").IsRequired();
        Builder.Property(x => x.Dependentes).HasColumnName("dependentes").IsRequired();
        Builder.Property(x => x.Genero).HasColumnName("genero").IsRequired();
        Builder.Property(x => x.Idade).HasColumnName("idade").IsRequired();
        Builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();
    }

    protected override void MapIndexes() => Builder.HasIndex(x => new { x.Documento, x.Ativo });

    protected override void MapForeignKeys()
    {
    }
}