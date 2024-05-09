using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreClient.Protocols
{
    class Http : IProtocol
    {
        private readonly string Endpoint;
        private readonly HttpClient HttpClient;

        public Http(string endpoint)
        {
            this.Endpoint = endpoint;
            this.HttpClient = new HttpClient();
        }

        public async Task Send(string data)
        {
            try
            {
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await HttpClient.PostAsync(Endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Data sent successfully to {Endpoint}");
                }
                else
                {
                    Console.WriteLine($"Failed to send data to {Endpoint}. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while sending data to {Endpoint}: {ex.Message}");
            }
        }
    }
}