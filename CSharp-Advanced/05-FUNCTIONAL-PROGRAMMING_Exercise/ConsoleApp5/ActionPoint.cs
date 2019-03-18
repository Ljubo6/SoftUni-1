using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Action_Point
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            var peopleNames = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> print = x => Console.WriteLine(x);

            foreach (var person in peopleNames)
            {
                print(person);
            }
        }
    }
}
