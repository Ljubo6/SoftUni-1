using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.Crossroads
{
    class Crossroad
    {
        public static void Main()
        {
            int greenLightInitial = int.Parse(Console.ReadLine());
            int windowInitial = int.Parse(Console.ReadLine());
            int safelyPassedCarsCount = 0;
            Queue<string> carQueue = new Queue<string>();

            string input = Console.ReadLine();
            
            while (input != "END")
            {
                if (input != "green")
                {
                    carQueue.Enqueue(input); // queueing up a new car
                }
                else
                {
                    int greenLight = greenLightInitial;
                    int window = windowInitial;
                    bool passedInWindowTime = false;

                    while (carQueue.Any())
                    {
                        if (greenLight > 0)
                        {
                            if (greenLight >= carQueue.Peek().Length)
                            {
                                greenLight -= carQueue.Peek().Length;
                                carQueue.Dequeue();
                                safelyPassedCarsCount++;
                            }
                            else if (greenLight + window >= carQueue.Peek().Length)
                            {
                                window -= carQueue.Peek().Length - greenLight;
                                carQueue.Dequeue();
                                safelyPassedCarsCount++;
                                break;
                            }
                            else
                            {
                                int hitPointIndex = greenLight + window;
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{carQueue.Peek()} was hit at {carQueue.Peek()[hitPointIndex]}.");
                                return;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{safelyPassedCarsCount} total cars passed the crossroads.");
        }
    }
}
