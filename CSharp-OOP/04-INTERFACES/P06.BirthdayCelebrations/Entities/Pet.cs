using System;
using System.Collections.Generic;
using System.Text;

namespace P06.BirthdayCelebrations.Entities
{
    class Pet : ILivingCreature
    {
        public DateTime Birthdate { get; private set; }

        public string Name { get; private set; }

        public Pet(string name, DateTime birthdate)
        {
            this.Birthdate = birthdate;
            this.Name = name;
        }
    }
}
