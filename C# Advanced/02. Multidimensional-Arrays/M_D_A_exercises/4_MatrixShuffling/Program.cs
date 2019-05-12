using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _4_MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var dims = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dims[0];
            int cols = dims[1];

            var matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions
                    .RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            string cmd = Console.ReadLine();

            while (cmd != "END")
            {
                //string regex = @"(swap [0-9]{1,3} [0-9]{1,3} [0-9]{1,3} [0-9]{1,})";
                //Match match = Regex.Match(cmd, regex);
                //if (!match.Success)
                //{
                //    Console.WriteLine("Invalid input!");
                //    cmd = Console.ReadLine();
                //    continue;
                //}



                var data = cmd.Split().ToArray();
                if (data.Length != 5 || data[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    cmd = Console.ReadLine();
                    continue;
                }


                ;
                int row1 = int.Parse(data[1]);
                int col1 = int.Parse(data[2]);
                int row2 = int.Parse(data[3]);
                int col2 = int.Parse(data[4]);

                if (row1 < rows && row1 >= 0 && row2 < rows && row2 >= 0 &&
                    col1 < cols && col1 >= 0 && col2 < cols && col2 >= 0)
                {
                    //Console.WriteLine("Invalid input!");
                    //cmd = Console.ReadLine();
                    //continue;


                    string currentCell = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = currentCell;

                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            Console.Write($"{matrix[row, col]} ");
                        }
                        Console.WriteLine();
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                    cmd = Console.ReadLine();
                    continue;
                }

                cmd = Console.ReadLine();
            }
        }
    }
}