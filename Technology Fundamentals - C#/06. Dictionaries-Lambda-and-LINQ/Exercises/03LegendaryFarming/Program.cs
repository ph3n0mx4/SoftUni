using System;
using System.Collections.Generic;
using System.Linq;

namespace _03LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> matirials = Console.ReadLine().ToLower().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string, int> allMatirials = new Dictionary<string, int>();
            Dictionary<string, int> keyMat = new Dictionary<string, int>();
            SortedDictionary<string, int> junkMat = new SortedDictionary<string, int>();
            string result = string.Empty;
            int count = 0;

            while(true)
            {
                if (!keyMat.Keys.Contains("shards"))
                {
                    keyMat.Add("shards", 0);
                }

                if (!keyMat.Keys.Contains("fragments"))
                {
                    keyMat.Add("fragments", 0);
                }

                if (!keyMat.Keys.Contains("motes"))
                {
                    keyMat.Add("motes", 0);
                }

                for (int i = 1; i < matirials.Count; i = i + 2)
                {
                    if (matirials[i] == "shards" || matirials[i] == "fragments" || matirials[i] == "motes")
                    {
                        if (!keyMat.Keys.Contains(matirials[i]))
                        {
                            keyMat.Add(matirials[i], int.Parse(matirials[i - 1]));
                        }

                        else
                        {
                            keyMat[matirials[i]] += int.Parse(matirials[i - 1]);
                        }
                    }

                    else if (matirials[i] != "shards" && matirials[i] != "fragments" && matirials[i] != "motes")
                    {
                        if (!junkMat.Keys.Contains(matirials[i]))
                        {
                            junkMat.Add(matirials[i], int.Parse(matirials[i - 1]));
                        }

                        else
                        {
                            junkMat[matirials[i]] += int.Parse(matirials[i - 1]);
                        }
                    }

                    if (keyMat.Keys.Contains("shards") && keyMat["shards"] >= 250)
                    {
                        keyMat["shards"] -= 250;
                        result = "Shadowmourne obtained!";
                        count++;
                        break;
                    }

                    else if (keyMat.Keys.Contains("motes") && keyMat["motes"] >= 250)
                    {
                        keyMat["motes"] -= 250;
                        result = "Dragonwrath obtained!";
                        count++;
                        break;
                    }

                    else if (keyMat.Keys.Contains("fragments") && keyMat["fragments"] >= 250)
                    {
                        keyMat["fragments"] -= 250;
                        result = "Valanyr obtained!";
                        count++;
                        break;
                    }
                }
                
                if(count!=0)
                { break; }

                matirials = Console.ReadLine().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            

            keyMat = keyMat.OrderBy(x => -x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine(result);

            foreach (var item in keyMat)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in junkMat)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
