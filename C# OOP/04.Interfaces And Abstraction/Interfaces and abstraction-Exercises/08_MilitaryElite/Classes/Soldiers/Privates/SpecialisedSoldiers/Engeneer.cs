using _08_MilitaryElite.Classes.Soldiers.Privates.SpecialisedSoldiers.Sets;
using _08_MilitaryElite.Interfaces.Soldier.Private.SpecialisedSoldier;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite.Classes.Soldiers.Privates.SpecialisedSoldiers
{
    public class Engeneer : SpecialisedSoldier, IEngeneer
    {
        private List<Repair> repairs;

        public Engeneer(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            repairs = new List<Repair>();
        }

        public List<Repair> Repairs
        {
            get => this.repairs;
            private set => this.repairs = value;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if(this.Repairs.Count>0)
            {
                sb.AppendLine();
                foreach (var repair in this.Repairs)
                {
                    sb.AppendLine($"  {repair.ToString()}");
                }
            }
            return $"{base.ToString()}{Environment.NewLine}Repairs:{sb.ToString().TrimEnd()}";
        }
    }
}
