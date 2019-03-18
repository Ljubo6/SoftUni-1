using System;

namespace Additional_04.Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Array.Reverse(input);
            string result = new string(input);
            Console.WriteLine(result);
        }
    }
}
