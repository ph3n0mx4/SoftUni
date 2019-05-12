namespace DefiningClasses
{
    public class Employee
    {
        public Employee(string name,double salary, string position, string department, string email, int age)
        {
            Name = name;
            Salary = salary;
            Position = position;
            Department = department;
            Email = email;
            Age = age;
        }

        public string Name { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        //Pesho 120.00 pesho @abv.bg 28
        public override string ToString()
        {
            return $"{Name} {Salary:f2} {Email} {Age}";
        }
    }
}
