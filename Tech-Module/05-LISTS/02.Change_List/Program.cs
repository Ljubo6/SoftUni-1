using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                List<string> command = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

                int element = 0;
                int position = 0;

                if (command.Count == 2)
                {
                    element = Int32.Parse(command[1]);
                }
                if (command.Count == 3)
                {
                    element = Int32.Parse(command[1]);
                    position = Int32.Parse(command[2]);
                }
                if (command[0] == "Delete")
                {
                    int counter = 0;
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] == element)
                        {
                            counter++;
                        }
                    }
                    for (int a = 0; a < counter; a++)
                    {
                        numbers.Remove(element);
                    }
                   
                }

                if (command[0] == "Insert")
                {
                    numbers.Insert(position, element);
                }

                if (command[0] == "Odd")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 == 1)
                        {
                            Console.Write(numbers[i] + " ");
                        }
                        
                    }
                    break;
                }
                else if (command[0] == "Even")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 == 0)
                        {
                            Console.Write(numbers[i] + " ");
                        }

                    }
                    break;
                }
            }
        }
    }
}
