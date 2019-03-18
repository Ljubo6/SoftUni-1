using System;

namespace _04.Password_Validator
{
    class Validating_Passwords
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            ValidatingPasswords(password);

            if (!CheckingLength(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!CheckingOnlyLettersDigits(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!CheckingForTwoDigits(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }

        private static void ValidatingPasswords(string password)
        {
            if (CheckingLength(password))
            {
                if (CheckingOnlyLettersDigits(password))
                {
                    if (CheckingForTwoDigits(password))
                    {
                        Console.WriteLine("Password is valid");
                    }
                }
            }
        }

        private static bool CheckingLength (string password)
        {
            if (password.Length >= 6 && password.Length <=10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckingOnlyLettersDigits(string password)
        {
            foreach (char element in password)
            {
                if (!char.IsLetterOrDigit(element))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool CheckingForTwoDigits (string password)
        {
            int counter = 0;
            foreach (char element in password)
            {
                if(char.IsDigit(element))
                {
                    counter++;
                }
            }
            if (counter >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
