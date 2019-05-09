using System;

namespace _04TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWord = Console.ReadLine().Split(new char[] {',',' '}, StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            for (int i = 0; i <bannedWord.Length; i++)
            {
                int lenght = bannedWord[i].Length;
                string replacement = new string('*', lenght);
                text =text.Replace(bannedWord[i], replacement);
            }

            Console.WriteLine(text);
        }
    }
}
