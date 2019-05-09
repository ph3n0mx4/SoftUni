using System;
using System.Globalization;

namespace _01SoftuniCoffeeOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal totalPrice = 0;

            for (int i = 0; i < n; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                string stringDate = Console.ReadLine();
                int capsulesCount = int.Parse(Console.ReadLine());

                DateTime date = DateTime.ParseExact(stringDate, "d/M/yyyy", CultureInfo.InvariantCulture);
                int month = date.Month;
                int year = date.Year;
                int days = DateTime.DaysInMonth(year, month);

                decimal price = days * pricePerCapsule * capsulesCount;
                totalPrice += price;
                Console.WriteLine($"The price for the coffee is: ${price:f2}");
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
            

            
            //Console.WriteLine(days);
        }
    }
}
