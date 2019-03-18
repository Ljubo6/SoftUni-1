using System;
using System.Numerics;

namespace _01._1_Data_Type_Finder
{
    public class Program
    {
        public static void Main()
        {
            string input = string.Empty;
            string dataType = string.Empty;
            BigInteger integer;
            float floatingPoint;
            char character;
            while (input != "END")
            {
                input = Console.ReadLine();

                if (BigInteger.TryParse(input, out integer))
                {
                    dataType = "integer";
                    Console.WriteLine($"{input} is {dataType} type");
                }
                else if (float.TryParse(input, out floatingPoint))
                {
                    dataType = "floating point";
                    Console.WriteLine($"{input} is {dataType} type");
                }
                else if (char.TryParse(input, out character))
                {
                    dataType = "character";
                    Console.WriteLine($"{input} is {dataType} type");
                }
                else if (input == "true" || input == "false")
                {
                    dataType = "boolean";
                    Console.WriteLine($"{input} is {dataType} type");
                }
                else if (input != "END" && input != string.Empty)
                {
                    dataType = "string";
                    Console.WriteLine($"{input} is {dataType} type");
                }
            }
        }
    }
}