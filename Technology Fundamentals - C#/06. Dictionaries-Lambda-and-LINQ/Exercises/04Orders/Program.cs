using System;
using System.Collections.Generic;

namespace _04Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var productPrice = new Dictionary<string, double>();
            var productQuantity = new Dictionary<string, double>();
            var result = new Dictionary<string, double>();

            string[] cmd = Console.ReadLine().Split();

            while(cmd[0]!="buy")
            {
                productPrice[cmd[0]] = double.Parse(cmd[1]);
                
                if(!productQuantity.ContainsKey(cmd[0]))
                {
                    productQuantity[cmd[0]] = int.Parse(cmd[2]);
                }

                else
                {
                    productQuantity[cmd[0]] += int.Parse(cmd[2]);
                }

                cmd = Console.ReadLine().Split();
            }

            foreach (var kvp in productPrice)
            {
                
                foreach (var item in productQuantity)
                {
                    if(kvp.Key==item.Key)
                    {
                        result[kvp.Key]= kvp.Value * item.Value;
                    }
                }
            }

            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value:f2}");
            }

            
        }
    }
}
