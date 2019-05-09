using System;
using System.Collections.Generic;
using System.Linq;

namespace _02ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] cmd = Console.ReadLine().Split();

            while(cmd[0]!="end")
            {
                switch (cmd[0])
                {
                    case "Delete":
                        nums.RemoveAll(i=> i==(int.Parse(cmd[1])));
                        break;

                    case "Insert":
                        nums.Insert(int.Parse(cmd[2]), int.Parse(cmd[1]));
                        break;
                }
                cmd = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(' ',nums));
        }
    }
}
