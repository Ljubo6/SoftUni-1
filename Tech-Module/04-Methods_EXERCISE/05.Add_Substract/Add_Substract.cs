using System;

namespace _05.Add_Substract
{
    class Add_Substract
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int result = Subtracting(Summing(firstNumber, secondNumber), thirdNumber);
            Console.WriteLine(result);
        }

        static int Summing (int a, int b)
        {
            return a + b;
        }

        static int Subtracting (int a, int b)
        {
            return a - b;
        }
    }
}
