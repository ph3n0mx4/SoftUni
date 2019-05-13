using System;
using System.Linq;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            var inputCar = Console.ReadLine().Split().ToArray();
            var inputTruck = Console.ReadLine().Split().ToArray();

            var car = new Car(double.Parse(inputCar[1]), double.Parse(inputCar[2]));
            var truck = new Truck(double.Parse(inputTruck[1]), double.Parse(inputTruck[2]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                if(input[0]=="Drive")
                {
                    if(input[1]=="Car")
                    {
                        car.Driven(double.Parse(input[2]));
                    }

                    else
                    {
                        truck.Driven(double.Parse(input[2]));
                    }
                }

                else
                {
                    if (input[1] == "Car")
                    {
                        car.Refuel(double.Parse(input[2]));
                    }

                    else
                    {
                        truck.Refuel(double.Parse(input[2]));
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
