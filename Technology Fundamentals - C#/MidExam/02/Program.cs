using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> dungeons = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> cmd = new List<string>();
            int health = 100;
            double coins = 0;

            for (int i = 0; i < dungeons.Count; i++)
            {
                cmd.AddRange(dungeons[i].Split(' ').ToList());

                if(cmd[0]== "potion")
                {
                    int healthToAdd = int.Parse(cmd[1]);
                    health =Potion(health, healthToAdd);
                }

                else if(cmd[0]== "chest")
                {
                    int coinsToAdd = int.Parse(cmd[1]);
                    coins += coinsToAdd;
                    Console.WriteLine($"You found {coinsToAdd} coins.");
                }

                else if (cmd[0] != "potion" && cmd[0] != "chest")
                {
                    int attackMonster = int.Parse(cmd[1]);
                    health -= attackMonster;
                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {cmd[0]}.");
                    }

                    else
                    {
                        Console.WriteLine($"You died! Killed by {cmd[0]}.");
                        Console.WriteLine($"Best room: {i+1}");
                        return;
                    }
                }

                if(i==dungeons.Count-1)
                {
                    Console.WriteLine("You've made it!");
                    Console.WriteLine($"Coins: {coins}");
                    Console.WriteLine($"Health: {health}");
                }

                cmd = new List<string>();
            }
        }

        private static int Potion(int health, int healthToAdd)
        {
            int sum = health + healthToAdd;
            if(sum>=100)
            {
                Console.WriteLine($"You healed for {100-health} hp.");
                sum = 100;
                Console.WriteLine($"Current health: {sum} hp.");
            }

            else
            {
                Console.WriteLine($"You healed for {healthToAdd} hp.");
                Console.WriteLine($"Current health: {sum} hp.");
            }
            return sum;
        }
    }
}
