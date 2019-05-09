using System;
using System.Collections.Generic;
using System.Linq;

namespace _09ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var users = new Dictionary<string, List<string>>();
            while(input!= "Lumpawaroo")
            {
                string side = "";
                string user = "";

                string[] b = input.Split(new string[] { " | ", " -> " }, StringSplitOptions.RemoveEmptyEntries);

                if (input.Contains(" | "))
                {
                    side = b[0];
                    user = b[1];
                    bool check = false;
                    foreach (var kvp in users)
                    {
                        if (kvp.Value.Contains(user))
                        {
                            check = true;
                            break;
                        }
                    }
                    if(check)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    if(!users.ContainsKey(side))
                    {
                        users[side] = new List<string>();
                    }

                    users[side].Add(user);
                }

                else if (input.Contains(" -> "))
                {
                    side = b[1];
                    user = b[0];

                    bool check = false;
                    string currentSide = "";
                    foreach (var kvp in users)
                    {
                        if (kvp.Value.Contains(user))
                        {
                            currentSide = kvp.Key;
                            check = true;
                            break;
                        }
                    }
                    if (check)
                    {
                        users[currentSide].Remove(user);

                        if(users.ContainsKey(side))
                        {
                            users[side].Add(user);
                        }

                        else
                        {
                            users[side] = new List<string>();
                            users[side].Add(user);
                        }
                        //input = Console.ReadLine();
                        //continue;
                    }

                    else
                    {
                        if (users.ContainsKey(side))
                        {
                            users[side].Add(user);
                        }

                        else
                        {
                            users[side] = new List<string>();
                            users[side].Add(user);
                        }
                    }
                    Console.WriteLine($"{user} joins the {side} side!");
                }

                input = Console.ReadLine();
            }

            foreach (var kvp in users.OrderBy(x=>-x.Value.Count).ThenBy(x=>x.Key))
            {
                if(kvp.Value.Count==0)
                {
                    continue;
                }
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");
                var result = kvp.Value.OrderBy(x => x).ToList();
                foreach (var user in result)
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
