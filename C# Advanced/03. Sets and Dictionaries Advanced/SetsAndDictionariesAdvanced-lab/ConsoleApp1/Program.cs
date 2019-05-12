using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var listName = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                listName.Add(input);
            }

            foreach (var name in listName)
            {
                Console.WriteLine(name);
            }
        }
    }
}
