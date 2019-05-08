using System;
using System.Linq;

namespace _04ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                   .Split()
                                   .Select(int.Parse)
                                   .ToArray();
            int numberOfRotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfRotations; i++)
            {
                for (int j = 0; j < numbers.Length-1; j++)
                {
                    int firstNum = numbers[j];
                    int indexOfReverseCell = j + 1;
                    numbers[j] = numbers[indexOfReverseCell];
                    numbers[indexOfReverseCell] = firstNum;
                }
            }

            Console.WriteLine(String.Join(' ',numbers));
        }
    }
}
