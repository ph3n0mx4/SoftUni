using System;
using System.Numerics;

namespace _08FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            double numOne = double.Parse(Console.ReadLine());
            double numTwo = double.Parse(Console.ReadLine());
            double divideFactorialNums =DivideTwoNumber(numOne, numTwo);
            Console.WriteLine($"{divideFactorialNums:f2}");
        }

        public static double DivideTwoNumber(double num1, double num2)
        {
            double factorialNumOne = FactorialNumber(num1);
            double factorialNumTwo = FactorialNumber(num2);
            double divide = factorialNumOne / factorialNumTwo;
            return divide;
        }

        public static double FactorialNumber(double num)
        {
            double factorial = num;
            for (double i = 1; i < num; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
