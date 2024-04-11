using NetCoreClient.Sensors;
using NetCoreClient.ValueObjects;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetCoreClient.Protocols
{
    class Http : IProtocol
    {
        private readonly string Endpoint;

        public ISensor Sensors { get; }
        private readonly List<ISensor> sensors;

        private readonly HttpClient client = new();
        

        public Http(string endpoint, List<ISensor> sensors)
        {
            Endpoint = endpoint;
            this.sensors = sensors;
        }

        public async Task Send(string json)
        {
            //var dataSensorsToJson = Sensors.ToJson();
            json = JsonSerializer.Serialize(Sensors.ToJson);

            var result = await client.PostAsync(Endpoint, new StringContent(json));

            Console.Out.WriteLine(result.StatusCode);
        }

       
    }
}

