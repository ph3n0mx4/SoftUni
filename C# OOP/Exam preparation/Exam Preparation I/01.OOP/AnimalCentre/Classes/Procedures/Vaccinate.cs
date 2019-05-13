using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Classes.Procedures
{
    public class Vaccinate : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);

            animal.IsVaccinated = true;
            animal.Energy -= 8;
            base.procedureHistory.Add(animal);
        }
    }
}
