using System;
using System.Linq;

namespace _10LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int leght = int.Parse(Console.ReadLine());

            long[] startPosition = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(long.Parse)
                                    .ToArray();

            int[] place = new int[leght];

            for(int i = 0; i < place.Length; i++)
            {
                place[i] = 0;
            }

            for (int i = 0; i < place.Length; i++)
            {
                for (int j = 0; j < startPosition.Length; j++)
                {
                    if (i == startPosition[j])
                    {
                        place[i] = 1;
                    }
                }
            }
            //Console.WriteLine(string.Join(' ',place));

            string text = Console.ReadLine();

            while (text != "end")
            {
                string[] command = text.Split();
                long ladyBugsIndex = long.Parse(command[0]);
                if(ladyBugsIndex <0 || ladyBugsIndex >= place.Length)
                {
                    text = Console.ReadLine();
                    continue;
                }

                string direction = command[1];
                long flyLenght= long.Parse(command[2]);
                long divider = Math.Abs(flyLenght) / flyLenght;
                flyLenght = Math.Abs(flyLenght);
                for (long i = 0; i < place.Length; i++)
                {
                    if(i==ladyBugsIndex)
                    {
                        place[i] = 0;

                        if ((direction == "left" && divider == 1) || (direction == "right" && divider == -1))
                        {
                            long a = i - flyLenght;
                            if (a >= 0)
                            {
                                if(place[a] == 0)
                                {
                                    place[a] = 1;
                                        break;
                                }
                                else if (place[a] == 1)
                                {
                                    a -= flyLenght;
                                    while (a >= 0)
                                    {
                                        if(place[a] == 1 /*&& a >= 0*/)
                                        {
                                            a -= flyLenght;
                                        }
                                        else if(place[a] == 0 /*&& a >= 0*/)
                                        {
                                            place[a] = 1;
                                            break;
                                        }
                                        else
                                        { break; }
                                    }
                                    break;
                                }
                            }
                            break;
                        }

                        else 
                        {
                            long a = i + flyLenght;
                            if (a <= place.Length-1)
                            {
                                if (place[a] == 0)
                                {
                                    place[a] = 1;
                                    break;
                                }
                                else if (place[a] == 1)
                                {
                                    a += flyLenght;
                                    while (a <= place.Length - 1)
                                    {
                                        if (place[a] == 1 /*&& a <= place.Length - 1*/)
                                        {
                                            a += flyLenght;
                                        }
                                        else if (place[a] == 0 /*&& a <= place.Length - 1*/)
                                        {
                                            place[a] = 1;
                                            break;
                                        }
                                        else
                                        { break; }
                                    }
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                text = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', place));
        }
    }
}
