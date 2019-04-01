using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonProcessing
{
    public class Person
    {
        [JsonProperty(PropertyName = "Име", Order = 2)]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonIgnore]
        public int Age { get; set; }
        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }
}
