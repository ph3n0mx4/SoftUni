namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            //“< TrainerName > < PokemonName > < PokemonElement > < PokemonHealth >
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var trainers = new List<Trainer>();
            while(input[0]!= "Tournament")
            {
                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealt = int.Parse(input[3]);

                if(!trainers.Any(x=>x.Name==trainerName))
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                }

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealt);
                trainers.First(x => x.Name == trainerName).Pokemons.Add(pokemon);

                input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            var cmd = Console.ReadLine();
            while (cmd!= "End")
            {
                for (int i = 0; i < trainers.Count; i++)
                {
                    if(trainers[i].Pokemons.Any(x=>x.Element==cmd))
                    {
                        trainers[i].Badges++;
                    }

                    else
                    {
                        trainers[i].Pokemons.Select(p => p.Healt -= 10).ToList();
                        trainers[i].Pokemons.RemoveAll(x => x.Healt <= 0);
                    }

                }
                //“Fire”, “Water”, “Electricity”
                cmd = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderBy(x=>-x.Badges))
            {
                Console.WriteLine(trainer);
            }
        }
    }
}
