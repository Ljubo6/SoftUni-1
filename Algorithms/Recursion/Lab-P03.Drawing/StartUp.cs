using System;

namespace Lab_P03.Drawing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Print(number);
        }

        private static void Print(int number)
        {
            if(number == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', number));
            Print(number - 1);
            Console.WriteLine(new string('#', number));
        }
    }
}
