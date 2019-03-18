using System;

namespace P04.Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            var phone = new Smartphone();
            var numbers = Console.ReadLine().Split();
            var sites = Console.ReadLine().Split();

            foreach (var number in numbers)
            {
                Console.WriteLine(phone.Dial(number));
            }

            foreach (var url in sites)
            {
                Console.WriteLine(phone.Browse(url));
            }
        }
    }
}
