using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_AutoRepairAndService
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicles = new Queue<string>(Console.ReadLine().Split());
            string[] cmd= Console.ReadLine().Split("-").ToArray();
            var history = new Stack<string>();

            while(cmd[0]!="End")
            {
                switch (cmd[0])
                {
                    case "Service":
                        if(vehicles.Count>0)
                        {
                            string currentVehicle = vehicles.Dequeue();
                            history.Push(currentVehicle);
                            Console.WriteLine($"Vehicle {currentVehicle} got served.");
                        }
                        
                        break;

                    case "CarInfo":
                        string infoVehicle = cmd[1];

                        if(vehicles.Contains(infoVehicle))
                        {
                            Console.WriteLine("Still waiting for service.");
                        }

                        else if(history.Contains(infoVehicle))
                        {
                            Console.WriteLine("Served.");
                        }
                        break;

                    case "History":
                        Console.WriteLine(string.Join(", ",history));
                        break;
                }

                cmd = Console.ReadLine().Split("-").ToArray();
            }
            if(vehicles.Count>0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", vehicles)}");
            }
            
            Console.WriteLine($"Served vehicles: {string.Join(", ",history)}");
        }
    }
}
