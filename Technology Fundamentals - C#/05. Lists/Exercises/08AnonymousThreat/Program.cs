using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> someText = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> cmd = Console.ReadLine().Split().ToList();

            while (cmd[0] != "3:1")
            {
                switch (cmd[0])
                {
                    case "merge":
                        Merge(someText, cmd);
                        //Console.WriteLine(string.Join(' ', someText));
                        break;

                    case "divide":
                        if (int.Parse(cmd[2]) <= someText[int.Parse(cmd[1])].Count() && int.Parse(cmd[2]) >= 0)
                        {
                            Divide(someText, cmd);
                        }
                       
                        break;
                }

                cmd = Console.ReadLine().Split().ToList();
            }

            Console.WriteLine(string.Join(' ', someText));
        }

        public static void Merge(List<string> text, List<string> command)
        {
            int startIndex = int.Parse(command[1]);
            int endIndex = int.Parse(command[2]);
            startIndex = CheckStartIndex(startIndex, text);
            endIndex = CheckEndIndex(endIndex, text);

            string result = string.Empty;
            for (int i = startIndex; i <= endIndex; i++)
            {
                result += text[i];
            }

            text.RemoveRange(startIndex, endIndex-startIndex+1);
            text.Insert(startIndex, result);
        }

        public static void Divide(List<string> text, List<string> command)
        {
            int index = int.Parse(command[1]);
            int partitions = int.Parse(command[2]);
            string textForDivide = text[index];
            int numsOfSymbol = textForDivide.Length / partitions;
            text.RemoveAt(index);

            for (int i = 0; i <partitions; i++)
            {
                
                string currentText = "";
                if(i<partitions-1)
                {
                    
                    for (int j = 0; j < numsOfSymbol; j++)
                    {
                        currentText += textForDivide[j];
                    }
                }

                else if (i == partitions-1)
                {
                    currentText = textForDivide;
                }

                textForDivide = textForDivide.Remove(0,numsOfSymbol);
                text.Insert(index + i, currentText);
            }

        }

        private static int CheckEndIndex(int endIndex, List<string> text)
        {
            int index = endIndex;
            if (index > text.Count - 1 || index <0)
            {
                index = text.Count - 1;
            }

            return index;
        }

        private static int CheckStartIndex(int startIndex, List<string> text)
        {
            int index = startIndex;
            if (index < 0 || index >= text.Count - 1)
            {
                index = 0;
            }

            return index;
        }
    }
}


//public static List<string> DivideCommand(List<string> input, int index, int partitions)
//{
//    string word = input[index];
//    List<string> divided = new List<string>();

//    input.RemoveAt(index);

//    int parts = word.Length / partitions;

//    for (int i = 0; i < partitions; i++)
//    {
//        if (i == partitions - 1)
//        {
//            divided.Add(word.Substring(i * parts));
//        }
//        else
//        {
//            divided.Add(word.Substring(i * parts, parts));
//        }
//    }