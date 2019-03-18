using System;
using System.Collections.Generic;
using P05.BorderControl.Entities;

namespace P05.BorderControl
{
   public class StartUp
    {
       public static void Main()
        {
            List<IIdentifiable> allEntered = new List<IIdentifiable>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }

                allEntered.Add(EntityFactory.CreateEnteringEntity(input));
            }

            string fakeId = Console.ReadLine();

            foreach (var entity in allEntered)
            {
                if (entity.Id.Substring(entity.Id.Length - fakeId.Length, fakeId.Length) == fakeId)
                {
                    Console.WriteLine(entity.Id);
                }
            }
        }
    }
}
