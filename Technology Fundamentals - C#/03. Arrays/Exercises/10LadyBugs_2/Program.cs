using System;
using System.Linq;

namespace _10LadyBugs_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            long[] indexOfLadybugs = Console.ReadLine()
                                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                            .Select(long.Parse)
                                            .ToArray();
            long[] field = new long[fieldSize];
            for (int i = 0; i < field.Length; i++)
            {
                field[i] = 0;
            }

            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < indexOfLadybugs.Length; j++)
                {
                    if(i == indexOfLadybugs[j])
                    {
                        field[i] = 1;
                    }
                }
            }
            long sum = field.Sum();

            string command = Console.ReadLine();

            while(command!="end")
            {
                if (sum<=0)
                {
                    command = Console.ReadLine();
                    continue;
                }

                string[] arr = command.Split();
                long startIndex = long.Parse(arr[0]);
                string direction = arr[1];
                long flyLength = long.Parse(arr[2]);
                
                if(startIndex >= 0 && startIndex < field.Length && field[startIndex] == 1)
                {
                    field[startIndex] = 0;
                    
                    if(direction=="left")
                    {
                        long a = startIndex - flyLength;
                        
                        while (a>=0)
                        {
                            if (field[a] == 0)
                            {
                                field[a] = 1;
                                break;
                            }
                                
                            a -= flyLength;
                        }
                        command = Console.ReadLine();
                        continue;
                    }
                    else 
                    {
                        long a = startIndex + flyLength;

                        while (a < field.Length)
                        {
                            if (field[a] == 0)
                            {
                                field[a] = 1;
                                break;
                            }

                            a += flyLength;
                        }
                        command = Console.ReadLine();
                        continue;

                    }
                }


                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', field));
        }
    }
}
