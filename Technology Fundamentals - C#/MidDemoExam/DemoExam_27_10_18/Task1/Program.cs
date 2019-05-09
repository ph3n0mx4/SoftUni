using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceOfFlour = double.Parse(Console.ReadLine()); //for a package 
            double priceOfEgg = double.Parse(Console.ReadLine());   //for a single egg 
            double priceOfApron = double.Parse(Console.ReadLine());  //for a single apron

            double priceAprons = priceOfApron * Math.Ceiling(students * 1.2);
            double priceFlours = (students - students/5) * priceOfFlour;
            double priceEggs = 10*students * priceOfEgg;
            double sum = priceAprons + priceFlours + priceEggs;

            if(budget>=sum)
            {
                Console.WriteLine($"Items purchased for {sum:f2}$.");
            }

            else
            {
                Console.WriteLine($"{(sum-budget):f2}$ more needed.");
            }
            

        }
    }
}
