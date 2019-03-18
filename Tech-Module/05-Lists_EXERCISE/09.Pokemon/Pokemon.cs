using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Pokemon
{
    class Pokemon
    {
        static void Main(string[] args)
        {
            List<int> pokemonValues = Console
               .ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            int sumOfValues = 0;

            while (pokemonValues.Count != 0)
            {
                int currentIndex = int.Parse(Console.ReadLine());

                if (currentIndex < 0)
                {
                    int deletedElement = pokemonValues[0];
                    pokemonValues.RemoveAt(0);
                    pokemonValues.Insert(0, pokemonValues.Last());
                    sumOfValues += deletedElement;
                    ManipulatingValues(pokemonValues, deletedElement);
                }
                else if (currentIndex >= pokemonValues.Count)
                {
                    int deletedElement = pokemonValues.Last();
                    pokemonValues.RemoveAt(pokemonValues.Count-1);
                    pokemonValues.Add(pokemonValues[0]);
                    sumOfValues += deletedElement;
                    ManipulatingValues(pokemonValues, deletedElement);
                }
                else
                {
                    int deletedElement = pokemonValues[currentIndex];
                    pokemonValues.RemoveAt(currentIndex);
                    sumOfValues += deletedElement;
                    ManipulatingValues(pokemonValues, deletedElement);
                }
            }
            Console.WriteLine(sumOfValues);
        }

        static void ManipulatingValues(List<int> pokemonValues, int deletedElement)
        {
            for (int i = 0; i < pokemonValues.Count; i++)
            {
                if (pokemonValues[i] <= deletedElement)
                {
                    pokemonValues[i] += deletedElement;
                }
                else
                {
                    pokemonValues[i] -= deletedElement;
                }
            }
        }
    }
}
