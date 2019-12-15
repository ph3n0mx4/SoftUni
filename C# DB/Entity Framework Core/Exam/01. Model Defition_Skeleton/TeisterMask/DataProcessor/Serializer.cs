namespace TeisterMask.DataProcessor
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
    using TeisterMask.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var pr = context
                .Projects
                .Where(p => p.Tasks.Any())
                .Select(p => new ExportProjectDto
                {
                    TasksCount=p.Tasks.Count,
                    ProjectName=p.Name,
                    HasEndDate=IsNull(p.DueDate),
                    Tasks=p.Tasks.Select(t=> new ExportTaskDto
                    {
                        Name=t.Name,
                        Label=t.LabelType.ToString()
                    })
                    .OrderBy(t=>t.Name)
                    .ToArray()
                })
                .OrderByDescending(p=>p.TasksCount)
                .ThenBy(p=>p.ProjectName)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportProjectDto[]),
                new XmlRootAttribute("Projects"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, pr, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        private static string IsNull(DateTime? dueDate)
        {
            var result = "No";
            //var dueDatePr = DateTime.TryParse(dueDate, out DateTime dueDateProject);
            var date = new DateTime(0001);
            if (dueDate != null)
            {
                result = "Yes";
            }
            return result;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            //throw new NotImplementedException();
            var users = context
                .Employees
                .Where(e => e.EmployeesTasks.Any(s => s.Task.OpenDate >= date))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                        .Where(s => s.Task.OpenDate >= date)
                        .OrderByDescending(x => x.Task.DueDate)
                        .ThenBy(x => x.Task.Name)
                        .Select(t => new
                        {
                            //"TaskName": "Pointed Gourd",
                            //"OpenDate": "10/08/2018",d
                            //"DueDate": "10/24/2019",d
                            //"LabelType": "Priority",
                            //"ExecutionType": "ProductBacklog"
                            TaskName = t.Task.Name,
                            OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = t.Task.LabelType.ToString(),
                            ExecutionType = t.Task.ExecutionType.ToString()
                        })
                        .ToArray()
                })
                .ToArray()
                .OrderByDescending(x => x.Tasks.Length)
                .ThenBy(x => x.Username)
                .Take(10)
                .ToArray();

            var json = JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);
            return json;
            //return null;

        }
    }
}