using System;
using System.Linq;

namespace _02.Articles
{
    public class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuhtor)
        {
            Author = newAuhtor;
        }

        public void Rename (string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    class Articles
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Article article = new Article(input[0], input[1], input[2]);

            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string task = command[0];
                string newInfo = command[1];
                if (task == "Edit")
                {
                    article.Edit(newInfo);
                }
                else if (task == "ChangeAuthor")
                {
                    article.ChangeAuthor(newInfo);
                }
                else if (task == "Rename")
                {
                    article.Rename(newInfo);
                }
            }
            Console.WriteLine(article.ToString());
        }
    }
}
