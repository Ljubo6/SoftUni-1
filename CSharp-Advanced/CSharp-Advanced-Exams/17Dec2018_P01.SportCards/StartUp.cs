using System;
using System.Collections.Generic;
using System.Linq;

namespace _17Dec2018_P01.SportCards
{
    public class StartUp
    {
        public static void Main()
        {
            var cardsHolder = new Dictionary<string, Dictionary<string, double>>();

            string[] input = Console.ReadLine().Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "end")
            {
                if(input[0] == "check")
                {
                    string card = input[1];

                    if (cardsHolder.ContainsKey(card))
                    {
                        Console.WriteLine($"{card} is available!");
                    }
                    else
                    {
                        Console.WriteLine($"{card} is not available!");
                    }

                    input = Console.ReadLine().Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }
                else
                {
                    string card = input[0];
                    string sport = input[1];
                    double price = double.Parse(input[2]);

                    if (!cardsHolder.ContainsKey(card))
                    {
                        cardsHolder[card] = new Dictionary<string, double>
                        {
                            { sport, price }
                        };
                    }
                    else
                    {
                        if (!cardsHolder[card].ContainsKey(sport))
                        {
                            cardsHolder[card].Add(sport, price);
                        }
                        else
                        {
                            cardsHolder[card][sport] = price;
                        }
                    }
                }
                input = Console.ReadLine().Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            }

            cardsHolder = cardsHolder.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            foreach (var card in cardsHolder)
            {
                Console.WriteLine($"{card.Key}:");
                foreach (var sport in card.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"  -{sport.Key} - {sport.Value:f2}");
                }
            }
        }
    }
}
