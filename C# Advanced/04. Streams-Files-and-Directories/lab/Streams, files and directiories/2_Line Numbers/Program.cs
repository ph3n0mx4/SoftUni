using System;
using System.IO;

namespace _2_Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"../../../Input.txt"))
            {
                using (var writer = new StreamWriter(@"../../../Output.txt"))
                {
                    string line = reader.ReadLine();
                    int counter = 1;

                    while(line!=null)
                    {
                        writer.WriteLine($"{counter}. {line}");
                        line = reader.ReadLine();
                        counter++;
                    }
                }
            }
        }
    }
}
