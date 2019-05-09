using System;

namespace _01SmallestOfThreeNumbers
{
    class Program
    {
        public static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int result = SmallestNumber(firstNum, secondNum, thirdNum);
            Console.WriteLine(result);
            
        }

        public static int SmallestNumber(int firstNum, int secondNum, int thirdNum)
        {
            int result = Math.Min(Math.Min(firstNum, secondNum), thirdNum);
            return result;
        }
    }
}
