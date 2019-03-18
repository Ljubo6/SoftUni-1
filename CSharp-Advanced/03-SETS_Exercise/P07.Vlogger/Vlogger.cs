using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.Vlogger
{
    class Vlogger
    {
        static void Main()
        {
            var vloggers = new List<string>(); // list of all vloggers
            var following = new Dictionary<string, HashSet<string>>(); // vlogger -> list of vloggers they follow
            var followers = new Dictionary<string, HashSet<string>>(); // vlogger -> list of vloggers who follow them

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] command = input.Split();
                string vlogger = command[0];
                string action = command[1];

                if (action == "joined")
                {
                    if (!vloggers.Contains(vlogger))
                    {
                        vloggers.Add(vlogger);
                        followers.Add(vlogger, new HashSet<string>());
                        following[vlogger] = new HashSet<string>();
                    }
                }
                else if (action == "followed")
                {
                    string followedVlogger = command[2];

                    if (vloggers.Contains(vlogger) && vloggers.Contains(followedVlogger) && vlogger != followedVlogger)
                    {
                        followers[followedVlogger].Add(vlogger);
                        following[vlogger].Add(followedVlogger);
                    }
                }
                input = Console.ReadLine();
            }


            following = following
                .OrderByDescending(x=>x.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);


            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            followers = followers
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => following[x.Key].Count)
                .ToDictionary(x => x.Key, x => x.Value);

            var topVlogger = followers.FirstOrDefault();

            Console.WriteLine($"1. {topVlogger.Key} : {topVlogger.Value.Count} followers, {following[topVlogger.Key].Count} following");

            List<string> currentFollowers = topVlogger.Value.OrderBy(x => x).ToList();

            if (currentFollowers.Count > 0)
            {
                foreach (var follower in currentFollowers)
                {
                    Console.WriteLine($"*  {follower}");
                }
            }

            int index = 2;

            foreach (var vlogger in followers.Where(x=>x.Key != topVlogger.Key))
            {
                Console.WriteLine($"{index++}. {vlogger.Key} : {vlogger.Value.Count} followers, {following[vlogger.Key].Count} following");
            }
        }
    }
}
