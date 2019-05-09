using System;
using System.Collections.Generic;
using System.Linq;

namespace _02Command_nterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> series = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string[] cmd = Console.ReadLine().Split().ToArray();

            while (cmd[0] != "end")
            {
                if(cmd[0]== "reverse")
                {
                    int startIndex = int.Parse(cmd[2]);
                    int count = int.Parse(cmd[4]);
                    int sum = startIndex + count - 1;
                    if (startIndex < 0 || startIndex > series.Count - 1 || count < 0 || sum > series.Count - 1) // || count >= series.Count - 1) 
                    {
                        Console.WriteLine("Invalid input parameters.");
                        cmd = Console.ReadLine().Split().ToArray();
                        continue;
                    }
                    ArrayReverse(startIndex, count, series);
                }

                else if(cmd[0] == "sort")
                {
                    int startIndex = int.Parse(cmd[2]);
                    int count = int.Parse(cmd[4]);
                    int sum = startIndex + count - 1;
                    if (startIndex < 0 || startIndex > series.Count - 1 || count < 0 || sum > series.Count - 1) // || count >= series.Count - 1) 
                    {
                        Console.WriteLine("Invalid input parameters.");
                        cmd = Console.ReadLine().Split().ToArray();
                        continue;
                    }
                    ArraySort(startIndex, count, series);
                }

                else if(cmd[0] == "rollLeft")
                {
                    int num = int.Parse(cmd[1]);
                    if(num<=0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        cmd = Console.ReadLine().Split().ToArray();
                        continue;
                    }

                    if (num > series.Count)
                    {
                        num %= series.Count;
                    }
                    RollLeft(num, series);
                }

                else if(cmd[0] == "rollRight")
                {
                    int num = int.Parse(cmd[1]);
                    if (num <= 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        cmd = Console.ReadLine().Split().ToArray();
                        continue;
                    }

                    if(num>series.Count)
                    {
                        num %= series.Count;
                    }
                    RollRight(num, series);
                }
                

                cmd = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine($"[{string.Join(", ", series)}]");
        }

        private static void RollRight(int num, List<string> series)
        {
            for (int i = 0; i < num; i++)
            {
                string lastString = series[series.Count - 1];
                series.RemoveAt(series.Count - 1);
                series.Insert(0, lastString);
            }
        }

        private static void RollLeft(int num, List<string> series)
        {
            for (int i = 0; i < num; i++)
            {
                series.Add(series[0]);
                series.RemoveAt(0);
            }
        }

        public static void ArraySort(int startIndex, int count, List<string> series)
        {
            List<string> currentList = new List<string>();
            for (int i = 0; i < count; i++)
            {
                currentList.Add(series[i + startIndex]);
            }
            series.RemoveRange(startIndex, count);
            currentList = currentList.OrderBy(x => x).ToList();
            series.InsertRange(startIndex, currentList);
        }

        public static void ArrayReverse(int startIndex, int count, List<string> series)
        {
            List<string> currentList = new List<string>();

            for (int i = 0; i < count; i++)
            {
                currentList.Add(series[i + startIndex]);
            }
            series.RemoveRange(startIndex, count);
            currentList.Reverse();
            series.InsertRange(startIndex, currentList);
        }
    }
}
