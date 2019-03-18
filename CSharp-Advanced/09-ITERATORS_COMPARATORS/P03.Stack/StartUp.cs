using System;

namespace P03.Stack
{
    public class StartUp
    {
        public static void Main()
        {
            var myStack = new MyStack<string>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "END")
                {
                    break;
                }

                if (input[0] == "Push")
                {
                    myStack.Push(input);
                }
                try
                {
                    if (input[0] == "Pop")
                    {
                        myStack.Pop();
                    }
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var item in myStack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
