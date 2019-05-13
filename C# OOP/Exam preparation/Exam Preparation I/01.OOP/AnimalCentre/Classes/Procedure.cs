﻿using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Classes
{
    public abstract class Procedure : IProcedure
    {
        protected List<IAnimal> procedureHistory;

        protected Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }

        public abstract void DoService(IAnimal animal, int procedureTime);

        public string History()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);

            var procedures = this.procedureHistory
                .Select(p=>p.ToString())
                .ToArray();
            sb.AppendLine(string.Join(Environment.NewLine, procedures));

            return sb.ToString().Trim();
        }

        protected void CheckTime(int time, IAnimal animal)
        {
            if(time<=animal.ProcedureTime)
            {
                animal.ProcedureTime -= time;
            }

            else
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
        }
    }
}
