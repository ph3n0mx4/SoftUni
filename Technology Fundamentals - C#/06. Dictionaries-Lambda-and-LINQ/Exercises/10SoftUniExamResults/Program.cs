using System;
using System.Linq;
using System.Collections.Generic;

namespace _10SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new Dictionary<string, int>();
            var languageCount = new Dictionary<string, int>();
            string[] input = Console.ReadLine().Split('-');
            var banned = new List<string>();
            while (input[0]!= "exam finished")
            {
                string username = input[0];
                string language = input[1];

                if (language == "banned")
                {
                    banned.Add(username);
                    input = Console.ReadLine().Split('-');
                    continue;
                }

                if (!languageCount.ContainsKey(language))
                {
                    languageCount[language] = 1;
                }

                else
                {
                    languageCount[language]++;
                }
                
                
                int points = int.Parse(input[2]);

                if(!list.ContainsKey(username))
                {
                    list[username] = points;
                }

                else if (list.ContainsKey(username) && list[username] < points)
                {
                    list[username] = points;
                }

                input = Console.ReadLine().Split('-');
            }
           
            Console.WriteLine("Results:");
            foreach (var item in list.OrderBy(x=>-x.Value).ThenBy(x=>x.Key))
            {
                if(banned.Contains(item.Key))
                {
                    continue;
                }
                Console.WriteLine(item.Key+" | "+item.Value);
            }

            Console.WriteLine("Submissions:");
            foreach (var item in languageCount.OrderBy(x=>-x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            //{language} – {submissionsCount}
        }
    }
}
