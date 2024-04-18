using NetCoreClient.Sensors;
using NetCoreClient.Protocols;

// define sensors
List<ISensor> sensors = new();
sensors.Add(new VirtualSpeedSensor());
sensors.Add(new VirtualPositionSensor());

// define protocol
//IProtocolInterface protocol = new Http("http://localhost:8011/cars/123");
IProtocol protocol = new Mqtt("test.mosquitto.org");

// send data to server
while (true)
{
    foreach (ISensor sensor in sensors)
    {
        var sensorValue = sensor.ToJson();

        protocol.Send(sensorValue, sensor.GetSlug());

        Console.WriteLine("Data sent: " + sensorValue);

        Thread.Sleep(1000);
    }

}