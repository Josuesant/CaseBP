using Domain.Entities.Card;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.PostgreSql.Mappings;

public class CardUserMapping(EntityTypeBuilder<CardUser> builder) : BaseEntityMapping<CardUser>(builder)
{
    protected override string TableName => "cardUser";

    protected override void MapProperties()
    {
        Builder.Property(x => x.DocumentoCliente).HasColumnName("documentoCliente").IsRequired();
        Builder.Property(x => x.Nome).HasColumnName("nome").IsRequired();
        Builder.Property(x => x.Limite).HasColumnName("limite").IsRequired();
        Builder.Property(x => x.NumeroCartao).HasColumnName("numeroCartao").IsRequired();
        Builder.Property(x => x.DataValidade).HasColumnName("dataValidade").IsRequired();
        Builder.Property(x => x.CodigoSeguranca).HasColumnName("codigoSeguranca").IsRequired();

    }

    protected override void MapIndexes() => Builder.HasIndex(x => new { x.DocumentoCliente });

    protected override void MapForeignKeys()
    {
    }
}