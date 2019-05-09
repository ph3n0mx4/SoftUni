using System;
using System.Collections.Generic;
using System.Linq;

namespace _02Articles
{
    class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public Article(string[] edit)
        {
            Title = edit[0];
            Content = edit[1];
            Author = edit[2];
        }

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            string result = $"{Title} - {Content}: {Author}";
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).ToArray();
            Article article = new Article(data);
            int n =int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if(cmd[0]== "Edit")
                {
                    article.Edit(cmd[1]);
                }
                else if(cmd[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(cmd[1]);
                }
                else if (cmd[0] == "Rename")
                {
                    article.Rename(cmd[1]);
                }
                data = new string[3];
            }
            Console.WriteLine(article);
        }
    }
}
