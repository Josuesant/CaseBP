﻿using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CreditoCliente.Presentation.Consumers;

public class WorkerConsumerCliente : BackgroundService
{
    public WorkerConsumerCliente()
    {
            
    }

    public void Consumer()
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "hello",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        Console.WriteLine(" [*] Waiting for messages.");

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($" [x] Received {message}");
        };
        channel.BasicConsume(queue: "hello",
            autoAck: true,
            consumer: consumer);
    }
}