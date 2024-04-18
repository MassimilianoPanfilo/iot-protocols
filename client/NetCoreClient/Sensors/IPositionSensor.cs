using NetCoreClient.ValueObjects;

namespace NetCoreClient.Sensors
{
    internal interface IPositionSensor
    {
        Position GetPosition();
        string GetSlug();
        string ToJson();
    }
}