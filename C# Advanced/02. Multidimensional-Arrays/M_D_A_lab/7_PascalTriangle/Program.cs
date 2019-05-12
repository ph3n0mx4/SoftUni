using System;

namespace _7_PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if(n<=0)
            {
                return;
            }
            long[][] jagged = new long[n][];

            if(n==1)
            {
                jagged[0] = new long[1] { 1 };
            }

            else if (n==2)
            {
                jagged[0] = new long[1] { 1 };
                jagged[1] = new long[2] { 1,1 };
            }

            else if(n>2 && n<61)
            {
                jagged[0] = new long[1] { 1 };
                jagged[1] = new long[2] { 1, 1 };

                for (int row = 2; row < n; row++)
                {
                    jagged[row] = new long[row+1];
                    jagged[row][0] = 1;
                    jagged[row][row] = 1;
                    for (int i = 1; i < row; i++)
                    {
                        jagged[row][i] = jagged[row - 1][i - 1] + jagged[row - 1][i];
                    }
                }
            }


            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write($"{jagged[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
