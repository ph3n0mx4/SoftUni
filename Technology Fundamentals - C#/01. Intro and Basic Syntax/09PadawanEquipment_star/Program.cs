using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09PadawanEquipment_star
{
    class Program
    {
        static void Main(string[] args)
        {
            double amount = double.Parse(Console.ReadLine());
            int countOfStudent = int.Parse(Console.ReadLine());
            double priceOfLS = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelt = double.Parse(Console.ReadLine());
            double totalPrice = 0;

            priceOfLS *= Math.Ceiling(1.1*countOfStudent);
            priceOfBelt *= countOfStudent  - (countOfStudent/ 6);
            priceOfRobes *= countOfStudent;

            totalPrice = priceOfRobes +priceOfLS+priceOfBelt ;

            if(totalPrice<=amount)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }

            else
            {
                totalPrice -= amount;
                Console.WriteLine($"Ivan Cho will need {totalPrice:f2}lv more.");
            }


        }
    }
}
