using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Pokemon_Evolution
{
    public class Pokemon
    {
        static void Main(string[] args)
        {
            var pokemons = new Dictionary<string, List<Evolution>>();

            string input = Console.ReadLine();

            while (input != "wubbalubbadubdub")
            {
                if (input.Contains("->"))
                {
                    string[] currentPokemon = input.Split(new char[] { '-', '>', ' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string name = currentPokemon[0];
                    string type = currentPokemon[1];
                    int index = int.Parse(currentPokemon[2]);

                    if (!pokemons.ContainsKey(name))
                    {
                        pokemons.Add(name, new List<Evolution>());
                        pokemons[name].Add(new Evolution() { Type = type, Index = index });
                    }
                    else
                    {
                        pokemons[name].Add(new Evolution() { Type = type, Index = index });
                    }
                }
                else
                {
                    string name = input;
                    if (pokemons.ContainsKey(name) == true)
                    {
                        Console.WriteLine($"# {name}");
                        foreach (var item in pokemons[name])
                        {
                            Console.WriteLine($"{item.Type} <-> {item.Index}");
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var pokemon in pokemons)
            {
                var evolutions = pokemon.Value.OrderByDescending(x => x.Index).ToList();
                Console.WriteLine($"# {pokemon.Key}");
                foreach (var item in evolutions)
                {
                    Console.WriteLine($"{item.Type} <-> {item.Index}");
                }

            }
        }
    }

    public class Evolution
    {
        public string Type { get; set; }
        public int Index { get; set; }
    }
}
