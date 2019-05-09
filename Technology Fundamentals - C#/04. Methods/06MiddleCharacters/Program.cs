using System;

namespace _06MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string someText = Console.ReadLine();
            string result =MiddleCharacters(someText);
            Console.WriteLine(result);
        }

        public static string MiddleCharacters(string someText)
        {
            string middleChars = string.Empty;
            int numOfChars = someText.Length;
            
            if(numOfChars%2==0)
            {
                middleChars += someText[numOfChars / 2-1];
                middleChars += someText[numOfChars / 2];
                return middleChars;
            }
            else
            {
                middleChars += someText[numOfChars / 2 ];
                return middleChars;
            }
            
        }
    }
}
