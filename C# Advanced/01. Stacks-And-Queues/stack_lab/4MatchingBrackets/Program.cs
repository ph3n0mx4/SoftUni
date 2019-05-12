using System;
using System.Collections.Generic;

namespace _4MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }

                else if (input[i] == ')')
                {
                    int startIndex = stack.Pop();
                    int endIndex = i;
                    int lenght = endIndex - startIndex + 1;
                    string currentExpression = input.Substring(startIndex, lenght);
                    Console.WriteLine(currentExpression);
                }
            }
        }
    }
}
