using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Fighter : BaseMachine, IFighter
    {
        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, 200)
        {
            this.AggressiveMode = true;
            base.AttackPoints += 50;
            base.DefensePoints -= 25;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if(!this.AggressiveMode)
            {//is activated, attack points are increased with 50 and defense points are decreased with 25,
                this.AggressiveMode = true;
                base.AttackPoints += 50;
                base.DefensePoints -= 25;
            }

            else
            {
                this.AggressiveMode = false;
                base.AttackPoints -= 50;
                base.DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            string OnOff;
            if (this.AggressiveMode)
            {
                OnOff = "ON";
            }

            else
            {
                OnOff = "OFF";
            }

            return $"{base.ToString()}{Environment.NewLine} *Aggressive: {OnOff}";
        }
    }
}
