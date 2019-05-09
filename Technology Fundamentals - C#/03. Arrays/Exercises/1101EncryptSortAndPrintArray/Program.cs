using System;

namespace _1101EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());
            int[] numbers = new int [numberOfStrings];

            for (int i = 0; i < numberOfStrings; i++)
            {
                string word = Console.ReadLine();
                int sum = 0;

                for (int j = 0; j < word.Length; j++)
                {
                    int num = word[j];
                    string letter = word[j].ToString();

                    if (letter == "a" || letter == "e" || letter == "i" || letter == "o" || letter == "u" /*|| letter == "y"*/ || letter == "A" || letter == "E" || letter == "I" || letter == "O" || letter == "U" /*|| letter == "Y"*/ )
                    {
                        num *= word.Length;
                        sum += num;
                    }
                    else
                    {
                        num /= word.Length;
                        sum += num;
                    }
                }

                numbers[i] = sum;
            }

            Array.Sort(numbers);
            

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
