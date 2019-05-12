using System;
using System.IO;
using System.Linq;

namespace _1_EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathInput = @"..\..\..\text.txt";
            string pathOutput = @"..\..\..\Output.txt";

            using (var reader = new StreamReader(pathInput))
            {
                using (var writer = new StreamWriter(pathOutput))
                {
                    string line = reader.ReadLine();
                    int counter = 0;
                    while (line != null)
                    {
                        if (counter % 2 == 0)
                        {
                            var oldSymbol = new char[] { '-', ',', '.', '!', '?' };
                            var newSymbol = "@";
                            for (int i = 0; i < oldSymbol.Length; i++)
                            {
                                string currentOldSymbol = oldSymbol[i].ToString();
                                line = line.Replace(currentOldSymbol, newSymbol);
                            }
                            var output = line.Split().ToList();
                            output.Reverse();

                            writer.WriteLine(string.Join(' ',output));
                        }
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
