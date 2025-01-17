using Domain.Entities.Card;
using Domain.Entities.Credit;
using Domain.Entities.Users;
using Infrastructure.PostgreSql.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.PostgreSql;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        _ = new UserMapping(builder.Entity<User>());
        _ = new CreditAnalysisMapping(builder.Entity<CreditAnalysis>());
        _ = new CardUserMapping(builder.Entity<CardUser>());
    }
}