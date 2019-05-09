using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

            string firstPart = input[0];
                //.Trim(new char[] {'#', '$','%','*','&' });
            string secondPart = input[1];
            string[] thirdPart = input[2].Split(" ",StringSplitOptions.RemoveEmptyEntries);

            string firstPartRegex = @"[#][A-Z]+[#]|[$][A-Z]+[$]|[%][A-Z]+[%]|[*][A-Z]+[*]|[&][A-Z]+[&]";
            MatchCollection firstPartMatch = Regex.Matches(firstPart, firstPartRegex);
            //var orderLetter = new List<string>();

            foreach (Match item in firstPartMatch)
            {
                firstPart=item.Value.Trim(new char[] { '#', '$', '%', '*', '&' });
            }
            string secondPartRegex = @"([6][5-9]|[7-8][0-9]|90):([0][1-9]|[1][0-9]|20)";
            MatchCollection secondPartMatch = Regex.Matches(secondPart, secondPartRegex);
            var letterAndLeght = new Dictionary<string,int>();
            foreach (Match item in secondPartMatch)
            {
                string[] currentPart = item.Value.Split(":");
                int numOnLetter = int.Parse(currentPart[0].ToString());
                char symbol = (char)numOnLetter;
                string capitalLetter = symbol.ToString();
                string lenghtString = currentPart[1];

                int lenght = 0;

                if (int.Parse(lenghtString.Substring(0)) == 0)
                {
                    lenght = int.Parse(lenghtString.Substring(1)) + 1;
                }
                else
                {
                    lenght = int.Parse(lenghtString) + 1;
                }
                letterAndLeght[capitalLetter] = lenght;
            }

            foreach (var letter in firstPart)
            {
                string capitalLetter = letter.ToString();
                int lenght = letterAndLeght[capitalLetter];
                var words = new List<string>();
                foreach (var item in thirdPart)
                {
                    string word = item;
                    if(!words.Contains(word) && word.Length==lenght && word.Substring(0,1)==capitalLetter)
                    {
                        Console.WriteLine(word);
                        words.Add(word);
                        break;
                    }
                }
                
            }

                //foreach (var item in thirdPart)
                //{
                //    string word = item;
                //    if(word.Substring(0,1)==capitalLetter && word.Length==lenght)
                //    {
                //        Console.WriteLine(word);
                //        break;
                //    }
                //}
            
        }
    }
}
