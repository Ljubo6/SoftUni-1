using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Hands_On_Cards
{
    class Program
    {
        static void Main(string[] args)
        {

            var cardsPlayers = new Dictionary<string, List<string>>();

            var cardsValue = new Dictionary<char, int>
            { { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 },
              { '1', 10 }, { 'J', 11 }, { 'Q', 12 }, { 'K', 13 }, { 'A', 14 }, { 'C', 1 }, { 'D', 2 }, { 'H', 3 }, { 'S', 4 } };

            var playersTotalPoints = new Dictionary<string, int>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(':').ToArray();

                if (input[0] != "JOKER")
                {
                    string player = input[0];
                    string hand = input[1];
                    if (!cardsPlayers.ContainsKey(player))
                    {
                        cardsPlayers[player] = hand
                            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

                        cardsPlayers[player] = cardsPlayers[player].Distinct().ToList();
                    }
                    else
                    {
                        cardsPlayers[player].AddRange(hand
                            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

                        cardsPlayers[player] = cardsPlayers[player].Distinct().ToList();
                    }
                }
                else
                {
                    foreach (var kvp in cardsPlayers)
                    {
                        int sum = 0;
                        int cardValue = 0;
                        string card = "";

                        for (int i = 0; i < kvp.Value.Count; i++)
                        {
                            card = kvp.Value[i].Trim();
                            char power = card.First();
                            char type = card.Last();

                            cardValue = cardsValue[power] * cardsValue[type];
                            sum = sum + cardValue;
                        }

                        playersTotalPoints[kvp.Key] = sum;
                    }

                    foreach (var player in playersTotalPoints)
                    {
                        Console.WriteLine($"{player.Key}: {player.Value}");
                    }
                    break;
                }
            }
        }
    }
}
