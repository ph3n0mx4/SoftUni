using System;
using System.Linq;

namespace _03ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arrayOne = new int[n];
            int[] arrayTwo = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();
                int numberOne = numbers[0];
                int numberTwo = numbers[1];

                if (i%2==0)
                {
                    arrayOne[i] = numberOne;
                    arrayTwo[i] = numberTwo;
                }
                else
                {
                    arrayOne[i] = numberTwo;
                    arrayTwo[i] = numberOne;
                }
            }

            Console.WriteLine(string.Join(" ",arrayOne));
            Console.WriteLine(string.Join(" ", arrayTwo));
        }
    }
}


//using System;

//namespace _03ZigZagArrays
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int n = int.Parse(Console.ReadLine());
//            int[] arrayOne = new int[n];
//            int[] arrayTwo = new int[n];

//            for (int i = 0; i < n; i++)
//            {
//                string[] numbers = Console.ReadLine().Split();
//                string numberOne = numbers[0];
//                string numberTwo = numbers[1];

//                if (i % 2 == 0)
//                {
//                    arrayOne[i] = int.Parse(numberOne);
//                    arrayTwo[i] = int.Parse(numberTwo);
//                }
//                else
//                {
//                    arrayOne[i] = int.Parse(numberTwo);
//                    arrayTwo[i] = int.Parse(numberOne);
//                }
//            }

//            Console.WriteLine(string.Join(" ", arrayOne));
//            Console.WriteLine(string.Join(" ", arrayTwo));
//        }
//    }
//}
