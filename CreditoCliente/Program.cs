using CreditoCliente;
using CreditoCliente.Presentation.Consumers;
using MassTransit;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddMassTransit(x =>
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

var host = builder.Build();
host.Run();