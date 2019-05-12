using System;
using System.Linq;

namespace _10_RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var dims = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dims[0];
            int cols = dims[1];

            var matrix = new char[rows][];

            int rowP = -1;
            int colP = -1;

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
                if(matrix[row].Contains('P'))
                {
                    int col = Array.IndexOf(matrix[row], 'P');
                    rowP = row;
                    colP = col;
                    matrix[rowP][colP] = '.';
                }
            }
            string cmds = Console.ReadLine();

            bool gameOver = false;
            string result = string.Empty;
            foreach (var cmd in cmds)
            {
                if(gameOver)
                {
                    break;
                }
                switch (cmd)
                {
                    case 'U': rowP--; break;
                    case 'D': rowP++; break;
                    case 'L': colP--; break;
                    case 'R': colP++; break;
                }

                if(rowP<0 || rowP>=rows || colP <0 || colP>cols)
                {
                    switch (cmd)
                    {
                        case 'U': rowP++; break;
                        case 'D': rowP--; break;
                        case 'L': colP++; break;
                        case 'R': colP--; break;
                    }

                    result = $"won: {rowP} {colP}";
                    gameOver = true;
                }

                if(matrix[rowP][colP]=='B')
                {
                    result = $"dead: {rowP} {colP}";
                    gameOver = true;
                }

                if(Bunnies(matrix, rows, cols, rowP, colP))
                {
                    result = $"dead: {rowP} {colP}";
                    gameOver = true;

                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, matrix.Select(r => string.Join("", r))));
            Console.WriteLine(result);
            
        }

        private static bool Bunnies(char[][] matrix, int rows, int cols, int rowP, int colP)
        {
            bool isDead = false;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if(matrix[row][col]=='B')
                    {
                        if(row - 1 >= 0 && row - 1 < rows)
                        {
                            matrix[row - 1][col] = 'b';
                        }

                        if (row + 1 >= 0 && row + 1 < rows)
                        {
                            matrix[row + 1][col] = 'b';
                        }

                        if (col - 1 >= 0 && col - 1 < cols)
                        {
                            matrix[row][col - 1] = 'b';
                        }

                        if (col + 1 >= 0 && col + 1 < cols)
                        {
                            matrix[row][col + 1] = 'b';
                        }

                        if(matrix[rowP][colP]=='b'|| matrix[rowP][colP] == 'B')
                        {
                            isDead = true;
                        }
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row][col] == 'b')
                    {
                        matrix[row][col] = 'B';
                    }
                }
            }
            return isDead;
        }

        private static bool CheckOutField(int row, int col, int rows, int cols)
        {
            if(row <0 || row >=rows || col<0|| col>=cols)
            {
                return true;
            }
            return false;
        }
    }
}
