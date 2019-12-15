namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            //var listIds = ids.ToList();

            var prisoners = context
                .Prisoners
                .Where(p => ids.Contains(p.Id))

                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers

                        .Select(o => new
                        {
                            OfficerName = o.Officer.FullName,
                            Department = o.Officer.Department.Name
                        })
                        .OrderBy(o => o.OfficerName)
                        .ToArray(),
                    TotalOfficerSalary = p.PrisonerOfficers.Sum(o => o.Officer.Salary)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var json = JsonConvert.SerializeObject(prisoners, Newtonsoft.Json.Formatting.Indented);
            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var prisonersBox = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();

            var prisoners = context
                .Prisoners
                .Where(p => prisonersBox.Contains(p.FullName))
                .OrderBy(p=>p.FullName)
                .ThenBy(p=>p.Id)
                .Select(p => new ExportPrisonerDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Messages = p.Mails.Select(m => new ExportMessagesDto
                    {
                        Description = ReverseText(m.Description)
                    })
                    .ToArray()
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportPrisonerDto[]),
                new XmlRootAttribute("Prisoners"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, prisoners, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        private static string ReverseText (string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }
    }
}