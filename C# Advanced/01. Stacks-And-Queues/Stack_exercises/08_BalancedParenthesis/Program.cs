using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _08_BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); //parentheses: (, {, and [

            Stack<char> open = new Stack<char>();

            string output = "YES";

            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == '(' || input[i] == '{' || input[i] == '[')
                {
                    open.Push(input[i]);

                }

                //else if(input[i] == ')' || input[i] == '}' || input[i] == ']')
                
                else if(open.Any() && open.Peek()=='(' && input[i] == ')')
                {
                    open.Pop();
                }

                else if (open.Any() && open.Peek() == '[' && input[i] == ']')
                {
                    open.Pop();
                }

                else if (open.Any() && open.Peek() == '{' && input[i] == '}')
                {
                    open.Pop();
                }
                

                else if (input[i]==' ')
                {
                    continue;
                }
                
                else
                {
                    output = "NO";
                    break;
                }
            }
            
            Console.WriteLine(output);
        }
    }
}
