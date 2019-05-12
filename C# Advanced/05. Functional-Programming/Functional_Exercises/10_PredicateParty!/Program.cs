using System;
using System.Linq;

namespace _10_PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();

            var cmd = Console.ReadLine().Split().ToArray();

            while (cmd[0]!= "Party!")
            {
                string currentCmd = cmd[0];
                string currentCriteria = cmd[1];
                string givenString = cmd[2];

                if(currentCmd=="Double")
                {
                    switch (currentCriteria)
                    {
                        case "StartsWith":
                            var currentNames = names.Where(x => x.StartsWith(givenString));
                            names = names.Concat(currentNames).ToList();
                            break;

                        case "EndsWith":
                            var currentNames1 = names.Where(x => x.EndsWith(givenString));
                            names = names.Concat(currentNames1).ToList();
                            break;

                        case "Length":
                            int givenLength = int.Parse(givenString);
                            var currentNames2 = names.Where(x => x.Length==givenLength);
                            names= names.Concat(currentNames2).ToList();
                            break;
                    }

                }

                else if (currentCmd == "Remove")
                {
                    switch (currentCriteria)
                    {
                        case "StartsWith":
                            names.RemoveAll(x => x.StartsWith(givenString));
                            break;

                        case "EndsWith":
                            names.RemoveAll(x => x.EndsWith(givenString));
                            break;

                        case "Length":
                            int givenLength = int.Parse(givenString);
                            names.RemoveAll(x => x.Length == givenLength);
                            break;
                    }
                }

                cmd = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(names.Any() ? $"{string.Join(", ", names)} are going to the party!"
                : "Nobody is going to the party!");
        }
    }
}
