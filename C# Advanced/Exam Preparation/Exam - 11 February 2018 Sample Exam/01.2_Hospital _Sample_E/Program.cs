using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._2_Hospital__Sample_E
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();
            var departments = new Dictionary<string, List<string>> ();
            var doctors = new Dictionary<string, List<string>> ();
            //var list = new Dictionary<string, Dictionary<string, List<string>>>();
            while (input[0] != "Output")
            {
                string department = input[0];
                string doctor = input[1];
                doctor = string.Concat(doctor, input[2]);
                string patient = input[3];

                if (!departments.ContainsKey(department))
                {
                    departments[department] = new List<string>();
                }

                if (!doctors.ContainsKey(doctor))
                {
                    doctors[doctor] = new List<string>();
                }

                departments[department].Add(patient);
                doctors[doctor].Add(patient);
                

                input = Console.ReadLine().Split().ToArray();
            }

            var cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (cmd[0] != "End")
            {
                if (cmd.Length == 1)
                {
                    var currentDepartment = departments.FirstOrDefault(x => x.Key == cmd[0]).Value;

                    foreach (var item in currentDepartment)
                    {
                        Console.WriteLine(item);
                    }
                }

                else if (char.IsDigit(cmd[1],0))
                {
                    int cmdRoom = int.Parse(cmd[1]);
                    var currentDepartment = departments.First(x => x.Key == cmd[0]).Value;
                    currentDepartment = currentDepartment.ToList();
                    
                    int startCount = (cmdRoom - 1) * 3;
                    int endCount = startCount+2;
                    var currentRoom = new List<string>();
                    for (int i = 0; i < currentDepartment.Count; i++)
                    {
                        if(i>=startCount && i<=endCount)
                        {
                            currentRoom.Add(currentDepartment[i]);
                        }
                    }

                    foreach (var item in currentRoom.OrderBy(x=>x))
                    {
                        Console.WriteLine(item);
                    }

                    
                }

                else 
                {
                    string cmdName = cmd[0];
                    cmdName = string.Concat(cmdName, cmd[1]);

                    var currentDoctor = doctors.FirstOrDefault(x => x.Key == cmdName).Value;

                    foreach (var item in currentDoctor.OrderBy(s => s))
                    {
                        Console.WriteLine(item);
                    }
                }

                cmd = Console.ReadLine().Split().ToArray();
            }
        }
    }
}
