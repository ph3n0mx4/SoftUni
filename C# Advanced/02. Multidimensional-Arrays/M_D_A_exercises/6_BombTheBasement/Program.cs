using System;
using System.Linq;

namespace _6_BombTheBasement
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int cols = size[1];

            var dataBomb = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rowBomb = dataBomb[0];
            int colBomb = dataBomb[1];
            int radius = dataBomb[2];

            var matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    double distance = Math.Sqrt(Math.Pow(row - rowBomb, 2) + Math.Pow(col - colBomb,2));
                    if(distance<=radius)
                    {
                        matrix[row][col] = 1;
                    }
                }
            }

            for (int col = 0; col < cols; col++) 
            {
                for (int row = 0; row < rows; row++)
                {
                    if(matrix[row][col]==0)
                    {
                        for (int i = row; i < rows; i++)
                        {
                            if(matrix[i][col]==1)
                            {
                                matrix[row][col] = 1;
                                matrix[i][col] = 0;
                                
                                break;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, matrix.Select(r => string.Join("", r))));
        }
    }
}
