using System;
using System.Collections.Generic;

namespace _02AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> collections = new Dictionary<string, long>();
            while(true)
            {
                string resource = Console.ReadLine();
                if(resource=="stop")
                {
                    break;
                }
                long quantity = long.Parse(Console.ReadLine());

                if(collections.ContainsKey(resource))
                {
                    collections[resource] += quantity;
                }

                else
                {
                    collections.Add(resource, quantity);
                }
            }

            foreach (var item in collections)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
