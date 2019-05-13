namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Machines;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots;
        private IList<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (this.pilots.Any(p => p.Name == name))
            {
                return $"Pilot {name} is hired already";
            }
            this.pilots.Add(new Pilot(name));
            return $"Pilot {name} hired";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if(this.machines.Any(m=>m.Name==name))
            {
                return $"Machine {name} is manufactured already";
            }

            var tank = new Tank(name, attackPoints, defensePoints);
            this.machines.Add(tank);
            return $"Tank {name} manufactured - attack: {tank.AttackPoints:f2}; defense: {tank.DefensePoints:f2}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }
            var fighter = new Fighter(name, attackPoints, defensePoints);
            this.machines.Add(fighter);
            return $"Fighter {name} manufactured - attack: {fighter.AttackPoints:F2}; defense: {fighter.DefensePoints:F2}; aggressive: ON";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if(!this.pilots.Any(p=>p.Name== selectedPilotName))
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            if(!this.machines.Any(m=>m.Name== selectedMachineName))
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            var mach = this.machines.First(m => m.Name == selectedMachineName);
            if(mach.Pilot!=null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }
            var pilot = this.pilots.First(p => p.Name == selectedPilotName);
            mach.Pilot = pilot;
            pilot.AddMachine(mach);

            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if (!this.machines.Any(m => m.Name == attackingMachineName))
            {
                return $"Machine {attackingMachineName} could not be found";
            }

            if (!this.machines.Any(m => m.Name == defendingMachineName))
            {
                return $"Machine {defendingMachineName} could not be found";
            }
            var attM = this.machines.First(m => m.Name == attackingMachineName);
            var defM = this.machines.First(m => m.Name == defendingMachineName);

            if (attM.HealthPoints<=0 )
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }

            if (defM.HealthPoints <= 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }

            attM.Attack(defM);
            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defM.HealthPoints:F2}";
        }

        public string PilotReport(string pilotReporting)
        {
            return this.pilots.FirstOrDefault(p => p.Name == pilotReporting).Report();
        }

        public string MachineReport(string machineName)
        {
            return this.machines.FirstOrDefault(p => p.Name == machineName).ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            //if (!this.machines.Any(m => m.Name == fighterName))
            //{
            //    return $"Machine {fighterName} could not be found";
            //}

            if(this.machines.Any(m => m.Name == fighterName && m.GetType().Name == "Fighter"))
            {
                var fighter = (Fighter)this.machines.First(m => m.Name == fighterName);

                fighter.ToggleAggressiveMode();
                return $"Fighter {fighterName} toggled aggressive mode";
            }
            return $"Machine {fighterName} could not be found";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            //if (!this.machines.Any(m => m.Name == tankName))
            //{
            //    return $"Machine {tankName} could not be found";
            //}
            if (this.machines.Any(m => m.Name == tankName && m.GetType().Name=="Tank"))
            {
                ITank tank = (Tank)this.machines.First(m => m.Name == tankName);
                tank.ToggleDefenseMode();
                return $"Tank {tankName} toggled defense mode";
            }

            return $"Machine {tankName} could not be found";
        }
    }
}