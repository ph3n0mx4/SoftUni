using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberA = double.Parse(Console.ReadLine());
            double numberb = double.Parse(Console.ReadLine());
            double eps = 0.000001;
            double diff = Math.Abs(numberA-numberb);

            bool tru3 = diff < eps;
            //bool fals3 = diff >= eps;

            if(tru3)
            {
                Console.WriteLine("True");
            }
            
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
