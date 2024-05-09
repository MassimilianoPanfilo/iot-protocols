using NetCoreClient.Sensors;
using NetCoreClient.Protocols;
using System.Text.Json;

// define sensors
List<ISensor> sensors = new();
sensors.Add(new VirtualSpeedSensor());

// Definizione del protocollo HTTP con l'endpoint del server
IProtocol protocol = new Http("http://localhost:8011");

// Esempio di invio di dati ogni secondo utilizzando un sensore
while (true)
{
    var sensor = new VirtualSpeedSensor(); // Utilizza il tuo sensore virtuale
    
    string jsonData = sensor.ToJson(); // Ottieni i dati come JSON

    Console.WriteLine($"Dati inviati: {jsonData}");
    // Invia i dati al server utilizzando il protocollo HTTP definito
    await protocol.Send(jsonData);

    // Attendere 1 secondo prima di inviare il prossimo dato
    await Task.Delay(1000);
}
