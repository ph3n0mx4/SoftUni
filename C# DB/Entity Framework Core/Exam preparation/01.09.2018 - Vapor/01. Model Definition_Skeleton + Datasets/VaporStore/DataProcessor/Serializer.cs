namespace VaporStore.DataProcessor
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
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.ExportDtos;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            var games = context
                .Genres
                .Where(g => genreNames.Contains(g.Name))
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                        .Where(x => x.Purchases.Any())
                        .Select(y => new
                        {
                            Id = y.Id,
                            Title = y.Name,
                            Developer = y.Developer.Name,
                            Tags = string.Join(", ", y.GameTags.Select(t => t.Tag.Name).ToArray()),
                            Players = y.Purchases.Count
                        })
                        .OrderByDescending(x=>x.Players)
                        .ThenBy(x=>x.Id)
                        .ToArray(),
                    TotalPlayers = g.Games.Sum(x => x.Purchases.Count)
                })
                .OrderByDescending(g=>g.TotalPlayers)
                .ThenBy(g=>g.Id)
                .ToArray();

            var json = JsonConvert.SerializeObject(games, Newtonsoft.Json.Formatting.Indented);
            return json;
        }

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
            var purchaseType = Enum.Parse<PurchaseType>(storeType);
            var users = context
                .Users
                //.Where(u => u.Cards.SelectMany(x => x.Purchases).Any(y=>y.Type== purchasetype))
                //&& u.Cards.All(x => x.Purchases.Any()))
                .Select(u => new ExportUserDto
                {
                    Username = u.Username,
                    Purchases= u.Cards
                        .SelectMany(f=>f.Purchases)
                        .Where(p=>p.Type==purchaseType)
                        .Select(z=> new ExportPurchaseDto
                        {
                            CardNumber=z.Card.Number,
                            Cvc=z.Card.Cvc,
                            Date=z.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game=new ExportGameDto
                            {
                                Title=z.Game.Name,
                                Genre=z.Game.Genre.Name,
                                Price=z.Game.Price
                            }
                        })
                        .OrderBy(p=>p.Date)
                        .ToArray(),
                    TotalSpent = u.Cards.SelectMany(c=>c.Purchases).Where(p => p.Type == purchaseType).Sum(p=>p.Game.Price)
                    //TotalSpent = u.Cards.Sum(x => x.Purchases.Sum(y => y.Game.Price))
                })
                .Where(p => p.Purchases.Any())
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u=>u.Username)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportUserDto[]),
                new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, users, namespaces);
            }

            return sb.ToString().TrimEnd();
		}
	}
}