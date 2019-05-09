using System;
using System.Collections.Generic;
using System.Linq;

namespace L04SplitByWordCasing
{
    class Program
    {
        static void Main(string[] args)
        {                                                                             
            char[] separator = new char[] {' ',',', ';',':','.','!','(', ')',  '\'','/', '[' , ']', (char)092};
            List<string> someText = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> lowercase = new List<string>();
            List<string> uppercase = new List<string>();
            List<string> mixedcase = new List<string>();
            foreach (var word in someText)
            {
                int countL = 0;
                int countU = 0;

                for (int i = 0; i < word.Length; i++)
                {
                    if(word[i]>='a' && word[i] <= 'z')
                    {
                        countL++;
                    }

                    else if(word[i] >= 'A' && word[i] <= 'Z')
                    {
                        countU++;
                    }
                }
                if(countL==word.Length)
                {
                    lowercase.Add(word);
                }

                else if(countU == word.Length)
                {
                    uppercase.Add(word);
                }

                else
                {
                    mixedcase.Add(word);
                }
            }
            Console.WriteLine(string.Join(' ',lowercase));     
            Console.WriteLine(string.Join(' ',uppercase));
            Console.WriteLine(string.Join(' ',mixedcase));
        }
    }
}
