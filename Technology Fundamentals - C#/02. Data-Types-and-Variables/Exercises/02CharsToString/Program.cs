using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02CharsToString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;

            for (int i = 0; i <=2; i++)
            {
                string readLine = Console.ReadLine();
                text += readLine;
            }
            Console.WriteLine(text);
        }
    }
}
