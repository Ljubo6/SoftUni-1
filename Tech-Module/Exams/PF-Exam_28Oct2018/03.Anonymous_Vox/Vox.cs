using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Anonymous_Vox
{
    class Vox
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] values = Console.ReadLine()
                .Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string pattern = @"([A-Za-z]+)(.*)(\1)";

            MatchCollection matches = Regex.Matches(input, pattern);

            for (int i = 0; i < matches.Count; i++)
            {
                string toReplace = matches[i].Groups[2].ToString();
                string replacement = string.Empty;

                if (i < values.Length)
                {
                    replacement = values[i];
                }

                string headToKeepOld = input.Substring(0, input.IndexOf(toReplace) + toReplace.Length);
                string headToKeepNew = headToKeepOld.Replace(toReplace, replacement);
                string tailToKeep = input.Substring(headToKeepOld.Length);
                input = headToKeepNew + tailToKeep;
            }

            Console.WriteLine(input);
        }
    }
}
