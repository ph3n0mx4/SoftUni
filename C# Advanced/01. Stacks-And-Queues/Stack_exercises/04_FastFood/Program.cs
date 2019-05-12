using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04_FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfTheFood = int.Parse(Console.ReadLine());
            Queue<int> order = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            Console.WriteLine(order.Max());

            while(order.Count>0)
            {
                int currentOrder = order.Peek();
                if(currentOrder<=quantityOfTheFood)
                {
                    quantityOfTheFood -= order.Dequeue();
                }

                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ",order)}");
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
