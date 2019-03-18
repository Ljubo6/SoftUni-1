using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Winning_Ticket
{
    class Ticket
    {
        public static void Main()
        {
            char[] winningSymbols = new char[] { '@', '#', '$', '^' };

            string[] ticketsToValidate = Console.ReadLine()
                    .Split(new char[] { ',', ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            for (int i = 0; i < ticketsToValidate.Length; i++)
            {
                string currentTicket = ticketsToValidate[i];

                if (currentTicket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                else
                {
                    string leftHalf = currentTicket.Substring(0, 10);
                    string rightHalf = currentTicket.Substring(10);

                    int LeftCounter = 1;
                    char LeftWinningChar = '\0';

                    for (int j = 0; j < leftHalf.Length - 1; j++)
                    {
                        if (winningSymbols.Contains(leftHalf[j]) && leftHalf[j] == leftHalf[j+1])
                        {
                            LeftCounter++;
                            LeftWinningChar = currentTicket[j];
                        }
                        else
                        {
                            if (LeftCounter >= 6)
                            {
                                break;
                            }
                            else
                            {
                                LeftCounter = 1;
                                LeftWinningChar = '\0';
                            }
                        }
                    }

                    int rightCounter = 1;
                    char rightWinningChar = '\0';

                    for (int j = 0; j < rightHalf.Length - 1; j++)
                    {
                        if (winningSymbols.Contains(rightHalf[j]) && rightHalf[j] == rightHalf[j + 1])
                        {
                            rightCounter++;
                            rightWinningChar = rightHalf[j];
                        }
                        else
                        {
                            if (rightCounter >= 6)
                            {
                                break;
                            }
                            else
                            {
                                rightCounter = 1;
                                rightWinningChar = '\0';
                            }
                        }
                    }

                    if (LeftCounter !=10 && rightCounter != 10 && 
                        LeftCounter >= 6 && rightCounter == LeftCounter && 
                        LeftWinningChar == rightWinningChar)
                    {
                        Console.WriteLine($"ticket \"{currentTicket}\" - {LeftCounter}{LeftWinningChar}");

                    }
                    else if (LeftCounter == 10 && rightCounter == 10 && LeftWinningChar == rightWinningChar)
                    {
                        Console.WriteLine($"ticket \"{currentTicket}\" - 10{LeftWinningChar} Jackpot!");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{currentTicket}\" - no match");
                    }
                }
                
            }
        }
    }
}
