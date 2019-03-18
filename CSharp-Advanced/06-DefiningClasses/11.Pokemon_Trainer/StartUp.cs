using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Trainer> allTrainers = new List<Trainer>();

        while (true)
        {
            string[] input = Console.ReadLine().Split();

            if (input[0] == "Tournament")
            {
                break;
            }

            string trainerName = input[0];
            string pokemonName = input[1];
            string pokemonElement = input[2];
            int pokemonHealth = int.Parse(input[3]);
            var currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            if (!allTrainers.Any(t => t.Name == trainerName))
            {
                var newTrainer = new Trainer(trainerName);
                newTrainer.AddPokemon(currentPokemon);
                allTrainers.Add(newTrainer);
            }
            else
            {
                var currentTrainer = allTrainers.FirstOrDefault(t => t.Name == trainerName);
                currentTrainer.OwnPokemons.Add(currentPokemon);
            }
        }

        while (true)
        {
            string element = Console.ReadLine();

            if (element == "End")
            {
                break;
            }

            foreach (var trainer in allTrainers)
            {
                if (trainer.OwnPokemons.Any(p => p.Element == element))
                {
                    trainer.AddBadge();
                }
                else
                {
                    trainer.ReduceAllPokemonsHealth();
                    trainer.RemoveDeadPokemons();
                }
            }
        }
        
        foreach (var trainer in allTrainers.OrderByDescending(t => t.BadgesCount))
        {
            Console.WriteLine(trainer);
        }
    }
}
