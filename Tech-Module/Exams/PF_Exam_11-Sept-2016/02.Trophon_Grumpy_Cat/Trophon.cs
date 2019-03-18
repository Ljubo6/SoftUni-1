using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Trophon_Grumpy_Cat
{
    class Trophon
    {
        static void Main(string[] args)
        {
            List<int> priceRatings = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int entryPoint = int.Parse(Console.ReadLine());
            string itemType = Console.ReadLine();
            string priceRatingType = Console.ReadLine();

            long leftSum = 0;
            long rightSum = 0;

            int entryPointItem = priceRatings[entryPoint];
            

            for (int left = 0; left < entryPoint; left++)
            {
                if (itemType == "cheap")
                {
                    if (priceRatings[left] < entryPointItem)
                    {
                        if (priceRatingType == "positive")
                        {
                            if (priceRatings[left] > 0)
                            {
                                leftSum += priceRatings[left];
                            }
                        }
                        else if (priceRatingType == "negative")
                        {
                            if (priceRatings[left] < 0)
                            {
                                leftSum += priceRatings[left];
                            }
                        }
                        else if (priceRatingType == "all")
                        {
                            leftSum += priceRatings[left];
                        }
                    }
                }

                if (itemType == "expensive")
                {
                    if (priceRatings[left] >= entryPointItem)
                    {
                        if (priceRatingType == "positive")
                        {
                            if (priceRatings[left] > 0)
                            {
                                leftSum += priceRatings[left];
                            }
                        }
                        else if (priceRatingType == "negative")
                        {
                            if (priceRatings[left] < 0)
                            {
                                leftSum += priceRatings[left];
                            }
                        }
                        else if (priceRatingType == "all")
                        {
                            leftSum += priceRatings[left];
                        }
                    }
                }
            }
            for (int right = entryPoint+1; right < priceRatings.Count; right++)
            {
                if (itemType == "cheap")
                {
                    if (priceRatings[right] < entryPointItem)
                    {
                        if (priceRatingType == "positive")
                        {
                            if (priceRatings[right] > 0)
                            {
                                rightSum += priceRatings[right];
                            }
                        }
                        else if (priceRatingType == "negative")
                        {
                            if (priceRatings[right] < 0)
                            {
                                rightSum += priceRatings[right];
                            }
                        }
                        else if (priceRatingType == "all")
                        {
                            rightSum += priceRatings[right];
                        }
                    }
                }

                if (itemType == "expensive")
                {
                    if (priceRatings[right] >= entryPointItem)
                    {
                        if (priceRatingType == "positive")
                        {
                            if (priceRatings[right] > 0)
                            {
                                rightSum += priceRatings[right];
                            }
                        }
                        else if (priceRatingType == "negative")
                        {
                            if (priceRatings[right] < 0)
                            {
                                rightSum += priceRatings[right];
                            }
                        }
                        else if (priceRatingType == "all")
                        {
                            rightSum += priceRatings[right];
                        }
                    }
                }
            }

            if (leftSum >= rightSum)
            {
                Console.WriteLine($"Left - {leftSum}");
            }
            else 
            {
                Console.WriteLine($"Right - {rightSum}");
            }
        }
    }
}
