namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Pokemon
    {
        public string PokemonName { get; set; }

        public string Type { get; set; }

        public Pokemon(string pokemonName, string type)
        {
            PokemonName = pokemonName;
            Type = type;
        }
    }
}
