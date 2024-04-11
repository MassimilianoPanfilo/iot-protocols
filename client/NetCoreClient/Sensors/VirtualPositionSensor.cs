using NetCoreClient.ValueObjects;
using System.Text.Json;

namespace NetCoreClient.Sensors
{
    public class VirtualPositionSensor : IPositionSensor, ISensor
    {
        private readonly Random Random = new();

        // Implementazione delle proprietà X, Y, Z
        public int X { get { return Random.Next(-100, 100); } }
        public int Y { get { return Random.Next(-100, 100); } }
        public int Z { get { return Random.Next(-100, 100); } }

        public VirtualPositionSensor()
        {

        }
        public string GetPosition(int X, int Y, int Z)
        {
            
            string position = "X: " + X.ToString() + ", Y: " + Y.ToString() + ", Z: " + Z.ToString();
            //string position = ToJson(); // Ottieni la rappresentazione JSON della posizione dal sensore
            return position; // Restituisci la posizione come stringa JSON
        }



        // Implementazione di un metodo ToJson
        public string ToJson()
        {
            // Ottieni la rappresentazione JSON della posizione direttamente dal sensore di posizione
            string json = JsonSerializer.Serialize(GetPosition(); // Serializza un oggetto anonimo con le coordinate X, Y e Z

            return json; // Restituisci la rappresentazione JSON della posizione
        }


    }
}
