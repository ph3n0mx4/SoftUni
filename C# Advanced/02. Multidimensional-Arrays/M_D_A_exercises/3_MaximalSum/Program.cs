using System;
using System.Linq;

namespace _3_MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int sum = int.MinValue;
            var biggestMatrix = new int[3, 3];

            for (int row = 0; row < rows-2; row++)
            {
                for (int col = 0; col < cols-2; col++)
                {
                    var currentMatrix = new int[3, 3];
                    int currentSum = 0;
                    for (int cRow = row; cRow < row+3; cRow++)
                    {
                        for (int cCol = col; cCol < col+3; cCol++)
                        {
                            int indexR = cRow-row;
                            int indexC = cCol-col;
                            currentMatrix[indexR, indexC] = matrix[cRow, cCol];
                            currentSum += currentMatrix[indexR, indexC];
                        }
                    }

                    if(currentSum>sum)
                    {
                        biggestMatrix = currentMatrix;
                        sum = currentSum;
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write($"{biggestMatrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
