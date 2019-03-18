using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Team> allTeams = new List<Team>();

        string[] input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

        while (input[0] != "END")
        {
            string command = input[0];
            string teamName = input[1];

            try
            {
                switch (command)
                {
                    case "Team":
                        var newTeam = new Team(teamName);
                        allTeams.Add(newTeam);
                        break;

                    case "Add":
                        var teamToAddPlayerTo = allTeams.FirstOrDefault(t => t.Name == teamName);

                        if (teamToAddPlayerTo != null)
                        {
                            string name = input[2];
                            int endurance = int.Parse(input[3]);
                            int sprint = int.Parse(input[4]);
                            int dribble = int.Parse(input[5]);
                            int passing = int.Parse(input[6]);
                            int shooting = int.Parse(input[7]);
                            var newPlayer = new Player(name, endurance, sprint, dribble, passing, shooting);
                            teamToAddPlayerTo.AddPlayer(newPlayer);
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }

                        break;

                    case "Remove":
                        string playerNameToRemove = input[2];
                        if (allTeams.First(t => t.Name == teamName).RemovePlayer(playerNameToRemove) == false)
                        {
                            Console.WriteLine($"Player {playerNameToRemove} is not in {teamName} team.");
                        }
                        break;

                    case "Rating":
                        var ratingInfoTeam = allTeams.FirstOrDefault(t => t.Name == teamName);

                        if (ratingInfoTeam != null)
                        {
                            Console.WriteLine($"{ratingInfoTeam.Name} - {ratingInfoTeam.Rating}");
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
