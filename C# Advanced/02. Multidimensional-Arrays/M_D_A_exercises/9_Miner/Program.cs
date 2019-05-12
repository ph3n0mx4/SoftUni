using System;
using System.Collections.Generic;
using System.Linq;

namespace _9_Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var cmd = Console.ReadLine().Split().ToArray();

            var matrix = new char[n][];
            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                matrix[row] = new char[n];
                for (int col = 0; col < n; col++)
                {

                    matrix[row][col] = currentRow[col];
                }
            }

            var listCoals = new Dictionary<string, int>();
            listCoals["total"] = 0;
            listCoals["current"] = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row][col] == 'c')
                    {
                        listCoals["total"]++;
                    }
                }
            }

            int startRow = -1;
            int startCol = -1;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row][col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                        break;
                    }
                }

                if (startCol != -1)
                {
                    break;
                }
            }
            

            for (int i = 0; i < cmd.Length; i++)
            {
                string currentCmd = cmd[i];
                //left, right, up and down
                if (currentCmd== "left")
                {
                    bool InField= CheckGetOutOfTheField(startRow, startCol-1, matrix);
                    if(!InField)
                    {
                        continue;
                    }
                    startCol -= 1;

                    var currentChar = matrix[startRow][startCol];
                    if(currentChar!='*')
                    {
                        bool abc =CheckCurrentCell(startRow, startCol, matrix, listCoals);
                        if(abc)
                        {
                            return;
                        }
                    }

                }
                else if(currentCmd == "right")
                {
                    bool InField = CheckGetOutOfTheField(startRow, startCol + 1, matrix);
                    if (!InField)
                    {
                        continue;
                    }
                    startCol += 1;

                    var currentChar = matrix[startRow][startCol];
                    if (currentChar != '*')
                    {
                        bool abc = CheckCurrentCell(startRow, startCol, matrix, listCoals);
                        if (abc)
                        {
                            return;
                        }
                    }
                }
                else if (currentCmd == "up")
                {
                    bool InField = CheckGetOutOfTheField(startRow-1, startCol, matrix);
                    if (!InField)
                    {
                        continue;
                    }
                    startRow -= 1;

                    var currentChar = matrix[startRow][startCol];
                    if (currentChar != '*')
                    {
                        bool abc = CheckCurrentCell(startRow, startCol, matrix, listCoals);
                        if (abc)
                        {
                            return;
                        }
                    }
                }
                else if (currentCmd == "down")
                {
                    bool InField = CheckGetOutOfTheField(startRow+1, startCol, matrix);
                    if (!InField)
                    {
                        continue;
                    }
                    startRow += 1;

                    var currentChar = matrix[startRow][startCol];
                    if (currentChar != '*')
                    {
                        bool abc = CheckCurrentCell(startRow, startCol, matrix, listCoals);
                        if (abc)
                        {
                            return;
                        }
                    }
                }
            }

            Console.WriteLine($"{listCoals["total"] - listCoals["current"]} coals left. ({startRow}, {startCol})");
        }

        public static bool CheckCurrentCell(int startRow, int startCol, char[][] matrix, Dictionary<string, int> listCoals)
        {
            var currentChar = matrix[startRow][startCol];

            if (currentChar == 'c')
            {
                listCoals["current"]++;
                matrix[startRow][startCol] = '*';
                if (listCoals["current"] == listCoals["total"])
                {
                    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                    return true;
                }
            }
            else if (currentChar == 'e')
            {
                Console.WriteLine($"Game over! ({startRow}, {startCol})");
                return true;
            }
            return false;
        }

        public static bool CheckGetOutOfTheField(int startRow, int v, char[][] matrix)
        {
            if(startRow>=0 && startRow<matrix.GetLength(0) && v>=0 && v<matrix[startRow].Length)
            {
                return true;
            }
            return false;
        }
    }
}
