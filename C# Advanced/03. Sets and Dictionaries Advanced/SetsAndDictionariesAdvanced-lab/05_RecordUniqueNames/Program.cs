using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new HashSet<string>();
            string[] input = Console.ReadLine().Split(", ").ToArray();

            while(input[0]!="END")
            {
                string direction = input[0];
                string carNumber = input[1];

                if(direction=="IN")
                {
                    list.Add(carNumber);
                }

                else if (direction =="OUT")
                {
                    list.Remove(carNumber);
                }

                input = Console.ReadLine().Split(", ").ToArray();
            }

            if(list.Count==0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }
            foreach (var car in list)
            {
                Console.WriteLine(car);
            }
        }
    }
}
