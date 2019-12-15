namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.ImportDtos;
    using PetClinic.Models;

    public class Deserializer
    {
        private const string ErrorMessage = "Error: Invalid data.";

        private const string SuccessfullyImportedAnimalAids
            = "Record {0} successfully imported.";

        private const string SuccessfullyImportedAnimals
            = "Record {0} Passport №: {1} successfully imported.";

        private const string SuccessfullyImportedProcedureAnimalAids
            = "Record successfully imported.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var animalAidsDto = JsonConvert.DeserializeObject<ImportAnimalAidDto[]>(jsonString);

            var sb = new StringBuilder();
            var animalAids = new List<AnimalAid>();
            var animalAidNames = new List<string>();

            foreach (var animalAidDto in animalAidsDto)
            {
                if (!IsValid(animalAidDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var animalAid = new AnimalAid
                {
                    Name=animalAidDto.Name,
                    Price= animalAidDto.Price
                };

                if(!animalAidNames.Contains(animalAid.Name))
                {
                    animalAids.Add(animalAid);
                    animalAidNames.Add(animalAid.Name);
                    sb.AppendLine(string.Format(SuccessfullyImportedAnimalAids, animalAid.Name));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
            }

            context.AnimalAids.AddRange(animalAids);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var animalsDto = JsonConvert.DeserializeObject<ImportAnimalDto[]>(jsonString);

            var sb = new StringBuilder();
            var animals = new List<Animal>();

            foreach (var animalDto in animalsDto)
            {
                bool animalIsValid = IsValid(animalDto);
                bool passportIsValid = IsValid(animalDto.Passport);

                bool alreadyExists = animals.Any(a => a.Passport.SerialNumber == animalDto.Passport.SerialNumber);

                if (!animalIsValid || !passportIsValid || alreadyExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var animal = new Animal
                {
                    Name = animalDto.Name,
                    Type = animalDto.Type,
                    Age=animalDto.Age
                };

                animal.Passport = new Passport
                {
                    OwnerName = animalDto.Passport.OwnerName,
                    OwnerPhoneNumber = animalDto.Passport.OwnerPhoneNumber,
                    SerialNumber = animalDto.Passport.SerialNumber,
                    RegistrationDate = DateTime.ParseExact(animalDto.Passport.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)
                };

                animals.Add(animal);
                sb.AppendLine(string.Format(SuccessfullyImportedAnimals, animal.Name, animal.Passport.SerialNumber));
            }

            context.Animals.AddRange(animals);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportVetDto[]),
                new XmlRootAttribute("Vets"));

            var vetsDto = (ImportVetDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();

            var vets = new List<Vet>();

            foreach (var vetDto in vetsDto)
            {
                bool alreadyExists = vets.Any(v => v.PhoneNumber == vetDto.PhoneNumber);

                if (!IsValid(vetDto) || alreadyExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var vet = new Vet
                {
                     Name=vetDto.Name,
                     Age=vetDto.Age,
                     PhoneNumber=vetDto.PhoneNumber,
                     Profession=vetDto.Profession
                };

                vets.Add(vet);
                sb.AppendLine(string.Format(SuccessfullyImportedAnimalAids, vet.Name));
            }

            context.Vets.AddRange(vets);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProcedureDto[]),
                new XmlRootAttribute("Procedures"));

            var proceduresDto = (ImportProcedureDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();

            var procedures = new List<Procedure>();

            foreach (var procedureDto in proceduresDto)
            {
                var vet = context.Vets.FirstOrDefault(v => v.Name == procedureDto.Vet);
                var animal = context.Animals.FirstOrDefault(v => v.Passport.SerialNumber == procedureDto.Animal);

                if (vet==null || animal==null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var procedure = new Procedure
                {
                    Animal=animal,
                    Vet=vet,
                    DateTime= DateTime.ParseExact(procedureDto.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture)
                };

                bool isValidAnimalAid = true;
                var animalAidsNames = new List<string>();

                foreach (var currentAnimalAid in procedureDto.AnimalAids)
                {
                    var animalAid = context.AnimalAids.FirstOrDefault(X => X.Name == currentAnimalAid.Name);

                    if(animalAid==null || animalAidsNames.Contains(currentAnimalAid.Name))
                    {
                        isValidAnimalAid = false;
                        break;
                    }

                    animalAidsNames.Add(currentAnimalAid.Name);

                    var procedureAnimalAid = new ProcedureAnimalAid
                    {
                        AnimalAid= animalAid,
                        Procedure = procedure
                    };

                    procedure.ProcedureAnimalAids.Add(procedureAnimalAid);
                }

                if (!isValidAnimalAid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                procedures.Add(procedure);
                sb.AppendLine(string.Format(SuccessfullyImportedProcedureAnimalAids));
            }

            context.Procedures.AddRange(procedures);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
            //throw new NotImplementedException();
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
