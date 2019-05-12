using System;
using System.Linq;

namespace _8_Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var matrix = new int[n][];
            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                matrix[row] = new int[n];
                for (int col = 0; col < n; col++)
                {
                    matrix[row][col] = currentRow[col];
                }
            }

            var coordinaters = Console.ReadLine().Split();

            for (int i = 0; i < coordinaters.Length; i++)
            {
                var currentCoordinate = coordinaters[i].Split(",").Select(int.Parse).ToArray();
                int rowBomb = currentCoordinate[0];
                int colBomb = currentCoordinate[1];
                int radius = 2;
                int damage = matrix[rowBomb][colBomb];
                
                if(damage<0)
                {
                    continue;
                }

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        double distance = Math.Sqrt(Math.Pow(row - rowBomb, 2) + Math.Pow(col - colBomb, 2));
                        int currentValue = matrix[row][col];

                        if(distance<radius && currentValue>0)
                        {
                            matrix[row][col] -= damage;
                        }
                    }
                }
            }

            int aliveCells = 0;
            int sum = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    int currentValue = matrix[row][col];
                    if(currentValue>0)
                    {
                        aliveCells++;
                        sum += currentValue;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(string.Join(" ",matrix[row]));
            }
        }

        
    }
}
