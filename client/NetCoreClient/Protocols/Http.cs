using System.Net;

namespace NetCoreClient.Protocols
{
    class Http : ProtocolInterface
    {
        private string Endpoint;
        //private HttpWebRequest httpWebRequest;


        public Http(string endpoint)
        {
            this.Endpoint = endpoint;
        }

        //EndPoint endPoint = new EndPoint("192.168.101.148");

        public async void Send(string data)
        {
            var client = new HttpClient();

            var result = await client.PostAsync(Endpoint, new StringContent(data));

            Console.Out.WriteLine(result.StatusCode);
        }
    }
}
