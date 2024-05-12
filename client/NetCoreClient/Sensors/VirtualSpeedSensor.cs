using NetCoreClient.ValueObjects;
using System.Text.Json;

namespace NetCoreClient.Sensors
{
    class VirtualSpeedSensor : ISpeedSensor, ISensor
    {
        private readonly Random Random;
        private readonly string SensorType = "speed";

        public VirtualSpeedSensor()
        {
            Random = new Random();
        }

        public int Speed()
        {
            return new Speed(Random.Next(100)).Value;
        }

        public string ToJson()
        {
            int currentSpeed = Speed();
            string vspeed = currentSpeed.ToString();
            DateTime date = DateTime.Now;
            string formattedDate = date.ToString("dd/MM/yyyy HH:mm");
            return JsonSerializer.Serialize(new {sensor = SensorType, value = vspeed, datetime = formattedDate });
        }

    }
}
