using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            string integer = Console.ReadLine();
            int sum = 0;
            int num = int.Parse(integer);

            for (int i = 1; i <=integer.Length; i++)
            {
                sum += num % 10;
                num = num / 10;
            }
            Console.WriteLine(sum);
            
        }
    }
}
