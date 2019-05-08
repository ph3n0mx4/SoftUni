using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _09PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            long pokePower = long.Parse(Console.ReadLine());  //N
            long pokePowerOriginal = pokePower;
            long distance = long.Parse(Console.ReadLine());   //M
            int exhaustionFactor = int.Parse(Console.ReadLine()); //Y
            long count = 0;

            while (pokePower>=distance)
            {
                pokePower -= distance;
                count += 1;

                if (pokePower ==pokePowerOriginal/2 && exhaustionFactor > 0)
                {
                    pokePower /= exhaustionFactor;
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(count);
        }
    }
}
