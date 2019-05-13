using AnimalCentre.Classes;
using AnimalCentre.Classes.Animals;
using AnimalCentre.Classes.Procedures;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre
{
    public class AnimalCentre
    {
        private IHotel hotel;
        private IDictionary<string, IProcedure> procedures;
        private IDictionary<string, List<string>> adoptedAnimals;
        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.procedures = new Dictionary<string, IProcedure>
            {
                {"Chip",new Chip() },
                {"DentalCare",new DentalCare() },
                {"Fitness",new Fitness() },
                {"NailTrim",new NailTrim() },
                {"Play",new Play() },
                {"Vaccinate",new Vaccinate() }
            };
            this.adoptedAnimals = new Dictionary<string, List<string>>();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = null;
            switch (type.ToLower())
            {
                case "cat":
                    animal = new Cat(name,happiness,energy,procedureTime);
                    break;
                case "dog":
                    animal = new Dog(name, happiness, energy, procedureTime);
                    break;
                case "lion":
                    animal = new Lion(name, happiness, energy, procedureTime);
                    break;
                case "pig":
                    animal = new Pig(name, happiness, energy, procedureTime);
                    break;
            }
            this.hotel.Accommodate(animal);
            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            CheckExistingAnimal(name);
            var animal = this.hotel.Animals[name];
            this.procedures["Chip"].DoService(animal, procedureTime);
            
            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            CheckExistingAnimal(name);
            var animal = this.hotel.Animals[name];
            this.procedures["Vaccinate"].DoService(animal, procedureTime);
            
            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            CheckExistingAnimal(name);
            var animal = this.hotel.Animals[name];
            this.procedures["Fitness"].DoService(animal, procedureTime);

            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            CheckExistingAnimal(name);
            var animal = this.hotel.Animals[name];
            this.procedures["Play"].DoService(animal, procedureTime);

            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            CheckExistingAnimal(name);
            var animal = this.hotel.Animals[name];
            this.procedures["DentalCare"].DoService(animal, procedureTime);

            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            CheckExistingAnimal(name);
            var animal = this.hotel.Animals[name];
            this.procedures["NailTrim"].DoService(animal, procedureTime);

            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            CheckExistingAnimal(animalName);

            bool isExistOwner = this.adoptedAnimals.ContainsKey(owner);
            if(!isExistOwner)
            {
                this.adoptedAnimals[owner] = new List<string>();
            }
            this.adoptedAnimals[owner].Add(animalName);

            var animal = this.hotel.Animals[animalName];
            this.hotel.Adopt(animalName, owner);

            return animal.IsChipped
                ? $"{owner} adopted animal with chip"
                : $"{owner} adopted animal without chip";
        }

        public string History(string type)
        {
            return this.procedures[type].History();
        }

        private void CheckExistingAnimal(string animalName)
        {
            bool isExist = this.hotel.Animals.ContainsKey(animalName);
            if(!isExist)
            {
                throw new ArgumentException("Animal {animalName} does not exist");
            }
        }
    }
}
