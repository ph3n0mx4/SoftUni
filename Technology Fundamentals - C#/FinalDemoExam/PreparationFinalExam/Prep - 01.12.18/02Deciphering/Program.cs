using System;
using System.Text.RegularExpressions;

namespace _02Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string regex = @"^[d-z{}|#]+$";
            Match match = Regex.Match(input, regex);

            if(!match.Success)
            {
                Console.WriteLine("This is not the book you are looking for.");
                return;
            }

            string decrypted = "";
            for (int i = 0; i < input.Length; i++)
            {
                char symbol =(char)(input[i]-3);
                decrypted += symbol;
            }

            string[] replace = Console.ReadLine().Split(" ");
            decrypted = decrypted.Replace(replace[0], replace[1]);
            Console.WriteLine(decrypted);
        }
    }
}
