using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace P06.BirthdayCelebrations.Entities
{
    public static class EntityFactory
    {
        public static ILivingCreature CreateEntity(string[] input)
        {
            switch (input[0])
            {
                case "Citizen":
                    string CitizenName = input[1];
                    int age = int.Parse(input[2]);
                    string CitizenID = input[3];
                    DateTime CitizenDoB = DateTime.ParseExact(input[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    return new Citizen(CitizenName, age, CitizenID, CitizenDoB);
                case "Pet":
                    string petName = input[1];
                    DateTime petDoB = DateTime.ParseExact(input[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    return new Pet(petName, petDoB);
                default:
                    return null;
            }
        }
    }
}
