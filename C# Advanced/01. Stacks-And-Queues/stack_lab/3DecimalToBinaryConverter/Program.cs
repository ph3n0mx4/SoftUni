﻿using System;
using System.Collections.Generic;

namespace _3DecimalToBinaryConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();

            if(input==0)
            {
                Console.WriteLine(0);
                return;
            }
            while(input>0)
            {
                int remainder = input % 2;
                stack.Push(remainder.ToString());
                input /= 2;
            }

            while(stack.Count>0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
