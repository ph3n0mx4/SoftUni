using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Classes.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int happiness, int energy, int procedurTime) 
            : base(name, happiness, energy, procedurTime)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
