using System;
using System.IO;

namespace P02.Line_Numbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"..\..\..\..\Resources\text.txt"))
            {
                using (var writer = new StreamWriter("LinedText.txt", true))
                {
                    string line = reader.ReadLine();
                    int lineNumber = 1;

                    while (line != null)
                    {
                        int punctionationsCount = 0;
                        int lettersCount = 0;
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (Char.IsPunctuation(line[i]))
                            {
                                punctionationsCount++;
                            }
                            else if (char.IsLetter(line[i]))
                            {
                                lettersCount++;
                            }
                        }

                        line = $"Line {lineNumber++}:{line} ({lettersCount})({punctionationsCount})";
                        writer.WriteLine(line);

                        line = reader.ReadLine();
                    }
                }
            }

        }
    }
}
