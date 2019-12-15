namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        private const string SuccessfullyImportedDepartment
            = "Imported {0} with {1} cells";

        private const string SuccessfullyImportedPrisoner
            = "Imported {0} {1} years old";

        private const string SuccessfullyImportedOfficer
            = "Imported {0} ({1} prisoners)";
        //Imported {officer name} ({prisoners count} prisoners)
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsDto = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            var sb = new StringBuilder();
            var departments = new List<Department>();

            foreach (var departmentDto in departmentsDto)
            {
                if (!IsValid(departmentDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var department = new Department
                {
                    Name = departmentDto.Name
                };

                bool isInvalidCell = false;

                foreach (var cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        isInvalidCell = true;
                        break;
                    }

                    var cell = new Cell
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow,
                        Department=department,
                    };

                    department.Cells.Add(cell);
                }
                if(isInvalidCell)
                {
                    continue;
                }

                departments.Add(department);
                sb.AppendLine(string.Format(SuccessfullyImportedDepartment, department.Name, department.Cells.Count));
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDto = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            var sb = new StringBuilder();
            var prisoners = new List<Prisoner>();

            foreach (var prisonerDto in prisonersDto)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age= prisonerDto.Age,
                    IncarcerationDate= DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                };

                prisoner.ReleaseDate = string.IsNullOrEmpty(prisonerDto.ReleaseDate) ?  null : prisoner.ReleaseDate = DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                prisoner.Bail = prisonerDto.Bail==null ? null : prisoner.Bail = prisonerDto.Bail;

                prisoner.CellId = prisonerDto.CellId == null ? null : prisoner.CellId = prisonerDto.CellId;

                bool isInvalidMail = false;
                foreach (var mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        isInvalidMail = true;
                        break;
                    }

                    var mail = new Mail
                    {
                        Description=mailDto.Description,
                        Address = mailDto.Address,
                        Sender=mailDto.Sender,
                        Prisoner=prisoner
                    };

                    prisoner.Mails.Add(mail);
                }

                if (isInvalidMail)
                {
                    continue;
                }

                prisoners.Add(prisoner);
                sb.AppendLine(string.Format(SuccessfullyImportedPrisoner, prisoner.FullName, prisoner.Age));
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]),
                new XmlRootAttribute("Officers"));

            var officersDto = (ImportOfficerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();

            var officers = new List<Officer>();

            foreach (var officerDto in officersDto)
            {
                var isValidPosition = Enum.TryParse<Position>(officerDto.Position, out Position position);
                var isValidWaepon = Enum.TryParse<Weapon>(officerDto.Weapon, out Weapon weapon);

                if (!IsValid(officerDto) || !isValidPosition || !isValidWaepon)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var officer = new Officer
                {
                    FullName= officerDto.FullName,
                    Salary= officerDto.Salary,
                    Position=position,
                    Weapon=weapon,
                    DepartmentId=officerDto.DepartmentId
                };

                foreach (var prisonerDto in officerDto.Prisoners)
                {
                    officer.OfficerPrisoners.Add(new OfficerPrisoner
                    {
                        PrisonerId=prisonerDto.Id
                    });
                }

                officers.Add(officer);
                sb.AppendLine(string.Format(SuccessfullyImportedOfficer, officer.FullName, officer.OfficerPrisoners.Count));
            }

            context.Officers.AddRange(officers);
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