using System;
using System.Collections.Generic;
using System.Text;

namespace P09.Simple_Text_Editor
{
    class TextEditor
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            int lines = int.Parse(Console.ReadLine());
            Stack<string> history = new Stack<string>();
            history.Push(text);

            for (int i = 0; i < lines; i++)
            {
                string[] currentCommand = Console.ReadLine().Split();
                switch (currentCommand[0])
                {
                    case "1":
                        text += currentCommand[1];
                        history.Push(text);
                        break;
                    case "2":
                        int countToErase = int.Parse(currentCommand[1]);
                        text = text.Substring(0, text.Length-countToErase);
                        history.Push(text);
                        break;
                    case "3":
                        int index = int.Parse(currentCommand[1]) - 1;
                        Console.WriteLine(text[index]);
                        break;
                    case "4":
                        history.Pop();
                        text = history.Peek();
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
