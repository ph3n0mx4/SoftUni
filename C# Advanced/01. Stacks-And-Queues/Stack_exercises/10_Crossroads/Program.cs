using System;
using System.Collections.Generic;

namespace _10_Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            int totalTime = greenLight + freeWindow;
            var queue = new Queue<string>();

            int count = 0;
            string characterHit = string.Empty;
            //string hitCar = string.Empty;
            string input = Console.ReadLine();

            while(input.ToLower()!="end")
            {
                if(input=="green")
                {
                    int currentGreen = greenLight;
                    int currentTotal = totalTime;
                    while (true)
                    {
                        if(queue.Count<1)
                        {
                            break;
                        }

                        string car = queue.Dequeue();
                        int carSize = car.Length;
                        if(carSize<currentGreen)
                        {
                            currentGreen -= carSize;
                            currentTotal -= carSize;
                            count++;
                            continue;
                        }

                        else if(carSize >= currentGreen && carSize <= currentTotal)
                        {
                            count++;
                            break;
                        }

                        else if(carSize > currentTotal)
                        {
                            characterHit = car[currentTotal].ToString();
                            Console.WriteLine($"A crash happened!");
                            Console.WriteLine($"{car} was hit at {characterHit}.");
                            break;
                        }
                    }
                }

                else
                {
                    queue.Enqueue(input);
                    
                }

                if(characterHit !=string.Empty)
                {
                    return;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{count} total cars passed the crossroads.");
        }
    }
}
