using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.PostgreSql.Mappings;

public abstract class BaseEntityMapping<T> where T : BaseEntity
{
    protected readonly EntityTypeBuilder<T> Builder;
    protected abstract string TableName { get; }

    protected BaseEntityMapping(EntityTypeBuilder<T> builder)
    {
        Builder = builder;
        Map();
    }

    protected abstract void MapProperties();
    protected abstract void MapIndexes();
    protected abstract void MapForeignKeys();

    private void Map()
    {
        MapTableName();
        MapProperties();
        MapBaseProperties();
        MapPrimaryKey();
        MapIndexes();
        MapForeignKeys();
    }

    private void MapTableName() => Builder.ToTable(TableName);

    private void MapBaseProperties()
    {
        Builder.Property(x => x.Id).HasColumnName("id").IsRequired();
        Builder.Property(x => x.CriadoEm).HasColumnName("created_at").IsRequired();
        Builder.Property(x => x.UltomaAtualizacao).HasColumnName("updated_at").IsRequired();
    }

    private void MapPrimaryKey() => Builder.HasKey(x => x.Id);
}