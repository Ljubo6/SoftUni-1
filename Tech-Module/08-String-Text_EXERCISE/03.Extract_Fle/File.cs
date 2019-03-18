using System;
using System.Linq;

namespace _03.Extract_File
{
    class File
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); //.ToCharArray();
            int indexOfSlash = input.LastIndexOf('\\');
            int indexOfDot = input.LastIndexOf('.');
            string fileName = string.Empty;
            string extension = string.Empty;

            for (int i = indexOfSlash+1; i < indexOfDot; i++)
            {
                fileName += input[i];
            }

            for (int i = indexOfDot+1; i < input.Length; i++)
            {
                extension += input[i];
            }

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
