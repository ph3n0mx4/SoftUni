using _08_MilitaryElite.Interfaces.Soldier.Private.SpecialisedSoldier.Sets;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite.Classes.Soldiers.Privates.SpecialisedSoldiers.Sets
{
    public class Mission : IMission
    {
        private string codeName;
        private string state;

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName
        {
            get => this.codeName;
            private set => this.codeName = value;
        }

        public string State
        {
            get => this.state;
            private set
            {
                if(value!= "inProgress" && value!= "Finished")
                {
                    throw new ArgumentException();
                }

                this.state = value;
            }
        }

        public void CompleteMission()
        {
            this.state="Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
