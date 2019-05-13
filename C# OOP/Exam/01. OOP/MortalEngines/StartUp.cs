using MortalEngines.Core;
using System;
using System.Linq;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split().ToArray();
            MachinesManager machinesManager = new MachinesManager();
            while (input[0]!="Quit")
            {

                try
                {
                    Console.WriteLine(Command(machinesManager,input));
                }

                catch (ArgumentNullException e)
                {
                    Console.WriteLine($"Error: {e.InnerException.Message}");
                }

                catch (NullReferenceException e)
                {
                    Console.WriteLine($"Error: {e.InnerException.Message}");
                }

                input = Console.ReadLine().Split().ToArray();
            }
        }

        private static string Command(MachinesManager machinesManager, string[] input)
        {
            string result = string.Empty;
            switch (input[0])
            {
                case "HirePilot":
                    result =machinesManager.HirePilot(input[1]);
                    break;
                case "PilotReport":
                    result = machinesManager.PilotReport(input[1]);
                    break;
                case "ManufactureTank":
                    result = machinesManager.ManufactureTank(input[1], double.Parse(input[2]), double.Parse(input[3]));
                    break;
                case "ManufactureFighter":
                    result = machinesManager.ManufactureFighter(input[1], double.Parse(input[2]), double.Parse(input[3]));
                    break;
                case "MachineReport":
                    result = machinesManager.MachineReport(input[1]);
                    break;
                case "AggressiveMode":
                    result = machinesManager.ToggleFighterAggressiveMode(input[1]);
                    break;
                case "DefenseMode":
                    result = machinesManager.ToggleTankDefenseMode(input[1]);
                    break;
                case "Engage":
                    result = machinesManager.EngageMachine(input[1], input[2]);
                    break;
                case "Attack":
                    result = machinesManager.AttackMachines(input[1], input[2]);
                    break;
                //default:
                //    break;
            }

            return result;
        }
    }
}