using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            var matrix = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();
                matrix[row] = new char[cols];
                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = currentRow[col];
                }
            }

            string cmd = Console.ReadLine();
            int rowPlayer = -1;
            int colPlayer = -1;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if(matrix[row][col]=='P')
                    {
                        rowPlayer = row;
                        colPlayer = col;
                    }
                }
            }

            string result = string.Empty;
            for (int i = 0; i < cmd.Length; i++)
            {
                char currentCmd = cmd[i];
                bool bunnyReachesPlayer = true;

                if (currentCmd=='L')
                {
                    bool inLair = CheckGoesOutOfLair(rowPlayer, colPlayer - 1, matrix);

                    if (!inLair)
                    {
                        result = "won";
                        matrix[rowPlayer][colPlayer] = '.';
                        BunniesSpread(matrix, rows, cols);
                        break;
                    }

                    else if(matrix[rowPlayer][colPlayer-1] == 'B')
                    {
                        matrix[rowPlayer][colPlayer] = '.';
                        result = "dead";
                        colPlayer -= 1;
                        BunniesSpread(matrix, rows, cols);
                        break;
                    }

                    else if(matrix[rowPlayer][colPlayer - 1] == '.')
                    {
                        matrix[rowPlayer][colPlayer] = '.';
                        colPlayer -= 1;
                        matrix[rowPlayer][colPlayer] = 'P';
                        bunnyReachesPlayer = BunniesSpread(matrix, rows, cols);
                    }

                    if (!bunnyReachesPlayer)
                    {
                        result = "dead";
                        break;
                    }
                }

                else if (currentCmd=='R')
                {
                    bool inLair = CheckGoesOutOfLair(rowPlayer, colPlayer + 1, matrix);

                    if (!inLair)
                    {
                        result = "won";
                        matrix[rowPlayer][colPlayer] = '.';
                        BunniesSpread(matrix, rows, cols);
                        break;
                    }

                    else if (matrix[rowPlayer][colPlayer + 1] == 'B')
                    {
                        matrix[rowPlayer][colPlayer] = '.';
                        result = "dead";
                        colPlayer += 1;
                        BunniesSpread(matrix, rows, cols);
                        break;
                    }

                    else if (matrix[rowPlayer][colPlayer + 1] == '.')
                    {
                        matrix[rowPlayer][colPlayer] = '.';
                        colPlayer += 1;
                        matrix[rowPlayer][colPlayer] = 'P';
                        bunnyReachesPlayer = BunniesSpread(matrix, rows, cols);
                    }

                    if (!bunnyReachesPlayer)
                    {
                        result = "dead";
                        break;
                    }
                    
                }
                else if (currentCmd == 'U')
                {
                    //bool inLair = CheckGoesOutOfLair(rowPlayer-1, colPlayer, matrix);
                    bool inLair = CheckGoesOutOfLair(rowPlayer-1, colPlayer, matrix);

                    if (!inLair)
                    {
                        result = "won";
                        matrix[rowPlayer][colPlayer] = '.';
                        BunniesSpread(matrix, rows, cols);
                        break;
                    }

                    else if (matrix[rowPlayer-1][colPlayer] == 'B')
                    {
                        matrix[rowPlayer][colPlayer] = '.';
                        result = "dead";
                        rowPlayer -= 1;
                        BunniesSpread(matrix, rows, cols);
                        break;
                    }

                    else if (matrix[rowPlayer-1][colPlayer] == '.')
                    {
                        matrix[rowPlayer][colPlayer] = '.';
                        rowPlayer -= 1;
                        matrix[rowPlayer][colPlayer] = 'P';
                        bunnyReachesPlayer = BunniesSpread(matrix, rows, cols);
                    }

                    if (!bunnyReachesPlayer)
                    {
                        result = "dead";
                        break;
                    }

                }
                else if (currentCmd == 'D')
                {
                    //bool inLair = CheckGoesOutOfLair(rowPlayer + 1, colPlayer, matrix);
                    bool inLair = CheckGoesOutOfLair(rowPlayer + 1, colPlayer, matrix);

                    if (!inLair)
                    {
                        result = "won";
                        matrix[rowPlayer][colPlayer] = '.';
                        BunniesSpread(matrix, rows, cols);
                        break;
                    }

                    else if (matrix[rowPlayer + 1][colPlayer] == 'B')
                    {
                        matrix[rowPlayer][colPlayer] = '.';
                        result = "dead";
                        rowPlayer += 1;
                        BunniesSpread(matrix, rows, cols);
                        break;
                    }

                    else if (matrix[rowPlayer + 1][colPlayer] == '.')
                    {
                        matrix[rowPlayer][colPlayer] = '.';
                        rowPlayer += 1;
                        matrix[rowPlayer][colPlayer] = 'P';
                        bunnyReachesPlayer = BunniesSpread(matrix, rows, cols);
                    }

                    if (!bunnyReachesPlayer)
                    {
                        result = "dead";
                        break;
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join("",matrix[row]));
            }

            Console.WriteLine($"{result}: {rowPlayer} {colPlayer}");
        }


        private static bool BunniesSpread(char[][] matrix, int rows, int cols)
        {
            var listCoordinates = new List< Dictionary<int, int>>();
            for (int currRow = 0; currRow < rows; currRow++)
            {
                for (int currCol = 0; currCol < cols; currCol++)
                {
                    if (matrix[currRow][currCol] == 'B')
                    {
                        listCoordinates.Add(new Dictionary<int, int>());
                        listCoordinates[listCoordinates.Count - 1][currRow] = currCol;
                    }
                }
            }

            bool result = true;
            foreach (var coordinates in listCoordinates)
            {
                foreach (var kvp in coordinates)
                {
                    int row = kvp.Key;
                    int col = kvp.Value;

                    for (int currRow = 0; currRow < rows; currRow++)
                    {
                        for (int currCol = 0; currCol < cols; currCol++)
                        {
                            double distance = Math.Sqrt(Math.Pow(currRow - row, 2) + Math.Pow(currCol - col, 2));

                            if (distance == 1)
                            {
                                if (matrix[currRow][currCol] == 'P')
                                {
                                    result = false;
                                    matrix[currRow][currCol] = 'B';
                                }

                                if ((matrix[currRow][currCol] == '.'))
                                {
                                    matrix[currRow][currCol] = 'B';
                                }
                            }
                        }
                    }
                }
                
            }
            return result;
        } 

        private static bool CheckGoesOutOfLair(int rowP, int colP, char[][] matrix)
        {
            if(rowP>=0 && rowP<matrix.GetLength(0) && colP>=0 && colP<matrix[rowP].Length)
            {
                return true;
            }
            return false;
        }
    }
}
