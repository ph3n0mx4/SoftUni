using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            string name = string.Empty;

            if (age >= 66) 
            {
                name = "elder";
            }

            else if (age >= 20 && age <= 65) 
            {
                name = "adult";
            }
            else if (age >= 14 && age <= 19)
            {
                name = "teenager";
            }

            else if (age >= 3 && age <= 13)
            {
                name = "child";
            }

            else if (age >= 0 && age <= 2)
            {
                name = "baby";
            }

            Console.WriteLine(name);
        }
    }
}
