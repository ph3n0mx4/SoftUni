namespace VehiclesExtension
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Vehicle
    {//fuel quantity} {liters per km
        
        private double fuelQuantity;
        private double litersPerKm;
        private double tankCapacity;
        //{initial fuel quantity} {liters per km} {tank capacity}
        public Vehicle(double fuelQunatity, double litersPerKm ,double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQunatity;
            this.LitersPerKm = litersPerKm;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            set
            {
                if(value>this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
                
            }
        }

        public double LitersPerKm
        {
            get => this.litersPerKm;
            set => this.litersPerKm = value;
        }

        public double TankCapacity
        {
            get => this.tankCapacity;
            set => this.tankCapacity = value;
        }

        public virtual void Driven (double distance)
        {
            double requiredFuel = this.LitersPerKm * distance;
            bool isDrive = requiredFuel <= this.FuelQuantity;

            if (isDrive)
            {
                this.FuelQuantity -= requiredFuel;
                throw new ArgumentException($"{this.GetType().Name} travelled {distance} km");
            }

            else
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double liters)
        {
            bool moreFuel = this.FuelQuantity + liters<=this.TankCapacity;

            if(liters<=0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            else if(!moreFuel)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            else if(moreFuel && liters>0)
            {
                this.FuelQuantity += liters;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
