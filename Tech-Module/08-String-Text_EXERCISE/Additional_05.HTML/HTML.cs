using System;

namespace Additional_05.HTML
{
    class HTML
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            PrintingTags(title, "h1");

            string content = Console.ReadLine();
            PrintingTags(content, "article");

            string comment = Console.ReadLine();

            while (comment != "end of comments")
            {
                PrintingTags(comment, "div");
                comment = Console.ReadLine();
            }
        }

        public static void PrintingTags(string element, string tag)
        {
            Console.WriteLine($"<{tag}>");
            Console.WriteLine($"\t {element}");
            Console.WriteLine($"</{tag}>");
        }
    }
}
