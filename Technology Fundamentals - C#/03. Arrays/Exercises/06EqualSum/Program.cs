using System;
using System.Linq;

namespace _06EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToArray();

            int rightSum = numbers.Sum();
            int leftSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                rightSum -= numbers[i];
                if(rightSum==leftSum)
                {
                    Console.WriteLine(i);
                    return;
                }
                leftSum += numbers[i];
            }
            Console.WriteLine("no");
        }
    }
}
