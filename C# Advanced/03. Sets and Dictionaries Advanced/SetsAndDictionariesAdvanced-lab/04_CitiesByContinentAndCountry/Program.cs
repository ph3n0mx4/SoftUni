using System;
using System.Collections.Generic;

namespace _04_CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var CCC = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if(!CCC.ContainsKey(continent))
                {
                    CCC[continent] = new Dictionary<string, List<string>>();
                }

                if(!CCC[continent].ContainsKey(country))
                {
                    CCC[continent][country] = new List<string>();
                }

                CCC[continent][country].Add(city);
            }

            foreach (var kvp in CCC)
            {
                Console.WriteLine($"{kvp.Key}:");
                
                foreach (var citiesInCountry in kvp.Value)
                {
                    string country = citiesInCountry.Key;
                    string cities = string.Join(", ", citiesInCountry.Value);
                    Console.WriteLine($"  {country} -> {cities}");
                }
            }
        }
    }
}
