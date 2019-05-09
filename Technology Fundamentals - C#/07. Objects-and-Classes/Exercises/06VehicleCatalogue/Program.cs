using System;
using System.Collections.Generic;
using System.Linq;

namespace _06VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicles = new List<Vehicle>();

            var data = Console.ReadLine().Split(" ").ToArray();

            while(data[0]!= "End")
            {
                Vehicle vehicle = new Vehicle(data);
                vehicles.Add(vehicle);

                data = Console.ReadLine().Split(" ").ToArray();
            }
            
            string receiveModel = Console.ReadLine();
            List<string> receiveModels = new List<string>();
            while(receiveModel!= "Close the Catalogue")
            {
                receiveModels.Add(receiveModel);
                foreach (var item in vehicles.Where(s=>s.Model==receiveModel))
                {
                    Console.WriteLine($"Type: {item.TypeOfVehicle}");
                    Console.WriteLine($"Model: {item.Model}");
                    Console.WriteLine($"Color: {item.Color}");
                    Console.WriteLine($"Horsepower: {item.HorsePower}");
                }
                receiveModel = Console.ReadLine();
            }
            
            double averageCarHP = AverageHP("Car", vehicles);
            double averageTruckHP = AverageHP("Truck",vehicles);

            Console.WriteLine($"Cars have average horsepower of: {averageCarHP:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageTruckHP:f2}.");
        }

        private static double AverageHP(string type, List<Vehicle> vehicles)
        {
            List<Vehicle> existingVehicle = vehicles.Where(x => x.TypeOfVehicle == type).ToList();
            double sum = existingVehicle.Select(x => x.HorsePower).Sum();
            if(existingVehicle.Count==0)
            {
                sum = 0;
                return sum;
            }

            sum /= existingVehicle.Count;
            return sum;
        }
    }

    class Vehicle
    {

        public string TypeOfVehicle { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int HorsePower { get; set; }

        public Vehicle(string[] data)
        {
            if(data[0]=="car")
            {
                TypeOfVehicle = "Car";
            }

            else if (data[0]=="truck")
            {
                TypeOfVehicle = "Truck";
            }
            
            Model = data[1];
            Color = data[2];
            HorsePower = int.Parse(data[3]);
        }
    }
}
