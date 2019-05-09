using System;
using System.Collections.Generic;
using System.Linq;

namespace _07OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            var data = Console.ReadLine().Split().ToArray();

            while(data[0]!= "End")
            {
                var person = new Person(data);
                people.Add(person);

                data = Console.ReadLine().Split().ToArray();
            }

            foreach (var item in people.OrderBy(x=>x.Age))
            {
                Console.WriteLine($"{item.Name} with ID: {item.ID} is {item.Age} years old.");
            }
        }
    }

    class Person
    {
        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }

        public Person(string[] data)
        {
            Name = data[0];
            ID = data[1];
            Age = int.Parse(data[2]);
        }
    }
}
