﻿namespace MusicHub.DataProcessor
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
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter 
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone 
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong 
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersDto = JsonConvert.DeserializeObject<ImportWriterDto[]>(jsonString);

            var sb = new StringBuilder();
            var writers = new List<Writer>();

            foreach (var writerDto in writersDto)
            {
                if (!IsValid(writerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = new Writer
                {
                    Name=writerDto.Name,
                    Pseudonym=writerDto.Pseudonym
                };

                writers.Add(writer);
                sb.AppendLine(string.Format(SuccessfullyImportedWriter,writer.Name));
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersDto = JsonConvert.DeserializeObject<ImportProducerAlbumDto[]>(jsonString);

            var sb = new StringBuilder();
            var producers = new List<Producer>();

            foreach (var producerDto in producersDto)
            {
                if (!IsValid(producerDto) || !producerDto.Albums.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var producer = new Producer
                {
                    Name = producerDto.Name,
                    PhoneNumber = producerDto.PhoneNumber,
                    Pseudonym = producerDto.Pseudonym,
                };

                foreach (var currentAlbum in producerDto.Albums)
                {
                    var album = new Album
                    {
                        Name = currentAlbum.Name,
                        ReleaseDate = DateTime.ParseExact(currentAlbum.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    };

                    producer.Albums.Add(album);
                }

                producers.Add(producer);

                if(producer.PhoneNumber==null)
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count));
                    
                }
                else
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count));
                }
                
            }
            context.Producers.AddRange(producers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongDto[]),
                new XmlRootAttribute("Songs"));

            var songsDto = (ImportSongDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();

            var songs = new List<Song>();

            foreach (var songDto in songsDto)
            {
                if (!IsValid(songDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var album = context.Albums.FirstOrDefault(a => a.Id == songDto.AlbumId);
                var writer = context.Writers.FirstOrDefault(a => a.Id == songDto.WriterId);
                var isValidEnum = Enum.TryParse<Genre>(songDto.Genre, out Genre genre);

                if (!isValidEnum || album==null || writer == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = new Song
                {
                    Name=songDto.Name,
                    Duration= TimeSpan.ParseExact(songDto.Duration, @"hh\:mm\:ss", CultureInfo.InvariantCulture) ,
                    CreatedOn = DateTime.ParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre= genre, //Enum.Parse<Genre>(songDto.Genre)
                    AlbumId=songDto.AlbumId,
                    WriterId=songDto.WriterId,
                    Price=songDto.Price
                };

                songs.Add(song);
                sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre,song.Duration));
            }
            context.Songs.AddRange(songs);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
            
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPerformerSongDto[]),
                new XmlRootAttribute("Performers"));

            var performersDto = (ImportPerformerSongDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();

            var performers = new List<Performer>();

            foreach (var performerDto in performersDto)
            {
                bool isValidSongs = true;

                foreach (var currentSong in performerDto.PerformersSongs)
                {
                    var song = context.Songs.FirstOrDefault(x => x.Id == currentSong.SongId);
                    if (song ==null )
                    {
                        isValidSongs = false;
                    }
                }

                if (!IsValid(performerDto) || !isValidSongs)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var performer = new Performer
                {
                    FirstName=performerDto.FirstName,
                    LastName=performerDto.LastName,
                    Age=performerDto.Age,
                    NetWorth=performerDto.NetWorth,
                };

                foreach (var currentSong in performerDto.PerformersSongs)
                {
                    var song = new SongPerformer
                    {
                        SongId = currentSong.SongId,
                    };
                    performer.PerformerSongs.Add(song);
                }

                performers.Add(performer);
                sb.AppendLine(string.Format(SuccessfullyImportedPerformer, performer.FirstName, performer.PerformerSongs.Count));
            }

            context.Performers.AddRange(performers);
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