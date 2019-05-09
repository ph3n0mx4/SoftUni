using System;
using System.Collections.Generic;
using System.Linq;

namespace _07StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n= int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if(!students.Keys.Contains(name))
                {
                    students[name] = new List<double>();
                }

                students[name].Add(grade);
            }

            var result = students.Where(x => x.Value.Average()>=4.50).OrderBy(x => -x.Value.Average());

            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Average():f2}");
            }
        }
    }
}
