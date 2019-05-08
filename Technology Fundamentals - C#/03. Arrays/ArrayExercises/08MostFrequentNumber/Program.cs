using System;
using System.Linq;

namespace _08MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToArray();
            int maxCount = 1;
            int minStartIndex = int.MaxValue;
            
            if(numbers.Length==1)
            {
                Console.WriteLine(numbers[0]);
                return;
            }

            for (int i = 0; i < numbers.Length-1 ; i++)
            {
                int currentCount = 1;
                int currentStartIndex = int.MaxValue;
                for (int j = i+1; j < numbers.Length; j++)
                {
                    if(numbers[i]==numbers[j])
                    {
                        currentCount++;
                        
                        if(i<currentStartIndex)
                        {
                            currentStartIndex = i;
                        }

                    }
                }

                if(currentCount==maxCount && currentStartIndex<minStartIndex)
                {
                    minStartIndex = currentStartIndex;
                }
                else if(currentCount>maxCount)
                {
                    maxCount = currentCount;
                    minStartIndex = currentStartIndex;

                }
            }
            if(maxCount==1)
            {
                Console.WriteLine(numbers[0]);
                return;
            }
            Console.WriteLine(numbers[minStartIndex]);
        }
    }
}
