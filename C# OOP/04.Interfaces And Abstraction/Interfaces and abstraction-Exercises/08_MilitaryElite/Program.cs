namespace _08_MilitaryElite
{
    using _08_MilitaryElite.Classes;
    using _08_MilitaryElite.Classes.Soldiers;
    using _08_MilitaryElite.Classes.Soldiers.Privates;
    using _08_MilitaryElite.Classes.Soldiers.Privates.SpecialisedSoldiers;
    using _08_MilitaryElite.Classes.Soldiers.Privates.SpecialisedSoldiers.Sets;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();

            var soldiers = new List<Soldier>();

            while (input[0]!="End")
            {
                switch (input[0])
                {
                    case "Private":
                        {//Private <id> <firstName> <lastName> <salary>
                            int id = int.Parse(input[1]);
                            string firstName = input[2];
                            string lastName = input[3];
                            decimal salary = decimal.Parse(input[4]);
                            soldiers.Add(new Private(id, firstName, lastName, salary));
                            break;
                        }
                    case "LieutenantGeneral":
                        {//LieutenantGeneral <id> <firstName> <lastName> <salary> <private1Id> <private2Id> … <privateNId>
                            int id = int.Parse(input[1]);
                            string firstName = input[2];
                            string lastName = input[3];
                            decimal salary = decimal.Parse(input[4]);
                            var lieutenant = new LieutenantGeneral(id,firstName,lastName,salary);
                            for (int i = 5; i < input.Length; i++)
                            {
                                if(soldiers.Any(x=>x.Id==int.Parse(input[i])) || true)
                                {
                                    lieutenant.Privates.Add((Private)soldiers.First(x => x.Id == int.Parse(input[i])));
                                }
                            }
                            soldiers.Add(lieutenant);
                            break;
                        }
                    case "Engineer":
                        {//Engineer <id> <firstName> <lastName> <salary> <corps> <repair1Part> <repair1Hours> … <repairNPart> <repairNHours>
                            int id = int.Parse(input[1]);
                            string firstName = input[2];
                            string lastName = input[3];
                            decimal salary = decimal.Parse(input[4]);
                            string corps = input[5];
                            try
                            {
                                var engeneer = new Engeneer(id, firstName, lastName, salary, corps);
                                for (int i = 6; i < input.Length; i += 2)
                                {
                                    var repair = new Repair(input[i], int.Parse(input[i + 1]));
                                    engeneer.Repairs.Add(repair);
                                }

                                soldiers.Add(engeneer);
                            }
                            catch (ArgumentException ae)
                            {
                                //break;
                            }
                            break;
                        }
                    case "Commando":
                        {//Commando <id> <firstName> <lastName> <salary> <corps> <mission1CodeName>  <mission1state> … <missionNCodeName> <missionNstate>
                            int id = int.Parse(input[1]);
                            string firstName = input[2];
                            string lastName = input[3];
                            decimal salary = decimal.Parse(input[4]);
                            string corps = input[5];
                            try
                            {
                                var commando = new Commando(id,firstName,lastName,salary,corps);
                                for (int i = 6; i < input.Length; i += 2)
                                {
                                    Mission mission;
                                    try
                                    {
                                        mission = new Mission(input[i], input[i + 1]);
                                        commando.Missions.Add(mission);
                                    }
                                    catch (ArgumentException ae)
                                    {
                                        //continue;
                                    }
                                    
                                }
                                soldiers.Add(commando);
                            }
                            catch (ArgumentException ae)
                            {
                                break;
                            }
                               
                            break;
                        }
                    case "Spy":
                        {//Spy <id> <firstName> <lastName> <codeNumber>
                            int id = int.Parse(input[1]);
                            string firstName = input[2];
                            string lastName = input[3];
                            int codeNumber = int.Parse(input[4]);
                            var spy = new Spy(id, firstName, lastName, codeNumber);
                            soldiers.Add(spy);
                            break;
                        }
                    default:
                        Console.WriteLine("Invalid Type of Soldier!");
                        break;
                }
                input = Console.ReadLine().Split().ToArray();
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
