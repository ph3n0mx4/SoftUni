using System;

namespace _05AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numThree = int.Parse(Console.ReadLine());
            int result =MathOperation(numOne, numTwo, numThree);
            Console.WriteLine(result);

        }

        public static int MathOperation (int num1, int num2, int num3)
        {
            int aritmetic = num1 + num2 - num3;
            return aritmetic;
        }
    }
}
