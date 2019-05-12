using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            int infoIndex = int.Parse(Console.ReadLine());

            var input = Console.ReadLine().Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var list = new Dictionary<string, Dictionary<string, string>>();
            while (input[0]!= "end transmissions")
            {
                string name = input[0];
                if(!list.ContainsKey(name))
                {
                    list[name] = new Dictionary<string, string>();
                }
                var data = input[1].Split(";",StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int i = 0; i < data.Length; i++)
                {
                    var currentData = data[i].Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    list[name][currentData[0]] = currentData[1];
                }
                input = Console.ReadLine().Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            var cmdKill = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string nameKill = cmdKill[1];

            var result = list.First(x => x.Key == nameKill).Value.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Info on {nameKill}:");

            int currentInfoIndex = 0;
            foreach (var item in result)
            {
                currentInfoIndex += item.Key.Length;
                currentInfoIndex += item.Value.Length;
                Console.WriteLine($"---{item.Key}: {item.Value}");
            }

            Console.WriteLine($"Info index: {currentInfoIndex}");

            if (currentInfoIndex >= infoIndex)
            {
                Console.WriteLine("Proceed");
            }

            else
            {
                Console.WriteLine($"Need {infoIndex-currentInfoIndex} more info.");
            }

        }
    }
}
