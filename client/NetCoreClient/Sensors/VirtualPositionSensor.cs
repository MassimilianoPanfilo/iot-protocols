using NetCoreClient.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetCoreClient.Sensors;

class VirtualPositionSensor : ISensor, IPositionSensor
{
    private readonly Random Random;

    public VirtualPositionSensor()
    {
        Random = new Random();
    }
    public Position GetPosition()
    {
        return new Position(Random.Next(100), Random.Next(100), Random.Next(100));
    }
    public string ToJson()
    {
        return JsonSerializer.Serialize(GetPosition());
    }

    public string GetSlug()
    {
        return "position";
    }
}
