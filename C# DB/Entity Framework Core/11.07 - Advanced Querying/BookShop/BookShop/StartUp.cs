namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);
                var input = Console.ReadLine();

                //var result = GetBooksByAgeRestriction(db, input);
                //var result = GetGoldenBooks(db);
                //var result = GetBooksByPrice(db);
                //var result = GetBooksNotReleasedIn(db,int.Parse(input));
                //var result = GetBooksByCategory(db, input);
                //var result = GetBooksReleasedBefore(db, input);
                //var result = GetAuthorNamesEndingIn(db, input);
                //var result = CountCopiesByAuthor(db);
                //var result = GetTotalProfitByCategory(db);
                var result = GetMostRecentBooks(db);

                Console.WriteLine(result);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var books = context
                .Books
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .OrderBy(b=>b.Title)
                .Select(b=>b.Title)
                .ToList();

            var sb = new StringBuilder();
            foreach (var b in books)
            {
                sb.AppendLine(b);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            
            var books = context
                .Books
                .Where(b => b.EditionType.ToString() == "Gold" && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var sb = new StringBuilder();
            foreach (var b in books)
            {
                sb.AppendLine(b);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - ${b.Price:f2}");
            }
            return sb.ToString().TrimEnd(); ;
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            List<string> books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var sb = new StringBuilder();

            //foreach (var b in books)
            //{
            //    sb.AppendLine(b);
            //}

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var books = context
                .BooksCategories
                .Where(b => categories.Contains(b.Category.Name.ToLower()))
                .Select(b => b.Book.Title)
                .ToList();

            
            var sb = new StringBuilder();

            foreach (var b in books.OrderBy(b => b))
            {
                sb.AppendLine(b);
            }

            //Console.WriteLine(sb.Length);

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);

            var books = context
                .Books
                .Where(b => b.ReleaseDate < dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.Price,
                    b.EditionType
                })
                ;

            var sb = new StringBuilder();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input.ToLower()))
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.FullName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var a in authors)
            {
                sb.AppendLine(a.FullName);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();
            var sb = new StringBuilder();

            foreach (var b in books)
            {
                sb.AppendLine(b);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b=>b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorFullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} ({b.AuthorFullName})");
            }

            return sb.ToString().TrimEnd();
            
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Select(b => b.Title)
                .ToList();

            return books.Count;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context
                .Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    Copies = a.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(a=>a.Copies)
                .ToList();

            var sb = new StringBuilder();

            foreach (var a in authors)
            {
                sb.AppendLine($"{a.FullName} - {a.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    Name = c.Name,
                    Profit = c.CategoryBooks.Sum(b => b.Book.Copies * b.Book.Price)
                })
                .OrderByDescending(c=>c.Profit)
                .ThenBy(c=>c.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var c in categories)
            {
                sb.AppendLine($"{c.Name} ${c.Profit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                        .OrderByDescending(b=>b.Book.ReleaseDate)
                        .Take(3)
                        .Select(b=>new
                        {
                            Title =b.Book.Title,
                            Release = b.Book.ReleaseDate
                        })
                        .OrderByDescending(b=>b.Release)
                })
                .OrderBy(c => c.Name)
                .ToList();
            var sb = new StringBuilder();

            foreach (var c in categories)
            {
                sb.AppendLine($"--{c.Name}");

                foreach (var b in c.Books)
                {
                    sb.AppendLine($"{b.Title} ({b.Release.Value.Year})");
                }
            }
            return sb.ToString().Trim();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var entities = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var entity in entities)
            {
                entity.Price += 5;
            }

            context.Books.UpdateRange(entities);

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksCategories = context
                .BooksCategories
                .Where(b => b.Book.Copies < 4200)
                .ToList();

            context.BooksCategories.RemoveRange(booksCategories);

            var books = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);

            context.SaveChanges();

            return books.Count;
        }
    }

    
}
