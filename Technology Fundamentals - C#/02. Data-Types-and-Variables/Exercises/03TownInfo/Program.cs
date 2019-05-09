using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03TownInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            string population = Console.ReadLine();
            string area = Console.ReadLine();

            Console.WriteLine($"Town {town} has population of {population} and area {area} square km.");
        }
    }
}
