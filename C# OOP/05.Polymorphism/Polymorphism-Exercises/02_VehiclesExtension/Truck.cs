namespace VehiclesExtension
{
    using System;

    public class Truck : Vehicle
    {
        public Truck(double fuelQunatity, double litersPerKm, double tankCapacity) 
            : base(fuelQunatity, litersPerKm+1.6, tankCapacity)
        {
        }

        public override void Driven(double distance)
        {
            base.Driven(distance);
        }

        public new void Refuel(double liters)
        {
            bool moreFuel = this.FuelQuantity + liters*0.95 <= this.TankCapacity;

            if (liters <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            else if (!moreFuel)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            else if (moreFuel && liters > 0)
            {
                this.FuelQuantity += liters*0.95;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
