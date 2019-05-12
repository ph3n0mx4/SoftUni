using System;
using System.Linq;
using System.Collections.Generic;

namespace _02_Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            
            var matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            int cols = matrix[1].Length;

            int rowSam = -1;
            int colSam = -1;

            int rowN = -1;
            int colN = -1;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row][col]=='S')
                    {
                        rowSam = row;
                        colSam = col;
                    }

                    if (matrix[row][col] == 'N')
                    {
                        rowN = row;
                        colN = col;
                    }
                }
            }
            var cmd = Console.ReadLine().ToCharArray();
            bool isAlive = true;
            for (int i = 0; i < cmd.Length; i++)
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if(matrix[row][col]=='b')
                        {
                            if (row == rowSam && colSam > col)
                            {
                                Console.WriteLine($"Sam died at {rowSam}, {colSam}");
                                matrix[rowSam][colSam] = 'X';
                                isAlive = false;
                                //return;
                            }

                            if (col==cols-1)
                            {
                                matrix[row][col] = 'd';

                                if(row==rowSam && colSam<col)
                                {
                                    Console.WriteLine($"Sam died at {rowSam}, {colSam}");
                                    matrix[rowSam][colSam] = 'X';
                                    isAlive = false;
                                    //return;
                                }
                                break;
                            }
                            
                            matrix[row][col] = '.';
                            matrix[row][col+1] = 'b';
                            break;
                        }

                        else if (matrix[row][col] == 'd')
                        {
                            if (row == rowSam && colSam < col)
                            {
                                Console.WriteLine($"Sam died at {rowSam}, {colSam}");
                                matrix[rowSam][colSam] = 'X';
                                isAlive = false;
                                //return;
                            }

                            if (col == 0)
                            {
                                matrix[row][col] = 'b';

                                if (row == rowSam && colSam > col)
                                {
                                    Console.WriteLine($"Sam died at {rowSam}, {colSam}");
                                    matrix[rowSam][colSam] = 'X';
                                    isAlive = false;
                                    
                                    //return;
                                }
                                break;
                            }

                            matrix[row][col] = '.';
                            matrix[row][col-1] = 'd';
                            break;
                        }
                        
                    }
                }

                if(!isAlive)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, matrix.Select(r => string.Join("", r))));
                    break;
                }
                

                if (cmd[i]=='U')
                {
                    rowSam--;
                    if(rowSam==rowN)
                    {
                        matrix[rowN][colN] = 'X';
                        matrix[rowSam + 1][colSam] = '.';
                        matrix[rowSam][colSam] = 'S';
                        Console.WriteLine("Nikoladze killed!");
                        Console.WriteLine(string.Join(Environment.NewLine, matrix.Select(r => string.Join("", r))));
                        return;
                    }
                    else
                    {
                        matrix[rowSam+1][colSam] = '.';
                        matrix[rowSam][colSam] = 'S';
                    }
                }

                else if(cmd[i] == 'D')
                {
                    rowSam++;
                    if (rowSam == rowN)
                    {
                        matrix[rowN][colN] = 'X';
                        matrix[rowSam - 1][colSam] = '.';
                        matrix[rowSam][colSam] = 'S';
                        Console.WriteLine("Nikoladze killed!");
                        Console.WriteLine(string.Join(Environment.NewLine, matrix.Select(r => string.Join("", r))));
                        return;
                    }
                    else
                    {
                        matrix[rowSam - 1][colSam] = '.';
                        matrix[rowSam][colSam] = 'S';
                    }
                }

                else if (cmd[i] == 'L')
                {
                    matrix[rowSam][colSam] = '.';
                    colSam--;
                    matrix[rowSam][colSam] = 'S';
                }

                else if (cmd[i] == 'R')
                {
                    matrix[rowSam][colSam] = '.';
                    colSam++;
                    matrix[rowSam][colSam] = 'S';
                }

                else if (cmd[i] == 'W')
                {
                    continue;
                }
            }

        }
    }
}
