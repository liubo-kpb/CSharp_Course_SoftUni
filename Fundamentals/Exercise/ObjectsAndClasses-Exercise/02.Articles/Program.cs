using System;

namespace _02.Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string[] cmdArgs = command.Split(", ");

            Article article = new Article(cmdArgs[0], cmdArgs[1], cmdArgs[2]);
            int cycles = int.Parse(Console.ReadLine());
            for (int i = 0; i < cycles; i++)
            {
                command = Console.ReadLine();
                string action = command.Split(": ")[0];
                string change = command.Split(": ")[1];
                switch (action)
                {
                    case "Edit":
                        article.Content = change;
                        break;
                    case "ChangeAuthor":
                        article.Author = change;
                        break;
                    case "Rename":
                        article.Title = change;
                        break;
                }
            }
            Console.WriteLine(article.ToString());
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
