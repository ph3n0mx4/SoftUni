﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace _1ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack <char>();

            foreach (var ch in input)
            {
                stack.Push(ch);
            }

            while (stack.Count >0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
