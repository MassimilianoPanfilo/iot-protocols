using NetCoreClient.Sensors;
using NetCoreClient.Protocols;
using Newtonsoft.Json;

// define sensors
List<ISensorInterface> sensors = new();
sensors.Add(new VirtualSpeedSensor());
sensors.Add(new VirtualPositionSensor());

// define protocol
ProtocolInterface protocol = new Http("http://localhost:8011");

// send data to server
while (true)
{
    // Creare un oggetto dictionary per accumulare i dati da tutti i sensori
    Dictionary<string, object> sensorData = new Dictionary<string, object>();

    foreach (ISensorInterface sensor in sensors)
    {
        // Convertire i dati del sensore in JSON e aggiungerli al dictionary
        var data = sensor.ToJson();
        fsdfdsffds
        sensorData[sensor.GetType().Name] = data;
    }

    // Convertire il dictionary in una stringa JSON
    string json = JsonConvert.SerializeObject(sensorData);

    // Inviare i dati unificati al server
    protocol.Send(json);

    Console.WriteLine("Data sent: " + json);

    Thread.Sleep(1000);
}