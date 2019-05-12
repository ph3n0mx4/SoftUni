using System;
using System.Linq;

namespace _02_CubicsRube
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var matrix = new int[n][][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] = new int[n][];
                for (int col = 0; col < n; col++)
                {
                    matrix[row][col] = new int[n];
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    for (int depth = 0; depth < n; depth++)
                    {
                        matrix[row][col][depth] = 0;
                    }
                }
            }

            long sum = 0;
            int count = 0;

            var cmd = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (cmd[0] != "Analyze")
            {
                int currentRow = int.Parse(cmd[0]);
                int currentCol = int.Parse(cmd[1]);
                int currentDepth = int.Parse(cmd[2]);
                int currentParticle = int.Parse(cmd[3]);


                if (CheckDimensions(currentRow, currentCol, currentDepth, n))
                {
                    if (matrix[currentRow][currentCol][currentDepth] == 0 && currentParticle!=0)
                    {
                        matrix[currentRow][currentCol][currentDepth] = currentParticle;
                        count++;
                        sum += currentParticle;
                    }
                }
                cmd = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            Console.WriteLine(sum);
            Console.WriteLine((n * n * n) - count);
        }

        private static bool CheckDimensions(int currentRow, int currentCol, int currentDepth, int n)
        {
            if (currentRow < 0 || currentRow >= n)
            {
                return false;
            }

            if (currentCol < 0 || currentCol >= n)
            {
                return false;
            }

            if (currentDepth < 0 || currentDepth >= n)
            {
                return false;
            }
            return true;
        }
    }
}