using System;

namespace _02VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int result = CounterOfVowels(word);
            Console.WriteLine(result);
        }

        public static int CounterOfVowels(string text)
        {
            int count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                string symbol = text[i].ToString();
                if(symbol=="a" || symbol == "e" || symbol == "i" || symbol == "o" || symbol == "u" || symbol == "A" || symbol == "E" || symbol == "I" || symbol == "O" || symbol == "U")
                {
                    count++;
                }
            }
            return count;
        }
    }
}
