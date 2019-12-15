namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using Newtonsoft.Json;
    using System.Text;
    using TeisterMask.Data.Models;
    using TeisterMask.DataProcessor.ImportDto;
    using System.Xml.Serialization;
    using System.IO;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectDto[]),
                new XmlRootAttribute("Projects"));

            var projectsDto = (ImportProjectDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();

            var projects = new List<Project>();

            foreach (var projectDto in projectsDto)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = DateTime.ParseExact(projectDto.OpenDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture)
                };
                
                if (projectDto.DueDate==null || projectDto.DueDate=="")
                {
                    project.DueDate = null;
                }
                else
                {
                    project.DueDate = DateTime.ParseExact(projectDto.DueDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                foreach (var currentTask in projectDto.Tasks)
                {
                    var openDateT = DateTime.ParseExact(currentTask.OpenDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture);
                    
                    var dueDateT = DateTime.ParseExact(currentTask.DueDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (!IsValid(currentTask))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (project.DueDate==null )
                    {
                        if(project.OpenDate > openDateT)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                        
                    }
                    else
                    {
                        if (project.OpenDate > openDateT || project.DueDate < dueDateT)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }

                    var task = new Task
                    {
                        Name = currentTask.Name,
                        OpenDate = openDateT,
                        DueDate = dueDateT,
                        ExecutionType = Enum.Parse<ExecutionType>(currentTask.ExecutionType),
                        LabelType = Enum.Parse<LabelType>(currentTask.LabelType),
                    };
                    
                    
                    project.Tasks.Add(task);
                }

                projects.Add(project);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }
            context.Projects.AddRange(projects);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
            //return null;
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeesDto = JsonConvert.DeserializeObject<ImportEmployeesDto[]>(jsonString);

            var sb = new StringBuilder();
            var employees = new List<Employee>();

            foreach (var employeeDto in employeesDto)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username=employeeDto.Username,
                    Email= employeeDto.Email,
                    Phone= employeeDto.Phone
                };

                foreach (var currentTask in employeeDto.Tasks.Distinct())
                {
                    var task = context.Tasks.FirstOrDefault(x => x.Id == currentTask);
                    if (!IsValid(currentTask) || task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask
                    {
                        Task=task,
                        Employee=employee
                    });
                }

                employees.Add(employee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
            //return null;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}