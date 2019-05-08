using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int meter = int.Parse(Console.ReadLine());
            double km = meter/1000.0;
            Console.WriteLine($"{km:f2}");
        }
    }
}
