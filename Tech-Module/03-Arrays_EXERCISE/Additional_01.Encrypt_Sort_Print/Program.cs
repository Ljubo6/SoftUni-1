using System;

namespace Additional_01.Encrypt_Sort_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int[] nameValues = new int[lines];

            for (int i = 0; i < lines; i++)
            {
                string name = Console.ReadLine();
                int nameValue = 0;
                for (int a = 0; a < name.Length; a++)
                {
                    char currentLetter = name[a];
                    int letterValue = 0;
                    if (currentLetter == 'a' || currentLetter == 'e' || currentLetter == 'i' ||
                        currentLetter == 'o' || currentLetter == 'u' || currentLetter == 'A' ||
                        currentLetter == 'E' || currentLetter == 'I' || currentLetter == 'O' ||
                        currentLetter == 'U')
                    {
                        letterValue = currentLetter * name.Length;
                    }
                    else
                    {
                        letterValue = currentLetter / name.Length;
                    }

                    nameValue += letterValue;
                }
                nameValues[i] = nameValue;
            }
            Array.Sort(nameValues);
            foreach (int item in nameValues)
            {
                Console.WriteLine(item);
            }
        }
    }
}
