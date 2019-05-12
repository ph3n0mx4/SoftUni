using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3_Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var counterOfWords = new Dictionary<string, int>();
            var listWords = new List<string>();
            using (var readWords = new StreamReader($"../../../words.txt"))
            {
                string line = readWords.ReadLine();
                while(line!=null)
                {
                    listWords.Add(line);
                    line = readWords.ReadLine();
                }
                
                for (int i = 0; i < listWords.Count; i++)
                {
                    string currentWord = listWords[i];
                    counterOfWords[currentWord] = 0;
                }
            }

            using (var reader = new StreamReader($"../../../text.txt"))
            {
                var textLine = reader.ReadLine();
                while (textLine != null)
                {
                    foreach (var word in listWords)
                    {
                        textLine = textLine.ToLower();
                        if (textLine.Contains(word))
                        {
                            counterOfWords[word]++;
                        }
                    }
                    textLine = reader.ReadLine();
                }
            }
            counterOfWords =counterOfWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            using (var writer = new StreamWriter("../../../Output.txt"))
            {
                foreach (var word in counterOfWords)
                {
                    string currentWord = word.Key;
                    int currentCounterWord = word.Value;
                    writer.WriteLine($"{currentWord} - {currentCounterWord}");
                }
            }

            using (var readerExpect = new StreamReader($"../../../expectedResult.txt"))
            {
                bool isSame = true;
                foreach (var word in counterOfWords)
                {
                    string line = readerExpect.ReadLine();
                    string output = $"{word.Key} - {word.Value}";

                    if(line!=output)
                    {
                        isSame = false;
                    }
                }
                Console.WriteLine(isSame);
            }
        }
    }
}
