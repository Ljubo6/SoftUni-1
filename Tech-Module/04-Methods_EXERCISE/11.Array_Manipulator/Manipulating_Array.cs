using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Array_Manipulator
{
    class Manipulating_Array
    {
        static void Main(string[] args)
        {
            int[] array = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[] command = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (command[0] != "end")
            {
                if (command[0] == "exchange")
                {
                    int index = int.Parse(command[1]);
                    int[] workingArray = new int[array.Length];
                    if (index > array.Length - 1 || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            workingArray[i] = array[(i + index + 1) % array.Length];
                        }
                        array = workingArray;
                    }
                }

                if (command[0] == "max")
                {
                    if (command[1] == "even")
                    {
                        GetMaxEvenOdd(array, 0);
                    }
                    else if (command[1] == "odd")
                    {
                        GetMaxEvenOdd(array, 1);
                    }
                }

                if (command[0] == "min")
                {
                    if (command[1] == "even")
                    {
                        GetMinEvenOdd(array, 0);
                    }
                    else if (command[1] == "odd")
                    {
                        GetMinEvenOdd(array, 1);
                    }
                }

                if (command[0] == "first")
                {
                    int count = int.Parse(command[1]);
                    if (count > array.Length)
                    {
                        Console.WriteLine("Invalid count");

                    }
                    else
                    {
                        if (command[2] == "even")
                        {
                            GetFirstEvenOdd(array, 0, count);
                            
                        }
                        else if (command[2] == "odd")
                        {
                            GetFirstEvenOdd(array, 1, count);
                        }
                    }
                }

                if (command[0] == "last")
                {
                    int count = int.Parse(command[1]);
                    if (count > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        if (command[2] == "even")
                        {
                            GetLastEvenOdd(array, 0, count);
                            
                           
                        }
                        else if (command[2] == "odd")
                        {
                            GetLastEvenOdd(array, 1, count);
                        }
                    }
                }

                command = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            Console.WriteLine("[" + string.Join(", ", array) + "]");
        }

        private static void GetLastEvenOdd(int[] array, int reminder, int count)
        {
            List<int> workingSet = new List<int>();
            List<int> resultSet = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == reminder)
                {
                    workingSet.Add(array[i]);
                }
            }

            if (workingSet.Count < count)
            {
                Console.WriteLine("[" + string.Join(", ", workingSet) + "]");
            }
            else
            {
                workingSet.Reverse();
                for (int i = 0; i < count; i++)
                {
                    resultSet.Add(workingSet[i]);
                }
                resultSet.Reverse();
                Console.WriteLine("[" + string.Join(", ", resultSet) + "]");
            }
        }

        private static void GetFirstEvenOdd(int[] array, int remainder, int count)
        {
            List<int> workingSet = new List<int>();
            List<int> resultSet = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == remainder)
                {
                    workingSet.Add(array[i]);
                }
            }
            if (workingSet.Count < count)
            {
                Console.WriteLine("[" + string.Join(", ", workingSet) + "]");
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    resultSet.Add(workingSet[i]);
                }
                Console.WriteLine("[" + string.Join(", ", resultSet) + "]");
            }
        }

        private static void GetMinEvenOdd(int[] array, int remainder)
        {
            int minNumber = int.MaxValue;
            bool found = false;
            int index = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == remainder)
                {
                    if (array[i] <= minNumber)
                    {
                        found = true;
                        minNumber = array[i];
                        index = i;
                    }
                }
            }

            if (found)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static void GetMaxEvenOdd(int[] array, int remainder)
        {
            int maxNumber = int.MinValue;
            bool found = false;
            int index = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == remainder)
                {
                    if (array[i] >= maxNumber)
                    {
                        found = true;
                        maxNumber = array[i];
                        index = i;
                    }
                }
            }

            if (found)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}