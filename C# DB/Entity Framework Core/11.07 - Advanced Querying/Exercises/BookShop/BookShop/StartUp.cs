namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                DbInitializer.ResetDatabase(db);
                var input = Console.ReadLine();

                Console.WriteLine(GetBooksByCategory(db,input));
            }
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var inputCategories = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(bc => bc.ToLower())
                .ToArray();

            var titlesByCategory = context
                .BooksCategories
                .Where(bc =>
                inputCategories.Contains(bc.Category.Name.ToLower()))
                .Select(bc => bc.Book.Title)
                .OrderBy(b => b)
                .ToList();

            var resultToPrint = new StringBuilder();


            foreach (var bookTitle in titlesByCategory)
            {
                resultToPrint.AppendLine(bookTitle);
            }

            return resultToPrint.ToString().TrimEnd();
        }
    }
}
