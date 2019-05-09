using System;

namespace _04CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string result = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                int symbol = text[i]+3;
                char a =(char) symbol;
                result += a;
                
            }
            Console.WriteLine(result);
        }
    }
}
