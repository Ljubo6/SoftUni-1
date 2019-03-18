using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Team_Projects
{
    class Team
    {
        public Team(string name, string creator)
        {
            Name = name;
            Creator = creator;
            Users = new List<string>();
        }

        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Users { get; set; }
    }

    class TeamProjects
    {
        static void Main(string[] args)
        {
            var allTeamProjects = new List<Team>();
            int teamsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < teamsCount; i++)
            {
                string[] input = Console.ReadLine().Split("-");

                if (allTeamProjects.Any(x => x.Name == input[1]))
                {
                    Console.WriteLine($"Team {input[1]} was already created!");
                    continue;
                }
                else if (allTeamProjects.Any(x => x.Creator == input[0]))
                {
                    Console.WriteLine($"{input[0]} cannot create another team!");
                    continue;
                }
                else
                {
                    Team newTeam = new Team(input[1], input[0]);
                    allTeamProjects.Add(newTeam);
                    Console.WriteLine($"Team {newTeam.Name} has been created by {newTeam.Creator}!");
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end of assignment")
                {
                    break;
                }

                string[] teamChange = command.Split("->");

                if (!allTeamProjects.Any(x => x.Name == teamChange[1]))
                {
                    Console.WriteLine($"Team {teamChange[1]} does not exist!");
                }
                else if ((allTeamProjects.Any(x => x.Users.Contains(teamChange[0])) || 
                    allTeamProjects.Any(y => y.Creator == teamChange[0])) && allTeamProjects.Any(z => z.Name == teamChange[1]))
                {
                    Console.WriteLine($"Member {teamChange[0]} cannot join team {teamChange[1]}!");
                    continue;
                }
                else
                {
                    int indexOfTeam = allTeamProjects.FindIndex(x => x.Name == teamChange[1]);
                    allTeamProjects[indexOfTeam].Users.Add(teamChange[0]);
                }
            }

            allTeamProjects = allTeamProjects.OrderByDescending(x => x.Users.Count).ThenBy(x => x.Name).ToList();

            foreach (var team in allTeamProjects)
            {
                if (team.Users.Count > 0)
                {
                    team.Users = team.Users.OrderBy(x => x).ToList();
                    Console.WriteLine(team.Name);
                    Console.WriteLine($"- {team.Creator}");
                    foreach (var member in team.Users)
                    {
                        Console.WriteLine($"-- {member}");
                    }
                }
            }
            Console.WriteLine("Teams to disband:");
            List<Team> teamsToDisband = allTeamProjects.Where(x => x.Users.Count == 0).OrderBy(x => x.Name).ToList();
            foreach (var team in teamsToDisband)
            {
                Console.WriteLine(team.Name);
            }
        }
    }
}
