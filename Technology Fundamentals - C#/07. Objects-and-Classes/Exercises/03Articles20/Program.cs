using System;
using System.Collections.Generic;
using System.Linq;

namespace _03Articles20
{
    class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

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
            int n = int.Parse(Console.ReadLine());

            var listArticle = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(", ").ToArray();

                Article article = new Article();
                article.Title = data[0];
                article.Content = data[1];
                article.Author = data[2];

                listArticle.Add(article);
            }

            string cmdOrder = Console.ReadLine();
            if(cmdOrder== "title")
            {
                listArticle.OrderBy(x => x.Title).ToList().ForEach(x => Console.WriteLine(x.ToString()));
            }

            else if(cmdOrder=="content")
            {
                listArticle.OrderBy(x => x.Content).ToList().ForEach(x => Console.WriteLine(x.ToString()));
            }

            else if(cmdOrder=="author")
            {
                listArticle.OrderBy(x => x.Author).ToList().ForEach(x => Console.WriteLine(x.ToString()));
            }

            //Console.WriteLine(string.Join(Environment.NewLine,listArticle));
        }
    }
}
