using System;

namespace _06.Foreign_Languages
{
    class Program
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine().ToLower();

            if (countryName == "england" || countryName == "usa")
            {
                Console.WriteLine("English");
            }
            else if (countryName == "spain" || countryName == "argentina" || countryName == "mexico")
            {
                Console.WriteLine("Spanish");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
