using System;
using System.Collections.Generic;
using System.Linq;

namespace _10SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> scheduleOfLesson = Console.ReadLine().Split(", ").ToList();
            string[] cmd = Console.ReadLine().Split(':').ToArray();

            while(cmd[0] != "course start")
            {
                switch(cmd[0])
                {
                    case "Add":
                        if(!scheduleOfLesson.Contains(cmd[1]))
                        {
                            scheduleOfLesson.Add(cmd[1]);
                        }
                        break;

                    case "Insert":
                        if (!scheduleOfLesson.Contains(cmd[1]))
                        {
                            scheduleOfLesson.Insert(int.Parse(cmd[2]), cmd[1]);
                        }
                        break;

                    case "Remove":
                        if (scheduleOfLesson.Contains(cmd[1]))
                        {
                            scheduleOfLesson.Remove(cmd[1]);
                        }

                        if(scheduleOfLesson.Contains($"{cmd[1]}-Exercise"))
                        {
                            scheduleOfLesson.Remove($"{cmd[1]}-Exercise");
                        }
                        break;

                    case "Swap":
                        SwapLessons(scheduleOfLesson, cmd);
                        SwapExercises(scheduleOfLesson, cmd);
                        break;

                    case "Exercise":
                        Exercises(scheduleOfLesson, cmd);
                        break;
                }
                cmd = Console.ReadLine().Split(':').ToArray();
            }

            for (int i = 0; i < scheduleOfLesson.Count; i++)
            {
                Console.WriteLine($"{i+1}.{scheduleOfLesson[i]}");
            }                     
        }

        private static void Exercises(List<string> scheduleOfLesson, string[] cmd)
        {
            if (!scheduleOfLesson.Contains($"{cmd[1]}-Exercise") && scheduleOfLesson.Contains(cmd[1]) ) 
            {
                int indexLesson = scheduleOfLesson.IndexOf(cmd[1]);
                scheduleOfLesson.Insert(indexLesson+1, $"{cmd[1]}-Exercise");
            }

            else if (!scheduleOfLesson.Contains($"{cmd[1]}-Exercise") && !scheduleOfLesson.Contains(cmd[1]))
            {
                scheduleOfLesson.Add(cmd[1]);
                scheduleOfLesson.Add($"{cmd[1]}-Exercise");
            }
        }

        private static void SwapExercises(List<string> scheduleOfLesson, string[] cmd)
        {      //Check for first exercises
            if (scheduleOfLesson.Contains($"{cmd[1]}-Exercise"))
            {
                int indexLesson = scheduleOfLesson.IndexOf(cmd[1]);
                int indexExercises = scheduleOfLesson.IndexOf($"{cmd[1]}-Exercise");
                if(indexExercises-1!=indexLesson)
                {
                    string Exercises = scheduleOfLesson[indexExercises];
                    scheduleOfLesson.RemoveAt(indexExercises);
                    scheduleOfLesson.Insert(indexLesson+1, Exercises);
                }
            }
                //Check for second exercises
            if (scheduleOfLesson.Contains($"{cmd[2]}-Exercise"))
            {
                int indexLesson = scheduleOfLesson.IndexOf(cmd[2]);
                int indexExercises = scheduleOfLesson.IndexOf($"{cmd[2]}-Exercise");
                if (indexExercises - 1 != indexLesson)
                {
                    string Exercises = scheduleOfLesson[indexExercises];
                    scheduleOfLesson.RemoveAt(indexExercises);
                    scheduleOfLesson.Insert(indexLesson + 1, Exercises);
                }
            }
        }

        private static void SwapLessons(List<string> scheduleOfLesson, string[] cmd)
        {
            if (scheduleOfLesson.Contains(cmd[1]) && scheduleOfLesson.Contains(cmd[2]))
            {
                int firstIndex = scheduleOfLesson.IndexOf(cmd[1]);
                int secondIndex = scheduleOfLesson.IndexOf(cmd[2]);
                scheduleOfLesson.Insert(firstIndex, cmd[2]);
                scheduleOfLesson.RemoveAt(firstIndex + 1);
                scheduleOfLesson.Insert(secondIndex, cmd[1]);
                scheduleOfLesson.RemoveAt(secondIndex + 1);

            }
        }
    }
}
