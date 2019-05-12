namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                var personArgs = Console.ReadLine().Split().ToArray();

                Person person = new Person()
                {
                    Name = personArgs[0],
                    Age = int.Parse(personArgs[1])
                };

                family.AddMember(person);
            }
            
            Console.WriteLine(family.GetOldestMember());
        }
    }
}
