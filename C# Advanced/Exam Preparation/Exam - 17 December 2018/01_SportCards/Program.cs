using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_SportCards
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] {' ','-' },StringSplitOptions.RemoveEmptyEntries).ToArray();

            var list = new Dictionary<string, Dictionary<string, double>>();

            while (input[0]!="end")
            {
                if(input[0]=="check")
                {
                    string card = input[1];
                    if(list.ContainsKey(card))
                    {
                        Console.WriteLine($"{card} is available!");
                    }

                    else
                    {
                        Console.WriteLine($"{card} is not available!");
                    }
                }

                else
                {
                    string card = input[0];
                    string sport = input[1];
                    double price = double.Parse(input[2]);

                    if(!list.ContainsKey(card))
                    {
                        list[card] = new Dictionary<string, double>();
                    }

                    list[card][sport] = price;
                }

                input = Console.ReadLine().Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (var card in list.OrderBy(x => -x.Value.Count()))
            {
                Console.WriteLine($"{card.Key}:");

                foreach (var sport in card.Value.OrderBy(x=>x.Key))
                {
                    Console.WriteLine($"  -{sport.Key} - {sport.Value:f2}");
                }
            }
        }
    }
}
