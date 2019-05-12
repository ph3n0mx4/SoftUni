using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new SortedDictionary<string,Dictionary<string, double>> ();
            string[] input = Console.ReadLine().Split(", ").ToArray();
            while(input[0] !="Revision")
            {
                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if(!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                }

                shops[shop][product] = price;

                input = Console.ReadLine().Split(", ").ToArray();
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var kvp in shop.Value)
                {
                    string product = kvp.Key;
                    double price = kvp.Value;
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }

            }
        }
    }
}
