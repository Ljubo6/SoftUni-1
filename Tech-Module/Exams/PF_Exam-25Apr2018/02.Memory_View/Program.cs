using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Memory_View
{
    class Program
    {
        static void Main(string[] args)
        {
            string allCommands = string.Empty;


            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "Visual Studio crash")
                {
                    break;
                }
                else
                {
                    allCommands += inputLine + " ";
                }
            }

            List<short> memory = allCommands
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(short.Parse)
                .ToList();

            for (int i = 0; i < memory.Count; i++)
            {
                if (memory[i] == 0)
                {
                    memory.Remove(memory[i]);
                    i--;
                }
            }

            List<short> textInAscii = new List<short>();
            List<string> names = new List<string>();

            for (int i = 0; i < memory.Count; i++)
            {
                if (memory[i] == 32656)
                {
                    if (memory[i+1] == 19759)
                    {
                        if (memory[i+2] == 32763)
                        {
                            short stringLength = memory[i + 3];
                            i += 4;

                            for (int a = 0; a < stringLength; a++)
                            {
                                textInAscii.Add(memory[i]);
                                i++;
                            }
                            i--;
                        }
                    }
                }

                string name = string.Empty;

                foreach (char letter in textInAscii)
                {
                    name += letter;
                }

                names.Add(name);

                textInAscii.Clear();
            }

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
