using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_JediGalaxy_13_06_2016
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            var matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    if(row==0)
                    {
                        matrix[row][col] = col;
                    }

                    else
                    {
                        matrix[row][col] = matrix[row - 1][col] + cols;
                    }
                }
            }

            string cmdIvo = Console.ReadLine();
            long sum = 0;
            while (cmdIvo!= "Let the Force be with you")
            {
                string cmdEvil = Console.ReadLine();

                var pointIvo = cmdIvo.Split().Select(int.Parse).ToArray();
                int rowI = pointIvo[0];
                int colI = pointIvo[1];

                var pointEvil = cmdEvil.Split().Select(int.Parse).ToArray();
                int rowE = pointEvil[0];
                int colE = pointEvil[1];

                while (rowE>=0 && colE >=0)
                {
                    if(inField(rowE,colE,rows,cols))
                    {
                        matrix[rowE][colE] = 0;
                    }
                    rowE--;
                    colE--;
                }

                while (rowI >= 0 && colI < cols)
                {
                    if (inField(rowI, colI, rows, cols))
                    {
                        sum += matrix[rowI][colI];
                    }
                    rowI--;
                    colI++;
                }

                cmdIvo = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        private static bool inField(int rowE, int colE, int rows, int cols)
        {
            if(rowE>=0 && colE>=0 && rowE<rows && colE<cols)
            {
                return true;
            }
            return false;
        }
    }
}
