using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Array_Manipulator
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
                List<string> commands = Console.ReadLine()
                                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();

                if (commands[0] == "add")
                {
                    int position = int.Parse(commands[1]);
                    int added = int.Parse(commands[2]);
                    numbers.Insert(position, added);
                }

                if (commands[0] == "addMany")
                {
                    int position = int.Parse(commands[1]);
                    for (int i = commands.Count - 1; i > 1; i--)
                    {
                        int added = int.Parse(commands[i]);
                        numbers.Insert(position, added);
                    }
                }

                if (commands[0] == "contains")
                {
                    int controller = int.Parse(commands[1]);
                    if (numbers.Contains(controller) == true)
                    {
                        Console.WriteLine(numbers.IndexOf(controller));
                    }
                    else
                    {
                        Console.WriteLine("-1");
                    }
                }

                if (commands[0] == "remove")
                {
                    int position = int.Parse(commands[1]);
                    numbers.RemoveAt(position);
                }

                if (commands[0] == "shift")
                {
                    List<int> tempNumbers = new List<int>();
                    int positions = int.Parse(commands[1]);
                    
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        tempNumbers.Add(numbers[((i + positions) % numbers.Count)]);
                    }
                    numbers = tempNumbers;
                }

                if (commands[0] == "sumPairs")
                {
                    
                    List<int> sumNumbers = new List<int>();

                    if (numbers.Count % 2 == 0)
                    {
                        for (int i = 1; i <= numbers.Count; i+=2)
                        {
                            sumNumbers.Add(numbers[i] + numbers[i - 1]);
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= numbers.Count - 2; i += 2)
                        {
                            sumNumbers.Add(numbers[i] + numbers[i - 1]);
                        }
                        sumNumbers.Add(numbers[numbers.Count - 1]);
                    }
                    numbers = sumNumbers;
                }

                if (commands[0] == "print")
                {
                    Console.WriteLine("[" + String.Join(", ", numbers) + "]");
                    break;
                }
            }
        }
    }
}
