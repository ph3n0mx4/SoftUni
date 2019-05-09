using System;
using System.Collections.Generic;
using System.Linq;

namespace _03HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split(' ','!');

                switch(cmd[2])
                {
                    case "going":
                        if(names.Contains(cmd[0]))
                        {
                            Console.WriteLine($"{cmd[0]} is already in the list!");
                        }
                        else
                        {
                            names.Add(cmd[0]);
                        }
                        break;

                    case "not":
                        if (names.Contains(cmd[0]))
                        {
                            names.Remove(cmd[0]);
                        }
                        else
                        {
                            Console.WriteLine($"{cmd[0]} is not in the list!");
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join('\n', names));
        }
    }
}
