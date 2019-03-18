using System;

using System.Linq;



namespace _02._Rotate_and_Sum

{

    class RotateAndSum

    {

        static void Main()

        {
            int[] numbers = Console.ReadLine()
             .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();

            int numberOfRotartions = int.Parse(Console.ReadLine());

            int[] sum = new int[numbers.Length];
            int[] newArray = new int[numbers.Length];

            for (int i = 0; i < numberOfRotartions; i++)
            {
                int lastElement = numbers[numbers.Length - 1];

                for (int j = numbers.Length - 1; j > 0; j--)
                {
                    numbers[j] = numbers[j - 1];
                }

                numbers[0] = lastElement;

                for (int k = 0; k < numbers.Length; k++)
                {
                    sum[k] += numbers[k];
                }
            }
            Console.WriteLine(string.Join(" ", sum));
        }

    }

}