using System;
using System.Linq;

namespace _10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] field = new int[fieldSize];

            int[] ladybugIndexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < ladybugIndexes.Length; i++)
            {
                if (ladybugIndexes[i] < fieldSize && ladybugIndexes[i] >= 0)
                {
                    field[ladybugIndexes[i]] = 1;
                }
            }

            string input = Console.ReadLine();
            

            while (input != "end")
            {

                string[] command = input
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string direction = command[1];
                int index = int.Parse(command[0]);
                int flyLength = int.Parse(command[2]);
                int newIndex = 0;

                if (index >= 0 && index < fieldSize)
                {
                    if (field[index] == 1)
                    {
                        if (direction == "right")
                        {
                            newIndex = index + flyLength;
                            field[index] = 0;

                            while (true)
                            {
                                if (newIndex < fieldSize)
                                {
                                    if (field[newIndex] == 1)
                                    {
                                        newIndex += flyLength;
                                    }
                                    else
                                    {
                                        field[newIndex] = 1;
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }

                        if (direction == "left")
                        {
                            newIndex = index - flyLength;
                            field[index] = 0;

                            while (true)
                            {
                                if (newIndex >= 0 && newIndex < fieldSize)
                                {
                                    if (field[newIndex] == 1)
                                    {
                                        newIndex -= flyLength;
                                    }
                                    else
                                    {
                                        field[newIndex] = 1;
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
            
            Console.WriteLine(string.Join(' ', field));
        }
    }
}
