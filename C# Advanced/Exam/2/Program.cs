using System;
using System.Linq;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var matrix = new char[n][];
            for (int row = 0; row < n; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            int fRow = -1;
            int fCol = -1;
            int sRow = -1;
            int sCol = -1;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if(matrix[row][col]=='f')
                    {
                        fRow = row;
                        fCol = col;
                    }

                    else if (matrix[row][col] == 's')
                    {
                        sRow = row;
                        sCol = col;
                    }
                }
            }

            while (true)
            {
                var cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string fCmd = cmd[0];
                string sCmd = cmd[1];
                // up, down, left or right

                switch (fCmd)
                {
                    case "up":
                        fRow--;
                        if(fRow<0)
                        {
                            fRow = (n-1);
                        }
                        break;
                    case "down":
                        fRow++;
                        if (fRow >= n)
                        {
                            fRow = 0;
                        }
                        break;
                    case "left":
                        fCol--;
                        if (fCol < 0)
                        {
                            fCol = (n-1);
                        }
                        
                        break;
                    case "right":
                        fCol++;
                        if (fCol >= n)
                        {
                            fCol = 0;
                        }
                        break;
                }

                switch (sCmd)
                {
                    case "up":
                        sRow--;
                        if (sRow < 0)
                        {
                            sRow = (n - 1);
                        }
                        break;
                    case "down":
                        sRow++;
                        if (sRow >= n)
                        {
                            sRow = 0;
                        }
                        break;
                    case "left":
                        sCol--;
                        if (sCol < 0)
                        {
                            sCol = (n-1);
                        }
                        break;
                    case "right":
                        sCol++;
                        if (sCol >= n)
                        {
                            sCol = 0;
                        }
                        break;
                }

                if(matrix[fRow][fCol]=='*')
                {
                    matrix[fRow][fCol] = 'f';
                }

                else if(matrix[fRow][fCol] == 's')
                {
                    matrix[fRow][fCol] = 'x';
                    break;
                }


                if (matrix[sRow][sCol] == '*')
                {
                    matrix[sRow][sCol] = 's';
                }

                else if (matrix[sRow][sCol] == 'f')
                {
                    matrix[sRow][sCol] = 'x';
                    break;
                }

                //bool gameOver = false;
                //for (int row = 0; row < n; row++)
                //{
                //    if(matrix[row].Contains('x'))
                //    {
                //        gameOver = true;
                //    }
                //}
                //if(gameOver)
                //{
                //    break;
                //}

                //Console.WriteLine(string.Join(Environment.NewLine, matrix.Select(r => string.Join("", r))));
            }
            Console.WriteLine(string.Join(Environment.NewLine, matrix.Select(r => string.Join("", r))));
        }

        private static bool inField(int row, int col, int n)
        {
            if(row>=0 && row<n && col >= 0 && col < n)
            {
                return true;
            }

            return false;
        }
    }
}
