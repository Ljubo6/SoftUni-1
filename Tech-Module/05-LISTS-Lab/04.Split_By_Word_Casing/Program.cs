using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Split_By_Word_Casing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> texts = Console.ReadLine()
                .Split(new char[] { ',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ' }, 
                StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> smalls = new List<string>();
            List<string> capitals = new List<string>();
            List<string> mixed = new List<string>();


            for (int i = 0; i < texts.Count; i++)
            {
                char[] currentString = texts[i].ToCharArray();
                int capitalsCounter = 0;
                int smallCounter = 0;
                
                for (int a = 0; a < currentString.Length; a++)
                {
                    if (currentString[a] >= 65 && currentString[a] <=90)
                    {
                        capitalsCounter++;
                    }
                    else if (currentString[a] >=97 && currentString[a] <= 122)
                    {
                        smallCounter++;
                    }
                }

                if (smallCounter == currentString.Length)
                {
                    smalls.Add(texts[i]);
                }
                else if (capitalsCounter == currentString.Length)
                {
                    capitals.Add(texts[i]);
                }
                else
                {
                    mixed.Add(texts[i]);
                }
            }
            Console.WriteLine("Lower-case: " + String.Join(", ", smalls));
            Console.WriteLine("Mixed-case: " + String.Join(", ", mixed));
            Console.WriteLine("Upper-case: " + String.Join(", ", capitals));
        }
    }
}
