using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Tagram
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] {'-', '>', ' '},StringSplitOptions.RemoveEmptyEntries).ToArray();

            var users = new Dictionary<string, Dictionary<string, int>>();
            while (input[0]!="end")
            {
                if(input[0]=="ban" && users.ContainsKey(input[1]))
                {
                    users.Remove(input[1]);
                }

                else
                {
                    int like = int.Parse(input[2]);
                    if (users.ContainsKey(input[0]) && users[input[0]].ContainsKey(input[1]))
                    {
                        users[input[0]][input[1]] += like;
                    }
                    else if(!users.ContainsKey(input[0]))
                    {
                        users[input[0]] = new Dictionary<string, int>();
                        users[input[0]][input[1]] = like;
                    }

                    else
                    {
                        users[input[0]][input[1]] = like;
                    }
                }
                input = Console.ReadLine().Split(new[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            users = users.OrderBy(x => -x.Value.Values.Sum()).ThenBy(x=>x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            //"{username}"
            //"- {tag}: {likes}"


            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}");

                foreach (var tag in user.Value)
                {
                    Console.WriteLine($"- {tag.Key}: {tag.Value}");
                }
            }
        }
    }
}
