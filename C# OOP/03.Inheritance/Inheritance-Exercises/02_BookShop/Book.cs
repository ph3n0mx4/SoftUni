namespace _02_BookShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Book
    {
        private string author;
        private string title;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public string Author
        {
            get => this.author;

            set
            {
                var name = value.Split(" ").ToArray();
                if(name.Length>1 && char.IsDigit(name[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
                this.author = value;
            }
        }

        public string Title
        {
            get => this.title;
            set
            {
                if(value.Length<3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                this.title = value;
            }
        }

        public virtual decimal Price
        {
            get => this.price;
            set
            {
                if(value<=0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}{Environment.NewLine}Title: {this.Title}{Environment.NewLine}Author: {this.Author}{Environment.NewLine}Price: {this.price:f2}";
        }
        //return $"Type: {this.GetType().Name}{Environment.NewLine}Title: {this.Title}{Environment.NewLine}Author: {this.Author}{Environment.NewLine}Price: {this.Price:f2}";
    }
}
