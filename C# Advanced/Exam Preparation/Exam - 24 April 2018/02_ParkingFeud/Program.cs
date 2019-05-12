using System;
using System.Linq;

namespace _02_ParkingFeud
{
    class Program
    {
        static void Main(string[] args)
        {
            var spots = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = spots[0] * 2 - 1;
            int cols = spots[1] + 2;

            var matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = 0;
                }
            }

            int numEntrance = int.Parse(Console.ReadLine());
            var cmd = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();

            int distance = 0;
            string endSpot = "";
            while (true)
            {
                int samStartRow = 2 * numEntrance - 1;
                int samStartCol = 0;
                int indexSameEnt = -1;
                string samSpot = cmd[numEntrance-1];
                for (int i = 0; i < cmd.Count; i++)
                {
                    if(i==numEntrance-1)
                    {
                        continue;
                    }

                    if(cmd[i]==samSpot)
                    {
                        indexSameEnt = i;
                        break;
                    }
                }

                if(indexSameEnt==-1)
                {
                    
                    int samSpotRow = (int.Parse(samSpot[1].ToString()) * 2) - 2;
                    int samSpotCol = (samSpot[0]) - 64;

                    if(samSpotRow==samStartRow-1 || samSpotRow == samStartRow + 1)
                    {
                        distance = samSpotCol - samStartCol;
                        endSpot = samSpot;
                        break;
                    }

                    else
                    {
                        int diff = Math.Abs(samSpotRow - samStartRow);
                        distance = (cols - 1) + diff * 2 + (cols - 1 - samSpotCol);
                        endSpot = samSpot;
                        break;
                    }
                }

                else
                {

                }

                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            Console.WriteLine($"Parked successfully at {endSpot}.");
            Console.WriteLine($"Total Distance Passed: {distance}");
        }
    }
}
