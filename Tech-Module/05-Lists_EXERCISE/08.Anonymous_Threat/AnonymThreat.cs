using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Anonymous_Threat
{
    class AnonymThreat
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();

            while (input != "3:1")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (commands[0] == "merge")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    if (startIndex > endIndex)
                    {
                        int temp = endIndex;
                        endIndex = startIndex;
                        startIndex = endIndex;

                    }

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }

                    if (endIndex >= data.Count)
                    {
                        endIndex = data.Count - 1;
                    }

                    for (int i = startIndex; i < endIndex; i++)
                    {
                        data[startIndex] += data[startIndex + 1];
                        data.RemoveAt(startIndex + 1);
                    }
                }
                if (commands[0] == "divide")
                {
                    int index = int.Parse(commands[1]);
                    int partitions = int.Parse(commands[2]);
                    List<char> stringToDivide = data[index].ToList();
                    int partSize = stringToDivide.Count / partitions;
                    string currentPart = string.Empty;
                    int counter = 0;

                    for (int i = 0; i < partitions - 1; i++)
                    {
                        for (int j = 0; j < partSize; j++)
                        {
                            currentPart += stringToDivide[0];
                            stringToDivide.RemoveAt(0);
                        }
                        data.Insert(index + i, currentPart);
                        counter++;
                        currentPart = string.Empty;
                    }

                    data[index + counter] = new string(stringToDivide.ToArray());


                }
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', data));
        }
    }
}
