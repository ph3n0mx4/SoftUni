using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var matrix = new int[n][];
            for (int row = 0; row < n; row++)
            {
                var inputRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                matrix[row] = new int[n];
                for (int col = 0; col < n; col++)
                {
                    matrix[row][col] = inputRow[col];
                }
            }

            var bombCells = Console.ReadLine().Split().ToArray();

            for (int i = 0; i < bombCells.Count(); i++)
            {//double distance = Math.Sqrt(Math.Pow(row - rowBomb, 2) + Math.Pow(col - colBomb,2));
                var currentBomb = bombCells[i].Split(",").Select(int.Parse).ToArray();
                int rowBomb = currentBomb[0];
                int colBomb = currentBomb[1];

                int bombDamage = matrix[rowBomb][colBomb];
                if(bombDamage<=0)
                {
                    continue;
                }
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        double distance = Math.Sqrt(Math.Pow(row - rowBomb, 2) + Math.Pow(col - colBomb, 2));
                        if(distance<2 && matrix[row][col]>0)
                        {
                            matrix[row][col] -= bombDamage;
                        }
                    }
                }
            }

            var positiveCells = new List<int>();

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if(matrix[row][col]>0)
                    {
                        positiveCells.Add(matrix[row][col]);
                    }
                }
            }
            Console.WriteLine($"Alive cells: {positiveCells.Count}");
            Console.WriteLine($"Sum: {positiveCells.Sum()}");
            Console.WriteLine(string.Join(Environment.NewLine, matrix.Select(r => string.Join(" ", r))));
        }
    }
}
