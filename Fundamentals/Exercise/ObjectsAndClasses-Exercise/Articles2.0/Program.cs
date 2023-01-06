using System.Linq;
using System;
using System.Collections.Generic;

namespace _02.Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Article> articlesList = new List<Article>();
            int cycles = int.Parse(Console.ReadLine());
            string command = string.Empty;
            for (int i = 0; i < cycles; i++)
            {
                command = Console.ReadLine();
                string[] cmdArgs = command.Split(", ");
                Article article = new Article(cmdArgs[0], cmdArgs[1], cmdArgs[2]);
                articlesList.Add(article);
            }
            command = Console.ReadLine();
            foreach (Article article in articlesList)
            {
                Console.WriteLine(article.ToString());
            }
        }
    }
    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
