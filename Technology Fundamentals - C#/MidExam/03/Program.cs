using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            var cmd = Console.ReadLine().Split(new string[] {" - ", ":" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            while(cmd[0]!= "Retire!")
            {
                if(cmd[0]== "Start")
                {
                    if(journal.Contains(cmd[1]))
                    {
                        cmd = Console.ReadLine().Split(new string[] { " - ", ":" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        continue;
                    }
                    journal.Add(cmd[1]);
                }

                else if(cmd[0] == "Complete")
                {
                    if (journal.Contains(cmd[1]))
                    {
                        journal.Remove(cmd[1]);
                    }
                }

                else if(cmd[0] == "Side Quest")
                {
                    if(journal.Contains(cmd[1])&& !journal.Contains(cmd[2]))
                    {
                        int index =journal.IndexOf(cmd[1]);
                        journal.Insert(index + 1, cmd[2]);
                    }
                }

                else if(cmd[0] == "Renew")
                {
                    if(journal.Contains(cmd[1]))
                    {
                        int index = journal.IndexOf(cmd[1]);
                        string quest = journal[index];
                        journal.RemoveAt(index);
                        journal.Add(quest);
                    }
                    
                }

                cmd = Console.ReadLine().Split(new string[] { " - ", ":" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            Console.WriteLine(string.Join(", ",journal));
        }
    }
}
