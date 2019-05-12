using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var students = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                string name = input[0];
                double grade = double.Parse(input[1]);

                if(!students.ContainsKey(name))
                {
                    students[name] = new List<double>();
                }

                students[name].Add(grade);
            }

            foreach (var kvp in students)
            {
                Console.Write($"{kvp.Key:f1} -> ");
                foreach (var grade  in kvp.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.Write($"(avg: { kvp.Value.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}
