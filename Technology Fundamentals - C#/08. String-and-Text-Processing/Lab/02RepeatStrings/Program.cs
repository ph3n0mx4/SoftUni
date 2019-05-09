using System;
using System.Text;

namespace _02RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split();
            string result = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < text[i].Length; j++)
                {
                    result += text[i];
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(result);
            Console.WriteLine(sb);
        }
    }
}
