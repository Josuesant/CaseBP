using Microsoft.Azure.ServiceBus.Core;
using RabbitMQ.Client;

namespace CreditoCliente;

public abstract class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    
    private const string UserName = "guest";
    private const string Password = "guest";
    private const string HostName = "localhost";

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }
    
    static void Main(string[] args)
    {
        ConnectionFactory connectionFactory = new ConnectionFactory
        {
            HostName = HostName,
            UserName = UserName,
            Password = Password,
        };
        var connection = connectionFactory.CreateConnection();
        var channel = connection.CreateModel();
        
        channel.BasicQos(0, 1, false);
        MessageReceiver messageReceiver = new MessageReceiver(channel);
        channel.BasicConsume("demoqueue", false, messageReceiver);
        Console.ReadLine();
    }
}