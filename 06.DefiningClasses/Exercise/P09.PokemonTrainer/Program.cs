using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string command1 = Console.ReadLine();
            while (command1 != "Tournament")
            {
                string[] cmdArgs = command1.Split();
                string trainerName = cmdArgs[0];
                string pokemonName = cmdArgs[1];
                string pokemonElement = cmdArgs[2];
                int health = int.Parse(cmdArgs[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, health);

                if (trainers.Any(t => t.Name == trainerName))
                {
                    trainers.Single(t => t.Name == trainerName).Pokemons.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName, pokemon);
                    trainers.Add(trainer);
                }

                command1 = Console.ReadLine();
            }

            string neededElement = Console.ReadLine();
            while (neededElement != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == neededElement))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.Pokemons.RemoveAll(p => p.ReduceHealth(10));
                    }
                }

                neededElement = Console.ReadLine();
            }

            foreach (var trainer in trainers
                .OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine(trainer);
            }
        }
    }
}
