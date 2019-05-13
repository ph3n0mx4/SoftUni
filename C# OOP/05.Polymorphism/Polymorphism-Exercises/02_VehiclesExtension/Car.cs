namespace VehiclesExtension
{
    public class Car : Vehicle
    {
        public Car(double fuelQunatity, double litersPerKm, double tankCapacity) 
            : base(fuelQunatity, litersPerKm+0.9, tankCapacity)
        {
        }

        public override void Driven(double distance)
        {
            base.Driven(distance);
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
