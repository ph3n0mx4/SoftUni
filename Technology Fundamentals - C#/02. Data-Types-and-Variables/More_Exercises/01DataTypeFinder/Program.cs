using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _01DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while(text!="END")
            {

                if (int.TryParse(text, out int result))
                {
                    Console.WriteLine($"{text} is integer type");
                }

                else if (double.TryParse(text, out double result2))
                {
                    Console.WriteLine($"{text} is floating point type");
                }

                else if (char.TryParse(text, out char result3))
                {
                    Console.WriteLine($"{text} is character type");
                }

                else if (bool.TryParse(text, out bool result4))
                {
                    Console.WriteLine($"{text} is boolean type");
                }

                else
                {
                    Console.WriteLine($"{text} is string type");
                }

                text = Console.ReadLine();
            }
            
        }
    }
}
