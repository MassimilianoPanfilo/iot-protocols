using NetCoreClient.Sensors;
using NetCoreClient.Protocols;
using System.Security.Authentication.ExtendedProtection;

// define sensors
List<ISensor> sensors = new();
sensors.Add(new VirtualSpeedSensor());
sensors.Add(new VirtualPositionSensor());

// define protocol
IProtocol protocol = new Http("http://localhost:8011");

// send data to server
while (true)
{
    foreach (ISensor sensor in sensors)
    {
        var sensorValue = sensor.ToJson();

        protocol.Send(sensorValue);

        Console.WriteLine("Data sent: " + sensorValue);

        Thread.Sleep(1000);
    }

}