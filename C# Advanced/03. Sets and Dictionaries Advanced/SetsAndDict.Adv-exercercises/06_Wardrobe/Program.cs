using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var listOfClothes = new Dictionary<string,Dictionary<string,int>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToList();
                string color = input[0];

                var items = input[1].Split(",",StringSplitOptions.RemoveEmptyEntries).ToList();
                
                if(!listOfClothes.ContainsKey(color))
                {
                    listOfClothes[color] = new Dictionary<string, int>();
                }

                foreach (var item in items)
                {
                    if(!listOfClothes[color].ContainsKey(item))
                    {
                        listOfClothes[color][item] = 0;
                    }

                    listOfClothes[color][item]++;
                }
            }

            var found = Console.ReadLine().Split(" ").ToArray();
            string foundColor = found[0];
            string foundItem = found[1];

            foreach (var color in listOfClothes)
            {
                string currentColor = color.Key;
                //Blue clothes:
                //* dress - 1(found!)
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var item in color.Value)
                {
                    string currentItem = item.Key;
                    int itemCount = item.Value;

                    if(currentColor==foundColor && currentItem==foundItem)
                    {
                        Console.WriteLine($"* {currentItem} - {itemCount} (found!)");
                    }

                    else
                    {
                        Console.WriteLine($"* {currentItem} - {itemCount}");
                    }
                }

            }
        }
    }
}
