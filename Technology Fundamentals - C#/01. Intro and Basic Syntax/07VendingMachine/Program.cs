using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            double money = 0;
            double totalPrice = 0;
            while(text!="Start")
            {
                double coins = 10*double.Parse(text);
                
                if (coins==1 || coins==2 || coins == 5 || coins == 10 || coins == 20)
                {
                    money += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {(coins/10):f2}");
                }

                text = Console.ReadLine();
            }

            text = Console.ReadLine();

            while (text!="End")
            {
                
                if(text== "Nuts")
                {
                    totalPrice += 20;

                    if (totalPrice > money)
                    {
                        totalPrice -= 20;
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine($"Purchased {text.ToLower()}");
                    }

                    
                }

                else if (text == "Water")
                {
                    totalPrice += 7;
                    if (totalPrice > money)
                    {
                        totalPrice -= 7;
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine($"Purchased {text.ToLower()}");
                    }
                }

                else if (text == "Crisps")
                {
                    totalPrice += 15;
                    if (totalPrice > money)
                    {
                        totalPrice -= 15;
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine($"Purchased {text.ToLower()}");
                    }
                }

                else if (text == "Soda")
                {
                    totalPrice += 8;
                    if (totalPrice > money)
                    {
                        totalPrice -= 8;
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine($"Purchased {text.ToLower()}");
                    }
                }

                else if (text == "Coke")
                {
                    totalPrice += 10;
                    if (totalPrice > money)
                    {
                        totalPrice -= 10;
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine($"Purchased {text.ToLower()}");
                    }
                }

                else
                {
                    Console.WriteLine("Invalid product");
                }

                text = Console.ReadLine();
            }

            Console.WriteLine($"Change: {((money-totalPrice)/10):f2}");
        }
    }
}
