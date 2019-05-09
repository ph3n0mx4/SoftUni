using System;
using System.Collections.Generic;
using System.Linq;

namespace _02MemoryView
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> memory = new List<int>();
            List<string> cmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            while(cmd[0]!= "Visual")
            {
                List<int> currentMemory = cmd.Select(int.Parse).ToList();
                memory.AddRange(currentMemory);
                cmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            for (int i = 0; i < memory.Count; i++)
            {
                if(memory[i]== 32763)
                {
                    int sizeOfString = memory[i+2];
                    int startIndex = i + 4;
                    int endIndex = sizeOfString+startIndex;
                    List<char> result = new List<char>();

                    for (int j = startIndex; j < endIndex; j++)
                    {
                        char symbol = (char)memory[j];
                        result.Add(symbol);
                    }

                    Console.WriteLine(string.Join("",result));
                }
            }
        }
    }
}
