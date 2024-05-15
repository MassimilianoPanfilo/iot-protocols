using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherMQ
{
    public class VirtualSpeedSensor
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
    }
}
