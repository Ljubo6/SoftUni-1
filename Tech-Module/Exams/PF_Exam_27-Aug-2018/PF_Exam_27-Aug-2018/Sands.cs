using System;
using System.Collections.Generic;
using System.Linq;

namespace PF_Exam_27_Aug_2018
{
    class Sands
    {
        static void Main(string[] args)
        {
            List<int> grains = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "Mort")
            {
                string[] command = input.Split(' ').ToArray();
                int value = int.Parse(command[1]);

                if (command[0] == "Add")
                {
                    grains.Add(value);
                }

                if (command[0] == "Remove")
                {
                    if (grains.Remove(value) == false)
                    {
                        if (value >= 0 && value <grains.Count)
                        {
                            grains.RemoveAt(value);
                        }
                    }
                }

                if (command[0] == "Replace")
                {
                    int replacement = int.Parse(command[2]);
                    for (int i = 0; i < grains.Count; i++)
                    {
                        if (grains[i] == value)
                        {
                            grains[i] = replacement;
                            break;
                        }
                    }
                }
                if (command[0] == "Increase")
                {
                    int increment = int.MinValue;
                    bool found = false;

                    for (int i = 0; i < grains.Count; i++)
                    {
                        if (grains[i] >= value)
                        {
                            increment = grains[i];
                            found = true;
                            break;
                        }
                    }

                    if (found == false)
                    {
                        increment = grains.Last();
                    }

                    for (int i = 0; i < grains.Count; i++)
                    {
                        grains[i] += increment;
                    }
                }
                if (command[0] == "Collapse")
                {
                    grains.RemoveAll(grain => grain < value);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', grains));
        }
    }
}
