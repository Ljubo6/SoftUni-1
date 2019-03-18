using P08.MilitaryElite.Contracts;
using P08.MilitaryElite.Models;
using System;
using System.Collections.Generic;

namespace P08.MilitaryElite
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var allSoldiers = new List<ISoldier>();
            var privates = new List<IPrivate>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string title = data[0];
                string id = data[1];
                string firstName = data[2];
                string lastName = data[3];
                decimal salary = decimal.Parse(data[4]);

                switch (title)
                {
                    case "Private":
                        var currentPrivate = new Private(id, firstName, lastName, salary);
                        privates.Add(currentPrivate);
                        allSoldiers.Add(currentPrivate);
                        break;
                    case "LieutenantGeneral":
                        var currentLeutenant = new LieutenantGeneral(id, firstName, lastName, salary);
                        for (int i = 5; i < data.Length; i++)
                        {
                            currentLeutenant.AddPrivate(privates, data[i]);
                        }
                        allSoldiers.Add(currentLeutenant);
                        break;
                    case "Engineer":
                        string engCorps = data[5];
                        if (engCorps == "Airforces" || engCorps == "Marines")
                        {
                            var currentEngineer = new Engineer(id, firstName, lastName, salary, engCorps);
                            for (int i = 6; i < data.Length; i += 2)
                            {
                                var repair = new Repair(data[i], int.Parse(data[i + 1]));
                                currentEngineer.AddRepair(repair);
                            }
                            if (currentEngineer.Corps != null)
                            {
                                allSoldiers.Add(currentEngineer);
                            }
                        }
                        
                        break;
                    case "Commando":
                        string commandoCorps = data[5];

                        if (commandoCorps == "Airforces" || commandoCorps == "Marines")
                        {
                            var currentCommando = new Commando(id, firstName, lastName, salary, commandoCorps);
                            for (int i = 6; i < data.Length; i += 2)
                            {
                                if (data[i+1] == "inProgress" || data[i+1] == "Finished")
                                {
                                    var mission = new Mission(data[i], data[i + 1]);
                                    currentCommando.AddMission(mission);
                                }
                            }
                            allSoldiers.Add(currentCommando);
                        }
                        break;
                    case "Spy":
                        var currentSpy = new Spy(id, firstName, lastName, (int)salary);
                        allSoldiers.Add(currentSpy);
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }

            foreach (var soldier in allSoldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}
