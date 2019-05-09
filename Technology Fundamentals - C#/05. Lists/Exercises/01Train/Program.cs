using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfWagon = Console.ReadLine().Split()
                                           .Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string[] cmd = Console.ReadLine().Split();

            while(cmd[0]!= "end")
            {
                switch (cmd[0])
                {
                    case "Add":
                        listOfWagon.Add(int.Parse(cmd[1]));
                        break;

                    default:
                        for (int i = 0; i < listOfWagon.Count; i++)
                        {
                            if(maxCapacity-listOfWagon[i]>= int.Parse(cmd[0]))
                            {
                                listOfWagon[i] += int.Parse(cmd[0]);
                                break;
                            }
                        }
                        break;
                }

                cmd = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(' ',listOfWagon));
        }
    }
}
