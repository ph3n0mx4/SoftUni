using System;
using System.Collections.Generic;
using System.Linq;

namespace _08LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sequence = Console.ReadLine().Split(new[]{' ','\t'}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            decimal sum = 0;
            foreach (var item in sequence)
            {
                char firstLetter = item[0];
                if(!(firstLetter>=65 && firstLetter<=90) && !(firstLetter >= 97 && firstLetter <= 122))
                {
                    continue;
                }
                char secondLetter = item[item.Length-1];
                if (!(secondLetter >= 65 && secondLetter <= 90) && !(secondLetter >= 97 && secondLetter <= 122))
                {
                    continue;
                }

                string number = item.TrimStart(item[0]).TrimEnd(item[item.Length - 1]);
                sum += EndNumber(firstLetter, secondLetter, number);
                //Console.WriteLine(firstLetter);
                //Console.WriteLine(secondLetter);
                //Console.WriteLine(number);

            }

            Console.WriteLine($"{sum:f2}");
        }

        private static decimal EndNumber(char firstLetter, char secondLetter, string number)
        {
            decimal num = decimal.Parse(number);
            if (!(num >= 0) && !(num <= 2147483647))
            {
                return num = 0;
            }
            int positionFirstLetter = 0;
            int positionSecondLetter = 0;

            if(char.IsLower(firstLetter))
            {
                positionFirstLetter = firstLetter - 96;
                //Console.WriteLine(positionFirstLetter);
                num *= positionFirstLetter;
            }

            else if(char.IsUpper(firstLetter))
            {
                positionFirstLetter = firstLetter - 64;
                num /= positionFirstLetter;
            }

            if(char.IsLower(secondLetter))
            {
                positionSecondLetter = secondLetter - 96;
                num += positionSecondLetter;
            }

            else if (char.IsUpper(secondLetter))
            {
                positionSecondLetter = secondLetter - 64;
                num -= positionSecondLetter;
            }
            return num;
        }
    }
}
