using System;

namespace _09PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string integer = Console.ReadLine();

            while (integer != "END")
            {
                Console.WriteLine(CheckPalindrome(integer).ToString().ToLower());
                integer = Console.ReadLine();
            }
        }

        public static bool CheckPalindrome(string integer)
        {
            bool result = true;
            
            for (int i = 0; i < integer.Length / 2; i++)
            {
                if (integer[i] != integer[integer.Length - 1 - i])
                {
                    result = false;
                }
            }

            return result;
        }
    }
}
