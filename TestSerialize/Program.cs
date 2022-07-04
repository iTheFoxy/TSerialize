using System;

namespace Serialize
{
    class Program
    {

      
        static void Main(string[] args)
        {
            Person tom = new Person() { Name = "Tom", Age = 35, Money = 3242.324M };
            var str = Serializer.Serialize(tom);
            Console.WriteLine(str);
            var restoredPerson = Serializer.Deserialize<Person>(str);
            Console.WriteLine($"Name: {restoredPerson.Name}  Age: {restoredPerson.Age}");
            Console.ReadKey();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Money { get; set; }
    }
}
