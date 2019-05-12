using System;
using System.Linq;

namespace _5_SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            var biggestMatrix = new int[2, 2];
            int sum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] 
                        + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if(currentSum>sum)
                    {
                        sum = currentSum;
                        biggestMatrix[0, 0] = matrix[row, col];
                        biggestMatrix[0, 1] = matrix[row, col+1];
                        biggestMatrix[1, 0] = matrix[row+1, col];
                        biggestMatrix[1, 1] = matrix[row+1, col+1];
                    }
                }
            }

            for (int row = 0; row < biggestMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < biggestMatrix.GetLength(1); col++)
                {
                    Console.Write($"{biggestMatrix[row,col]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(sum);
        }
    }
}
