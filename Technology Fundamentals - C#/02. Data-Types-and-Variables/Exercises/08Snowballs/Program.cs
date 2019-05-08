using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _08Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int snowballNumber = int.Parse(Console.ReadLine());
            BigInteger maxValue =long.MinValue;
            int snow = 0;
            int time = 1;
            int quality = 0;
            BigInteger result = 0;

            for (int i = 0; i < snowballNumber; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                result = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);
                
                if(result>=maxValue)
                {
                    maxValue = result;
                    snow = snowballSnow;
                    time = snowballTime;
                    quality = snowballQuality;
                }
            }
            Console.WriteLine($"{snow} : {time} = {maxValue} ({quality})");
        }
    }
}
