using System;
using System.Linq;
using System.Collections.Generic;

namespace _10SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new Dictionary<string, Dictionary<string, int>>();
            string[] input = Console.ReadLine().Split('-');
            var banned = new List<string>();
            var languageList = new Dictionary<string, int>();
            while (input[0] != "exam finished")
            {
                string username = input[0];
                string language = input[1];
                if (language == "banned")
                {
                    banned.Add(username);
                    input = Console.ReadLine().Split('-');
                    continue;
                }

                if(!languageList.ContainsKey(language))
                {
                    languageList[language] = 0;
                }
                languageList[language]++;

                int points = int.Parse(input[2]);

                if (!list.ContainsKey(language))
                {
                    list[language] = new Dictionary<string, int>();
                }

                if (!list[language].ContainsKey(username))
                {
                    list[language].Add(username, points);
                }

                else if (list[language].ContainsKey(username) && list[language][username] < points)
                {
                    list[language][username] = points;
                }

                input = Console.ReadLine().Split('-');
            }
            var studentsAndPoints = new Dictionary<string, int>();
            
            foreach (var item in list)
            {
                foreach (var kvp in list[item.Key])
                {
                    studentsAndPoints[kvp.Key] = kvp.Value;
                }
            }
            Console.WriteLine("Results:");
            foreach (var item in studentsAndPoints.OrderBy(x => -x.Value).ThenBy(x => x.Key))
            {
                if (banned.Contains(item.Key))
                {
                    continue;
                }
                Console.WriteLine(item.Key + " | " + item.Value);
            }

            Console.WriteLine("Submissions:");
            foreach (var item in languageList.OrderBy(x => -x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
