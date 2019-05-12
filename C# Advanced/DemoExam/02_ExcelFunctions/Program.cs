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
                var input = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                if(cols<0)
                {
                    cols = input.Length;
                }
                matrix[row] = new string[cols];
                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = input[col];
                }
            }

            var cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string command = cmd[0];
            string header = cmd[1];
            int colHeader = FindColumnOfHeader(matrix, header, cols);

            if (command == "hide")
            {
                int colIndex = -1;
                var resultHide = new string[rows][];
                for (int i = 0; i < cols; i++)
                {
                    if (matrix[0][i] == header)
                    {
                        colIndex = i;
                        break;
                    }
                }
                    
                for (int row = 0; row < rows; row++)
                {
                    var abc = new List<string>();
                    for (int col = 0; col < cols; col++)
                    {
                        if(col==colIndex)
                        {
                            continue;
                        }

                        abc.Add(matrix[row][col]);
                    }
                    resultHide[row] = abc.ToArray();
                }
                
                //string[][] resultHide = matrix.Where((arr, i) => i != -2) //skip row#3
                          //.Select(arr => arr.Where((item, i) => i != colHeader).ToArray()) //skip col#3
                          //.ToArray();

                Console.WriteLine(string.Join(Environment.NewLine, resultHide.Select(r => string.Join(" | ", r))));
            }

            else if (command == "sort")
            {
                Console.WriteLine(string.Join(" | ", matrix[0]));
                var currentColumn = new SortedDictionary<string,int>();
                for (int row = 1; row < rows; row++)
                {
                    currentColumn.Add(matrix[row][colHeader],row);
                }

                foreach (var item in currentColumn)
                {
                    Console.WriteLine(string.Join(" | ",matrix[item.Value]));
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
                if(matrix[row][colHeader]==cellContents)
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
                if(matrix[0][col]==header)
                {
                    colHeader = col;
                    break;
                }
            }
            return colHeader;
        }
    }
}
