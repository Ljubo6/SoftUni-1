using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    class QuestJournal
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();

            while (input != "Retire!")
            {
                string[] currentInput = input.Split(" - ").ToArray();
                string command = currentInput[0];
                string quest = currentInput[1];

                if (command == "Start")
                {
                    if (!journal.Contains(quest))
                    {
                        journal.Add(quest);
                    }
                }
                else if (command == "Complete")
                {
                    journal.Remove(quest);
                }
                else if (command == "Side Quest")
                {
                    string[] currentQuest = quest.Split(':').ToArray();
                    string questToCheck = currentQuest[0];
                    string sideQuest = currentQuest[1];

                    if (journal.Contains(questToCheck) && !journal.Contains(sideQuest))
                    {
                        int index = journal.IndexOf(questToCheck);
                        if (journal.Count == index + 1)
                        {
                            journal.Add(sideQuest);
                        }
                        else
                        {
                            journal.Insert(index + 1, sideQuest);
                        }
                    }
                }
                else if (command == "Renew")
                {
                    if (journal.Contains(quest))
                    {
                        journal.Remove(quest);
                        journal.Add(quest);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", journal));
        }
    }
}
