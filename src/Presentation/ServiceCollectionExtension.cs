using System.Collections.Immutable;
using System.Reflection;
using Domain;
using Application.Consumers;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Presentation.Helpers;
using Swashbuckle.AspNetCore.Filters;

namespace Presentation;

public static class ServiceCollectionExtension
{
    public static void AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddRouting(x => x.LowercaseUrls = true);
        services.AddJwt();
        services.AddSwagger();
        services.AddRabbitMq();
    }

    private static void AddJwt(this IServiceCollection services) => services
        .AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = TokenHelper.GetSecurityKey(),
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidAudience = AppSettings.JwtAudience,
                ValidIssuer = AppSettings.JwtIssuer
            };
        });
    
    internal static void AddRabbitMq(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<ConsumerDadosClienteEvent>();
            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host("localhost", "/", c =>
                {
                    c.Username("guest");
                    c.Password("guest");
                });
                cfg.ConfigureEndpoints(ctx);
                cfg.ReceiveEndpoint("DadosAnalise", e => {e.ConfigureConsumer<ConsumerDadosClienteEvent>(ctx);});
            });
        });
        
    }

    private static void AddSwagger(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddSwaggerExamplesFromAssemblies(assembly);
        services.AddSwaggerGen(x =>
        {
            x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Description = "JWT authorization header using the bearer scheme.",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Scheme = "Bearer",
                Type = SecuritySchemeType.ApiKey
            });
            x.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    ImmutableArray<string>.Empty
                }
            });
            x.ExampleFilters();
            x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{assembly.GetName().Name}.xml"));
            x.SwaggerDoc("v1", new OpenApiInfo
            {
                Contact = new OpenApiContact
                {
                    Email = "example@template.com"
                },
                Description = "API to manage the CadastroCliente application.",
                License = new OpenApiLicense
                {
                    Name = "© All rights reserved."
                },
                Title = "CadastroCliente",
                Version = "v1"
            });
        });
    }
}