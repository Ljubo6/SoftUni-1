using System;
using System.Linq;

namespace P01.ListyIterator
{
    class StartUp
    {
        static void Main()
        {
            var set = new ListyIterator<string>();

            while (true)
            {
                var input = Console.ReadLine().Split().ToList();

                string command = input[0];

                if (command == "END")
                {
                    break;
                }

                try
                {
                    if (command == "Create")
                    {
                        input.RemoveAt(0);
                        set.Create(input);
                    }

                    if (command == "Move")
                    {
                        Console.WriteLine(set.Move());
                    }

                    if (command == "Print")
                    {
                        Console.WriteLine(set.Print());
                    }

                    if (command == "PrintAll")
                    {
                        Console.WriteLine(string.Join(' ', set));
                    }


                    if (command == "HasNext")
                    {
                        Console.WriteLine(set.HasNext());
                    }
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
