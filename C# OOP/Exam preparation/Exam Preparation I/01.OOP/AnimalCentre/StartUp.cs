using AnimalCentre.Classes;
using System;
using System.Linq;
using System.Reflection;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var type = typeof(Animal).GetProperty("Happiness", (BindingFlags)62);
            var animalCenter = new AnimalCentre();
            var input = Console.ReadLine().Split().ToArray();
            while (input[0]!="End")
            {
                try
                {
                    Console.WriteLine(Command(input, animalCenter));
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine($"InvalidOperationException:  {e.Message}");
                }
                catch (ArgumentException e)
                {

                    Console.WriteLine($"ArgumentException:  {e.Message}");
                }

                input = Console.ReadLine().Split().ToArray();
            }

            
        }

        private static string Command(string[] input, AnimalCentre animalCenter)
        {
            string result = "";
            if (input[0] == "RegisterAnimal")
            {
                //{type} {name} {energy} {happiness} {procedureTime}
                string type = input[1];
                string name = input[2];
                int energy = int.Parse(input[3]);
                int happiness = int.Parse(input[4]);
                int procedureTime = int.Parse(input[5]);
                result = animalCenter.RegisterAnimal(type, name, energy, happiness, procedureTime);
                
            }

            else if (input[0] == "Chip")
            {
                //•	Chip {name} {procedureTime}
                string name = input[1];
                int procedureTime = int.Parse(input[2]);
                result = animalCenter.Chip(name, procedureTime);
            }

            else if (input[0] == "DentalCate")
            {
                string name = input[1];
                int procedureTime = int.Parse(input[2]);
                result = animalCenter.DentalCare(name, procedureTime);
            }

            else if (input[0] == "Fitness")
            {
                string name = input[1];
                int procedureTime = int.Parse(input[2]);
                result = animalCenter.Fitness(name, procedureTime);
            }

            else if (input[0] == "NailTrim")
            {
                string name = input[1];
                int procedureTime = int.Parse(input[2]);
                result = animalCenter.NailTrim(name, procedureTime);
            }

            else if (input[0] == "Play")
            {
                string name = input[1];
                int procedureTime = int.Parse(input[2]);
                result = animalCenter.Play(name, procedureTime);
            }

            else if (input[0] == "Vaccinate")
            {
                string name = input[1];
                int procedureTime = int.Parse(input[2]);
                result = animalCenter.Vaccinate(name, procedureTime);
            }

            else if (input[0] == "Adopt")
            {
                string name = input[1];
                string owner = input[2];
                result = animalCenter.Adopt(name, owner);
            }

            else if (input[0] == "History")
            {
                string type = input[1];

                result = animalCenter.History(type);
            }

            return result;
        }
    }
}
