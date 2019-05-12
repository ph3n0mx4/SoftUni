using System;
using System.Collections.Generic;
using System.Linq;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var stack = new Stack<string>(input);
            var halls = new Dictionary<string, List<int>>();
            //Console.WriteLine(stack.Pop());
            var listPrintedHalls = new List<string>();
            var listPrintedHallss = new List<string>();
            while (stack.Count > 0)
            {
                string a = stack.Pop();
                if (char.IsLetter(a[0]))
                {
                    halls[a] = new List<int>();
                    listPrintedHalls.Add(a);
                    listPrintedHallss.Add(a);
                }

                else if (halls.Keys.Count == 0)
                {
                    continue;
                }
                else
                {
                    for (int i = 0; i < listPrintedHalls.Count; i++)
                    {
                        string currentHalls = listPrintedHalls[i];
                        if (halls[currentHalls].Sum() <= capacity - int.Parse(a))
                        {
                            halls[currentHalls].Add(int.Parse(a));

                            if (halls[currentHalls].Sum() == capacity)
                            {
                                string output = $"{currentHalls} -> ";
                                string g = string.Join(", ", halls[currentHalls]);
                                output = string.Concat(output, g);
                                Console.WriteLine(output);
                                listPrintedHalls.Remove(currentHalls);
                                halls.Remove(currentHalls);
                            }
                            break;
                        }

                        else //if (halls[currentHalls].Sum() > capacity - int.Parse(a))
                        {
                            string output = $"{currentHalls} -> ";
                            string g = string.Join(", ", halls[currentHalls]);
                            output = string.Concat(output, g);
                            Console.WriteLine(output);
                            listPrintedHalls.Remove(currentHalls);
                            halls.Remove(currentHalls);

                            //if(halls.Keys.Count>0)
                            //{
                            //    i = 0;

                            //}
                            //else
                            //{
                            //    break;
                            //}
                            stack.Push(a);
                            break;
                        }
                    }
                }
            }
        }
    }
}