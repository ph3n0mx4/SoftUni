namespace _06_StrategyPattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var listOne = new SortedSet<ComparatorName>();
            var listTwo = new SortedSet<ComparatorAge>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                string name = input[0];
                int age = int.Parse(input[1]);

                listOne.Add(new ComparatorName { Name = name, Age = age });
                listTwo.Add(new ComparatorAge { Name = name, Age = age });
            }

            foreach (var person in listOne)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }

            foreach (var person in listTwo)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }
        }
    }
}
