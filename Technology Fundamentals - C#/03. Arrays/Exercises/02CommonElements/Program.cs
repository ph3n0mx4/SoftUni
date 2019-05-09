using System;

namespace _02CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text1 = Console.ReadLine().Split();
            string[] text2 = Console.ReadLine().Split();

            for (int i = 0; i < text1.Length; i++)
            {
                string word1 = text1[i];
                for (int j = 0; j < text2.Length; j++)
                {
                    string word2 = text2[j];

                    if (word1==word2)
                    {
                        Console.Write(word1 + " ");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
