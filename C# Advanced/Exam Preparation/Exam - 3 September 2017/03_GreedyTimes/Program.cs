using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _03_GreedyTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());
            var gem = new Dictionary<string, long>();
            var cash = new Dictionary<string, long>();
            long quantityGold = 0;
            long quantityGem = 0;
            long quantityCash = 0;

            long currentCapacity= 0;
            var input = new Queue<string>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray());
            while (input.Count>0)
            {
                string name = input.Dequeue();
                long quantity = long.Parse(input.Dequeue());

                


                if (name=="Gold" && currentCapacity+quantity<=capacity)
                {
                    quantityGold += quantity;
                    currentCapacity += quantity;
                }

                else if(name.Length>=4 && CheckGem(name) && quantityGem+quantity<=quantityGold && currentCapacity + quantity <= capacity)
                {
                    if(gem.ContainsKey(name))
                    {
                        gem[name] += quantity;
                        currentCapacity += quantity;
                    }

                    else
                    {
                        gem[name] = quantity;
                        currentCapacity += quantity;
                    }
                    
                }
                else if(name.Length==3 && CheckForLetter(name) && quantityCash + quantity <= quantityGem
                    && currentCapacity + quantity <= capacity)
                {
                    if(cash.ContainsKey(name))
                    {
                        cash[name] += quantity;
                        currentCapacity += quantity;
                    }

                    else
                    {
                        cash[name] = quantity;
                        currentCapacity += quantity;
                    }
                    
                }

                quantityGem = gem.Values.Sum();
                quantityCash = cash.Values.Sum();

            }
            
                PrintGold(quantityGold);

                PrintGem(quantityGem, gem);

                PrintCash(quantityCash, cash);
        }

        private static void PrintCash(long quantityCash, Dictionary<string, long> cash)
        {
            if (quantityCash > 0)
            {
                Console.WriteLine($"<Cash> ${quantityCash}");

                foreach (var item in cash.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }

        private static void PrintGem(long quantityGem, Dictionary<string, long> gem)
        {
            if (quantityGem > 0)
            {
                Console.WriteLine($"<Gem> ${quantityGem}");
                foreach (var item in gem.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }

        private static void PrintGold(long quantityGold)
        {
            Console.WriteLine($"<Gold> ${quantityGold}");
            Console.WriteLine($"##Gold - {quantityGold}");
        }

        private static bool CheckGem(string name)
        {
            if(name.ToLower().EndsWith("gem"))
            {
                return true;
            }
            
            return false;
        }

        private static bool CheckForLetter(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if(!char.IsLetter(name[i]) || !char.IsUpper(name[i]))
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}
