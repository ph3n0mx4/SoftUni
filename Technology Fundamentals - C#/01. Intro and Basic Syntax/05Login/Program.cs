using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string reverseUserName = string.Empty;
            string password = string.Empty;
            
            for (int i = userName.Length-1; i >= 0; i--)
            {
                reverseUserName += userName[i];
            }
            for (int j =1; j<=4; j++)
            {
                password = Console.ReadLine();
                if (reverseUserName != password && j<4)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }

                else if (reverseUserName == password)
                {
                    Console.WriteLine($"User {userName} logged in.");
                    return;
                }

                else
                {
                    Console.WriteLine($"User {userName} blocked!");
                    return;
                }
            }
        }
    }
}
