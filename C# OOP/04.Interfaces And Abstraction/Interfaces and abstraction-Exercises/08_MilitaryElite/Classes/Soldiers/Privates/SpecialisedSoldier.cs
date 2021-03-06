﻿using _08_MilitaryElite.Interfaces.Soldier.Private;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite.Classes.Soldiers.Privates
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName,salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get => this.corps;
            private set
            {
                if(value!= "Airforces" && value!= "Marines")
                {
                    throw new ArgumentException();
                }

                this.corps = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}{Environment.NewLine}Corps: {this.Corps}";
        }
    }
}
