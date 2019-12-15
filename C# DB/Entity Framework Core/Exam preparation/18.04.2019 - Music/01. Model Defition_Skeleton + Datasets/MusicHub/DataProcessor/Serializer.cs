namespace MusicHub.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.DataProcessor.ExportDtos;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context
                .Albums
                .Where(x => x.ProducerId == producerId)
                .OrderByDescending(a=>a.Price)
                .Select(a => new
                {
                    AlbumName=a.Name,
                    ReleaseDate=a.ReleaseDate.ToString(@"MM\/dd\/yyyy"),
                    ProducerName=a.Producer.Name,
                    Songs = a.Songs
                        .Select(s=> new
                            {
                                SongName=s.Name,
                                Price=$"{s.Price:f2}",
                                Writer=s.Writer.Name
                        })
                        .OrderByDescending(s=>s.SongName)
                        .ThenBy(s=>s.Writer)
                        .ToArray(),
                    AlbumPrice= $"{a.Price:f2}"
                })
                .ToArray();
            var json = JsonConvert.SerializeObject(albums, Newtonsoft.Json.Formatting.Indented);
            return json;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context
                .Songs
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new ExportSongDto
                {
                    SongName = s.Name,
                    Writer = s.Writer.Name,
                    Performer = s.SongPerformers.Select(p => $"{p.Performer.FirstName} {p.Performer.LastName}").FirstOrDefault(),
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = TimeSpan.FromSeconds(s.Duration.TotalSeconds).ToString("c")
                })
                .OrderBy(s=>s.SongName)
                .ThenBy(s=>s.Writer)
                .ThenBy(s=>s.Performer)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportSongDto[]),
                new XmlRootAttribute("Songs"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, songs, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}