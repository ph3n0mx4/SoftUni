using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int devisible = 0;
            if (num%10==0)
            {
                devisible = 10;
                Console.WriteLine($"The number is divisible by {devisible}");
            }

            else if (num%7==0)
            {
                devisible = 7;
                Console.WriteLine($"The number is divisible by {devisible}");
            }
            
            else if (num % 6 == 0)
            {
                devisible = 6;
                Console.WriteLine($"The number is divisible by {devisible}");
            }

            else if (num % 3 == 0)
            {
                devisible = 3;
                Console.WriteLine($"The number is divisible by {devisible}");
            }

            else if (num % 2 == 0)
            {
                devisible = 2;
                Console.WriteLine($"The number is divisible by {devisible}");
            }
            
            else
            {
                Console.WriteLine("Not divisible");
            }

            
        }
    }
}
