using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace _05_BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Identificatable>();
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (input[0]!= "End")
            {
                if(input.Length==2)
                {
                    var robot = new Robot(input[1], input[0]);
                    list.Add(robot);
                }
                //“< name > < age > < id >” for citizens and “< model > < id >” for robots
                else if (input.Length==3)
                {
                    var citizen = new Citizen(input[2], input[0], int.Parse(input[1]));
                    list.Add(citizen);
                }

                input = Console.ReadLine().Split().ToArray();
            }

            string number = Console.ReadLine();
            //foreach (var item in list.Where(x => x.Id.EndsWith("number")))
            //{
            //    Console.WriteLine(item.Id);
            //}

            list.Where(x => x.Id.EndsWith(number)).ToList().ForEach(x => Console.WriteLine(x.Id));
        }
    }
}
