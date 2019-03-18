using System;
using System.Collections.Generic;
using System.Linq;
namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 12, 765, 44, 244, 56, 1, 4, 12, 66, 100, 3, 241 };
            int[] array = { 10, 10, 10 };

            numbers.Find(n => n == 12333);
        }
    }
}
