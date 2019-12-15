namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var author = context
                .Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks
                        .OrderByDescending(b=>b.Book.Price)
                        .Select(b => new
                        {
                            BookName=b.Book.Name,
                            BookPrice=$"{b.Book.Price:f2}"
                        })
                        .ToArray()
                })
                .ToArray()
                .OrderByDescending(a=>a.Books.Length)
                .ThenBy(a=>a.AuthorName)
                .ToArray();

            var json = JsonConvert.SerializeObject(author, Newtonsoft.Json.Formatting.Indented);
            return json;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var books = context
                .Books
                .Where(b=>b.PublishedOn<date && (int)b.Genre==3)
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .Select(b => new ExportBookDto
                {
                    Pages=b.Pages.ToString(),
                    Name=b.Name,
                    Date=b.PublishedOn.ToString("d",CultureInfo.InvariantCulture)
                })
                .ToArray()
                .Take(10)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportBookDto[]),
                new XmlRootAttribute("Books"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, books, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}