using System;
using System.Collections;

namespace _05_GenericCountMethodString
{
    class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var box = new Box<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                box.Add(input);
            }

            string inputForCompare = Console.ReadLine();

            int result = GetCounterOfGreaterElements<string>(inputForCompare, box);
            Console.WriteLine(result);
        }

        public static int GetCounterOfGreaterElements<T>(string template, Box<string> box) where T : IComparable
        {
            int count = 0;
            foreach (var item in box.values)
            {
               
                if (item.CompareTo(template) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
