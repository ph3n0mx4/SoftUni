using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Hospital_Sample_E
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var list = new Dictionary<string, Dictionary<string, List<string>>>();
            while (input[0]!="Output")
            {
                string department = input[0];
                string doctor = input[1];
                doctor = string.Concat(doctor, input[2]);
                string patient = input[3];

                if (!list.ContainsKey(department))
                {
                    list[department] = new Dictionary<string, List<string>>();
                }

                int countPatientInDepartment = list[department].Values.Count;
                if (countPatientInDepartment < 60)
                {
                    

                    if (!list[department].ContainsKey(doctor))
                    {
                        list[department][doctor] = new List<string>();
                    }

                
                    list[department][doctor].Add(patient);
                }

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            var cmd = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (cmd[0]!="End")
            {
                if (cmd.Length == 1)
                {
                    string cmdDepartment = cmd[0];
                    var a = list.First(x => x.Key == cmdDepartment);

                    foreach (var item in a.Value)
                    {
                        foreach (var p in item.Value)
                        {
                            Console.WriteLine(p);
                        }
                    }
                }

                else if (int.TryParse(cmd[1], out int room))
                {
                    int cmdRoom = room;
                    string cmdDepartment = cmd[0];
                    var a = list.First(x => x.Key == cmdDepartment);
                    int startCount = (room-1) * 3;
                    int endCount = startCount + 2;
                    int count = 1;
                    var roomResult = new List<string>();

                    foreach (var kvp in a.Value)
                    {
                        foreach (var b in kvp.Value)
                        {
                            if (count >= startCount && count <= endCount)
                            {
                                roomResult.Add(b);
                            }
                            count++;
                        }
                    }

                    foreach (var p in roomResult.OrderBy(x => x))
                    {
                        Console.WriteLine(p);
                    }
                }

                else
                {
                    string cmdName = cmd[0];
                    cmdName = string.Concat(cmdName, cmd[1]);
                    var result = new List<string>();
                    foreach (var kvp in list)
                    {
                        foreach (var aaa in kvp.Value)
                        {
                            if (aaa.Key == cmdName)
                            {
                                result.AddRange(aaa.Value);
                            }
                        }
                    }

                    foreach (var item in result.OrderBy(s=>s))
                    {
                        Console.WriteLine(item);
                    }
                }

                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            
        }
    }
}
