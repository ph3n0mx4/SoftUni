using System;
using System.Linq;
using System.Collections.Generic;

namespace _10WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(new[] { ' ', ',','\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int i = 0; i < input.Count; i++)
            {
                string currentTicket = input[i];

                if(currentTicket.Length!=20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                
                string leftSide = currentTicket.Substring(0, 10);
                string rightSide = currentTicket.Substring(10);  //'@', '#', '$' and '^'. 

                int length = 0;
                char symbol = ' ';

                for (int j = 6; j <= 10; j++)
                {
                    if (leftSide.Contains(new string('@', j)) && rightSide.Contains(new string('@', j)))
                    {
                        symbol = '@';
                        length = j;
                    }

                    else if (leftSide.Contains(new string('#', j)) && rightSide.Contains(new string('#', j)))
                    {
                        symbol = '#';
                        length = j;
                    }

                    else if (leftSide.Contains(new string('$', j)) && rightSide.Contains(new string('$', j)))
                    {
                        symbol = '$';
                        length = j;
                    }

                    else if (leftSide.Contains(new string('^', j)) && rightSide.Contains(new string('^', j)))
                    {
                        symbol = '^';
                        length = j;
                    }
                }
                
                
                if(length==10)
                {
                    Console.WriteLine($"ticket \"{currentTicket}\" - {length}{symbol} Jackpot!");
                }

                else if(length >= 6 && length <= 10)
                {
                    Console.WriteLine($"ticket \"{currentTicket}\" - {length}{symbol}");
                }

                else if(length<6)
                {
                    Console.WriteLine($"ticket \"{currentTicket}\" - no match");
                }
            }
        }
    }
}
