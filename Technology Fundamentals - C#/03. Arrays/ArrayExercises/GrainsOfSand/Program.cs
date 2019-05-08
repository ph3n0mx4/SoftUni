using System;
using System.Linq;

namespace GrainsOfSand
{
    class Program
    {
        static void Main(string[] args)
        {
            var countOfSands = Console.ReadLine()
                                        .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToList();
            string[] cmd = Console.ReadLine()
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while(cmd[0]!= "Mort")
            {
                if(cmd[0] == "Add")
                {
                    countOfSands.Add(int.Parse(cmd[1]));
                }

                else if(cmd[0] == "Remove")
                {
                    if(countOfSands.Contains(int.Parse(cmd[1])))
                    {
                        countOfSands.Remove(int.Parse(cmd[1]));
                    }

                    else if(int.Parse(cmd[1])>=0 && int.Parse(cmd[1])<countOfSands.Count)
                    {
                        countOfSands.RemoveAt(int.Parse(cmd[1]));
                    }
                }

                else if(cmd[0] == "Replace")
                {
                    if(countOfSands.Contains(int.Parse(cmd[1])))
                    {
                        for (int i = 0; i < countOfSands.Count; i++)
                        {
                            if(countOfSands[i]== int.Parse(cmd[1]))
                            {
                                countOfSands[i] = int.Parse(cmd[2]);
                                break;
                            }
                        }
                    }
                }

                else if (cmd[0] == "Increase")
                {
                    int increaseValue = int.MinValue;
                    for (int i = 0; i < countOfSands.Count; i++)
                    {
                        if (countOfSands[i] >= int.Parse(cmd[1]))
                        {
                            increaseValue = countOfSands[i];
                            break;
                        }

                        else if (i==countOfSands.Count-1)
                        {
                            increaseValue = countOfSands[i];
                        }
                    }

                    for (int i = 0; i < countOfSands.Count; i++)
                    {
                        countOfSands[i] += increaseValue;
                    }
                }

                else if (cmd[0] == "Collapse")
                {
                    for (int i = 0; i < countOfSands.Count; i++)
                    {
                        if (countOfSands[i] < int.Parse(cmd[1]))
                        {
                            countOfSands.Remove(countOfSands[i]);
                            i = -1;
                        }
                    }
                }

                cmd = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(' ',countOfSands));
        }
    }
}
