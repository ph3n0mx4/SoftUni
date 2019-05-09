using System;

namespace _05DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string digit = "";
            string letter = "";
            string other = "";
            for (int i = 0; i < text.Length; i++)
            {
                if(char.IsDigit(text[i]))
                {
                    digit += text[i];
                }

                else if(char.IsLetter(text[i]))
                {
                    letter += text[i];
                }

                else
                {
                    other += text[i];
                }
            }

            Console.WriteLine(digit);
            Console.WriteLine(letter);
            Console.WriteLine(other);
        }
    }
}
