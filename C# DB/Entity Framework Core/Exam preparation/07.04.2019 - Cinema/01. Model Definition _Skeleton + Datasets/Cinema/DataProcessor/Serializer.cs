namespace Cinema.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Cinema.DataProcessor.ExportDto;
    

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context
                .Movies
                .Where(m => m.Rating >= rating && m.Projections.Any())
                .OrderByDescending(m => m.Rating)
                .ThenByDescending(m => m.Projections.Sum(x => x.Tickets.Sum(y => y.Price)))
                .Select(m=> new
                {
                    MovieName=m.Title,
                    Rating=$"{m.Rating:f2}",
                    TotalIncomes= $"{m.Projections.Sum(x=>x.Tickets.Sum(y=>y.Price)):f2}",
                    Customers= m.Projections.SelectMany(p=>p.Tickets)
                            .Select(t=>new
                            {
                                FirstName=t.Customer.FirstName,
                                LastName = t.Customer.LastName,
                                Balance = $"{t.Customer.Balance:f2}",
                            })
                            .OrderByDescending(t => t.Balance)
                            .ThenBy(t => t.FirstName)
                            .ThenBy(t => t.LastName)
                            .ToArray()
                })
                .Take(10)
                .ToArray();

            var json = JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);
            return json;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context
                .Customers
                .Where(c => c.Age > age)
                .OrderByDescending(c => c.Tickets.Sum(t => t.Price))
                .Select(c => new ExportCustomerDto
                {
                    FirstName=c.FirstName,
                    LastName=c.LastName,
                    SpentMoney=$"{c.Tickets.Sum(t=>t.Price):f2}",
                    SpentTime = $"{TimeSpan.FromSeconds(c.Tickets.Sum(t => t.Projection.Movie.Duration.TotalSeconds)).ToString(@"hh\:mm\:ss")}"
                  
                })
                //.OrderByDescending(c=>c.SpentMoney)
                .Take(10)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCustomerDto[]),
                new XmlRootAttribute("Customers"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, customers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}