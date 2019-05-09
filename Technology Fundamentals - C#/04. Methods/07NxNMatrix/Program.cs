using System;

namespace _07NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            MatrixNxN(number);
        }

        public static void MatrixNxN(int number)
        {
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    Console.Write(number+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
