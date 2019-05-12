namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string model = input[0];
                int speed = int.Parse(input[1]);
                int power = int.Parse(input[2]);
                int weight = int.Parse(input[3]);
                string type = input[4];

                Engine engine = new Engine(speed, power);
                Cargo cargo = new Cargo(weight, type);
                List<Tire> tires = new List<Tire>();

                for (int j = 0; j < 4; j++)
                {
                    double pressure = double.Parse(input[5+j*2]);
                    int age = int.Parse(input[6+j*2]);
                    Tire tire = new Tire(age,pressure);
                    tires.Add(tire);
                }

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string cmd = Console.ReadLine();
            var resultCars = new List<Car>();
            if (cmd=="fragile")
            {
                resultCars = cars.Where(x => x.Cargo.Type == cmd && x.Tires.Any(y=>y.Pressure<1)).ToList();
            }

            else
            {
                resultCars = cars.Where(x => x.Cargo.Type == cmd && x.Engine.Power>250).ToList();
            }
            

            foreach (var car in resultCars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
