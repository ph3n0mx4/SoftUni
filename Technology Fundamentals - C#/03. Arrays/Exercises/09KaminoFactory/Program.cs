using System;
using System.Linq;

namespace _09KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int[] result = new int[lenght];
            int maxCount = 1;
            int minIndex = 101;
            int sum = 0;
            int bestSequence = 0;
            int loopCounter = 0;

            string sequence = Console.ReadLine();

            while(sequence !="Clone them!")
            {
                loopCounter++;
                int[] dNA = sequence.Split('!',StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int count = 1;
                int countArray = 1;
                int indexOfdNA = 0;
                int sumOfdNA = 0;

                for (int i = 0; i < dNA.Length - 1; i++)
                {
                    if(dNA[i] == 1)
                    {
                        if (dNA[i] == dNA[i + 1])
                        {
                            count++;
                        }
                        else
                        {
                            count = 1;
                            continue;
                        }

                        if (count > countArray)
                        {
                            countArray = count;
                            indexOfdNA = i;
                        }
                    }
                    
                }
               
                sumOfdNA = dNA.Sum();

                if (countArray > maxCount)
                {
                    maxCount = countArray;
                    minIndex = indexOfdNA;
                    result = dNA;
                    sum = sumOfdNA;
                    bestSequence=loopCounter;
                }

                else if (countArray == maxCount && indexOfdNA < minIndex)
                {
                    minIndex = indexOfdNA;
                    result = dNA;
                    sum = sumOfdNA;
                    bestSequence=loopCounter;
                }

                else if (countArray == maxCount && indexOfdNA == minIndex && sum < sumOfdNA)
                {
                    result = dNA;
                    sum = sumOfdNA;
                    bestSequence=loopCounter;
                }
                
                sequence = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSequence} with sum: {sum}.");
            Console.WriteLine(string.Join(' ',result));
        }
    }
}
