using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Microsoft.Extensions.Configuration;

public class Subscriber
{
    public static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder().AddUserSecrets<Subscriber>();
        IConfigurationRoot configuration = builder.Build();
        //var factory = new ConnectionFactory { HostName = "amqps://jzfdrjhc:srlLV4huYomCzrg0L0bkLlOtgckRC1HW@goose.rmq2.cloudamqp.com/jzfdrjhc" }; NON LASCIARE COSI PERCHE NON FUNZIONA, METTERE I VALORI SINGOLARMENTE

        ConnectionFactory factory = new ConnectionFactory
        {
            HostName = configuration["FactoryConnection:HostName"],
            UserName = configuration["FactoryConnection:UserName"],
            Password = configuration["FactoryConnection:Password"],
            VirtualHost = configuration["FactoryConnection:VirtualHost"],
            Port = int.Parse(configuration["FactoryConnection:Port"])
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "Sensor",
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
            Console.WriteLine($"Data received {message}");
        };
        channel.BasicConsume(queue: "Sensor",
                             autoAck: true,
                             consumer: consumer);

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}
