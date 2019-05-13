using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AnimalCentre.Classes
{
    public class Hotel : IHotel
    {
        private const int capacity = 10;
        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals
        {
            get => new ReadOnlyDictionary<string, IAnimal>(this.animals);
        }

        public void Accommodate(IAnimal animal)
        {
            if(this.animals.Count>=capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if(this.animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals[animal.Name] = animal;
        }

        public void Adopt(string animalName, string owner)
        {
            if(this.animals.ContainsKey(animalName))
            {
                IAnimal animal = this.animals[animalName];
                animal.Owner = owner;
                animal.IsAdopt = true;
                this.animals.Remove(animalName);
            }

            else
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
            
        }
    }
}
