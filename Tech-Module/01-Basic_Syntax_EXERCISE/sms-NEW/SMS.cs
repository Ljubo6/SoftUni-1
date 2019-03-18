using System;

public class SMS
{
    static void Main(string[] args)
    {
        string[] letters = new string[8];
            //new string[] { " ", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
        string message = string.Empty;

        
        int lastLetterIndex = 0;
        
        for (int i = 0; i <= 7; i++)
        {
            
            if (i == 5 || i == 7)
            {
                for (int a = 0; a < 4; a++)
                {
                    letters[i] += (char)(lastLetterIndex + 97);
                    lastLetterIndex++;
                }
            }
            else
            {
                for (int a = 0; a < 3; a++)
                {
                    letters[i] += (char)(lastLetterIndex + 97);
                    lastLetterIndex++;
                }
            }
            
        }




        int inputLines = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputLines; i++)
        {
            string command = Console.ReadLine();
            int timesPressed = command.Length;
            var buttonNumber = int.Parse(command[0].ToString());
            var currentButton = letters[buttonNumber];

            var letter = currentButton[(timesPressed - 1) % currentButton.Length];
            message += letter;
        }
        Console.WriteLine(message);
    }
}
