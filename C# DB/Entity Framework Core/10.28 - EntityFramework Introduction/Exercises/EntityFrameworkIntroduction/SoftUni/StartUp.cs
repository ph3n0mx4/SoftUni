using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var db=new SoftUniContext())
            {
                //var employees1 = GetEmployeesFullInformation(db);
                //var employees2 = GetEmployeesWithSalaryOver50000(db);
                //var employees3 = GetEmployeesFromResearchAndDevelopment(db);
                //var employees4 = AddNewAddressToEmployee(db);
                //var employees5 = GetEmployeesInPeriod(db);
                //var employees6 = GetAddressesByTown(db);
                //var employees7 = GetEmployee147(db);
                //var employees8 = GetLatestProjects(db);
                //var employees9 = IncreaseSalaries(db);
                //var employees11 = GetEmployeesByFirstNameStartingWithSa(db);
                //var employees12 = DeleteProjectById(db);
                //var employees13 = RemoveTown(db);
                var employees = GetDepartmentsWithMoreThan5Employees(db);
                Console.WriteLine(employees);

            }
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e=>new {
                    Name=string.Join(" ",e.FirstName,e.LastName,e.MiddleName),
                    JobTitle = e.JobTitle,
                    Salary = $"{e.Salary:f2}"
                })
                .ToList();

            foreach (var item in employees)
            {
                sb.AppendLine(string.Join(" ", item.Name, item.JobTitle, item.Salary));
            }

            return sb.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e=>e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }
            return sb.ToString(); 
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e=>e.Salary)
                .ThenByDescending(e=>e.FirstName)
                .Select(e=>new { 
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var newAddress = new Address();
            newAddress.AddressText = "Vitoshka 15";
            newAddress.TownId = 4;

            context.Addresses.Add(newAddress);
            context.SaveChanges();

            var newAddressId = context
                .Addresses
                .Where(a => a.AddressText == newAddress.AddressText 
                            && a.TownId == newAddress.TownId)
                .Select(a=>a.AddressId)
                .FirstOrDefault();

            var employee = context
                .Employees
                .Where(e => e.LastName == "Nakov")
                .FirstOrDefault();

            employee.AddressId = newAddressId;
            
            context.Update(employee);
            context.SaveChanges();

            var addresses = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e=>e.Address.AddressText)
                .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine(address);
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(p => p.EmployeesProjects.Any(x => x.Project.StartDate.Year >= 2001
                  && x.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new {
                    NameE = e.FirstName +" "+ e.LastName,
                    NameM = e.Manager.FirstName + " " + e.Manager.LastName,
                    Project = e.EmployeesProjects.Select(p => new {
                        ProjectName = p.Project.Name,
                        ProjectStart = p.Project.StartDate,
                        ProjectEnd = p.Project.EndDate
                    }).ToList()
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.NameE} - Manager: {e.NameM}");
                foreach (var p in e.Project)
                {
                    var startDate = p.ProjectStart
                        .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    var endDate = p.ProjectEnd == null ?
                        "not finished" : 
                        p.ProjectEnd.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    sb.AppendLine($"--{p.ProjectName} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context
                .Addresses
                .OrderByDescending(a => a.Employees.Count())
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    a.Town,
                    count = a.Employees.Count()
                })
                //.ToList();
                ;

            var sb = new StringBuilder();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.Town.Name} - {a.count} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e=>new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects.Select(p => new { 
                        p.Project.Name
                    })
                    .OrderBy(p=>p.Name)
                    .ToList()
                })
                .FirstOrDefault();
                

            var sb = new StringBuilder();
            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");
            foreach (var p in employee147.Projects)
            {
                sb.AppendLine($"{p.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context
                .Departments
                .Where(d=>d.Employees.Count()>5)
                .OrderBy(d => d.Employees.Count() > 5)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    d.Manager.FirstName,
                    d.Manager.LastName,
                    d.Employees
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} - {d.FirstName} {d.LastName}");

                foreach (var e in d.Employees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
                
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var p in projects)
            {
                var startDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt");
                sb.AppendLine($"{p.Name}");
                sb.AppendLine($"{p.Description}");
                sb.AppendLine($"{startDate}");
            }
            return sb.ToString();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Engineering" ||
                e.Department.Name == "Tool Design" ||
                e.Department.Name == "Marketing" ||
                e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            employees.ForEach(e => e.Salary = e.Salary * 1.12m);
            //context.SaveChanges();

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e=>e.FirstName)
                .ThenBy(e=>e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }
            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var employeesProjects = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == 2);
            context.EmployeesProjects.RemoveRange(employeesProjects);
            var projectWithId2 = context
                .Projects
                .FirstOrDefault(p => p.ProjectId == 2);

            context.Projects.Remove(projectWithId2);
            context.SaveChanges();

            var projects = context
                .Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var p in projects)
            {
                sb.AppendLine($"{p}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var currentTown = context
                .Towns
                .FirstOrDefault(t => t.Name == "Seattle");

            var addressesForDelete = context
                .Addresses
                .Where(a => a.TownId == currentTown.TownId)
                .ToList();
            var employees = context
                .Employees
                .Where(e => addressesForDelete.Contains(e.Address))
                .ToList();

            foreach (var e in employees)
            {
                e.AddressId = null;
            }
            context.SaveChanges();

            context.Addresses.RemoveRange(addressesForDelete);
            context.SaveChanges();

            context.Towns.Remove(currentTown);
            context.SaveChanges();

            var result = addressesForDelete.Count();

            return $"{result} addresses in Seattle were deleted";
        }
    }

    
}
