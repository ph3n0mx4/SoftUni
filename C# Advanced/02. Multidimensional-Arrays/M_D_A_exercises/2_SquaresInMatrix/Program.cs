using System;
using System.Linq;

namespace _2_SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimension = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = dimension[0];
            int cols = dimension[1];
            var matrix = new char[rows,cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            int counter = 0;
            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    char a = matrix[row, col];
                    char b = matrix[row, col+1];
                    char c = matrix[row+1, col];
                    char d = matrix[row+1, col+1];

                    if(a==b && a==c && a==d)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
