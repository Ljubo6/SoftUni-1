using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class ForceBook
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> sidesWithUsers = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "Lumpawaroo")
            {
                string forceSide = input[0];
                string forceUser = input[2];
                string command = input[1];

                switch (command)
                {
                    case "|":
                        if (!sidesWithUsers.ContainsKey(forceSide))
                        {
                            sidesWithUsers.Add(forceSide, new List<string>() { forceUser });
                        }
                        else
                        {
                            if (!sidesWithUsers[forceSide].Contains(forceUser))
                            {
                                sidesWithUsers[forceSide].Add(forceUser);
                            }
                        }
                        break;

                    case "->":
                        if (sidesWithUsers.Any(x => x.Value.Contains(forceUser)))
                        {
                            foreach (var list in sidesWithUsers.Values)
                            {
                                list.Remove(forceUser);
                            }

                            sidesWithUsers[forceSide].Add(forceUser);
                            Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                        }
                        else
                        {
                            sidesWithUsers[forceSide].Add(forceUser);
                        }
                        break;

                    default:
                        break;
                }
                input = Console.ReadLine().Split();
            }

            sidesWithUsers = sidesWithUsers
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var side in sidesWithUsers)
            {
                int usersCount = side.Value.Count;
                if (usersCount > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {usersCount}");
                    side.Value.OrderBy(x => x);
                    foreach (var user in side.Value)
                    {
                        Console.WriteLine($"!{user}");
                    }
                }

            }

        }
    }
}
