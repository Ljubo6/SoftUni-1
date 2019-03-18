using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Valid_Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ").ToArray();
            bool isValid = true;
            var validUsername = new List<string>();

            for (int i = 0; i < usernames.Length; i++)
            {
                if (usernames[i].Length >= 3 && usernames[i].Length <= 16)
                {
                    foreach (char sign in usernames[i])
                    {
                        if (char.IsLetterOrDigit(sign) || sign == '-' || sign == '_')
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
                else
                {
                    isValid = false;
                }

                if (isValid)
                {
                    validUsername.Add(usernames[i]);
                }
            }

            foreach (string username in validUsername)
            {
                Console.WriteLine(username);
            }
        }
    }
}
