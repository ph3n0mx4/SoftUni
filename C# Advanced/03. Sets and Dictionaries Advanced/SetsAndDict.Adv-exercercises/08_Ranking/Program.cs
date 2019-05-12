using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputContests = Console.ReadLine().Split(":").ToArray();

            var contests = new Dictionary<string, string>();
            while (inputContests[0]!= "end of contests")
            {
                string contest = inputContests[0];
                string password = inputContests[1];

                contests[contest] = password;

                inputContests = Console.ReadLine().Split(":").ToArray();
            }

            var inputSubmissions = Console.ReadLine().Split("=>").ToArray();

            var listUsers = new Dictionary<string, Dictionary<string, int>>();
            while (inputSubmissions[0]!= "end of submissions")
            {//“{contest}=>{password}=>{username}=>{points}
                string contestName = inputSubmissions[0];
                string password = inputSubmissions[1];
                string username = inputSubmissions[2];
                int points = int.Parse(inputSubmissions[3]);

                if (contests.ContainsKey(contestName) && contests[contestName]==password)
                {
                    if(!listUsers.ContainsKey(username))
                    {
                        listUsers[username] = new Dictionary<string, int>();
                    }

                    if(listUsers[username].ContainsKey(contestName) && listUsers[username][contestName]>points)
                    {
                        inputSubmissions = Console.ReadLine().Split("=>").ToArray();
                        continue;
                    }

                    listUsers[username][contestName] = points;
                }

                inputSubmissions = Console.ReadLine().Split("=>").ToArray();
            }

            string bestCandidate = "";
            int bestPoints = 0;

            foreach (var candidate in listUsers)
            {
                string currentName = candidate.Key;
                int currentPoints = 0;

                foreach (var item in candidate.Value)
                {
                    currentPoints += item.Value;
                }

                if(currentPoints>bestPoints)
                {
                    bestPoints = currentPoints;
                    bestCandidate = currentName;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in listUsers.OrderBy(x=>x.Key))
            {
                string name = user.Key;
                Console.WriteLine(name);

                foreach (var contest in user.Value.OrderBy(x=>-x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
