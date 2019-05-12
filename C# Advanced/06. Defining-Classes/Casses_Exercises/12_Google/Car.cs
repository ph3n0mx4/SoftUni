namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        public string Model { get; set; }

        public int Speed { get; set; }

        public Car(string model, int speed)
        {
            Model = model;
            Speed = speed;
        }

        //public override string ToString()
        //{
        //    string output = $"Car: {Model} {Speed}";
        //    return output;
        //}
    }
}
