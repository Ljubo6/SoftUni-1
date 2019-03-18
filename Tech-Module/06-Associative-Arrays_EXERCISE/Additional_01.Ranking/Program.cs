using System;
using System.Collections.Generic;
using System.Linq;

namespace Additional_01.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestPassword = new Dictionary<string, string>();
            var contestParticipants = new Dictionary<string, Dictionary<string, double>>();

            string firstInput = Console.ReadLine();
            while (firstInput != "end of contests")
            {
                string[] contests = firstInput.Split(":").ToArray();
                string currentContest = contests[0];
                string currentPassword = contests[1];

                if (!contestPassword.ContainsKey(currentContest))
                {
                    contestPassword.Add(currentContest, currentPassword);
                }
                else
                {
                    contestPassword[currentContest] = currentPassword;
                }

                firstInput = Console.ReadLine();
            }

            string submission = Console.ReadLine();

            while (submission != "end of submissions")
            {
                string[] currentSubmission = submission.Split("=>").ToArray();
                string currentContest = currentSubmission[0];
                string currentPassword = currentSubmission[1];
                string currentUser = currentSubmission[2];
                double currentPoints = double.Parse(currentSubmission[3]);

                if (contestPassword.ContainsKey(currentContest))
                {
                    if (contestPassword[currentContest] == currentPassword)
                    {
                        if (!contestParticipants.ContainsKey(currentUser))
                        {
                            contestParticipants.Add(currentUser, new Dictionary<string, double>());
                            contestParticipants[currentUser].Add(currentContest, currentPoints);
                        }
                        else
                        {
                            if (!contestParticipants[currentUser].ContainsKey(currentContest))
                            {
                                contestParticipants[currentUser].Add(currentContest, currentPoints);
                            }
                            else
                            {
                                if (contestParticipants[currentUser][currentContest] < currentPoints)
                                {
                                    contestParticipants[currentUser][currentContest] = currentPoints;
                                }
                            }
                        }
                    }
                }
                submission = Console.ReadLine();
            }

            contestParticipants = contestParticipants
                .OrderByDescending(x => x.Value.Values.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            string bestCandidateName = contestParticipants.First().Key;
            double bestCandidatePoints = contestParticipants.First().Value.Values.Sum();
            Console.WriteLine($"Best candidate is {bestCandidateName} with total {bestCandidatePoints} points.");

            contestParticipants = contestParticipants
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Ranking:");
            foreach (var user in contestParticipants)
            {
                Console.WriteLine(user.Key);
                var userContests = user.Value.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                foreach (var contest in userContests)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
