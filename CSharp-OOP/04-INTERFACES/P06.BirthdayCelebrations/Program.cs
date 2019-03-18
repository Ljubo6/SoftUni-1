using System;
using System.Collections.Generic;
using System.Linq;
using P06.BirthdayCelebrations.Entities;

namespace P06.BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ILivingCreature> allEntered = new List<ILivingCreature>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                allEntered.Add(EntityFactory.CreateEntity(input));
            }

            int year = int.Parse(Console.ReadLine());

            foreach (var entity in allEntered.Where(x => x != null))
            {
                if (entity.Birthdate.Year == year)
                {
                    Console.WriteLine(entity.Birthdate.ToString("dd/MM/yyyy"));
                }
            }
        }
    }
}
