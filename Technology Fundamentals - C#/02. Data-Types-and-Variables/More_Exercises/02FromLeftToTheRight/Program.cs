using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int numLines = int.Parse(Console.ReadLine());

            for (int i = 0; i <numLines; i++)
                {
                string[] nums = Console.ReadLine().Split(' ');
                long sum = 0;
                string num1 = nums[0];
                string num2 = nums[1];

                long num1Integer = long.Parse(num1);
                long num2Integer = long.Parse(num2);

                if (num1Integer>num2Integer)
                {
                    for (int j = 0; j < num1.Length; j++)
                    {
                        sum += Math.Abs(num1Integer % 10);
                        num1Integer /= 10;
                    }
                    Console.WriteLine(sum);
                }

                else
                {
                    for (int k = 0; k < num2.Length; k++)
                    {
                        sum +=Math.Abs(num2Integer % 10);
                        num2Integer /= 10;
                    }
                    Console.WriteLine(sum);
                }
            }
        }
    }
}
