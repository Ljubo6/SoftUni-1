using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.House_Party
{
    class HouseParty
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();

            for (int i = 0; i < lines; i++)
            {
                string[] goingOrNot = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (goingOrNot[2] != "not")
                {
                    string guestName = goingOrNot[0];
                    if (guests.Contains(guestName) == false)
                    {
                        guests.Add(guestName);
                    }
                    else
                    {
                        Console.WriteLine($"{guestName} is already in the list!");
                    }
                }
                else
                {
                    string guestName = goingOrNot[0];
                    if (guests.Contains(guestName) == false)
                    {
                        Console.WriteLine($"{guestName} is not in the list!");
                    }
                    else
                    {
                        guests.Remove(guestName);
                    }
                }
            }

            foreach (string guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
