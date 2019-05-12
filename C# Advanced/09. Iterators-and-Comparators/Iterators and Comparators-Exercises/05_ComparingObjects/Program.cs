namespace _05_ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();

            var people = new List<Person>();
            while (input[0]!= "END")
            {
                string name = input[0];
                int age = int.Parse(input[1]);
                string town = input[2];

                var person = new Person(name, age, town);
                people.Add(person);

                input = Console.ReadLine().Split().ToArray();
            }

            int index = int.Parse(Console.ReadLine());

            int equalPeople = 0;
            int notEqualPeople = 0;

            var currentPerson = people[index - 1];

            for (int i = 0; i < people.Count; i++)
            {
                if(i==index-1)
                {
                    continue;
                }

                if(currentPerson.CompareTo(people[i])==0)
                {
                    if(equalPeople==0)
                    {
                        equalPeople++;
                    }
                    equalPeople++;
                }

                else
                {
                    notEqualPeople++;
                }
            }

            if(equalPeople==0)
            {
                Console.WriteLine("No matches");
            }

            else
            {
                Console.WriteLine($"{equalPeople} {notEqualPeople} {people.Count}");
            }
        }
    }
}
