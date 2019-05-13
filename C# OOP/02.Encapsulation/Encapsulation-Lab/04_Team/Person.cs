namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get => this.firstName;

            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;

            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                this.lastName = value;
            }
        }

        public int Age
        {
            get => this.age;

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                this.age = value;
            }
        }

        public decimal Salary
        {
            get => this.salary;

            set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }
                this.salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {

            if (this.Age <= 30)
            {
                this.Salary += this.Salary * percentage / 200;
            }

            else
            {
                this.Salary += this.Salary * percentage / 100;
            }

        }

        //public override string ToString()
        //{
        //    return $"{this.FirstName} {this.LastName} gets {this.Salary:f2} leva.";
        //    //Asen Ivanov receives 2640.00 leva.
        //}
    }
}
