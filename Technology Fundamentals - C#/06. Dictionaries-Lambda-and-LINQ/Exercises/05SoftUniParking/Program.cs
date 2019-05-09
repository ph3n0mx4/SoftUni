using System;
using System.Collections.Generic;
using System.Linq;

namespace _05SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var parkingList = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split().ToArray();

                if(cmd[0]== "register")
                {
                    if(parkingList.Keys.Contains(cmd[1]))
                    {
                        //string result = parkingList[cmd[1]];
                        Console.WriteLine($"ERROR: already registered with plate number {parkingList[cmd[1]]}");
                    }

                    else
                    {
                        parkingList[cmd[1]] = cmd[2];
                        Console.WriteLine($"{cmd[1]} registered {cmd[2]} successfully");
                    }
                }

                else if (cmd[0] == "unregister")
                {
                    if(!parkingList.Keys.Contains(cmd[1]))
                    {
                        Console.WriteLine($"ERROR: user {cmd[1]} not found");
                    }

                    else
                    {
                        parkingList.Remove(cmd[1]);
                        Console.WriteLine($"{cmd[1]} unregistered successfully");
                    }
                }
            }

            foreach (var kvp in parkingList)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
