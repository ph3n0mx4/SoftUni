using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(", ").ToArray();
            string letterPattern = @"[A-Za-z]";
            string numPattern = @"[0-9]";
            string input = Console.ReadLine();
            var racer = new Dictionary<string, int>();
            while (input!= "end of race")
            {
                string name = "";
                int num = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    string a = input.Substring(i, 1);
                    Match matchL = Regex.Match(a, letterPattern);
                    Match matchN = Regex.Match(a, numPattern);

                    if(matchL.Success)
                    {
                        name += input[i];
                    }

                    else if(matchN.Success)
                    {
                        num += int.Parse(input[i].ToString());
                    }
                }

                if(!racer.ContainsKey(name))
                {
                    racer[name] = num;
                }
                
                else
                {
                    racer[name] += num;
                }

                input = Console.ReadLine();
            }

            int count = 1;
            foreach (var kvp in racer.OrderBy(x=>-x.Value))
            {
                if(count>3)
                {
                    break;
                }
                if(!names.Contains(kvp.Key))
                {
                    continue;
                }

                if(count==1)
                {
                    Console.WriteLine($"1st place: {kvp.Key}");
                }

                else if(count==2)
                {
                    Console.WriteLine($"2nd place: {kvp.Key}");
                }

                else if (count == 3)
                {
                    Console.WriteLine($"3rd place: {kvp.Key}");
                }

                count++;
            }
        }
    }
}
