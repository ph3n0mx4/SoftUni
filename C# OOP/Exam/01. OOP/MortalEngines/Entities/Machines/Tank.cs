using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Tank : BaseMachine, ITank
    {
        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, 100)
        {
            this.DefenseMode = true;
            base.AttackPoints -= 40;
            base.DefensePoints += 30;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (!this.DefenseMode)
            {//is activated, attack points are decreased with 40 and defense points are increased with 30
                this.DefenseMode = true;
                base.AttackPoints -= 40;
                base.DefensePoints += 30;
            }

            else
            {
                this.DefenseMode = false;
                base.AttackPoints += 40;
                base.DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            string OnOff;
            if (this.DefenseMode)
            {
                OnOff = "ON";
            }

            else
            {
                OnOff = "OFF";
            }

            return $"{base.ToString()}{Environment.NewLine} *Defense: {OnOff}";
        }
    }
}
