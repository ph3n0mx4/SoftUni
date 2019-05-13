namespace _03_Mankind
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            try
            {
                var inputStudent = Console.ReadLine().Split().ToArray();
                string studentFirstName = inputStudent[0];
                string studentLastName = inputStudent[1];
                string studentFacultyNumber = inputStudent[2];

                var inputWorker = Console.ReadLine().Split().ToArray();
                string workerFirstName = inputWorker[0];
                string workerLastName = inputWorker[1];
                double workerSalary = double.Parse(inputWorker[2]);
                double workerWorkingHour = double.Parse(inputWorker[3]);

                var student = new Student(studentFirstName, studentLastName, studentFacultyNumber);
                var worker = new Worker(workerFirstName, workerLastName, workerSalary, workerWorkingHour);
                Console.WriteLine(student);
                Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            
        }
    }
}
