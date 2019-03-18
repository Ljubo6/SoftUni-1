using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SoftUni_Exam_Results
{
    class SoftUni_Exam
    {
        static void Main(string[] args)
        {
            var usersPoints = new Dictionary<string, int>();
            var submissions = new Dictionary<string, int>();
            var bannedUsers = new List<string>();

            string[] input = Console.ReadLine().Split('-').ToArray();

            while (string.Join(" ", input) != "exam finished")
            {
                string username = input[0];

                if (input[1] == "banned")
                {
                    bannedUsers.Add(username);
                    input = Console.ReadLine().Split('-').ToArray();
                    continue;
                }

                string language = input[1];
                int points = int.Parse(input[2]);


                if (!usersPoints.ContainsKey(username))
                {
                    usersPoints.Add(username, points);
                }
                else
                {
                    if (usersPoints[username] < points)
                    {
                        usersPoints[username] = points;
                    }

                }


                if (!submissions.ContainsKey(language))
                {
                    submissions.Add(language, 1);
                }
                else
                {
                    submissions[language]++;
                }

                input = Console.ReadLine().Split('-').ToArray();
            }

            usersPoints = usersPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            submissions = submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");
            foreach (var user in usersPoints)
            {
                if (!bannedUsers.Contains(user.Key))
                {
                    Console.WriteLine($"{user.Key} | {user.Value}");
                }
            }

            Console.WriteLine("Submissions:");
            foreach (var language in submissions)
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
