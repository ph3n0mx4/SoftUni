using System;

namespace _01Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagon = int.Parse(Console.ReadLine());
            int[] peopleOfWagon = new int[wagon];
            int sum = 0;
            for (int i = 0; i < wagon; i++)
            {
                peopleOfWagon[i] = int.Parse(Console.ReadLine());
                sum += peopleOfWagon[i];
            }

            for (int i = 0; i < peopleOfWagon.Length; i++)
            {
                Console.Write(peopleOfWagon[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
