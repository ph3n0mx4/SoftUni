using _08_MilitaryElite.Classes.Soldiers.Privates.SpecialisedSoldiers.Sets;
using _08_MilitaryElite.Interfaces.Soldier.Private.SpecialisedSoldier;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite.Classes.Soldiers.Privates.SpecialisedSoldiers
{
    public class Commando : SpecialisedSoldier, ICommando
    { 
        private List<Mission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<Mission>();
        }

        public List<Mission> Missions
        {
            get => this.missions;
            private set => this.missions = value;
        }

        

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (this.Missions.Count > 0)
            {
                sb.AppendLine();
                foreach (var mission in this.Missions)
                {
                    sb.AppendLine($"  {mission.ToString()}");
                }
            }
            return $"{base.ToString()}{Environment.NewLine}Missions:{sb.ToString()}";
        }
    }
}
