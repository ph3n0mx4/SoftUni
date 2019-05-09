using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] substring = Console.ReadLine().Split(' ');
            string regex = @"^[d-z\#\|\{\}]+$";
            Match match = Regex.Match(input, regex);

            if (!match.Success)
            {
                Console.WriteLine("This is not the book you are looking for.");
                return;
            }

            string editInput = "";
            for (int i = 0; i < input.Length; i++)
            {
                char symbol = (char)(input[i] - 3);
                editInput += symbol;
            }

            string result = editInput.Replace(substring[0], substring[1]);
            Console.WriteLine(result);
            


        }
    }
}
