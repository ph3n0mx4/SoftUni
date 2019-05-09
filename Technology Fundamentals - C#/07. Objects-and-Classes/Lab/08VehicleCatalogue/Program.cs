using System;
using System.Collections.Generic;
using System.Linq;

namespace _08VehicleCatalogue
{
    class Truck
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public string Weight { get; set; }

        public Truck(string[] cmd)
        {
            Brand = cmd[1];
            Model = cmd[2];
            Weight = cmd[3];
        }
    }

    class Car
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public string HorsePower { get; set; }

        public Car(string[] cmd)
        {
            Brand = cmd[1];
            Model = cmd[2];
            HorsePower = cmd[3];
        }
    }
    class CatalogueVehicle
    {
        public List <Car> Cars { get; set; }

        public List <Truck> Trucks { get; set; }

        public CatalogueVehicle(List<Car> cars, List<Truck> trucks)
        {
            
           Cars = cars;
           Trucks = trucks;
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] cmd = Console.ReadLine().Split('/').ToArray();
            var cars = new List<Car>();
            var trucks = new List<Truck>();

            while(cmd[0]!= "end")
            {
                if(cmd[0]== "Car")
                {
                    cars.Add(new Car(cmd));
                }

                else if(cmd[0] == "Truck")
                {
                    trucks.Add(new Truck(cmd));
                }

                cmd = Console.ReadLine().Split('/').ToArray();
            }
            var catalogueVehicle = new CatalogueVehicle(cars,trucks);

            if (catalogueVehicle.Cars.Count != 0)
            {
                Console.WriteLine("Cars:");
            }
            foreach (var item in catalogueVehicle.Cars.OrderBy(x=>x.Brand))
            {
                Console.WriteLine($"{item.Brand}: {item.Model} - {item.HorsePower}hp");
            }

            if (catalogueVehicle.Trucks.Count != 0)
            {
                Console.WriteLine("Trucks:");
            }
            
            foreach (var item in catalogueVehicle.Trucks.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{item.Brand}: {item.Model} - {item.Weight}kg");
            }


        }
    }
}

