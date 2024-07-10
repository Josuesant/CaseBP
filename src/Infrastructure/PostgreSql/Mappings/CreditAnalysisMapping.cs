using Domain.Entities.Credit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.PostgreSql.Mappings;

public class CreditAnalysisMapping(EntityTypeBuilder<CreditAnalysis> builder) : BaseEntityMapping<CreditAnalysis>(builder)
{
    protected override string TableName => "creditAnalysis";

    protected override void MapProperties()
    {
        Builder.Property(x => x.DocumentoCliente).HasColumnName("documentoCliente").IsRequired();
        Builder.Property(x => x.StatusAnalise).HasColumnName("statusAnalise").IsRequired();
        Builder.Property(x => x.LimiteMinimo).HasColumnName("limiteMinimo").IsRequired();
        Builder.Property(x => x.LimiteMaximo).HasColumnName("limiteMaximo").IsRequired();
        Builder.Property(x => x.Descricao).HasColumnName("descricao").IsRequired();

    }

    protected override void MapIndexes() => Builder.HasIndex(x => new { x.DocumentoCliente});

    protected override void MapForeignKeys()
    {
        
    }
}