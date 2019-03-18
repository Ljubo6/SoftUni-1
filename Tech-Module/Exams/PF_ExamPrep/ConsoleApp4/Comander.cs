using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Commander_Interpreter
{
    class Commander
    {
        static void Main(string[] args)
        {
            List<string> texts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "reverse")
                {
                    int index = int.Parse(command[2]);
                    int count = int.Parse(command[4]);

                    if (!CheckingParameters(count, index, texts))
                    {
                        Console.WriteLine("Invalid input parameters");
                        break;
                    }
                    else
                    {
                        texts.Reverse(index, count);
                    }

                }

                if (command[0] == "sort")
                {
                    int index = int.Parse(command[2]);
                    int count = int.Parse(command[4]);

                    if (!CheckingParameters(count, index, texts))
                    {
                        Console.WriteLine("Invalid input parameters");
                        break;
                    }
                    else
                    {
                        List<string> workingList = new List<string>();

                        for (int i = 0; i <= count - index; i++)
                        {
                            workingList.Add(texts[index]);
                            texts.RemoveAt(index);
                        }
                        workingList.Sort();
                        workingList.Reverse();
                        for (int i = 0; i < workingList.Count; i++)
                        {
                            texts.Insert(index, workingList[i]);
                        }
                    }
                }

                if (command[0] == "rollLeft")
                {
                    int count = int.Parse(command[1]);

                    if (!CheckingParameters(count, 0, texts))
                    {
                        Console.WriteLine("Invalid input parameters");
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            texts.Add(texts[0]);
                            texts.RemoveAt(0);
                        }
                    }
                }

                if (command[0] == "rollRight")
                {
                    int count = int.Parse(command[1]);

                    if (!CheckingParameters(count, 0, texts))
                    {
                        Console.WriteLine("Invalid input parameters");
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            texts.Insert(0, texts.Last());
                            texts.Remove(texts[texts.Count - 1]);
                        }
                    }
                }

                command = Console.ReadLine().Split();
            }
            Console.WriteLine("["+string.Join(", ", texts)+"]");
        }
        static bool CheckingParameters(int count, int index, List<string> texts)
        {
            if (index < 0 || index >= texts.Count || count < 0)
            {
                return false;
            }
            return true;
        }
    }
}
