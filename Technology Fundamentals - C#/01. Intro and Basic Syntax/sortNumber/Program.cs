using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int max = Math.Max(num1,(Math.Max(num2, num3)));

            int min = Math.Min(num1, (Math.Min(num2, num3)));

            Console.WriteLine(max);

            if ( (num2 == max && num1 == min) || (num1 == max && num2 == min))
            {
                
                Console.WriteLine(num3);
                
            }

            else if ((num1 == max && num3 == min)|| (num3 == max && num1 == min))
            {
                
                Console.WriteLine(num2);
                
            }

            else if ((num3 == max && num2 == min)|| (num2 == max && num3 == min))
            {
                
                Console.WriteLine(num1);
                
            }

            Console.WriteLine(min);
        }
    }
}
