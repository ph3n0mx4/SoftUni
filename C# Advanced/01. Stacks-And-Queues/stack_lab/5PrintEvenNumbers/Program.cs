using System;
using System.Collections.Generic;

namespace _5PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            Queue<string> queue = new Queue<string>(input);
            List<string> output = new List<string>();
            
            while(queue.Count>0)
            {
                int currentNum = int.Parse(queue.Peek());

                if(currentNum%2==0)
                {
                    queue.Dequeue();
                    output.Add(currentNum.ToString());
                }

                else
                {
                    queue.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ",output));
        }
    }
}
