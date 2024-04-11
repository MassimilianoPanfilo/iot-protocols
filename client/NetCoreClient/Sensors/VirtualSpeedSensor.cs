using NetCoreClient.ValueObjects;
using System.Text.Json;

namespace NetCoreClient.Sensors
{
    class VirtualSpeedSensor : ISpeedSensor, ISensor
    {
        private readonly Random Random;
        public int Speed => Random.Next(100); // Proprietà Speed come propietà di sola lettura

        public VirtualSpeedSensor()
        {
            Random = new Random(); // Inizializzazione corretta del campo Random
        }

        public int GetSpeed()
        {
            return Speed;
        }

        public string ToJson()
        {
            // Creazione di un oggetto anonimo per rappresentare il valore della velocità
            var speedObject = new { speed = Speed }; // Utilizzo della proprietà Speed invece della variabile locale speed

            // Serializzazione dell'oggetto anonimo in formato JSON
            string json = JsonSerializer.Serialize(speedObject);

            return json;
        }

    }
}
