using System;
using System.IO;

namespace _2_LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathInput = @"..\..\..\text.txt";
            string pathOutput = @"..\..\..\Output.txt";
            using (var reader= new StreamReader(pathInput))
            {
                using (var writer = new StreamWriter(pathOutput))
                {
                    string line = reader.ReadLine();

                    int counter = 1;
                    while (line != null)
                    {
                        int punktuation = 0;
                        int letter = 0;
                        for (int i = 0; i < line.Length; i++)
                        {
                            char currentSymbol = line[i];
                            if(char.IsPunctuation(currentSymbol))
                            {
                                punktuation++;
                            }
                            
                            else if(char.IsLetter(currentSymbol))
                            {
                                letter++;
                            }
                        }
                        //Line 1: -I was quick to judge him, but it wasn't his fault. (37)(4)
                        writer.WriteLine($"Line {counter}: {line} ({letter})({punktuation})");
                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
