using System;

namespace P03.Ferrari
{
    public class StartUp
    {
        public static void Main()
        {
            var ferrari = new Car("Ferrari", "488-Spider");
            var driver = Console.ReadLine();
            ferrari.Driver = driver;
            Console.WriteLine(ferrari);
        }
    }
}
