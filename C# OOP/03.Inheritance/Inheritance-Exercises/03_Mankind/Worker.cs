namespace _03_Mankind
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Worker : Human
    {
        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay) 
            : base(firstName,lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double WeekSalary
        {
            get => this.weekSalary;
            set
            {
                if(value<10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get => this.workHoursPerDay;
            set
            {
                if(value<1 || value >12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                this.workHoursPerDay = value;
            }
        }

        public double SalaryPerHour()
        {
            return (this.WeekSalary/5.00)/this.WorkHoursPerDay;
        }

        public override string ToString()
        {
            return $"First Name: {this.FirstName}{Environment.NewLine}Last Name: {this.LastName}{Environment.NewLine}Week Salary: {this.WeekSalary:f2}{Environment.NewLine}Hours per day: {this.WorkHoursPerDay:f2}{Environment.NewLine}Salary per hour: {this.SalaryPerHour():f2}";
        }
        //$"Type: {this.GetType().Name}{Environment.NewLine}Title: {this.Title}{Environment.NewLine}Author: {this.Author}{Environment.NewLine}Price: {this.price:f2}"
    }
}
