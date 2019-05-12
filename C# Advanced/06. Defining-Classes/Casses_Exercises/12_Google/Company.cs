namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Company
    {
        public string CompanyName { get; set; }

        public string Department { get; set; }

        public double Salary { get; set; }

        public Company(string companyName, string department, double salary)
        {
            CompanyName = companyName;
            Department = department;
            Salary = salary;
        }

        public override string ToString()
        {
            string output="";
            if (CompanyName == null)
            {
                output =string.Concat(output, "Company:");

            }

            else
            {
                output= string.Concat(output, $"Company:{CompanyName} {Department} {Salary}");
            }

            return output;
        }
    }
}
