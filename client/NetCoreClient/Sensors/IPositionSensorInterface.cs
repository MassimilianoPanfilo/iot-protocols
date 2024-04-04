using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreClient.Sensors
{
    internal interface IPositionSensorInterface
    {
        int X { get; }
        int Y { get; }
        int Z { get; }
    }
}
