namespace CreditoCliente;

public class AppSettings
{
    public static string AppEnvironment =>
        Environment.GetEnvironmentVariable("APP_ENVIRONMENT")?.Trim().ToLowerInvariant() ?? "development";
    public static bool IsDevelopment => AppEnvironment is "development";

    public static string RabbitMqConnectionString =>
        Environment.GetEnvironmentVariable("RABBITMQ_CONNECTION_STRING")?.Trim() ??
        "amqp://guest:guest@127.0.0.1:5672/";
}