namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int employeesCount = int.Parse(Console.ReadLine());

            var employees = new List<Employee>();
            for (int i = 0; i < employeesCount; i++)
            {
                var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                //name, salary, position, department, email and age
                string name = input[0];
                double salary = double.Parse(input[1]);
                string position = input[2];
                string department = input[3];
                string email = input.Length>4? input[4].Contains("@") ? input[4]: "n/a" : "n/a";
                int age = input.Length > 4 ? !input[4].Contains("@") ? int.Parse(input[4]) : -1 : -1;
                age = input.Length > 5 ? int.Parse(input[5]) : age;

                Employee employee = new Employee(name, salary, position, department, email, age);

                employees.Add(employee);
            }

            string theBestDepartmnet = string.Empty;


            //employees = employees.OrderBy(x => x.Department).ToList();
            //var checkDep = new List<string>();
            //
            //double maxAverageSalary = 0;
            //int count = 0;
            //while (true)
            //{
            //    string currentDepartment = "";
            //    double currentSumSalary = 0;
            //    int currentCount = 0;
            //    for (int i = 0; i < employees.Count; i++)
            //    {
            //        if(checkDep.Contains(employees[i].Department))
            //        {
            //            continue;
            //        }

            //        if(!checkDep.Contains(employees[i].Department) && currentDepartment== "")
            //        {
            //            currentDepartment = employees[i].Department;
            //            currentSumSalary += employees[i].Salary;
            //            currentCount++;
            //        }

            //        else if (currentDepartment == employees[i].Department)
            //        {
            //            currentSumSalary += employees[i].Salary;
            //            currentCount++;
            //        }

            //        else
            //        {
            //            break;
            //        }
            //    }

            //    checkDep.Add(currentDepartment);
            //    currentSumSalary /= currentCount;

            //    if(currentSumSalary>maxAverageSalary)
            //    {
            //        maxAverageSalary = currentSumSalary;
            //        theBestDepartmnet = currentDepartment;
            //    }

            //    count += currentCount;

            //    if (count==employees.Count)
            //    {
            //        break;
            //    }
            //}

            theBestDepartmnet = employees.GroupBy(x => x.Department)
                .OrderByDescending(y => y.Select(s => s.Salary).Average())
                .FirstOrDefault()
                .Key;

            var result = employees.Where(e => e.Department == theBestDepartmnet).OrderByDescending(e=>e.Salary).ToList();

            Console.WriteLine($"Highest Average Salary: {theBestDepartmnet}");

            foreach (var employee in result)
            {
                Console.WriteLine(employee);
            }
            

            //Employee abc = new Employee()
        }
    }
}
