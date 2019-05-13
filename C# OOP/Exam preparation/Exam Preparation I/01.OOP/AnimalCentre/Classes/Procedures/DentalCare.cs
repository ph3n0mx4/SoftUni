using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Classes.Procedures
{
    public class DentalCare : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);

            animal.Happiness += 12;
            animal.Energy += 10;
            base.procedureHistory.Add(animal);
        }
    }
}
