using System;
using System.Collections;
using System.Collections.Generic;

namespace _01_Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLine = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            string cmd = Console.ReadLine();
            var queue = new Queue<string>();
            int passedCar = 0;
            while (cmd!="END")
            {
                if(cmd=="green" && queue.Count>0)
                {
                    int time = greenLine + freeWindow;
                    while (time>0)
                    {
                        if(time>freeWindow && queue.Count > 0)
                        {
                            string currentCar = queue.Dequeue();
                            if (currentCar.Length <= time)
                            {
                                time -= currentCar.Length;
                                passedCar++;
                            }

                            else
                            {
                                char characterHit = currentCar[time];
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {characterHit}.");
                                return;
                            }
                        }

                        else
                        {
                            break;
                        }
                        
                    }
                }

                else
                {
                    queue.Enqueue(cmd);
                }

                
                cmd = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCar} total cars passed the crossroads.");
        }
    }
}
