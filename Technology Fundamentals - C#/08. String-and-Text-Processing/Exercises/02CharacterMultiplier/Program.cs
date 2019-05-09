using System;

namespace _02CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] @strings = Console.ReadLine().Split();

            string firstString = strings[0];
            string secondString = strings[1];
            int sum =MultiplierChars(firstString, secondString);
            Console.WriteLine(sum);
        }

        private static int MultiplierChars(string firstString, string secondString)
        {
            int firstStringLength = firstString.Length;
            int secondStringLength = secondString.Length;
            int sum = 0;
            if (firstStringLength == secondStringLength)
            {
                for (int i = 0; i < firstStringLength; i++)
                {
                    sum += firstString[i] * secondString[i];
                }
            }

            else if (firstStringLength > secondStringLength)
            {
                for (int i = 0; i < secondStringLength; i++)
                {
                    sum += firstString[i] * secondString[i];
                }

                for (int i = secondStringLength; i < firstStringLength; i++)
                {
                    sum += firstString[i];
                }
            }

            else if (firstStringLength < secondStringLength)
            {
                for (int i = 0; i < firstStringLength; i++)
                {
                    sum += firstString[i] * secondString[i];
                }

                for (int i = firstStringLength; i < secondStringLength; i++)
                {
                    sum += secondString[i];
                }
            }

            return sum;
        }
    }
}
