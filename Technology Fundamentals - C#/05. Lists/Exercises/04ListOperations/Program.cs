using System;
using System.Collections.Generic;
using System.Linq;

namespace _04ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] cmd = Console.ReadLine().Split();

            while(cmd[0]!= "End")
            {
                switch(cmd[0])
                {
                    case "Add":
                        nums.Add(int.Parse(cmd[1]));
                        break;
                    case "Insert":
                        if(int.Parse(cmd[2])>nums.Count-1 || int.Parse(cmd[2])<0)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        nums.Insert(int.Parse(cmd[2]),int.Parse(cmd[1]));
                        break;
                    case "Remove":
                        if (int.Parse(cmd[1]) > nums.Count - 1 || int.Parse(cmd[1]) < 0)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        nums.RemoveAt(int.Parse(cmd[1]));
                        break;
                    case "Shift":
                        if(cmd[1]== "left")
                        {
                            Left(int.Parse(cmd[2]), nums);
                        }

                        else if (cmd[1] == "right")
                        {
                            Right(int.Parse(cmd[2]), nums);
                        }
                        break;
                }

                cmd = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(' ',nums));
        }

        private static void Left(int n, List<int> numL)
        {
            int i = 0;
            while(i<n)
            {
                numL.Add(numL[0]);
                numL.RemoveAt(0);
                i++;
            }
        }

        private static void Right(int n, List<int> numR)
        {
            int i = 0;
            while (i < n)
            {
                int currentNum = numR[numR.Count - 1];
                numR.RemoveAt(numR.Count - 1);
                numR.Insert(0, currentNum);
                i++;
            }
        }
        
    }
}
