using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.IronGirder_27._08._18
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new string[] { ":", "->" }, StringSplitOptions.RemoveEmptyEntries);

            var listTime = new Dictionary<string, int>();
            var listPassengers = new Dictionary<string, int>();

            while(input[0]!= "Slide rule")
            {
                string town = input[0];
                int passenger = int.Parse(input[2]);
                if (input[1]== "ambush" && listTime.ContainsKey(town))
                {
                    listTime[town] = 0;
                    listPassengers[town] -= passenger;
                    input = Console.ReadLine().Split(new string[] { ":", "->" }, StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                else if (input[1] == "ambush")
                {
                    input = Console.ReadLine().Split(new string[] { ":", "->" }, StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }


                int time = int.Parse(input[1]);
                

                if(!listTime.ContainsKey(town))
                {
                    listTime[town] = time;
                    listPassengers[town] = passenger;
                }

                else
                {
                    if (listTime[town] > time || listTime[town] == 0)
                    {
                        listTime[town] = time;
                    }

                    listPassengers[town] += passenger;
                }
                
                input = Console.ReadLine().Split(new string[] { ":", "->" }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in listTime.OrderBy(x=>x.Value).ThenBy(x=>x.Key))
            {
                string town = item.Key;
                int time = item.Value;
                int passengers = listPassengers[town];
                
                if(time==0 || passengers==0)
                {
                    continue;
                }
                Console.WriteLine($"{town} -> Time: {time} -> Passengers: {passengers}");
                
            }

        }
    }
}
