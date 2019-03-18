using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Change_List
{
    class ChangeList
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console
               .ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            string[] command = Console.ReadLine().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (command[0] != "end")
            {
                if (command[0] == "delete")
                {
                    int elementToDelete = int.Parse(command[1]);
                    numbers.RemoveAll(n => n == elementToDelete);
                }
                else if (command[0] == "insert")
                {
                    int elementToInsert = int.Parse(command[1]);
                    int position = int.Parse(command[2]);
                    if (position < numbers.Count)
                    {
                        numbers.Insert(position, elementToInsert);
                    }
                }
                command = Console.ReadLine().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
