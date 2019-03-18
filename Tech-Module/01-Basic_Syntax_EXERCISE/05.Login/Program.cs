using System;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            char[] password = username.ToCharArray();
            Array.Reverse(password);
            string passReversed = new string(password);
            int counter = 0;

            while (true)
            {
                string passPrompt = Console.ReadLine();
                
                if (passPrompt != passReversed && counter < 3)
                {
                    counter++;
                    Console.WriteLine("Incorrect password. Try again.");
                    
                }
                else if (passPrompt != passReversed && counter == 3)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
                else
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
            }
        }
    }
}
