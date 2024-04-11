using NetCoreClient.Sensors;
using NetCoreClient.ValueObjects;


namespace NetCoreClient.Protocols
{
    class Http : IProtocol
    {
        private string Endpoint;
        //private HttpWebRequest httpWebRequest;


        public Http(string endpoint)
        {
            this.Endpoint = endpoint;
        }

        //EndPoint endPoint = new EndPoint("192.168.101.148");

        //position e speed devono coincidere con i metodi nelle loro classi /virtualsensor../ ed essere agglomerati per fare il messaggio da inviare
        public async void Send(string data)
        {
            var client = new HttpClient();

            ISensor sensor = null;   ////aaaaaaaaadevo prendere i valori json dai sensori
            data = sensor.ToJson(); ////aaaaaaaaa  e caricarli in data per inviare il messaggio

            var result = await client.PostAsync(Endpoint, new StringContent(data));

            Console.Out.WriteLine(result.StatusCode);
        }

        
    }
}
