using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var member = new Dictionary<string, List<string>>();
            var time = new Dictionary<string, int>();

            string[] input = Console.ReadLine().Split("; ", StringSplitOptions.RemoveEmptyEntries);

            while(input[0]!= "start of concert")
            {
                string bandname = input[1];
                if (input[0] == "Add")
                {
                    if(!member.ContainsKey(bandname))
                    {
                        member[bandname] = new List<string>();
                    }

                    string[] currentMember = input[2].Split(", ", StringSplitOptions.RemoveEmptyEntries);

                    foreach (var v in currentMember)
                    {
                        if(!member[bandname].Contains(v))
                        {
                            member[bandname].Add(v);
                        }
                    }
                }

                else if (input[0]=="Play")
                {
                    if(!time.ContainsKey(bandname))
                    {
                        time[bandname] = 0;
                    }

                    time[bandname] += int.Parse(input[2]);
                }
                input = Console.ReadLine().Split("; ", StringSplitOptions.RemoveEmptyEntries);
            }

            int totalTime = 0;
            foreach (var kvp in time)
            {
                totalTime += kvp.Value;
            }
            Console.WriteLine($"Total time: {totalTime}");

            foreach (var kvp in time.OrderBy(x=>-x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                //Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            string bandPrint = Console.ReadLine();

            foreach (var kvp in member)
            {
                if(bandPrint==kvp.Key)
                {
                    //Console.WriteLine($"{}");
                    Console.WriteLine($"{kvp.Key}");

                    foreach (var v in kvp.Value)
                    {
                        Console.WriteLine($"=> {v}");
                    }
                }
            }
        }
    }
}
