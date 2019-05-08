using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double countOfPeople = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double priceForPerson = 0;
            double totalPrice =0;

            if (type == "Students")
            {
                if (dayOfWeek == "Friday")
                {
                    priceForPerson = 8.45;
                }

                else if (dayOfWeek == "Saturday")
                {
                    priceForPerson = 9.80;
                }

                else if (dayOfWeek == "Sunday")
                {
                    priceForPerson = 10.46;
                }
            }

            else if (type == "Business")
            {
                if (dayOfWeek == "Friday")
                {
                    priceForPerson = 10.90;
                }

                else if (dayOfWeek == "Saturday")
                {
                    priceForPerson = 15.60;
                }

                else if (dayOfWeek == "Sunday")
                {
                    priceForPerson = 16;
                }
            }

            else if (type == "Regular")
            {
                if (dayOfWeek == "Friday")
                {
                    priceForPerson = 15;
                }

                else if (dayOfWeek == "Saturday")
                {
                    priceForPerson = 20;
                }

                else if (dayOfWeek == "Sunday")
                {
                    priceForPerson = 22.50;
                }
            }

            if (type == "Students" && countOfPeople>=30 )
            {
                totalPrice =countOfPeople * priceForPerson * 0.85;
            } 

            else if (type == "Business" && countOfPeople >= 100)
            {
                totalPrice = (countOfPeople - 10) * priceForPerson;
            }

            else if (type == "Regular" && countOfPeople >= 10 && countOfPeople <= 20)
            {
                totalPrice = countOfPeople * priceForPerson * 0.95;
            }

            else
            {
                totalPrice = countOfPeople * priceForPerson;
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
