using System;
using System.Collections.Generic;
using System.Linq;

namespace _06Students2
{
    class Students
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
            List<Students> students = new List<Students>();
            while(data[0]!= "end")
            {
                Students list = new Students();
                list.FirstName = data[0];
                list.LastName = data[1];
                list.Age = int.Parse(data[2]);
                list.HomeTown = data[3];

                Students condition = students.FirstOrDefault(s => s.FirstName == data[0] && s.LastName == data[1]);
                if(condition==null)
                {
                    students.Add(list);
                }

                else
                {
                    condition.Age= int.Parse(data[2]);
                    condition.HomeTown= data[3];

                }

                data = Console.ReadLine().Split().ToArray();
            }

            string town = Console.ReadLine();

            students = students.Where(s => s.HomeTown == town).ToList();

            foreach (var item in students)
            {
                Console.WriteLine($"{ item.FirstName} {item.LastName} is {item.Age} years old.");
            }
        }
    }
}
