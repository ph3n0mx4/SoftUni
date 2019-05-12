using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _6_FullDirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            var files = Directory.GetFiles(path);

            var extensionsFileInfo = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                if (!extensionsFileInfo.ContainsKey(info.Extension))
                {
                    extensionsFileInfo[info.Extension] = new List<FileInfo>();
                }

                extensionsFileInfo[info.Extension].Add(info);
            }
            string outputPath = @"C:\Users\ASUS\Desktop\output.txt";

            using (var writer = new StreamWriter(outputPath))
            {
                foreach (var kvp in extensionsFileInfo.OrderBy(x => -x.Value.Count).ThenBy(x => x.Key))
                {
                    string ext = kvp.Key;
                    var info = kvp.Value;
                    writer.WriteLine($"{ext}");
                    foreach (var fileInfo in info.OrderBy(x => x.Length))
                    {
                        string name = fileInfo.Name;
                        double size = fileInfo.Length / 1024;
                        writer.WriteLine($"--{name} - {size:F3}kb");
                    }
                }
            }




        }
    }
}
