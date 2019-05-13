using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            machines = new List<IMachine>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }
                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if(machine==null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }
            this.machines.Add(machine);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} - {this.machines.Count} machines");

            foreach (var machine in this.machines)
            {
                sb.AppendLine(machine.ToString());
                //sb.AppendLine($"- {machine.Name}")
                //    .AppendLine($" *Type: {machine.GetType().Name}")
                //    .AppendLine($" *Health: {machine.HealthPoints}")
                //    .AppendLine($" *Attack: {machine.AttackPoints})")
                //    .AppendLine($" *Defense: {machine.DefensePoints}")
                //    .AppendLine($" *Targets: {machine.}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
