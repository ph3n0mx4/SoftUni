namespace Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Vehicle
    {//fuel quantity} {liters per km
        
        private double fuelQuantity;
        private double litersPerKm;
        
        public Vehicle(double fuelQunatity, double litersPerKm)
        {
            this.FuelQuantity = fuelQunatity;
            this.LitersPerKm = litersPerKm;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            set => this.fuelQuantity = value;
        }

        public double LitersPerKm
        {
            get => this.litersPerKm;
            set => this.litersPerKm = value;
        }

        public virtual void Driven (double distance)
        {
            double requiredFuel = this.LitersPerKm * distance;
            bool isDrive = requiredFuel <= this.FuelQuantity;

            if (isDrive)
            {
                this.FuelQuantity -= requiredFuel;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }

            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
