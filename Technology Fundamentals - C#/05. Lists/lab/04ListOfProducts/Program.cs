using System;
using System.Collections.Generic;
using System.Linq;

namespace _04ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> product = new List<string>();

            for (int i = 0; i < n; i++)
            {
                product.Add(Console.ReadLine());
            }

            product.Sort();
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"{i}.{product[i-1]}");
            }
        }
    }
}
