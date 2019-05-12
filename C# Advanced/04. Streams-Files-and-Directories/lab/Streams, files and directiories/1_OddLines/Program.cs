using System;
using System.IO;

namespace _1_OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"..\..\..\Input.txt"))
            {
                using (var writer = new StreamWriter(@"..\..\..\Output.txt"))
                {
                    int counter = 0;
                    string line = reader.ReadLine();

                    while(line!=null)
                    {
                        if(counter%2==1)
                        {
                            writer.WriteLine(line);
                        }

                        line = reader.ReadLine();
                        counter++;
                    }
                }
            }
        }
    }
}
