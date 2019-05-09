using System;
using System.Collections.Generic;
using System.Linq;

namespace _05Students
{
    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split().ToArray();
            var students = new List<Student>();
            while(data[0]!="end")
            {
                Student list = new Student();
                list.FirstName = data[0];
                list.LastName = data[1];
                list.Age = int.Parse(data[2]);
                list.HomeTown = data[3];

                students.Add(list);

                data = Console.ReadLine().Split().ToArray();
            }

            string town = Console.ReadLine();

            students = students.Where(x => x.HomeTown == town).ToList();

            foreach (var item in students)
            {
                Console.WriteLine($"{ item.FirstName} {item.LastName} is {item.Age} years old.");
            }
        }
    }
}
 