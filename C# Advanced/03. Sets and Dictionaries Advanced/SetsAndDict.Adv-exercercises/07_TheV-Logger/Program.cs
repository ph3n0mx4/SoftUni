using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_TheV_Logger
{
    public class Vlogger
    {
        public string Name { get; set; }

        public List<string> Followers { get; set; }

        public List<string> Followings { get; set; }

        public Vlogger(string name)
        {
            this.Name = name;
            Followers = new List<string>();
            Followings = new List<string>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var listVloggers = new List<Vlogger>();
            var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (input[0]!= "Statistics")
            {
                string follower = input[0];
                string cmd = input[1];
                string followed = input[2];
                
                if(cmd == "joined" && !listVloggers.Any(x=>x.Name==follower))
                {
                    listVloggers.Add(new Vlogger(follower));
                }

                else if(cmd == "followed" && listVloggers.Any(x=>x.Name==follower) && listVloggers.Any(y => y.Name == followed) && follower!=followed)
                {
                    int a = listVloggers.FindIndex(x => x.Name == followed);

                    if(listVloggers[a].Followers.Contains(follower))
                    {
                        input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                        continue;
                    }
                    listVloggers[a].Followers.Add(follower);

                    int b = listVloggers.FindIndex(x => x.Name == follower);
                    listVloggers[b].Followings.Add(followed);
                }

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            listVloggers = listVloggers.OrderBy(x => -x.Followers.Count).ThenBy(x => x.Followings.Count).ToList();
            

            var bestVLogger = listVloggers.First();

            Console.WriteLine($"The V-Logger has a total of {listVloggers.Count} vloggers in its logs.");

            Console.WriteLine($"1. {bestVLogger.Name} : {bestVLogger.Followers.Count} followers, {bestVLogger.Followings.Count} following");

            foreach (var follower in bestVLogger.Followers.OrderBy(x=>x))
            {
                Console.WriteLine($"*  {follower}");
            }

            int count = 2;

            foreach (var vlogger in listVloggers)
            {
                if(vlogger.Name==bestVLogger.Name)
                {
                    continue;
                }
                Console.WriteLine($"{count}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Followings.Count} following");

                count++;
            }
        }
    }
}
