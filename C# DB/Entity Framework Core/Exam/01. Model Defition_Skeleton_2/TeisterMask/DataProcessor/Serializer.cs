namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            throw new NotImplementedException();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var users = context
                .Employees
                .Where(e => e.EmployeesTasks.Any(s=>s.Task.OpenDate>=date))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
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