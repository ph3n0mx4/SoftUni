using System;
using System.Text.RegularExpressions;

namespace _4.ChoreWars_28._10._18
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string regex = @"(?<dishes>(?<=\<)[a-z0-9]+(?=\>))|(?<clean>(?<=\[)[A-Z0-9]+(?=\]))|(?<laundry>(?<=\{).+(?=\}))";
            int timeDishes = 0;
            int timeCleaning = 0;
            int timeLaundry = 0;
            
            while(input != "wife is happy")
            {
                Match match = Regex.Match(input, regex);
                if(!match.Success)
                {
                    input = Console.ReadLine();
                    continue;
                }
                string dishes = match.Groups["dishes"].Value;
                string clean = match.Groups["clean"].Value;
                string laundry = match.Groups["laundry"].Value;

                if(dishes.Length!=0)
                {
                    timeDishes += TimeChore(dishes);
                }

                else if(clean.Length!=0)
                {
                    timeCleaning += TimeChore(clean);
                }

                else if (laundry.Length!=0)
                {
                    timeLaundry += TimeChore(laundry);
                }
                input = Console.ReadLine();
            }
            int totalMinutes = timeCleaning + timeDishes + timeLaundry;
            Console.WriteLine($"Doing the dishes - {timeDishes} min.");
            Console.WriteLine($"Cleaning the house - {timeCleaning} min.");
            Console.WriteLine($"Doing the laundry - {timeLaundry} min.");
            Console.WriteLine($"Total - {totalMinutes} min.");
        }

        public static int TimeChore(string chore)
        {
            int sum = 0;
            string input = chore;
            string regex = @"[0-9]";
            MatchCollection digits = Regex.Matches(input, regex);
            foreach (Match item in digits)
            {
                sum += int.Parse(item.Value);
            }
            return sum;
        }
    }
}
