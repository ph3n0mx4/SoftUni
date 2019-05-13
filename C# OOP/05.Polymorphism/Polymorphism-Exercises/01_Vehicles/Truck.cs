namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQunatity, double litersPerKm)
            : base(fuelQunatity, litersPerKm + 1.6)
        {
        }

        public override void Driven(double distance)
        {
            base.Driven(distance);
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters*0.95);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
