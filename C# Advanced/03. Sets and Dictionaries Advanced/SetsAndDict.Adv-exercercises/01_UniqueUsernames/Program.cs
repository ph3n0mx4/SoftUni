using System;
using System.Collections.Generic;

namespace _01_UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var listNames =new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                listNames.Add(input);
            }

            foreach (var name in listNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
