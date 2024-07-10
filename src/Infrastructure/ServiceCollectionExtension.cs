using Domain;
using Domain.Entities;
using Infrastructure.PostgreSql;
using Infrastructure.PostgreSql.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddPostgreSql();
    }

    internal static void AddPostgreSql(this IServiceCollection services)
    {
        services.AddDbContextPool<DatabaseContext>(x =>
            x.UseNpgsql(AppSettings.PostgreSqlConnectionString, y =>
            {
                y.MigrationsAssembly("Infrastructure");
                y.EnableRetryOnFailure();
            }));
        services.AddScoped(typeof(IBaseEntityRepository<>), typeof(BaseEntityRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        if (!AppSettings.IsDevelopment)
            services.BuildServiceProvider().GetRequiredService<DatabaseContext>().Database.Migrate();

        services.AddHealthChecks()
            .AddDbContextCheck<DatabaseContext>()
            .AddNpgSql(AppSettings.PostgreSqlConnectionString);
    }
}