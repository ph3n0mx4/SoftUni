using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Classes
{
    public abstract class Animal : IAnimal
    {
        private string name;
        private int happiness;
        private int energy;
        private int procedurTime;
        private string owner;
        private bool isAdopt;
        private bool isChipped;
        private bool isVaccinated;

        public Animal(string name, int energy, int happiness, int procedurTime)
        {
            this.Name = name;
            this.Happiness = happiness;
            this.Energy = energy;
            this.ProcedureTime = procedurTime;
            this.Owner = "Centre";
            this.IsAdopt = false;
            this.isChipped = false;
            this.IsVaccinated = false;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public int Happiness
        {
            get => this.happiness;
            set
            {
                if(value<0 || value >100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                this.happiness = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                this.energy = value;
            }
        }

        public int ProcedureTime
        {
            get => this.procedurTime;
            set => this.procedurTime = value;
        }

        public bool IsAdopt
        {
            get => this.isAdopt;
            set => this.isAdopt = value;
        }
        

        public bool IsChipped
        {
            get => this.isChipped;
            set => this.isChipped = value;
        }

        public bool IsVaccinated
        {
            get => this.isVaccinated;
            set => this.isVaccinated = value;
        }

        public string Owner
        {
            get => this.owner;
            set => this.owner = value;
        }

        public override string ToString()
        {
            string output = $"    Animal type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
            return output;
        }
        //"    Animal type: {animal type} - {animal name} - Happiness: {animal happiness} - Energy: {animal energy}"
    }
}
