using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05_FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int capacity = int.Parse(Console.ReadLine());
            
            int rack = 1;
            int currentRack = 0;
            while(clothes.Count>0)
            {
                int currentCloth = clothes.Peek();
                
                if (currentRack+currentCloth>capacity)
                {
                    currentRack = 0;
                    rack++;
                }

                else if (currentRack + currentCloth == capacity)
                {
                    currentRack = 0;
                    clothes.Pop();
                    if (clothes.Count>0)
                    {
                        rack++;
                    }
                }

                else
                {
                    currentRack += currentCloth;
                    clothes.Pop();
                }
            }

            Console.WriteLine(rack);
        }
    }
}
