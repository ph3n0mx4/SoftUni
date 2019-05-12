using System;
using System.Collections.Generic;
using System.IO;

namespace _4_MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>();

            using (var reader = new StreamReader($"../../../Input1.txt"))
            {
                var line = reader.ReadLine();
                while(line!=null)
                {
                    list.Add(line);
                    line = reader.ReadLine();
                }
            }

            using (var reader = new StreamReader($"../../../Input2.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    list.Add(line);
                    line = reader.ReadLine();
                }
            }

            list.Sort();

            using (var writer = new StreamWriter($"../../../Output.txt"))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    writer.WriteLine(list[i]);
                }
            }
        }
    }
}
