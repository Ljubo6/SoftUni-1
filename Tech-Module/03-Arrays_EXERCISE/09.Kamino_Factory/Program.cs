using System;
using System.Linq;

namespace _09.Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequenceLength = int.Parse(Console.ReadLine());

            int length = 0;
            int sum = 0;
            int startIndex = -1;
            int row = 0;
            int currentRow = 1;
            int[] bestDNA = new int[sequenceLength];

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Clone them!")
                {
                    break;
                }

                int[] currentDNA = command
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currentSum = 0;


                for (int i = 0; i < currentDNA.Length; i++)
                {
                    if (currentDNA[i] == 1)
                    {
                        currentSum++;
                    }
                }

                if (currentRow == 1)
                {
                    bestDNA = currentDNA;
                    row = currentRow;
                    sum = currentSum;
                }

                int currentStartIndex = -1;
                int currentLength = 0;
                bool isFound = false;

                for (int i = 0; i < currentDNA.Length; i++)
                {
                    if (currentDNA[i] == 1)
                    {
                        if (!isFound)
                        {
                            currentStartIndex = i;
                        }
                        currentLength++;

                        if (currentLength > length)
                        {
                            length = currentLength;
                            startIndex = currentStartIndex;
                            sum = currentSum;
                            row = currentRow;
                            bestDNA = currentDNA;
                        }
                        else if (currentLength == length)
                        {
                            if (currentStartIndex < startIndex)
                            {
                                length = currentLength;
                                startIndex = currentStartIndex;
                                sum = currentSum;
                                row = currentRow;
                                bestDNA = currentDNA;
                            }
                            else if (currentSum > sum)
                            {
                                length = currentLength;
                                startIndex = currentStartIndex;
                                sum = currentSum;
                                row = currentRow;
                                bestDNA = currentDNA;
                            }
                        }
                    }
                    else
                    {
                        currentStartIndex = -1;
                        currentLength = 0;
                        isFound = false;
                        
                    }
                }
                currentRow++;
            }
            Console.WriteLine($"Best DNA sample {row} with sum: {sum}.");
            Console.WriteLine(string.Join(' ', bestDNA));
        }
    }
}
