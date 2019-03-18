using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            char lineOne = char.Parse(Console.ReadLine());
            char lineTwo = char.Parse(Console.ReadLine());
            char lineThree = char.Parse(Console.ReadLine());
            Console.WriteLine($"{lineThree} {lineTwo} {lineOne}");
        }
    }
}
