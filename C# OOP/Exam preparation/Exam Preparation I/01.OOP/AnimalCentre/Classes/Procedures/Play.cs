using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Classes.Procedures
{
    public class Play : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);

            animal.Energy -= 6;
            animal.Happiness += 12;
            base.procedureHistory.Add(animal);
        }
    }
}
