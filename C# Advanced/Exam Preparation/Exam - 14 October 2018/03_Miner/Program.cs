using System;
using System.Linq;

namespace _03_Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cmd = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();

            var matrix = new char[n][];

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                matrix[row] = new char[n];

                for (int col = 0; col < n; col++)
                {
                    matrix[row][col] = input[col];
                }
            }

            int rowS = -1;
            int colS = -1;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if(matrix[row][col]=='s')
                    {
                        rowS = row;
                        colS = col;
                        break;
                    }
                }
                if(rowS!=-1)
                {
                    break;
                }
            }

            int totalCountCoal = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if(matrix[row][col]=='c')
                    {
                        totalCountCoal++;
                    }
                }
            }

            int findCoal = 0;

            for (int i = 0; i < cmd.Length; i++)
            {
                string currentCmd = cmd[i];

                if(currentCmd=="left")
                {
                    bool inField = CheckGetOutOfTheField(matrix, rowS, colS-1);
                    if(!inField)
                    {
                        continue;
                    }

                    colS--;
                }

                else if (currentCmd == "right")
                {
                    bool inField = CheckGetOutOfTheField(matrix, rowS, colS + 1);
                    if (!inField)
                    {
                        continue;
                    }

                    colS++;
                }

                else if (currentCmd == "up")
                {
                    bool inField = CheckGetOutOfTheField(matrix, rowS-1, colS);
                    if (!inField)
                    {
                        continue;
                    }

                    rowS--;
                }

                else if (currentCmd == "down")
                {
                    bool inField = CheckGetOutOfTheField(matrix, rowS + 1, colS);
                    if (!inField)
                    {
                        continue;
                    }

                    rowS++;
                }

                bool isCoal = CheckForCoal(matrix, rowS, colS);
                if (isCoal)
                {
                    findCoal++;
                }

                bool isEnd = CheckForEnd(matrix, rowS, colS);
                if (isEnd)
                {
                    Console.WriteLine($"Game over! ({rowS}, {colS})");
                    return;
                }

                if (findCoal == totalCountCoal)
                {
                    Console.WriteLine($"You collected all coals! ({rowS}, {colS})");
                    return;
                }
            }

            Console.WriteLine($"{totalCountCoal-findCoal} coals left. ({rowS}, {colS})");
        }

        private static bool CheckForEnd(char[][] matrix, int rowS, int colS)
        {
            bool isEnd = false;

            if(matrix[rowS][colS]=='e')
            {
                isEnd = true;
            }

            return isEnd;
        }

        private static bool CheckForCoal(char[][] matrix, int rowS, int colS)
        {
            bool isCoal = false;

            if(matrix[rowS][colS]=='c')
            {
                matrix[rowS][colS] = '*';
                isCoal = true;
            }
            return isCoal;
        }

        private static bool CheckGetOutOfTheField(char[][] matrix, int row, int col)
        {
            bool inField = true;

            if(row<0 || col<0 || row>=matrix.Length || col >=matrix.Length)
            {
                inField = false;
            }
            return inField;
        }
    }
}
