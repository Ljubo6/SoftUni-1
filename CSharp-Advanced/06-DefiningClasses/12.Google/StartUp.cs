using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var allPersons = new List<Person>();

        while (true)
        {
            string line = Console.ReadLine();
            string[] input = line.Split();
            string personName = input[0];
            Person currentPerson = allPersons.FirstOrDefault(p => p.Name == personName);

            if (line == "End")
            {
                break;
            }

            string filter = input[1];

            if (currentPerson == null)
            {
                allPersons.Add(new Person(personName));
                currentPerson = allPersons.FirstOrDefault(p => p.Name == personName);
            }

            switch (filter)
            {
                case "company":
                    var companyInfo = new CompanyInfo(input[2], input[3], decimal.Parse(input[4]));
                    currentPerson.CompanyInfo = companyInfo;
                    break;
                case "pokemon":
                    var currentPokemon = new Pokemon(input[2], input[3]);
                    currentPerson.Pokemons.Add(currentPokemon);
                    break;
                case "parents":
                    var currentParent = new Relative(input[2], input[3]);
                    currentPerson.Parents.Add(currentParent);
                    break;
                case "children":
                    var currentChild = new Relative(input[2], input[3]);
                    currentPerson.Children.Add(currentChild);
                    break;
                case "car":
                    var currentCar = new Car(input[2], int.Parse(input[3]));
                    currentPerson.Car = currentCar;
                    break;
                default:
                    break;
            }
        }

        string personToFindByName = Console.ReadLine();
        Console.WriteLine(allPersons.FirstOrDefault(p => p.Name == personToFindByName));
    }
}
