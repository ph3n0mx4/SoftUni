using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_FilterByAge
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int totalPoeple = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < totalPoeple; i++)
            {
                var input = Console.ReadLine()
                    .Split(", ")
                    .ToArray();

                var person = new Person
                {
                    Name = input[0],
                    Age = int.Parse(input[1])
                };

                people.Add(person);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Func<Person, bool> filterPredicate;

            if(condition=="older")
            {
                filterPredicate = p => p.Age >= age;
            }

            else
            {
                filterPredicate = p => p.Age < age;
            }

            string format = Console.ReadLine();

            Func<Person, string> selectFunc;

            if(format=="name age")
            {
                selectFunc = p => $"{p.Name} - {p.Age}";
            }

            else if (format=="name")
            {
                selectFunc = p => $"{p.Name}";
            }

            else
            {
                selectFunc = p => $"{p.Age}";
            }

            people
                .Where(filterPredicate)
                .Select(selectFunc)
                .ToList()
                .ForEach(Console.WriteLine);
              
        }
    }
}
