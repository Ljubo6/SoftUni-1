using System;
using System.Linq;

namespace P02.Knights_of_Honour
{
    class Knights
    {
        static void Main(string[] args)
        {
            var peopleNames = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> print = x => Console.WriteLine("Sir "+ x);

            foreach (var person in peopleNames)
            {
                print(person);
            }
        }
    }
}
