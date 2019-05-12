using System;
using System.Linq;
using System.Collections.Generic;

namespace _01_DangerousFloor
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 8;
            int cols = 8;

            var matrix = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split(",").Select(char.Parse).ToArray();
            }

            var input = Console.ReadLine();

            while (input!="END")
            {
                //Q01-12
                char piece = input[0];
                int currentRow = int.Parse(input[1].ToString());
                int currentCol = int.Parse(input[2].ToString());
                int nextRow = int.Parse(input[4].ToString());
                int nextCol = int.Parse(input[5].ToString()); 

                if(matrix[currentRow][currentCol]==piece)
                {
                    if(CheckMove(matrix,piece,currentRow,currentCol,nextRow,nextCol))
                    {
                        if(nextRow <rows && nextCol<cols)
                        {
                            matrix[currentRow][currentCol] = 'x';
                            matrix[nextRow][nextCol] = piece;
                        }

                        else
                        {
                            Console.WriteLine("Move go out of board!");
                        }
                    }

                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }

                else
                {
                    Console.WriteLine("There is no such a piece!");
                }
                input = Console.ReadLine();
            }
        }

        private static bool CheckMove(char[][] matrix, char piece, int currentRow, int currentCol, int nextRow, int nextCol)
        {
            switch (piece)
            {
                case 'Q':
                    return Math.Abs(currentRow - nextRow) == Math.Abs(currentCol - nextCol) || currentRow == nextRow || currentCol == nextCol;
                case 'K':
                    return Math.Sqrt(Math.Pow(currentRow-nextRow,2)+Math.Pow(currentCol-nextCol,2))<2;
                case 'P':
                    return currentRow-nextRow==1;
                case 'R':
                    return currentRow==nextRow || currentCol==nextCol;
                case 'B':
                    return Math.Abs(currentRow - nextRow) == Math.Abs(currentCol - nextCol);
                default:
                    return false;
            }
        }
    }
}
