using System;
using System.Linq;

namespace _6_Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var jagged = new int[n][];
            for (int row = 0; row < n; row++)
            {
                jagged[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string[] cmd = Console.ReadLine().Split().ToArray();

            while (cmd[0] != "END")
            {
                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);
                int num = int.Parse(cmd[3]);

                if (row >= 0 && (row < jagged.GetLength(0)) && col >= 0 && (col < jagged[row].Length))
                {
                    switch (cmd[0])
                    {
                        case "Add":
                            jagged[row][col] += num;
                            break;
                        case "Subtract":
                            jagged[row][col] -= num;
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

                cmd = Console.ReadLine().Split().ToArray();
            }

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write($"{jagged[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
