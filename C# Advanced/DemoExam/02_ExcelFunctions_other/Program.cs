using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_ExcelFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = -1;
            string[][] matrix = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().Split(", ").ToArray();
                if (cols < 0)
                {
                    cols = input.Length;
                }
                matrix[row] = new string[cols];
                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = input[col];
                }
            }

            var cmd = Console.ReadLine().Split().ToArray();
            string command = cmd[0];
            string header = cmd[1];
            int colHeader = FindColumnOfHeader(matrix, header, cols);

            if (command == "hide")
            {
                string[][] resultHide = matrix.Where((arr, i) => i != -2) //skip row#3
                          .Select(arr => arr.Where((item, i) => i != colHeader).ToArray()) //skip col#3
                          .ToArray();

                for (int row = 0; row < rows; row++)
                {
                    var currentRow = new List<string>();
                    for (int col = 0; col < cols - 1; col++)
                    {
                        currentRow.Add(resultHide[row][col]);
                    }

                    Console.WriteLine(string.Join(" | ", currentRow));
                }
            }

            else if (command == "sort")
            {
                var currentColumn = new List<string>();
                for (int row = 1; row < rows; row++)
                {
                    currentColumn.Add(matrix[row][colHeader]);
                }
                //currentColumn.Sort();
                currentColumn = currentColumn.OrderBy(x => x).ToList();

                for (int i = 1; i < currentColumn.Count; i++)
                {
                    string cellContents = currentColumn[i - 1];
                    int currentRowIndex = FindRow(matrix, cellContents, colHeader, rows);

                    if (currentRowIndex == i)
                    {
                        continue;
                    }

                    for (int j = 0; j < cols; j++)
                    {
                        string temp = matrix[i][j];
                        matrix[i][j] = matrix[currentRowIndex][j];
                        matrix[currentRowIndex][j] = temp;
                    }
                }

                for (int row = 0; row < rows; row++)
                {
                    var currentRow = new List<string>();
                    for (int col = 0; col < cols; col++)
                    {
                        currentRow.Add(matrix[row][col]);
                    }

                    Console.WriteLine(string.Join(" | ", currentRow));
                }
            }

            else if (command == "filter")
            {
                Console.WriteLine(string.Join(" | ", matrix[0]));

                string value = cmd[2];
                for (int row = 0; row < rows; row++)
                {
                    if (value == matrix[row][colHeader])
                    {
                        Console.WriteLine(string.Join(" | ", matrix[row]));

                    }
                }
            }

        }


        private static int FindRow(string[][] matrix, string cellContents, int colHeader, int rows)
        {
            int currentRow = -1;
            for (int row = 0; row < rows; row++)
            {
                if (matrix[row][colHeader] == cellContents)
                {
                    currentRow = row;
                    break;
                }
            }
            return currentRow;
        }

        private static int FindColumnOfHeader(string[][] matrix, string header, int cols)
        {
            int colHeader = -1;

            for (int col = 0; col < cols; col++)
            {
                if (matrix[0][col] == header)
                {
                    colHeader = col;
                    break;
                }
            }
            return colHeader;
        }
    }
}