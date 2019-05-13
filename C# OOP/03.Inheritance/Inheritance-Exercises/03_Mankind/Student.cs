namespace _03_Mankind
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber):base(firstName,lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get => this.facultyNumber;
            set
            {
                if(value.Length<5 || value.Length>10)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                foreach (var item in value)
                {
                    if(!char.IsDigit(item) && !char.IsLetter(item))
                    {
                        throw new ArgumentException("Invalid faculty number!");
                    }
                }
                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return $"First Name: {this.FirstName}{Environment.NewLine}Last Name: {this.LastName}{Environment.NewLine}Faculty number: {this.FacultyNumber}"; 
        }
    }
}
