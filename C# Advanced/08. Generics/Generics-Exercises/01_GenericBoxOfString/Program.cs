﻿using System;

namespace _01_GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var box = new Box<string>(input);
                Console.WriteLine(box.ToString());
            }
        }
    }
}
