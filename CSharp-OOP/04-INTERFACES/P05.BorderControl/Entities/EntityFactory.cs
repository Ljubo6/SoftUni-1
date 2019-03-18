using System;
using System.Collections.Generic;
using System.Text;

namespace P05.BorderControl.Entities
{
    public static class EntityFactory
    {
        public static IIdentifiable CreateEnteringEntity(string[] input)
        {
            switch (input.Length)
            {
                case 3:
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string CitizenID = input[2];
                    return new Citizen(name, age, CitizenID);
                case 2:
                    string model = input[0];
                    string id = input[1];
                    return new Robot(model, id);
                default:
                    return null;
            }
        }
    }
}
