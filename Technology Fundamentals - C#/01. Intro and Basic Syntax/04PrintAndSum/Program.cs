using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PrintAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int startN = int.Parse(Console.ReadLine());
            int endN = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = startN; i <= endN; i++)
            {
                Console.Write(i+" ");
                sum += i;
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
