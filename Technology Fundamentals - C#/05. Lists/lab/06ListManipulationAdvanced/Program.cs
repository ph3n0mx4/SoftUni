using System;
using System.Collections.Generic;
using System.Linq;

namespace _06ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse).ToList();
            List<string> cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            int count = 0;
            while(cmd[0]!= "end")
            {
                switch (cmd[0])
                {
                    case "Add":
                        nums.Add(int.Parse(cmd[1]));
                        count++;
                        break;

                    case "Remove":
                        nums.Remove(int.Parse(cmd[1]));
                        count++;
                        break;

                    case "RemoveAt":
                        nums.RemoveAt(int.Parse(cmd[1]));
                        count++;
                        break;

                    case "Insert":
                        nums.Insert(int.Parse(cmd[2]), int.Parse(cmd[1]));
                        count++;
                        break;

                    case "Contains":
                        if (nums.Contains(int.Parse(cmd[1])))
                        {
                            Console.WriteLine("Yes");
                        }

                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;

                    case "PrintEven":
                        for (int i = 0; i < nums.Count; i++)
                        {
                            if (nums[i] % 2 == 0 && nums[i]!=0)
                            {
                                Console.Write(nums[i] + " ");
                            }
                        };
                        Console.WriteLine();
                        break;

                    case "PrintOdd":
                        for (int i = 0; i < nums.Count; i++)
                        {
                            if (nums[i] % 2 == 1)
                            {
                                Console.Write(nums[i] + " ");
                            }
                        };
                        Console.WriteLine();
                        break;

                    case "GetSum":
                        Console.WriteLine(nums.Sum());
                        break;

                    case "Filter":
                        switch (cmd[1])
                        {
                            case "<":
                                List<int> n = new List<int>();
                                for (int i = 0; i < nums.Count; i++)
                                {
                                    if (nums[i] < int.Parse(cmd[2]))
                                    {
                                        n.Add(nums[i]);
                                    }
                                }
                                Console.WriteLine(string.Join(' ',n));
                                break;

                            case ">":
                                List<int> m = new List<int>();
                                for (int i = 0; i < nums.Count; i++)
                                {
                                    if (nums[i] > int.Parse(cmd[2]))
                                    {
                                        m.Add(nums[i]);
                                    }
                                }
                                Console.WriteLine(string.Join(' ',m));
                                break;

                            case "<=":
                                List<int> k = new List<int>();
                                for (int i = 0; i < nums.Count; i++)
                                {
                                    if (nums[i] <= int.Parse(cmd[2]))
                                    {
                                        k.Add(nums[i]);
                                    }
                                }
                                Console.WriteLine(string.Join(' ', k));
                                break;

                            case ">=":
                                List<int> j = new List<int>();
                                for (int i = 0; i < nums.Count; i++)
                                {
                                    if (nums[i] >= int.Parse(cmd[2]))
                                    {
                                        j.Add(nums[i]);
                                    }
                                }
                                Console.WriteLine(string.Join(' ', j));
                                break;
                        }
                        break;
                }

                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            if(count!=0)
            {
                Console.WriteLine(string.Join(' ', nums));
            }
            
        }
    }
}
