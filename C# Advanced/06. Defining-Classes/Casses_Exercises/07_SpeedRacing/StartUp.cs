namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int countCars = int.Parse(Console.ReadLine());

            var cars = new List<Car>();
            for (int i = 0; i < countCars; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                //“<Model> <FuelAmount> <FuelConsumptionFor1km>”. All cars start at 0 kilometers traveled
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);
                double distanse = 0;

                Car car = new Car(model, fuelAmount, fuelConsumption, distanse);
                cars.Add(car);
            }

            var cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (cmd[0]!="End")
            {
                string currentModel = cmd[1];
                double currentDistance = double.Parse(cmd[2]);
                int currentIndex = cars.IndexOf(cars.Find(x => x.Model == currentModel));
                cars[currentIndex].Drive(currentDistance);

                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
