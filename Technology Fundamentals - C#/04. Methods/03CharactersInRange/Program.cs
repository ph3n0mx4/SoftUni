using System;

namespace _03CharactersInRange
{
    class Program
    {
        public static void Main(string[] args)
        {
            char symbolOne = char.Parse(Console.ReadLine());
            char symbolTwo = char.Parse(Console.ReadLine());
            CharactersInRange(symbolOne, symbolTwo);
            
            Console.WriteLine();
        }

        public static void CharactersInRange(char symbolOne, char symbolTwo)
        {
            int comparison = symbolOne.CompareTo(symbolTwo);
            char start = '0';
            char end = '0';

            if (comparison >= 1)
            {
                start = symbolTwo;
                end = symbolOne;
            }
            else
            {
                start = symbolOne;
                end = symbolTwo;
            }

            for (int i = start + 1; i < end; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
