using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.Cubic_Message
{
    class Football
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string input = Console.ReadLine();

            var points = new Dictionary<string, long>();
            var goals = new Dictionary<string, long>();


            while (input != "final")
            {
                string[] currentGame = input.Split();

                string firstArr = currentGame[0];
                string seccondArr = currentGame[1];
                string[] result = currentGame[2].Split(':').ToArray();

                //Getting Team Names
                string firstTeamName = GetTeamName(firstArr, key);
                string secondTeamName = GetTeamName(seccondArr, key);

                //Getting Game Score
                int firstTeamScore = int.Parse(result[0]);
                int secondTeamScore = int.Parse(result[1]);

                //Adding the goals to the total number
                AddGoals(goals, points, firstTeamName, firstTeamScore);
                AddGoals(goals, points, secondTeamName, secondTeamScore);

                //Adding points

                if (firstTeamScore > secondTeamScore)
                {
                    points[firstTeamName] += 3;
                }
                else if (secondTeamScore > firstTeamScore)
                {
                    points[secondTeamName] += 3;
                }
                else
                {
                    points[firstTeamName]++;
                    points[secondTeamName]++;
                }
                input = Console.ReadLine();
            }

            points = points.OrderByDescending(x => x.Value).ThenBy(x=>x.Key).ToDictionary(x => x.Key, x => x.Value);
            goals = goals.OrderByDescending(x => x.Value).ThenBy(x=>x.Key).Take(3).ToDictionary(x => x.Key, x => x.Value);

            int index = 1;
            Console.WriteLine("League standings:");
            foreach (var team in points)
            {
                Console.WriteLine($"{index}. {team.Key} {team.Value}");
                index++;
            }

            Console.WriteLine("Top 3 scored goals:");
            foreach (var team in goals)
            {
                Console.WriteLine($"- {team.Key} -> {team.Value}");
            }
        }

        public static void AddGoals(Dictionary<string, long> goals, Dictionary<string, long> points, string teamName, long teamScore)
        {
            if (!goals.ContainsKey(teamName))
            {
                goals.Add(teamName, teamScore);
                points.Add(teamName, 0);
            }
            else
            {
                goals[teamName] += teamScore;
            }
        }

        public static string GetTeamName(string input, string key)
        {
            int indexOfFrontKey = input.IndexOf(key);
            input = input.Substring(indexOfFrontKey + key.Length);

            int indexOfBackKey = input.IndexOf(key);
            input = input.Substring(0, indexOfBackKey);

            char[] toReverse = input.ToCharArray();
            Array.Reverse(toReverse);
            input = new string(toReverse);
            
            return input.ToUpper();
        }
    }
}
    

