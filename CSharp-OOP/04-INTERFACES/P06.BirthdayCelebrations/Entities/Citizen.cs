using System;
using System.Collections.Generic;
using System.Text;

namespace P06.BirthdayCelebrations.Entities
{
    public class Citizen : IIdentifiable, ILivingCreature
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public DateTime Birthdate { get; private set; }

        public Citizen(string name, int age, string id, DateTime birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
    }
}
