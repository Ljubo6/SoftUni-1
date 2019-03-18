using System;
using System.Linq;
using System.Collections.Generic;


namespace _04.List_Operations
{
    class ListOperations
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
                if (command[0] == "add")
                {
                    numbers.Add(int.Parse(command[1]));
                }

                else if (command[0] == "insert")
                {
                    int element = int.Parse(command[1]);
                    int index = int.Parse(command[2]);

                    if (index < numbers.Count && index >= 0)
                    {
                        numbers.Insert(index, element);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command[0] == "remove")
                {
                    int index = int.Parse(command[1]);

                    if (index < numbers.Count && index >= 0)
                    {
                        numbers.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command[0] == "shift")
                {
                    int positions = int.Parse(command[2]);

                    if (command[1] == "left")
                    {
                        for (int i = 0; i < positions; i++)
                        {
                            int firstNumber = numbers[0];
                            numbers.Add(firstNumber);
                            numbers.RemoveAt(0);
                        }
                    }
                    else if (command[1] == "right")
                    {
                        for (int i = 0; i < positions; i++)
                        {
                            int lastNumber = numbers.Last();
                            numbers.Remove(lastNumber);
                            numbers.Insert(0, lastNumber);
                        }
                    }
                }
                command = Console.ReadLine().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
