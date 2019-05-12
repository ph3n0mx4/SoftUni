using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _5_SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            int rows = size[0];
            int cols = size[1];

            string input = Console.ReadLine();

            var queue = new Queue<char>(input);
            var matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = queue.Dequeue();
                    queue.Enqueue(matrix[row, col]);
                }
            }

            for(int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
            //Console.WriteLine(string.Join(Environment.NewLine,matrix.Select(r=>string.Join("",r))));
        }
    }
}
