using System;
using System.Linq;

namespace _02_KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var matrix = new char[n][];
            for (int row = 0; row < n; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            int result = 0;
            while (true)
            {
                int maxDangerousKnight = 0;
                int maxRow = -1;
                int maxCol = -1;
                //int currentKnight = 0;
                //int currentKnightRow = -1;
                //int currentKnightCol = -1;
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if(matrix[row][col]=='K')
                        {
                            int currentKnight = CheckCountConflict(matrix, row, col,n);
                            if(currentKnight>maxDangerousKnight)
                            {
                                maxDangerousKnight = currentKnight;
                                maxRow = row;
                                maxCol = col;
                            }
                        }
                    }
                }

                if(maxDangerousKnight==0)
                {
                    break;
                }
                matrix[maxRow][maxCol] = '0';
                result++;
            }

            Console.WriteLine(result);
        }

        private static int CheckCountConflict(char[][] matrix, int row, int col, int n)
        {
            int count = 0;
            
            if(row - 2 >=0 && col+1 <n && matrix[row - 2][col + 1] == 'K')
            { count++; }

            if (row -2 >=0 && col -1 >=0 && matrix[row - 2][col - 1] == 'K')
            { count++; }
            
            if (row - 1 >= 0 && col + 2 < n && matrix[row - 1][col + 2] == 'K')
            { count++; }

            if (row - 1 >= 0 && col - 2 >= 0 && matrix[row - 1][col - 2] == 'K')
            { count++; }
            
            if (row + 1 < n && col + 2 < n && matrix[row + 1][col + 2] == 'K')
            { count++; }

            if (row + 1 < n && col - 2 >=0 && matrix[row + 1][col - 2] == 'K')
            { count++; }
            
            if (row + 2 < n && col + 1 < n && matrix[row + 2][col + 1] == 'K')
            { count++; }

            if (row + 2 < n && col - 1 >= 0 && matrix[row + 2][col - 1] == 'K')
            { count++; }

            return count;
        }
    }
}
