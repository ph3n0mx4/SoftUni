using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05RefactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int borderUp = Math.Abs(int.Parse(Console.ReadLine()));
            for (int borderDown = 2; borderDown <= borderUp; borderDown++)
            {
                bool result = true;
                for (int divider = 2; divider < borderDown; divider++)         //2-> true
                {
                    if (borderDown % divider == 0)
                    {
                        result = false;
                        break;
                    }
                }

                Console.WriteLine($"{borderDown} -> {result.ToString().ToLower()}");
            }

        }
    }
}
