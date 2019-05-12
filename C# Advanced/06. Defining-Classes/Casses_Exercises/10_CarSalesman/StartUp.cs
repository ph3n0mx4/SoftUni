namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int countEngine = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();
            for (int i = 0; i < countEngine; i++)
            {
                //model, power, displacement and an efficiency. 
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string modelEngine = input[0];
                int power = int.Parse(input[1]);
                int displacement=-1;
                string efficiency="n/a";

                if(input.Count()==4)
                {
                    displacement = int.Parse(input[2]);
                    efficiency = input[3];
                }

                else if(input.Count()==3)
                {
                    var isDigit = int.TryParse(input[2], out displacement);
                    if(!isDigit)
                    {
                        efficiency = input[2];
                        displacement = -1;
                    }
                }
                
                Engine engine = new Engine(modelEngine, power, displacement, efficiency);
                engines.Add(engine);
            }


            int countCar= int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int i = 0; i < countCar; i++)
            {
                //model, engine, weight and color
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string model = input[0];
                string modelEngine = input[1];
                int weight = -1;
                string color = "n/a";

                if (input.Count() == 4)
                {
                    weight = int.Parse(input[2]);
                    color = input[3];
                }

                else if (input.Count() == 3)
                {
                    var isDigit = int.TryParse(input[2], out weight);
                    if (!isDigit)
                    {
                        color = input[2];
                        weight = -1;
                    }
                }

                var engine = engines.Find(x => x.Model == modelEngine);

                var car = new Car(model, engine, weight, color);
                cars.Add(car);

            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
            //int parsed;
            //bool isDigit = int.TryParse(info[4], out parsed);
        }
    }
}
