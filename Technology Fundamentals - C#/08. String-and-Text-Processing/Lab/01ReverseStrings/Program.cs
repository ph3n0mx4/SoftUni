using System;

namespace _01ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (text!="end")
            {
                string reverseText = "";

                for (int i = text.Length-1; i >=0; i--)
                {
                    reverseText += text[i];
                }
                Console.WriteLine($"{text} = {reverseText}");

                text = Console.ReadLine();
            }
        }
    }
}
