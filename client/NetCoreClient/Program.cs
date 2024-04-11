using NetCoreClient.Sensors;
using NetCoreClient.Protocols;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;

// Define sensors
List<ISensor> sensors = new()
{
    new VirtualSpeedSensor(),
    new VirtualPositionSensor()
};

string endpoint = "http://localhost:8011";
// Crea un'istanza di Http fornendo l'endpoint e la lista di sensori
IProtocol protocol = new Http(endpoint, sensors);

// Invia i dati al server
await protocol.Send("Dati da inviare al server: ");

Console.WriteLine("Data sent: ");

    Thread.Sleep(1000);

