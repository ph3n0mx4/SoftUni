using System;
using System.Collections.Generic;
using System.Linq;

namespace _02ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine().Split(new string[] {" "},StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            var cmd = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            while(cmd[0]!= "end")
            {
                if(cmd[0]== "swap")
                {
                    int indexFirst = int.Parse(cmd[1]);
                    int indexSecond = int.Parse(cmd[2]);
                    long firstNum = sequence[indexFirst];
                    long secondNum = sequence[indexSecond];
                    sequence.Insert(indexFirst, secondNum);
                    sequence.RemoveAt(indexFirst + 1);
                    sequence.Insert(indexSecond, firstNum);
                    sequence.RemoveAt(indexSecond + 1);
                }

                else if(cmd[0] == "multiply")
                {
                    int indexFirst = int.Parse(cmd[1]);
                    int indexSecond = int.Parse(cmd[2]);
                    sequence[indexFirst] = sequence[indexFirst] * sequence[indexSecond];
                }

                else if (cmd[0] == "decrease")
                {
                    sequence = sequence.Select(x => x - 1).ToList();
                }

                cmd = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            Console.WriteLine(string.Join(", ",sequence));
        }
    }
}
