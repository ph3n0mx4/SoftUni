using System;
using System.Collections.Generic;
using System.Linq;

namespace _05TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int countTeam = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();
            for (int i = 0; i < countTeam; i++)
            {
                string[] cmd = Console.ReadLine().Split("-");
                string teamName = cmd[1];
                string creator = cmd[0];
                if (teams.Any(x=>x.TeamName==teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }

                else if(teams.Any(x=>x.Creator==creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }

                else
                {
                    Team team = new Team();
                    team.Creator = cmd[0];
                    team.TeamName = cmd[1];
                    team.Member = new List<string>();
                    teams.Add(team);

                    Console.WriteLine($"Team {cmd[1]} has been created by {cmd[0]}!");
                }
            }

            string[] cmdUser = Console.ReadLine().Split("->");

            while(cmdUser[0]!= "end of assignment")
            {
                string teamName = cmdUser[1];
                string user = cmdUser[0];
                if(!teams.Any(x=>x.TeamName==teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }

                else if(teams.Any(x=>x.Member.Contains(user)) || teams.Any(x=>x.Creator==user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                }

                else
                {
                    teams.First(x => x.TeamName == teamName).Member.Add(user);
                    //Team currentTeam = teams.First(x => x.TeamName == teamName);
                    //currentTeam.Member.Add(user);
                }
                

                cmdUser = Console.ReadLine().Split("->");
            }

            teams = teams.OrderBy(x => -x.Member.Count).ThenBy(x=>x.TeamName).ToList();

            foreach (var team in teams.Where(x=>x.Member.Count>0))
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");

                foreach (var member in team.Member.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine($"Teams to disband:");
            foreach (var item in teams.Where(x => x.Member.Count == 0))
            {
                Console.WriteLine($"{item.TeamName}");
            }
        }
    }

    class Team
    {
        public string TeamName { get; set; }

        public string Creator { get; set; }

        public List<string> Member { get; set; }
    }
}
