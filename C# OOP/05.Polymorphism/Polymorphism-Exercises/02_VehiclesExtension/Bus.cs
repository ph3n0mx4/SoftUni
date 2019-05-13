namespace VehiclesExtension
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Bus : Vehicle
    {
        public Bus(double fuelQunatity, double litersPerKm, double tankCapacity) 
            : base(fuelQunatity, litersPerKm, tankCapacity)
        {
        }

        public void DrivenEmpty(double distance)
        {
            base.Driven(distance);
        }

        public new void Driven(double distance)
        {
            double requiredFuel = (this.LitersPerKm+1.4) * distance;
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

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
