namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Car
    {
        //A Car has a model, engine, weight and color.
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Colos { get; set; }

        //public List<Engine> EngineList { get; set; }

        public Car(string model, Engine engine, int weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Colos=color;
        }

        public override string ToString()
        {
            string output = $"{Model}:";
            output = string.Concat(output, Environment.NewLine);

            output = string.Concat(output, Engine);
            output = string.Concat(output, Environment.NewLine);

            if (Weight == -1)
            {
                output = string.Concat(output, $"   Weight: n/a");
            }

            else
            {
                output = string.Concat(output, $"   Weight: {Weight}");
            }
            output = string.Concat(output, Environment.NewLine);

            output = string.Concat(output, $"Color: {Colos}");

            return output;

            //theBestDepartmnet = employees.GroupBy(x => x.Department)
            //.OrderByDescending(y => y.Select(s => s.Salary).Average())
            // .FirstOrDefault()
            // .Key;
        }
    }
}
