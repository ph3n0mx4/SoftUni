using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> events = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> cmd = new List<string>();
            int initialEnergy = 100;
            double initialCoins = 100;
            for (int i = 0; i < events.Count; i++)
            {
                cmd.AddRange(events[i].Split('-').ToList());

                if (cmd[0] == "rest")
                {
                    int energyForAdd = int.Parse(cmd[1]);
                    initialEnergy = Energy(initialEnergy, energyForAdd);
                }

                else if (cmd[0] == "order")
                {
                    double coinsForAdd = double.Parse(cmd[1]);
                    if (initialEnergy >= 30)
                    {
                        initialEnergy -= 30;
                        initialCoins = Coins(initialCoins, coinsForAdd);
                    }
                    else
                    {
                        initialEnergy += 50;
                        Console.WriteLine("You had to rest!");
                    }

                }

                else if (cmd[0] != "order" && cmd[0] != "rest")
                {
                    double price = double.Parse(cmd[1]);
                    string ingredient = cmd[0];
                    initialCoins = Purchase(initialCoins, price, ingredient);
                    if (initialCoins <= 0)
                    {
                        break;
                    }
                }

                if (i == events.Count - 1)
                {
                    Console.WriteLine("Day completed!");
                    Console.WriteLine($"Coins: {initialCoins}");
                    Console.WriteLine($"Energy: {initialEnergy}");
                }
                //Console.WriteLine(string.Join(' ', cmd));
                cmd = new List<string>();
            }


        }

        private static double Purchase(double initialCoins, double price, string ingredient)
        {
            double currentCoins = initialCoins - price;
            if (currentCoins <= 0)
            {
                Console.WriteLine($"Closed! Cannot afford {ingredient}.");
            }
            else
            {
                Console.WriteLine($"You bought {ingredient}.");
            }
            return currentCoins;
        }

        private static double Coins(double initialCoins, double coinsForAdd)
        {
            initialCoins += coinsForAdd;
            Console.WriteLine($"You earned {coinsForAdd} coins.");
            return initialCoins;
        }

        private static int Energy(int initialEnergy, int energyForAdd)
        {
            int sum = initialEnergy + energyForAdd;
            if (sum >= 100)
            {
                initialEnergy = 100;
                Console.WriteLine("You gained 0 energy.");
                Console.WriteLine($"Current energy: {initialEnergy}.");
            }
            else
            {
                initialEnergy = sum;
                Console.WriteLine($"You gained {energyForAdd} energy.");
                Console.WriteLine($"Current energy: {initialEnergy}.");
            }

            return initialEnergy;
        }
    }
}