using NetCoreClient.ValueObjects;
using System.Text.Json;

namespace NetCoreClient.Sensors
{
    public class VirtualPositionSensor : IPositionSensor, ISensor
    {
        private readonly Random Random = new Random();

        // Implementazione delle proprietà X, Y, Z
        public int X { get { return Random.Next(-100, 100); } }
        public int Y { get { return Random.Next(-100, 100); } }
        public int Z { get { return Random.Next(-100, 100); } }

        public VirtualPositionSensor()
        {

        }
        public string GetPosition()
        {
            VirtualPositionSensor positionSensor = new VirtualPositionSensor();
            string PositionSensor = positionSensor.ToString();
            return PositionSensor;
        }

        // Implementazione di un metodo ToJson di esempio
        public string ToJson()//string position
        {
            string PositionSensorJson = JsonSerializer.Serialize(GetPosition());
            return PositionSensorJson;
        }

    }
}
