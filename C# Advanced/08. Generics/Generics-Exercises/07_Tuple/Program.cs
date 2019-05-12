using System;
using System.Linq;

namespace _07_Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine().Split().ToArray();
            string firstName = firstInput[0] + " " + firstInput[1];
            string adress = firstInput[2];

            var firstTuple = new Tuple<string, string>(firstName, adress);

            var secondInput = Console.ReadLine().Split().ToArray();
            string secondName = secondInput[0];
            int litersOfBeer = int.Parse(secondInput[1]);

            var secondTuple = new Tuple<string, int>(secondName, litersOfBeer);

            var thirdInput = Console.ReadLine().Split().ToArray();
            int integer = int.Parse(thirdInput[0]);
            double @double = double.Parse(thirdInput[1]);

            var thirdTuple = new Tuple<int, double>(integer, @double);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
