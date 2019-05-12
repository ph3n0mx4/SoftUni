namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Trainer
    {
        //Trainers have a name, number of badges and a collection of pokemon
        public string Name { get; set; }

        public int Badges { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            Pokemons = new List<Pokemon>();
        }

        public override string ToString()
        {
            return $"{Name} {Badges} {Pokemons.Count}";
        }
        //Pesho 2 2
        //“<TrainerName> <Badges> <NumberOfPokemon>”.
        //string output = $"{Model}:";
        //output = string.Concat(output, Environment.NewLine);

        //output = string.Concat(output, Engine);
    }
}
