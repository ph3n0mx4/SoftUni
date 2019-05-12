namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine
    {
        //model, power, displacement and an efficiency. 
        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public Engine(string model, int power, int displacement, string efficiency)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public override string ToString()
        {
            string output= $"  {Model}:";
            output = string.Concat(output, Environment.NewLine);

            output = string.Concat(output, $"   Power: {Power}");
            output = string.Concat(output, Environment.NewLine);

            if(Displacement==-1)
            {
                output = string.Concat(output, $"   Displacement: n/a");
            }

            else
            {
                output = string.Concat(output, $"   Displacement: {Displacement}");
            }

            output = string.Concat(output, Environment.NewLine);
            output = string.Concat(output, $"   Efficiency: {Efficiency}");
            return output;
        }
    }
}
