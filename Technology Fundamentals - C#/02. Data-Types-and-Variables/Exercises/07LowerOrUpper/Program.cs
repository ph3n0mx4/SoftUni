using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char read = char.Parse(Console.ReadLine());

            if (read >=65 && read <=90)
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
