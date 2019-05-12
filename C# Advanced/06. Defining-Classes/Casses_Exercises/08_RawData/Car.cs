namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }
        private string model;

        public string Model
        {
            get => model;
            set => model = value;
        }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public List<Tire> Tires { get; set; }

        public override string ToString()
        {
            return $"{Model}";
        }
    }
}
