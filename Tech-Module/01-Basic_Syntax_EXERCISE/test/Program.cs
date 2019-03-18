using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace messagesSMS
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<int, string> keyboard = new Dictionary<int, string>()
            {
                {1,"" },
                {2,"abc"},
                {3,"def"},
                {4,"ghi"},
                {5,"jkl"},
                {6,"mno"},
                {7,"pqrs"},
                {8,"tuv"},
                {9,"wxyz"},
                {0," "}
            };

            string input = Console.ReadLine();
            List<char> output = new List<char>();

            while (input != "1")
            {
                char[] numberArrray = input.ToCharArray();
                char[] keyboardChar = keyboard[int.Parse(numberArrray[0].ToString())].ToCharArray();
                output.Add(keyboardChar[numberArrray.Length - 1]);
                Console.WriteLine(String.Join("", output));
                input = Console.ReadLine();
            }
        }
    }
}