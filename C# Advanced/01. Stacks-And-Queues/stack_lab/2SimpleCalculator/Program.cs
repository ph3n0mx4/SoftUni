using System;
using System.Collections.Generic;
using System.Linq;

namespace _2SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
        
            Stack<string> stack = new Stack<string>(input.Reverse());
            while(stack.Count > 1)
            {
                int firstNum = int.Parse(stack.Pop());
                string @operator = stack.Pop();
                int secondNum = int.Parse(stack.Pop());

                if(@operator=="+")
                {
                    stack.Push((firstNum + secondNum).ToString());
                    
                }

                else if(@operator=="-")
                {
                    stack.Push((firstNum - secondNum).ToString());
                }
            }

            Console.WriteLine(stack.Pop());

        }
    }
}
