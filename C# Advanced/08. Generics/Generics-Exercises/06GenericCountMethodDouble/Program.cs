using System;
using System.Collections;

namespace _06_GenericCountMethodDouble
{
    class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var box = new Box<double>();
            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box.Add(input);
            }

            double inputForCompare = double.Parse(Console.ReadLine());

            int result = GetCounterOfGreaterElements<double>(inputForCompare, box);
            Console.WriteLine(result);
        }

        public static int GetCounterOfGreaterElements<T>(double template, Box<double> box) 
            where T : IComparable
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
