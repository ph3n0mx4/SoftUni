using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Classes.Animals
{
    public class Lion : Animal
    {
        public Lion(string name, int happiness, int energy, int procedurTime) 
            : base(name, happiness, energy, procedurTime)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
