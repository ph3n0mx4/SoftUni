using System;
using System.Linq;

namespace _1_DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int d1 = 0;
            int d2 = 0;

            for (int i = 0; i < n; i++)
            {
                d1 += matrix[i, i];
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                d2 += matrix[row, matrix.GetLength(0) - 1 - row];

            }

            int result = Math.Abs(d1 - d2);
            Console.WriteLine(result);
        }
    }
}