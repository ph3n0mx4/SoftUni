using System;
using System.Collections.Generic;
using System.Linq;

namespace _06Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var listCourses = new Dictionary<string, List<string>>();
            string[] cmd = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (cmd[0] != "end") 
            {
                
                if (!listCourses.ContainsKey(cmd[0]))
                {
                    listCourses[cmd[0]] = new List<string>();
                }
                
                listCourses[cmd[0]].Add(cmd[1]);

                cmd = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            listCourses = listCourses.OrderBy(x => -x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in listCourses)
            {
                string resultKey = kvp.Key;
                List<string> resultValue = kvp.Value;
                resultValue.Sort();

                Console.WriteLine($"{resultKey}: {kvp.Value.Count}");

                for (int i = 0; i < resultValue.Count; i++)
                {
                    Console.WriteLine($"-- {resultValue[i]}");
                }
            }
        }
    }
}
