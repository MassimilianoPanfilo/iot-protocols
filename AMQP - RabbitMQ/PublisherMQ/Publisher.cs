using Microsoft.Extensions.Configuration;
using PublisherMQ;
using RabbitMQ.Client;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

internal class Publisher 
{
    private static void Main(string[] args)
    {
        

        var builder = new ConfigurationBuilder().AddUserSecrets<Publisher>();
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
        VirtualSpeedSensor speedSensor = new VirtualSpeedSensor();

        string value = speedSensor.Speed().ToString();

        string message = value;
        
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: string.Empty,
                             routingKey: "Sensor",
                             basicProperties: null,
                             body: body);
        Console.WriteLine($"Data sent {message}");

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}