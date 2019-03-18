using System;
using System.Collections.Generic;
using System.Linq;

public class Personal_Info
{
    public static void Main()
    {
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string input = Console.ReadLine();
            string name = string.Empty;
            string age = string.Empty;
            int nameLength = 0;
            int ageLength = 0;
            int nameStartIndex = 0;
            int ageStartIndex = 0;

            int nameStart = input.IndexOf('@') + 1;
            int nameEnd = input.IndexOf('|');

            int ageStart = input.IndexOf('#') + 1;
            int ageEnd = input.IndexOf('*');

            if (nameEnd != -1 && nameStart != -1)
            {
                nameLength = Math.Abs(nameEnd - nameStart);
                nameStartIndex = Math.Min(nameStart, nameEnd);
            }

            if (ageEnd != -1 && ageStart != -1)
            {
                ageLength = Math.Abs(ageEnd - ageStart);
                ageStartIndex = Math.Min(ageStart, ageEnd);
            }

            name = input.Substring(nameStartIndex, nameLength);
            age = input.Substring(ageStartIndex, ageLength);

            Console.WriteLine($"{name} is {age} years old.");
            
        }
    }
}