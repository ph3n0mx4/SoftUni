using System;
using System.Linq;

namespace VehiclesExtension
{
    public class Program
    {
        static void Main(string[] args)
        {

            var inputCar = Console.ReadLine().Split().ToArray();
            var inputTruck = Console.ReadLine().Split().ToArray();
            var inputBus = Console.ReadLine().Split().ToArray();
            //{initial fuel quantity} {liters per km} {tank capacity}
            var car = new Car(double.Parse(inputCar[1]), double.Parse(inputCar[2]), double.Parse(inputCar[3]));
            var truck = new Truck(double.Parse(inputTruck[1]), double.Parse(inputTruck[2]), double.Parse(inputTruck[3]));
            var bus = new Bus(double.Parse(inputBus[1]), double.Parse(inputBus[2]), double.Parse(inputBus[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                try
                {
                    if (input[0] == "Drive")
                    {
                        if (input[1] == "Car")
                        {
                            car.Driven(double.Parse(input[2]));
                        }

                        else if(input[1] == "Truck")
                        {
                            truck.Driven(double.Parse(input[2]));
                        }

                        else
                        {
                            bus.Driven(double.Parse(input[2]));
                        }
                    }

                    else if(input[0] == "Refuel")
                    {
                        if (input[1] == "Car")
                        {
                            car.Refuel(double.Parse(input[2]));
                        }

                        else if(input[1] == "Truck")
                        {
                            truck.Refuel(double.Parse(input[2]));
                        }

                        else
                        {
                            bus.Refuel(double.Parse(input[2]));
                        }
                    }

                    else
                    {
                        bus.DrivenEmpty(double.Parse(input[2]));
                    }
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);

        }
    }
}
