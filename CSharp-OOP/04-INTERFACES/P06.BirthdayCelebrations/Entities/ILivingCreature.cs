using System;
using System.Collections.Generic;
using System.Text;

namespace P06.BirthdayCelebrations.Entities
{
   public interface ILivingCreature
    {
        DateTime Birthdate { get; }
        string Name { get; }
    }
}
