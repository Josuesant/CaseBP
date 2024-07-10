using Application.Observability;
using Application.Services.Users;
using Domain;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services) => services.AddServices();

    public static void AddObservability(this IServiceCollection services)
    {
        if (!AppSettings.IsDevelopment)
            services.AddOpenTelemetry().AddMetrics().AddTraces();
    }

    internal static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserCreator, UserCreator>();

        services.Configure<HostOptions>(x =>
        {
            x.ServicesStartConcurrently = true;
            x.ServicesStopConcurrently = true;
        });

        //services.AddHostedService<UserMeterReceiver>();
        //services.AddRabbitMq();
    }

    // internal static void AddRabbitMq(this IServiceCollection services)
    // {
    //     services.AddMassTransit(x =>
    //     {
    //         x.AddConsumer<ConsumerDadosClienteEvent>();
    //         x.UsingRabbitMq((ctx, cfg) =>
    //         {
    //             cfg.Host("localhost", "/", c =>
    //             {
    //                 c.Username("guest");
    //                 c.Password("guest");
    //             });
    //             cfg.ConfigureEndpoints(ctx);
    //             cfg.ReceiveEndpoint("DadosAnalise", e => {e.ConfigureConsumer<ConsumerDadosClienteEvent>(ctx);});
    //         });
    //     });
    //     
    // }
}