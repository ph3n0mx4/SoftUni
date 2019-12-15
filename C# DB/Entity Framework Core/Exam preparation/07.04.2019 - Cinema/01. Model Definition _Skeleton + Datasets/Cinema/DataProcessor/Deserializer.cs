namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDto = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);

            var sb = new StringBuilder();
            var movies = new List<Movie>();

            foreach (var movieDto in moviesDto)
            {
                if (!IsValid(movieDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidEnum = Enum.TryParse<Genre>(movieDto.Genre, out Genre purchaseType);

                if (!isValidEnum)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var titles = new List<string>();

                if(titles.Contains(movieDto.Title) || context.Movies.Any(x=>x.Title==movieDto.Title))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie
                {
                    Title=movieDto.Title,
                    Genre= Enum.Parse<Genre>(movieDto.Genre),
                    Duration = movieDto.Duration,
                    Rating=movieDto.Rating,
                    Director=movieDto.Director
                };

                movies.Add(movie);
                sb.AppendLine($"Successfully imported {movieDto.Title} with genre {movieDto.Genre} and rating {movieDto.Rating:F2}!");
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsDto = JsonConvert.DeserializeObject<ImportHallDto[]>(jsonString);
            var sb = new StringBuilder();
            var halls = new List<Hall>();

            foreach (var hallDto in hallsDto)
            {
                if (!IsValid(hallDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name=hallDto.Name,
                    Is3D=hallDto.Is3D,
                    Is4Dx=hallDto.Is4Dx
                };

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }

                string typeHall = "";
                
                if(hall.Is3D && hall.Is4Dx)
                {
                    typeHall = "4Dx/3D";
                }

                else if(hall.Is3D)
                {
                    typeHall = "3D";
                }

                else if (hall.Is4Dx)
                {
                    typeHall = "4Dx";
                }

                else
                {
                    typeHall = "Normal";
                }

                halls.Add(hall);
                sb.AppendLine(string.Format(SuccessfulImportHallSeat, hall.Name,typeHall,hall.Seats.Count));
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectionDto[]),
                new XmlRootAttribute("Projections"));

            var projectionsDto = (ImportProjectionDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();
            var projections = new List<Projection>();

            var hallsId = context.Halls.Select(h => h.Id);
            var moviesId = context.Movies.Select(h => h.Id);

            foreach (var projectionDto in projectionsDto)
            {
                var movie = context.Movies.FirstOrDefault(x => x.Id == projectionDto.MovieId);
                var hall = context.Halls.FirstOrDefault(x => x.Id == projectionDto.HallId);

                if (!IsValid(projectionDto) || movie == null || hall == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                var projection = new Projection
                {
                    MovieId=projectionDto.MovieId,
                    Movie=movie,
                    HallId= projectionDto.HallId,
                    Hall=hall,
                    DateTime= DateTime.ParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                projections.Add(projection);

                sb.AppendLine(string.Format(SuccessfulImportProjection, projection.Movie.Title, projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]),
                new XmlRootAttribute("Customers"));

            var customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();

            var customers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projectionsId = context.Projections.Select(p => p.Id);
                bool isValidTickets = true;
                foreach (var ticket in customerDto.Tickets)
                {
                    if(!projectionsId.Contains(ticket.ProjectionId) || !IsValid(ticket))
                    {
                        isValidTickets = false;
                        break;
                    }
                }

                if (!isValidTickets)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName=customerDto.FirstName,
                    LastName=customerDto.LastName,
                    Age=customerDto.Age,
                    Balance=customerDto.Balance,
                };

                foreach (var currentTicket in customerDto.Tickets)
                {
                    var ticket = new Ticket
                    {
                        Price = currentTicket.Price,
                        ProjectionId = currentTicket.ProjectionId
                    };

                    customer.Tickets.Add(ticket);
                }

                customers.Add(customer);
                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customer.Tickets.Count));
            }
            context.Customers.AddRange(customers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}