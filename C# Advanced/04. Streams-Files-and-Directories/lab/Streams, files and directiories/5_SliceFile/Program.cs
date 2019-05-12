using System;
using System.IO;

namespace _5_SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            int parts = 4;
            string sourceFile = @"../../../sliceMe.txt";

            using (var readFileStream = new FileStream(sourceFile,FileMode.Open))
            {
                long pieceSize = (long)Math.Ceiling((double)readFileStream.Length / parts);

                for (int i = 1; i <= parts; i++)
                {
                    var currnetFileName = $"Part-{i}.txt";
                    var currentPieceSIze = 0;

                    using (var createFileStream = new FileStream($"../../../{currnetFileName}", FileMode.Create))
                    {
                        var buffer = new byte[4096];

                        while (readFileStream.Read(buffer,0,buffer.Length)==buffer.Length)
                        {
                            currentPieceSIze += buffer.Length;
                            createFileStream.Write(buffer, 0, buffer.Length);

                            if(currentPieceSIze>=pieceSize)
                            {
                                break;
                            }
                        }
                    }

                }
            }

        }
    }
}
