using System;

namespace _02.Character_Multiplier
{
    class CharMultiply
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string firstText = input[0];
            string secondText = input[1];

            int rotations = Math.Min(firstText.Length, secondText.Length);
            long sum = 0L;

            for (int i = 0; i < rotations; i++)
            {
                sum += firstText[i] * secondText[i];
            }

            if (firstText.Length > secondText.Length)
            {
                for (int i = 0; i < firstText.Length - rotations; i++)
                {
                    sum += firstText[rotations + i];
                }
                
            }
            else if (secondText.Length > firstText.Length)
            {
                for (int i = 0; i < secondText.Length - rotations; i++)
                {
                    sum += secondText[rotations + i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
