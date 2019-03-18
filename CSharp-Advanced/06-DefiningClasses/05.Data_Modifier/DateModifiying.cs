using System;

namespace _05.Date_Modifier
{
    public class DateModifying
    {
        public static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            Console.WriteLine(DateModifier.GetDifferenceBetweenTwoDates(firstDate, secondDate));
        }
    }
}
