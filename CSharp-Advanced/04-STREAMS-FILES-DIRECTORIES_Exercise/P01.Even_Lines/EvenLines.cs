using System;
using System.IO;
using System.Linq;

namespace P01.Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] charsToReplace = new char[] { '-', ',', '.', '!', '?' };
            int lineNumber = 0;

            using (var reader = new StreamReader(@"..\..\..\..\Resources\text.txt"))
            {
                using (var writer = new StreamWriter("modifiedText.txt", true))
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        if (lineNumber % 2 == 0)
                        {
                            string[] currentLine = line.Split();

                            for (int i = currentLine.Length - 1; i >= 0; i--)
                            {
                                char[] currentWord = currentLine[i].ToCharArray();

                                for (int j = 0; j < currentWord.Length; j++)
                                {
                                    if (charsToReplace.Contains(currentLine[i][j]))
                                    {
                                        currentWord[j] = '@';
                                    }
                                }

                                currentLine[i] = new string(currentWord);
                            }

                            writer.WriteLine(string.Join(' ', currentLine.Reverse()));
                        }

                        lineNumber++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
