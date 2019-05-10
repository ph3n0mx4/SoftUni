using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separator = new char[] {' ', '#' };
            List<string> batches = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries)
                                                    .ToList();
            int maxQuality = int.MinValue;
            double maxGreaterAverageQuality = double.MinValue;
            int fewestElements = int.MaxValue;
            List<int> result = new List<int>();
            while(batches[0]!= "Bake")
            {
                
                List<int> currentSequance = batches.Select(int.Parse).ToList();
                
                int currentQuality = currentSequance.Sum();
                double currentGreaterAverageQuality = currentQuality / currentSequance.Count;
                int currentFewestElements = currentSequance.Count;
                //bool quality = currentQuality == maxQuality;
                //bool averageFirst = currentGreaterAverageQuality > maxGreaterAverageQuality;
                //bool averageSecond = currentGreaterAverageQuality == maxGreaterAverageQuality;
                if (currentQuality>maxQuality)
                {
                    maxQuality=currentQuality;
                    maxGreaterAverageQuality = currentGreaterAverageQuality;
                    fewestElements = currentFewestElements;
                    result = currentSequance;

                    batches = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries)
                                                    .ToList();
                    continue;
                }

                if (currentQuality >= maxQuality && currentGreaterAverageQuality > maxGreaterAverageQuality)
                {
                    maxQuality = currentQuality;
                    maxGreaterAverageQuality = currentGreaterAverageQuality;
                    fewestElements = currentFewestElements;
                    result = currentSequance;

                    batches = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries)
                                                    .ToList();
                    continue;
                }

                if (currentQuality >= maxQuality && currentGreaterAverageQuality >= maxGreaterAverageQuality && currentFewestElements<fewestElements  )
                {
                    maxQuality = currentQuality;
                    maxGreaterAverageQuality = currentGreaterAverageQuality;
                    fewestElements=currentFewestElements;
                    result = currentSequance;

                    batches = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries)
                                                    .ToList();
                    continue;
                }

                batches = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries)
                                                    .ToList();
            }

            Console.WriteLine($"Best Batch quality: {maxQuality}");
            Console.WriteLine(string.Join(' ',result));
        }
    }
}
