using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MOBA_Challenger
{
    public class MOBA
    {
        static void Main(string[] args)
        {
            var allPlayers = new Dictionary<string, List<Position>>();

            string[] input = Console.ReadLine().Split();

            while (string.Join(" ", input) != "Season end")
            {
                if (input[1] == "->")
                {
                    string player = input[0];
                    string position = input[2];
                    int value = int.Parse(input[4]);

                    if (!allPlayers.ContainsKey(player))
                    {
                        allPlayers.Add(player, new List<Position>());
                        allPlayers[player].Add(new Position() { PositionName = position, Value = value });
                    }
                    else
                    {
                        if (!allPlayers[player].Any(x => x.PositionName == position))
                        {
                            allPlayers[player].Add(new Position() { PositionName = position, Value = value });
                        }
                        else
                        {
                            if (allPlayers[player].FirstOrDefault(x => x.PositionName == position).Value < value)
                            {
                                allPlayers[player].FirstOrDefault(x => x.PositionName == position).Value = value;
                            }
                        }
                    }
                }
                else if (input[1] == "vs")
                {
                    string playerOne = input[0];
                    string playerTwo = input[2];
                    bool haveSkillInCommon = false;

                    if (allPlayers.ContainsKey(playerOne) && allPlayers.ContainsKey(playerTwo))
                    {
                        for (int i = 0; i < allPlayers[playerOne].Count; i++)
                        {
                            for (int j = 0; j < allPlayers[playerTwo].Count; j++)
                            {
                                if (allPlayers[playerOne][i].PositionName == allPlayers[playerTwo][j].PositionName)
                                {
                                    haveSkillInCommon = true;
                                    break;
                                }
                            }

                            if (haveSkillInCommon == true)
                            {
                                break;
                            }
                        }

                        if (haveSkillInCommon == true)
                        {
                            int skillPointsPlayerOne = allPlayers[playerOne].Sum(x => x.Value);
                            int skillPointsPlayerTwo = allPlayers[playerTwo].Sum(x => x.Value);

                            if (skillPointsPlayerOne > skillPointsPlayerTwo)
                            {
                                allPlayers.Remove(playerTwo);
                            }
                            else if (skillPointsPlayerTwo > skillPointsPlayerOne)
                            {
                                allPlayers.Remove(playerOne);
                            }
                        }
                    }
                }
                input = Console.ReadLine().Split();
            }

            allPlayers = allPlayers.OrderByDescending(x => x.Value.Sum(y => y.Value)).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var player in allPlayers)
            {
                var positions = player.Value.OrderByDescending(x => x.Value).ThenBy(x => x.PositionName).ToList();
                int totalSkills = player.Value.Sum(x => x.Value);
                Console.WriteLine($"{player.Key}: {totalSkills} skill");

                foreach (var position in positions)
                {
                    Console.WriteLine($"- {position.PositionName} <::> {position.Value}");
                }
            }
        }
    }

    public class Position
    {
        public string PositionName { get; set; }
        public int Value { get; set; }
    }
}
