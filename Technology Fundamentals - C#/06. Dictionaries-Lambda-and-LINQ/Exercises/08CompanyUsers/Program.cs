using System;
using System.Collections.Generic;
using System.Linq;

namespace _08CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            var companyList = new Dictionary<string, List <string>>();
            var cmd = Console.ReadLine().Split(" -> ",).ToArray();

            while(cmd[0]!= "End")
            {
                if(!companyList.Keys.Contains(cmd[0]))
                {
                    companyList[cmd[0]] = new List<string>
                    {
                        cmd[1]
                    };

                }

                else if(!companyList[cmd[0]].Contains(cmd[1]))
                {
                    companyList[cmd[0]].Add(cmd[1]);
                }

                cmd = Console.ReadLine().Split(" -> ").ToArray();
            }
            companyList = companyList.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var kvp in companyList)
            {
                Console.WriteLine(kvp.Key);

                for (int i = 0; i < kvp.Value.Count; i++)
                {
                    Console.WriteLine($"-- {kvp.Value[i]}");
                }
            }
            
        }
    }
}
