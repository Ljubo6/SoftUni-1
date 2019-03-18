using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Articles
{
    class Article
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

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    public class Articles
    {
        static void Main()
        {
            List<Article> articles = new List<Article>();

            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                Article currentArtcle = new Article(input[0], input[1], input[2]);
                articles.Add(currentArtcle);
            }

            string infoToOrderBy = Console.ReadLine();

            if (infoToOrderBy == "title")
            {
                articles = articles.OrderBy(x => x.Title).ToList();
            }
            else if (infoToOrderBy == "content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
            }
            else if (infoToOrderBy == "author")
            {
                articles = articles.OrderBy(x => x.Author).ToList();
            }

            foreach (var article in articles)
            {
                Console.WriteLine(article.ToString());
            }
        }
    }
}