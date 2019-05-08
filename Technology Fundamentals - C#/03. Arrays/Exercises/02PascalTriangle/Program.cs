using System;
using System.Linq;

namespace _02PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr1 = new int[1] {1};
            int[] arr2 = new int[2] {1,1};
            //int[] arr = new int[n];
            int[] arrTemp = new int[n];
            Console.WriteLine(string.Join(' ', arr1));
            Console.WriteLine(string.Join(' ', arr2));

            for (int i=3; i<=n; i++)
            {
                int[] arr = new int[i];
                //int[] arrTemp = new int[i];
                if (i==3)
                {
                    arr[0] = 1;
                    arr[1] = arr2[0] + arr2[1];
                    arr[2] = 1;

                    Console.WriteLine(string.Join(' ', arr));

                    arrTemp = arr;
                }
                else if(i>3)
                {
                    arr[0] = 1;
                    arr[i-1] = 1;
                    for (int j = 1; j < i-1; j++)
                    {
                        arr[j] = arrTemp[j-1] + arrTemp[j];
                    }
                    Console.WriteLine(string.Join(' ', arr));
                    arrTemp = arr;
                }
                
            }


            //Console.WriteLine(string.Join(',', arr));
        }
    }
}
