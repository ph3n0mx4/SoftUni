using System;
using System.Collections;

namespace _03ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            int indexBacksLash = path.LastIndexOf('\\')+1;
            string file = path.Substring(indexBacksLash);
            int @indexDot = file.LastIndexOf('.');
            string extension = file.Substring(indexDot+1);
            file = file.Remove(indexDot);
            Console.WriteLine($"File name: {file}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}

//string[] text = Console.ReadLine().Split(new char[] { '\\', '.' }, StringSplitOptions.RemoveEmptyEntries);
//int lastIndex = text.Length - 1;
//string nameFile = text[lastIndex - 1];
//string extensionFile = text[lastIndex];
//Console.WriteLine($"File name: {nameFile}");
//Console.WriteLine($"File extension: {extensionFile}");