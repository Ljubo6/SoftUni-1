using System;
using System.Collections.Generic;
using System.Text;

namespace P07.FoodShortage
{
    public class Citizen : IBuyer
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public DateTime Birthdate { get; private set; }
        public int Food { get; private set; }

        public Citizen(string name, int age, string id, DateTime birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
