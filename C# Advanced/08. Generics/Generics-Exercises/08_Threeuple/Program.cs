using System;
using System.Linq;

namespace _08_Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine().Split().ToArray();
            string firstName = firstInput[0] + " " + firstInput[1];
            string adress = firstInput[2];
            string town = firstInput[3];

            var firstTuple = new Threeuple<string, string, string>(firstName, adress, town);

            var secondInput = Console.ReadLine().Split().ToArray();
            string secondName = secondInput[0];
            int litersOfBeer = int.Parse(secondInput[1]);
            bool drunkOrNot = secondInput[2] == "drunk" ? true : false;

            var secondTuple = new Threeuple<string, int,bool>(secondName, litersOfBeer,drunkOrNot);

            var thirdInput = Console.ReadLine().Split().ToArray();
            string integer = thirdInput[0];
            double @double = double.Parse(thirdInput[1]);
            string bancName = thirdInput[2];
            var thirdTuple = new Threeuple<string, double,string>(integer, @double,bancName);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
            
        }
    }
}
