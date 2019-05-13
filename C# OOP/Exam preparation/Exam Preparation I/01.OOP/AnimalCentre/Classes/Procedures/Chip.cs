using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Classes;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Classes.Procedures
{
    public class Chip : Procedure
    {
        private const int removeHappiness = 5;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);

            if (animal.IsChipped)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }
            animal.IsChipped = true;
            animal.Happiness = animal.Happiness- removeHappiness;

            base.procedureHistory.Add(animal);
        }
    }
}
