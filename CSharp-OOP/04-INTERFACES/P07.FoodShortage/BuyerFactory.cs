using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace P07.FoodShortage
{
    public static class BuyerFactory
    {
        public static IBuyer CreateEntity(string[] input)
        {
            switch (input.Length)
            {
                case 4:
                    string CitizenName = input[0];
                    int age = int.Parse(input[1]);
                    string CitizenID = input[2];
                    DateTime CitizenDoB = DateTime.ParseExact(input[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    return new Citizen(CitizenName, age, CitizenID, CitizenDoB);
                case 3:
                    string rebelName = input[0];
                    int rebelAge = int.Parse(input[1]);
                    string rebelGroup = input[2];
                    return new Rebel(rebelName,rebelAge, rebelGroup);
                default:
                    return null;
            }
        }
    }
}
