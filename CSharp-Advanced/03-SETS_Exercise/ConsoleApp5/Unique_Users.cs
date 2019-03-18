using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    class Unique_Users
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                names.Add(input);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
