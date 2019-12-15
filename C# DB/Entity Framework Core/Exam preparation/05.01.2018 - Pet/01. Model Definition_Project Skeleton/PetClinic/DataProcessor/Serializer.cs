namespace PetClinic.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.ExportDtos;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var owners = context
                .Animals
                .Where(x => x.Passport.OwnerPhoneNumber == phoneNumber)
                .OrderBy(x=>x.Age)
                .ThenBy(x=>x.PassportSerialNumber)
                .Select(x => new
                {
                    //"OwnerName": "Ivan Ivanov",
                    //"AnimalName": "Jessy",
                    //"Age": 3,
                    //"SerialNumber": "jessiii355",
                    //"RegisteredOn": "05-11-2015"
                    OwnerName=x.Passport.OwnerName,
                    AnimalName=x.Name,
                    Age=x.Age,
                    SerialNumber=x.PassportSerialNumber,
                    RegisteredOn=x.Passport.RegistrationDate.ToString(@"dd-MM-yyyy", CultureInfo.InvariantCulture)
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(owners, Newtonsoft.Json.Formatting.Indented);
            return json;
            //throw new NotImplementedException();
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedures = context
                .Procedures
                .OrderBy(x => x.DateTime)
                .ThenBy(x => x.Animal.PassportSerialNumber)
                .Select(x => new ExportProcedureDto
                {
                    Passport=x.Animal.PassportSerialNumber,
                    OwnerNumber=x.Animal.Passport.OwnerPhoneNumber,
                    DateTime=x.DateTime.ToString(@"dd-MM-yyyy", CultureInfo.InvariantCulture),
                    AnimalAids=x.ProcedureAnimalAids
                        .Select(y=> new AnimalAidDto
                        {
                            Name=y.AnimalAid.Name,
                            Price=y.AnimalAid.Price.ToString()
                        })
                        .ToArray(),
                    TotalPrice= x.ProcedureAnimalAids.Sum(y=>y.AnimalAid.Price).ToString()
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportProcedureDto[]),
                new XmlRootAttribute("Procedures"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, procedures, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
