namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.ImportDtos;

    public static class Deserializer
	{
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gamesDto = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            var sb = new StringBuilder();
            var games = new List<Game>();

            foreach (var gameDto in gamesDto)
            {
                if (!IsValid(gameDto) || gameDto.Tags.Count==0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                //•	If a developer/genre/tag with that name doesn’t exist, create it. 

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                };

                var developer = GetDeveloper(context, gameDto.Developer);
                var genre = GetGenre(context, gameDto.Genre);

                game.Developer = (Developer)developer;
                game.Genre = (Genre)genre;

                foreach (var currentTag in gameDto.Tags)
                {
                    var tag = GetTag(context, currentTag);

                    game.GameTags.Add(new GameTag
                    {
                        Game = game,
                        Tag = tag
                    });
                }

                games.Add(game);
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();
            var result = sb.ToString().TrimEnd();
            return result;
		}

        
        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            var usersDto = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            var sb = new StringBuilder();
            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                if (!IsValid(userDto) || userDto.Cards.Length == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isValid = true;

                foreach (var card in userDto.Cards)
                {
                    var cardType = Enum.TryParse<CardType>(card.Type, out CardType test);
                    
                    if(!cardType || !IsValid(card))
                    {
                        isValid = false;
                    }
                }

                if(!isValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User
                {
                    Username=userDto.Username,
                    FullName= userDto.FullName,
                    Age=userDto.Age,
                    Email=userDto.Email
                };

                //var cards = new List<Card>();

                foreach (var currentCard in userDto.Cards)
                {
                    var card = new Card
                    {
                        Number=currentCard.Number,
                        Cvc=currentCard.Cvc,
                        Type= Enum.Parse<CardType>(currentCard.Type)
                    };

                    user.Cards.Add(card);
                }

                users.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            var xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]),
                new XmlRootAttribute("Purchases"));

            var purchasesDto = (ImportPurchaseDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();
            var purchases = new List<Purchase>();

            foreach (var purchaseDto in purchasesDto)
            {
                if(!IsValid(purchaseDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isValidEnum = Enum.TryParse<PurchaseType>(purchaseDto.Type, out PurchaseType purchaseType);

                if (!isValidEnum)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var game = context.Games.FirstOrDefault(x => x.Name == purchaseDto.Title);
                var card = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.Card);

                if(game==null || card==null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var purchase = new Purchase
                {
                    Type = purchaseType,
                    Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    ProductKey= purchaseDto.Key,
                    Game=game,
                    Card=card
                };

                purchases.Add(purchase);
                sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid (object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }

        private static Genre GetGenre(VaporStoreDbContext context, string gameDtoGenre)
        {
            var genre = context.Genres.FirstOrDefault(x => x.Name == gameDtoGenre);

            if (genre == null)
            {
                genre = new Genre
                {
                    Name = gameDtoGenre
                };

                context.Genres.Add(genre);
                context.SaveChanges();
            }

            return genre;
        }

        private static Developer GetDeveloper(VaporStoreDbContext context, string gameDtoDeveloper)
        {
            var developer = context.Developers.FirstOrDefault(x => x.Name == gameDtoDeveloper);

            if (developer == null)
            {
                developer = new Developer
                {
                    Name = gameDtoDeveloper
                };

                context.Developers.Add(developer);
                context.SaveChanges();
            }

            return developer;
        }

        private static Tag GetTag(VaporStoreDbContext context, string currentTag)
        {
            var tag = context.Tags.FirstOrDefault(x => x.Name == currentTag);

            if (tag == null)
            {
                tag = new Tag
                {
                    Name = currentTag
                };

                context.Tags.Add(tag);
                context.SaveChanges();
            }

            return tag;
        }

    }
}