namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumption { get; set; }

        public double Distance { get; set; }

        public Car (string model, double fuelAmount, double fuelConsumption, double distance)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
            Distance = distance;
        }

        public void Drive (double disance)
        {
            bool canContinue = FuelAmount - (disance * FuelConsumption) >= 0;

            if(canContinue)
            {
                FuelAmount -= disance * FuelConsumption;
                Distance += disance;
            }

            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            //“<Model> <fuelAmount>  <distanceTraveled>”. 
            return $"{Model} {FuelAmount:f2} {Distance}";
        }
    }
}
