using System;
using System.Collections.Generic;
using System.Linq;

namespace _05ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();

            List <string> cmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            while(cmd[0]!="end")
            {
                switch(cmd[0])
                {
                    case "Add":
                        nums.Add(int.Parse(cmd[1]));
                        break;

                    case "Remove":
                        nums.Remove(int.Parse(cmd[1]));
                        break;

                    case "RemoveAt":
                        nums.RemoveAt(int.Parse(cmd[1]));
                        break;

                    case "Insert":
                        nums.Insert(int.Parse(cmd[2]), int.Parse(cmd[1]));
                        break;
                }

                cmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            Console.WriteLine(string.Join(' ',nums));
        }
    }
}
