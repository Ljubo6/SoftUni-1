using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var phonebook = new SortedDictionary<string, string>();

            while (true)
            {
                List<string> commands = Console.ReadLine().Split(' ').ToList();

                string command = commands[0];

                if (command == "A")
                {
                    string name = commands[1];
                    string number = commands[2];
                    phonebook[name] = number;
                }
                else if (command == "S")
                {
                    string name = commands[1];
                    if (phonebook.ContainsKey(name) == true)
                    {
                          Console.WriteLine($"{name} -> {phonebook[name]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                }
                else if (command == "END")
                {
                    break;
                }
            }
        }
    }
}
