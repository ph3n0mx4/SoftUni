using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ");

                students.Add(new Student(data));
            }

            students.OrderBy(x => -x.Grade).ToList().ForEach(x => Console.WriteLine(x.ToString()));

        }
    }

    class Student
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public double Grade { get; set; }

        public Student(string[] cmd)
        {
            Firstname = cmd[0];
            Lastname = cmd[1];
            Grade = double.Parse(cmd[2]);
        }

        public override string ToString()
        {
            return $"{Firstname} {Lastname}: {Grade:f2}";
        }
    }
}
