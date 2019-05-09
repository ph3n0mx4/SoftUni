using System;

namespace _06ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            string result = string.Empty;
            string currentSymbol = string.Empty;
            for (int i = 0; i < sequence.Length; i++)
            {
                if(currentSymbol!=sequence[i].ToString())
                {
                    result += sequence[i];
                    currentSymbol = sequence[i].ToString();
                }
            }

            Console.WriteLine(result);
        }
    }
}
