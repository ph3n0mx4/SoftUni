namespace _06_BirthdayCelebrations
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Collections.Generic;
    using _06_BirthdayCelebrations.Interfaces;

    public class Program
    {
        static void Main(string[] args)
        {
            var list = new List<IBirthable>();
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (input[0]!= "End")
            {
                if(input[0]== "Pet")
                {//<name> <birthdate>
                    var pet = new Pet(input[1], input[2]);
                    list.Add(pet);
                }
                
                else if (input[0] == "Citizen")
                {//Citizen <name> <age> <id> <birthdate>
                    var citizen = new Citizen(input[1], int.Parse(input[2]), input[3], input[4]);
                    list.Add(citizen);
                }

                input = Console.ReadLine().Split().ToArray();
            }

            string number = Console.ReadLine();
            //foreach (var item in list.Where(x => x.Id.EndsWith("number")))
            //{
            //    Console.WriteLine(item.Id);
            //}

            list.Where(x => x.Birthdate.EndsWith(number)).ToList().ForEach(x => Console.WriteLine(x.Birthdate));
            //if(result.Count==0)
            //{
            //    Console.WriteLine("<empty output>");
            //}
            //else
            //{
            //    foreach (var item in result)
            //    {
            //        Console.WriteLine(item.Birthdate);
            //    }
            //}
        }
    }
}
