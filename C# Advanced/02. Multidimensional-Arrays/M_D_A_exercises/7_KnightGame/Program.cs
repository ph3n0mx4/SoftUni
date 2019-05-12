using System;
using System.Linq;

namespace _7_KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n][];

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                    
                matrix[row] = new char[n];
                for (int col = 0; col < n; col++)
                {
                    matrix[row][col] = input[col];
                }
            }
            
            int count = 0;
            
            while (true)
            {
                int currentKnightInDanger = 0;
                int mostDangerousKnightRow = 0;
                int mostDangerousKnightCol = 0;
                int maxKnightInDanger = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        char currentSymbol = matrix[row][col];
                        if (currentSymbol == '0')
                        {
                            continue;
                        }

                        currentKnightInDanger = CheckCurrentInDanger(row, col, matrix);
                        
                        if(currentKnightInDanger>maxKnightInDanger)
                        {
                            maxKnightInDanger = currentKnightInDanger;
                            mostDangerousKnightRow = row;
                            mostDangerousKnightCol = col;
                        }
                    }
                }

                if(maxKnightInDanger>0)
                {
                    matrix[mostDangerousKnightRow][mostDangerousKnightCol] = '0';
                    count++;
                }
                else
                {
                    Console.WriteLine(count);
                    break;
                }
            }
            
        }

        private static bool CheckCell(int row, int col, char[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix.Length;

            if(row<0 || row >=rows || col <0 || col>=cols)
            {
                return false;
            }

            if(matrix[row][col]=='0')
            {
                return false;
            }

            return true;
        }

        private static int CheckCurrentInDanger(int row, int col, char[][] matrix)
        {
            int currentKnightInDanger = 0;
            if (CheckCell(row - 2, col - 1, matrix))
            {
                currentKnightInDanger++;
            }

            if (CheckCell(row - 2, col + 1, matrix))
            {
                currentKnightInDanger++;
            }

            if (CheckCell(row + 2, col - 1, matrix))
            {
                currentKnightInDanger++;
            }

            if (CheckCell(row + 2, col + 1, matrix))
            {
                currentKnightInDanger++;
            }

            if (CheckCell(row - 1, col - 2, matrix))
            {
                currentKnightInDanger++;
            }

            if (CheckCell(row - 1, col + 2, matrix))
            {
                currentKnightInDanger++;
            }

            if (CheckCell(row + 1, col - 2, matrix))
            {
                currentKnightInDanger++;
            }

            if (CheckCell(row + 1, col + 2, matrix))
            {
                currentKnightInDanger++;
            }

            return currentKnightInDanger;
        }
    }
}
