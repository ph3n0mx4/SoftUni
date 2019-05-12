using System;
using System.IO;

namespace _6_FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(@"../../../TestFolder");
            double sum = 0;

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }

            sum = sum / 1024 / 1024;
            string outputPath = @"..\..\..\Output.txt";
            File.WriteAllText(outputPath, sum.ToString());
        }
    }
}
