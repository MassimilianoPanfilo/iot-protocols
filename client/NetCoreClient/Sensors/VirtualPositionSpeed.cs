using NetCoreClient.ValueObjects;
using System.Text.Json;

namespace NetCoreClient.Sensors
{
    public class VirtualPositionSensor : IPositionSensorInterface, ISensorInterface
    {
        private readonly Random Random = new Random();

        // Implementazione delle proprietà X, Y, Z
        public int X { get { return Random.Next(-100, 100); } }
        public int Y { get { return Random.Next(-100, 100); } }
        public int Z { get { return Random.Next(-100, 100); } }

        public VirtualPositionSensor()
        {
        }

        // Implementazione di un metodo ToJson di esempio
        public string ToJson()
        {
            var position = new Position(X, Y, Z);
            return JsonSerializer.Serialize(position);
        }
    }
}
