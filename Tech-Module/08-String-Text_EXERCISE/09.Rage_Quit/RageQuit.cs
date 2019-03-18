using System;
using System.Collections.Generic;
using System.Text;

namespace _09.Rage_Quit
{
    class RageQuit
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();

            string currentString = string.Empty;
            string timesRepeated = string.Empty;
            StringBuilder toCountSymbols = new StringBuilder();

            StringBuilder rageMsgs = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsDigit(input[i]))
                {
                    currentString += input[i];
                }
                else
                {
                    timesRepeated += input[i];

                    if (i < input.Length - 1)
                    {
                        if (!Char.IsDigit(input[i + 1]))
                        {
                            if (int.Parse(timesRepeated) > 0)
                            {
                                toCountSymbols.Append(currentString);
                            }
                            for (int a = 0; a < int.Parse(timesRepeated); a++)
                            {
                                rageMsgs.Append(currentString);
                            }
                            currentString = "";
                            timesRepeated = "";
                        }
                    }
                    else
                    {
                        if (int.Parse(timesRepeated) > 0)
                        {
                            toCountSymbols.Append(currentString);

                        }
                        for (int a = 0; a < int.Parse(timesRepeated); a++)
                        {
                            rageMsgs.Append(currentString);
                        }
                        currentString = "";
                        timesRepeated = "";
                    }
                }
            }

            HashSet<char> uniqueSymbols = new HashSet<char>();
            for (int i = 0; i < toCountSymbols.Length; i++)
            {
                uniqueSymbols.Add(toCountSymbols[i]);
            }

            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Count}");
            Console.WriteLine(rageMsgs);
        }
    }
}
