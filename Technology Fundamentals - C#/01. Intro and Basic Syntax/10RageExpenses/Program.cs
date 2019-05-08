using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int countLostGame = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            double sum = 0;

            int breakH = countLostGame / 2;
            int breakM = countLostGame / 3;
            int breakK = breakM/2;
            int breakD = breakK/2;

            sum = breakH * headsetPrice + breakM * mousePrice + breakK * keyboardPrice + breakD * displayPrice;

            Console.WriteLine($"Rage expenses: {sum:f2} lv.");
        }
    }
}
