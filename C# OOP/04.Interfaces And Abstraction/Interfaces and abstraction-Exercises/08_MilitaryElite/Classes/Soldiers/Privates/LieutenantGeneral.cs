using _08_MilitaryElite.Interfaces.Soldier.Private;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite.Classes.Soldiers.Privates
{
    public class LieutenantGeneral : Private,ILieutenantGeneral
    {
        private List<Private> privates;
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            privates = new List<Private>();
        }

        public List<Private> Privates
        {
            get =>this.privates;
            private set => this.privates = value;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if(this.Privates.Count>0)
            {
                //sb.AppendLine();
                //sb.AppendLine("Privates:");
                foreach (var p in this.Privates)
                {
                    sb.AppendLine($"  {p.ToString()}");
                }
            }
            return $"{base.ToString()}{Environment.NewLine}{"Privates:"}{sb.ToString().TrimEnd()}";
        }
    }
}
