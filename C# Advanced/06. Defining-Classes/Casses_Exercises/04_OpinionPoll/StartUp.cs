namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int membeCount = int.Parse(Console.ReadLine());

            var people = new List<Person>();
            for (int i = 0; i < membeCount; i++)
            {
                var personArguments = Console.ReadLine().Split().ToArray();

                string name = personArguments[0];
                int age = int.Parse(personArguments[1]);

                Person person = new Person(name,age);
                people.Add(person);
            }

            people = people.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
