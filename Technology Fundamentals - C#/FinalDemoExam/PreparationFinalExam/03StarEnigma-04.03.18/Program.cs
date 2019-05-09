using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03StarEnigma_04._03._18
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var decryptedA = new List<string>();
            var decryptedD = new List<string>();
            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                string regex = @"[sStTaArR]";
                MatchCollection match = Regex.Matches(input, regex);
                int matchCount = match.Count;
                string newText = "";
                for (int j = 0; j < input.Length; j++)
                {
                    char symbol = (char)(input[j] - matchCount);
                    newText +=symbol ;
                }

                string validRegex = @"@(?<name>(?<=@)[a-zA-Z]+)[^@\-!:>]*:(?<population>(?<=:)[0-9]+)[^@\-!:>]*!(?<type>(?<=!)[A,D](?=!))![^@\-!:>]*->(?<soldier>(?<=->)[0-9]+)";
                Match validMatch = Regex.Match(newText, validRegex);
                string type = validMatch.Groups["type"].Value;
                string name = validMatch.Groups["name"].Value;
                string population = validMatch.Groups["population"].Value;
                string soldier = validMatch.Groups["soldier"].Value;
                
                if (validMatch.Success)
                {
                    if(type=="A")
                    {
                        decryptedA.Add(name);
                    }

                    else if(type=="D")
                    {
                        decryptedD.Add(name);
                    }
                    
                }

            }
            Console.WriteLine($"Attacked planets: {decryptedA.Count}");
            foreach (var item in decryptedA.OrderBy(x=>x))
            {
                Console.WriteLine($"-> {item}");
            }

            Console.WriteLine($"Destroyed planets: {decryptedD.Count}");
            foreach (var item in decryptedD.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }

        }
    }
}
//"Attacked planets: {attackedPlanetsCount}"
//"-> {planetName}"
//"Destroyed planets: {destroyedPlanetsCount}"
//"-> {planetName}"

