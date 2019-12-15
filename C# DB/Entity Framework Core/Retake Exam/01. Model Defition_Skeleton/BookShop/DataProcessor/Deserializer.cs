namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportBookDto[]),
                new XmlRootAttribute("Books"));

            var booksDto = (ImportBookDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();

            var books = new List<Book>();

            foreach (var bookDto in booksDto)
            {
                bool isValidGenre=false;  //= Enum.TryParse<Genre>(bookDto.Genre, out Genre genre);
                //=Enum.IsDefined(typeof(Genre), bookDto.Genre);

                if (bookDto.Genre=="1" || bookDto.Genre == "2" || bookDto.Genre == "3" ||
                    bookDto.Genre == "Biography" || bookDto.Genre == "Business" || bookDto.Genre == "Science")
                {
                    isValidGenre = true;
                }

                if (!IsValid(bookDto) || !isValidGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var book = new Book
                {
                    Name= bookDto.Name,
                    Genre= Enum.Parse<Genre>(bookDto.Genre),
                    PublishedOn= DateTime.ParseExact(bookDto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                };

                book.Price = bookDto.Price == null ? null : book.Price = bookDto.Price;
                book.Pages = bookDto.Pages == null ? null : book.Pages = bookDto.Pages;

                books.Add(book);
                sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorsDto = JsonConvert.DeserializeObject<ImportAuthorDto[]>(jsonString);

            var sb = new StringBuilder();
            var authors = new List<Author>();
            var emails = new List<string>();

            foreach (var authorDto in authorsDto)
            {

                if (!IsValid(authorDto) || emails.Contains(authorDto.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                emails.Add(authorDto.Email);

                var author = new Author
                {
                    FirstName=authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Email = authorDto.Email,
                    Phone = authorDto.Phone,
                };

                //bool isNotExistBook = false;
                
                foreach (var bookDto in authorDto.Books)
                {
                    //if (!IsValid(bookDto))
                    //{
                    //    sb.AppendLine(ErrorMessage);
                    //    continue;
                    //}
                    var book = context.Books.FirstOrDefault(x => x.Id == bookDto.Id);

                    if(book==null)
                    {
                        //isNotExistBook = true;
                        //sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var authorBook = new AuthorBook
                    {
                        Book = book,
                        Author=author
                    };

                    author.AuthorsBooks.Add(authorBook);
                }

                if(author.AuthorsBooks.Count<=0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(author);
                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, author.FirstName+" "+ author.LastName, author.AuthorsBooks.Count));
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}