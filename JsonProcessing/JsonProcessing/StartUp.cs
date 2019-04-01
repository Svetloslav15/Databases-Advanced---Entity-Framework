using Newtonsoft.Json;
using System;

namespace JsonProcessing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person("Svetloslav", "Novoselski", 17);
            string jsonSerialized = JsonConvert.SerializeObject(person);
            var deserialized = JsonConvert.DeserializeObject(jsonSerialized);
            Console.WriteLine(jsonSerialized);
            Console.WriteLine(deserialized);
        }
    }
}
