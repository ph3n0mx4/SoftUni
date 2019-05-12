using System;
using System.Collections.Generic;

namespace _07_SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var VIP = new HashSet<string>();
            var regular = new HashSet<string>();

            string input = Console.ReadLine();

            while(input.ToLower()!="party")
            {
                if(input.Length==8)
                {
                    char firstSymbol = input[0];

                    bool isDigit = Char.IsDigit(firstSymbol);
                    if(isDigit)
                    {
                        VIP.Add(input);
                    }

                    else
                    {
                        regular.Add(input);
                    }
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while(input.ToLower()!="end")
            {
                if(VIP.Contains(input))
                {
                    VIP.Remove(input);
                }

                else if (regular.Contains(input))
                {
                    regular.Remove(input);
                }
                input = Console.ReadLine();
            }
            int a = VIP.Count + regular.Count;

            Console.WriteLine(a);

            if(VIP.Count>0)
            {
                foreach (var guest in VIP)
                {
                    Console.WriteLine(guest);
                }
            }
            
            if(regular.Count>0)
            {
                foreach (var guest in regular)
                {
                    Console.WriteLine(guest);
                }
            }
            
        }
    }
}
